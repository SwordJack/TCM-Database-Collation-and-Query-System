using System;
/*
 * 以上为系统自动引用；
 * 以下为开发者引用；
 * 2019.12.30, 15:05
 */
using System.Data;                  //数据服务。
using System.Data.SqlClient;        //需访问SQL Server。
using Newtonsoft.Json;              //返回Json格式数据。
using System.Collections.Generic;   //用于调用泛型。
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography; //用于密码加密。
using System.Text;

namespace LandSpark_Query_API.Areas.TCM.Services
{
    /// <summary>
    /// 执行对输入项或输入内容的检查。
    /// </summary>
    public class InputCheck
    {
        /// <summary>
        ///
        /// 校验码按GB 12904及GB/T 17710校验码计算方法规定。<br />
        /// <br />
        /// 代码位置序号是指包括校验码在内的,由右至左的顺序号（校验码的代码位置序号为1）。<br />
        /// 校验码的计算步骤如下：<br />
        /// <br />
        /// a、从代码位置序号2开始，所有偶数位的数字代码求和；<br />
        /// b、将步骤a的和乘以3；<br />
        /// c、从代码位置序号3开始，所有奇数位的数字代码求和；<br />
        /// d、将步骤b与步骤c的结果相加；<br />
        /// e、用大于或等于步骤d所得结果且为10最小整数倍的数减去步骤d所得结果，其差即为所求校验码的值。<br />
        /// <br />
        /// 输入序列号文本，函数将根据校验码是否符合上述规则，返回“true”或“false”。<br />
        /// 
        /// </summary>
        /// <param name="codeText"></param>
        /// <returns></returns>
        public static bool CheckCodeVerification(string codeText)
        {
            try
            {
                //将序列号转换为整数型数组。
                int length = codeText.Length;
                int[] checkCode = new int[length];
                for (int i = 0; i < length; i++) checkCode[i] = int.Parse(codeText[i].ToString());

                //将数组倒序，并对校验码进行校验。
                Array.Reverse(checkCode);
                int sumOddPlace = 0, sumEvenPlace = 0;
                for (int i = 1; i < length; i++)        //序列号的第2位，数组索引为1，以此类推。
                {
                    if (i % 2 == 1) sumEvenPlace += checkCode[i];
                    else sumOddPlace += checkCode[i];
                }
                if (((sumOddPlace + sumEvenPlace * 3) % 10 + checkCode[0]) % 10 == 0) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 将数据库的查询结果组装为一个类实例返回。
    /// </summary>
    public class ResponseWithStatusCode
    {
        private ResponseWithStatusCode() { }    //必须包含的无参构造函数。

        /// <summary>
        /// 通过状态码和查询结果构造类实例。
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <param name="data">查询返回的结果集</param>
        public ResponseWithStatusCode(int statusCode, object data)
        {
            _statusCode = statusCode;
            _data = data;
        }

        private int _statusCode;    //状态码。
        private object _data;            //获取的数据。
        public int StatusCode
        {
            get { return _statusCode; }
        }
        public object Data
        {
            get { return _data; }
        }

        /// <summary>
        /// 析构ResponseWithStatusCode返回对象。
        /// </summary>
        ~ResponseWithStatusCode() { }
    }

    /// <summary>
    /// 数据库辅助服务类，用于进行数据库连接，组织SQL语句，返回查询结果等。
    /// </summary>
    public class LandsparkTCMDataService
    {
        /// <summary>
        /// 获取数据库连接字符串。
        /// </summary>
        static string ConnectionString
        {
            get { return SqlDataPreprocessing.TCMConnString; }
        }

        /// <summary>
        /// 获取网站的存储目录。
        /// </summary>
        public static string SiteFileDirectory
        {
            get { return SqlDataPreprocessing.FileDirectory; }
        }

        /// <summary>
        /// 根据SQL语句，从数据库获取数据集形式结果。
        /// </summary>
        /// <param name="SQLText">Select类，返回数据集的SQL命令。</param>
        /// <returns></returns>
        public static ResponseWithStatusCode ExecuteSelectDatasetQuery(string SQLText)
        {
            var cmdApprole = SqlDataPreprocessing.AppRoleActivation(0);
            if (SQLText.Substring(SQLText.Length - 1, 1) != ";") SQLText += ";";             //如果语句尾部没有分号，就补上一个。
            string fullCommand = cmdApprole[0] + cmdApprole[1] + SQLText + cmdApprole[2];    //在查询语句前后，添加激活和退出应用程序角色的指令。
            using (SqlConnection conn = new SqlConnection(ConnectionString))   //声明数据库连接。
            {
                using (SqlCommand command = new SqlCommand(fullCommand, conn))
                {
                    DataSet dataSet = new DataSet();
                    try
                    {
                        conn.Open();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                        conn.Close();
                        sqlDataAdapter.Fill(dataSet);
                        return new ResponseWithStatusCode(200, dataSet); //成功请求，状态码200。
                    }
                    catch (SqlException ex)
                    {
                        return new ResponseWithStatusCode(401, ex);      //SqlCilent此处的报错多数原因为无权限，状态码401。
                    }
                    catch (Exception ex)
                    {
                        return new ResponseWithStatusCode(409, ex);      //其它报错归为发生冲突，状态码409。
                    }
                    finally
                    {
                        conn.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// 根据SQL语句，从数据库获取单个值结果。
        /// </summary>
        /// <param name="SQLText">Select类，返回单个值的SQL命令。</param>
        /// <returns></returns>
        public static ResponseWithStatusCode ExecuteSelectScalarQuery(string SQLText)
        {
            var cmdApprole = SqlDataPreprocessing.AppRoleActivation(0);
            if (SQLText.Substring(SQLText.Length - 1, 1) != ";") SQLText += ";";    //如果语句尾部没有分号，就补上一个。
            string fullCommand = cmdApprole[0] + cmdApprole[1] + SQLText + cmdApprole[2];    //在查询语句前后，添加激活和退出应用程序角色的指令。
            using (SqlConnection conn = new SqlConnection(ConnectionString))   //声明数据库连接。
            {
                using (SqlCommand command = new SqlCommand(fullCommand, conn))
                {
                    try
                    {
                        conn.Open();
                        var value = command.ExecuteScalar();
                        conn.Close();

                        return new ResponseWithStatusCode(200, value); //成功请求，状态码200。
                    }
                    catch (SqlException ex)
                    {
                        return new ResponseWithStatusCode(401, ex);      //SqlCilent此处的报错多数原因为无权限，状态码401。
                    }
                    catch (Exception ex)
                    {
                        return new ResponseWithStatusCode(409, ex);      //其它报错归为发生冲突，状态码409。
                    }
                    finally
                    {
                        conn.Dispose();
                    }

                }
            }


        }

        /// <summary>
        /// 根据输入的账号密码，判断登录是否成功。
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static ResponseWithStatusCode ExecuteSelectScalarQuery(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Get_Member_Login", conn))
                {
                    string passwordEncrypted = SqlDataPreprocessing.PasswordEncryption(password);   //计算密码的密文。

                    command.CommandType = CommandType.StoredProcedure;          //向存储过程装载参数。
                    command.Parameters.AddWithValue("@Member_uid", username);
                    command.Parameters.AddWithValue("@Password_Encrypted", passwordEncrypted);

                    try
                    {
                        conn.Open();
                        var access = command.ExecuteScalar();
                        conn.Close();
                        return new ResponseWithStatusCode(200, access);
                        
                    }
                    catch (SqlException ex)
                    {
                        return new ResponseWithStatusCode(401, ex);      //SqlCilent此处的报错多数原因为权限设置出错，状态码401。
                    }
                    catch (Exception ex)
                    {
                        return new ResponseWithStatusCode(409, ex);      //其它报错归为发生冲突，状态码409。
                    }
                }
            }
        }


        /// <summary>
        /// 向数据库录入数据（录入药物图片使用）
        /// </summary>
        /// <param name="SQLText">INSERT类，只需返回受影响行数的SQL命令。</param>
        /// <returns></returns>
        public static ResponseWithStatusCode ExecuteInsertQuery(string SQLText)
        {
            var cmdApprole = SqlDataPreprocessing.AppRoleActivation(1);
            if (SQLText.Substring(SQLText.Length - 1, 1) != ";") SQLText += ";";            //如果语句尾部没有分号，就补上一个。
            string fullCommand = cmdApprole[0] + cmdApprole[1] + SQLText + cmdApprole[2];   //在查询语句前后，添加激活和退出应用程序角色的指令。
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(fullCommand, conn))
                {
                    try
                    {
                        conn.Open();
                        int value = command.ExecuteNonQuery();
                        conn.Close();

                        return new ResponseWithStatusCode(201, value); //成功录入数据，状态码201。
                    }
                    catch (SqlException ex)
                    {
                        return new ResponseWithStatusCode(401, ex);      //SqlCilent此处的报错多数原因为无权限，状态码401。
                    }
                    catch (Exception ex)
                    {
                        return new ResponseWithStatusCode(409, ex);      //其它报错归为发生冲突，状态码409。
                    }
                }
            }
        }
    }

    class SqlDataPreprocessing
    {
        /// <summary>
        /// 文件的存储目录。
        /// </summary>
        public static string FileDirectory { get; } = ConfigManager.Configuration.GetSection("FileDirectory").Value;

        /// <summary>
        /// 数据库连接字符串。
        /// </summary>
        public static string TCMConnString { get; } = ConfigManager.Configuration.GetSection("ConnectionStrings:SqlConnection:TCM").Value;

        /// <summary>
        /// 用SHA256算法对密码进行加密处理。
        /// </summary>
        /// <param name="data">待加密的字符串。</param>
        /// <returns></returns>
        public static string PasswordEncryption(string data)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            byte[] hashResult = SHA256.Create().ComputeHash(buffer);

            StringBuilder builder = new StringBuilder();
            foreach (byte i in hashResult)
            {
                builder.Append(i.ToString("X2"));
                /*
                 * C# ToString("x2")的理解：
                 * 1）转化为16进制；
                 * 2）大写X:ToString("X2")即转化为大写的16进制；
                 * 3）小写x:ToString("x2")即转化为小写的16进制；
                 * 4）2表示输出两位，不足的2位的前面补0，如 0x0A 如果没有2，就只会输出0xA。
                 */
            }

            return builder.ToString();
        }

        /// <summary>
        /// 根据权限编号，组装激活和登出应用程序角色的命令。
        /// </summary>
        /// <param name="accessNumber">权限编号，0表示匿名用户，1表示组内成员，默认为0</param>
        /// <returns>三元数组，分别为声明cookie、激活、登出应用程序角色的命令。</returns>
        public static string[] AppRoleActivation(int accessNumber)
        {
            Dictionary<int, string[]> appRoleDict = new Dictionary<int, string[]>();

            appRoleDict.Add(0, new string[] { "LandSpark_Query_API", "Long_Live_Communism" });
            appRoleDict.Add(1, new string[] { "LandSpark_Member_API", "Working_Class_Leads_Everything" });
            if (accessNumber != 0 && accessNumber != 1)
            {
                accessNumber = 0;
            }
            
            string[] uidPwdPair = appRoleDict[accessNumber];
            string[] approleCommandList = new string[3] {
                "DECLARE @cookie varbinary(8000);",
                $"EXEC sp_setapprole @rolename = '{uidPwdPair[0]}', @password = N'{uidPwdPair[1]}', @fCreateCookie = true, @cookie = @cookie OUTPUT; ",
                "EXEC sys.sp_unsetapprole @cookie;"
                };
            return approleCommandList;
        }

    }
}

