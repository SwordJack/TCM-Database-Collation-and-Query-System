using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TCMServerConstructionAuxiliary;
using System.Security.Cryptography;     //进行SHA256加密所需。

namespace 控制台实验室
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("输入字符串：");
                string input = Console.ReadLine();
                if (input.Length == 0) break;
                string result = PasswordEncryption(input);
                Console.WriteLine($"加密结果为：{result}，长度：{result.Length}");
            }

            Console.ReadKey();
        }

        //
        //测试数据库连接功能。
        //
        private static SqlConnection GetSqlConnection()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();

            scsb.DataSource = "localhost";                      //SQL Server的服务器位置，此处为本地SQL Server。
            //scsb.DataSource = "49.234.214.35,1433";             //SQL Server的服务器位置，此处为远程SQL Server地址。
            //scsb.DataSource = "datatcm.landspark.cn";           //SQL Server的服务器位置，此处为远程SQL Server域名。
            scsb.InitialCatalog = "TraditionalChineseMedicine"; //连接的数据库的名称。
            //scsb.IntegratedSecurity = true;                     //连接SQL Server所用账号，此处使用Windows账户登陆。
            Console.Write("输入您的用户名："); scsb.UserID = Console.ReadLine();    //连接SQL Server所用账号；
            Console.Write("输入您的密码："); scsb.Password = Console.ReadLine();    //连接SQL Server所用密码。

            SqlConnection connection = new SqlConnection(scsb.ToString());
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();  //若连接未打开，则打开连接。
                }

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("连接建立并已打开！");
                }
            }
            catch
            {
                Console.WriteLine("连接建立失败。");
            }
            return connection;
        }

        //
        //测试校验码校验功能。
        //
        private static void CheckCodeTest()
        {
            while (true)
            {
                Console.Write("请输入序列号（输入0退出）：");
                string codeInput = Console.ReadLine();
                if (codeInput != "0")
                {
                    Console.WriteLine(InputCheck.CheckCodeVerification(codeInput));
                }
                else break;
            }
        }

        //
        //仅尝试泛型语法。
        //
        static void Initialize<T>(T[] array) where T : new()
        {


        }

        /// <summary>
        /// 用SHA256算法对密码进行加密处理。
        /// </summary>
        /// <param name="data">待加密的字符串。</param>
        /// <returns></returns>
        static string PasswordEncryption(string data)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            byte[] hashResult = SHA256Managed.Create().ComputeHash(buffer);

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
    }
}
