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

namespace LandSpark_Query_API.Services
{
    //
    //执行对输入项或输入内容的检查。
    //
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
                if (((sumOddPlace + sumEvenPlace * 3) % 10 + checkCode[0]) % 10 == 0) return (true);
                else return (false);
            }
            catch
            {
                return(false);
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
            this._statusCode = statusCode;
            this._data = data;
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
        static SqlConnectionStringBuilder _scsb = new SqlConnectionStringBuilder("Data Source=localhost;Initial Catalog=TraditionalChineseMedicine;Persist Security Info=True;User ID=XXX;Password=XXX");
        static string _cmdOpenAppRole = String.Format(@"DECLARE @cookie varbinary(8000);
EXEC sp_setapprole @rolename = 'XXX', @password = N'XXX', @fCreateCookie = true, @cookie = @cookie OUTPUT;");
        static string _cmdCloseAppRole = String.Format(@"EXEC sys.sp_unsetapprole @cookie;");

        static string _siteFileDirectory = @"F:\Landspark_File\";   //网站文件的存储目录。

        static string ConnectionString
        {
            get { return _scsb.ToString(); }
        }

        public static string SiteFileDirectory      //网站文件的存储目录。
        {
            get { return _siteFileDirectory; }
        }

        /// <summary>
        /// 根据SQL语句，从数据库获取数据集形式结果。
        /// </summary>
        /// <param name="SQLText">Select类，返回数据集的SQL命令。</param>
        /// <returns></returns>
        public static ResponseWithStatusCode ExecuteSelectDatasetQuery(string SQLText)
        {
            if (SQLText.Substring(SQLText.Length - 1, 1) != ";") SQLText += ";";    //如果语句尾部没有分号，就补上一个。
            string fullCommand = (_cmdOpenAppRole + SQLText + _cmdCloseAppRole);    //在查询语句前后，添加激活和退出应用程序角色的指令。
            SqlConnection conn = new SqlConnection(ConnectionString);   //声明数据库连接。
            SqlCommand command = new SqlCommand(fullCommand, conn);
            DataSet dataSet = new DataSet();
            try
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                conn.Close();
                sqlDataAdapter.Fill(dataSet);
                return (new ResponseWithStatusCode(200, dataSet)); //成功请求，状态码200。
            }
            catch (SqlException ex)
            {
                return (new ResponseWithStatusCode(401, ex));      //SqlCilent此处的报错多数原因为无权限，状态码401。
            }
            catch (Exception ex)
            {
                return (new ResponseWithStatusCode(409, ex));      //其它报错归为发生冲突，状态码409。
            }
            finally
            {
                conn.Dispose();
            }
        }

        /// <summary>
        /// 根据SQL语句，从数据库获取单个值结果。
        /// </summary>
        /// <param name="SQLText">Select类，返回单个值的SQL命令。</param>
        /// <returns></returns>
        public static ResponseWithStatusCode ExecuteSelectScalarQuery(string SQLText)
        {
            if (SQLText.Substring(SQLText.Length - 1, 1) != ";") SQLText += ";";    //如果语句尾部没有分号，就补上一个。
            string fullCommand = (_cmdOpenAppRole + SQLText + _cmdCloseAppRole);    //在查询语句前后，添加激活和退出应用程序角色的指令。
            SqlConnection conn = new SqlConnection(ConnectionString);   //声明数据库连接。
            SqlCommand command = new SqlCommand(fullCommand, conn);
            DataSet dataSet = new DataSet();
            try
            {
                conn.Open();
                var value = command.ExecuteScalar();
                conn.Close();
                
                return (new ResponseWithStatusCode(200, value)); //成功请求，状态码200。
            }
            catch (SqlException ex)
            {
                return (new ResponseWithStatusCode(401, ex));      //SqlCilent此处的报错多数原因为无权限，状态码401。
            }
            catch (Exception ex)
            {
                return (new ResponseWithStatusCode(409, ex));      //其它报错归为发生冲突，状态码409。
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}
