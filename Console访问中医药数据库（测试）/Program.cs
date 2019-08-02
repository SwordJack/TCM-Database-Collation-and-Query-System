using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TCMServerConstructionAuxiliary;

namespace Console访问中医药数据库_测试_
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("请输入序列号（输入0退出）：");
                string codeInput = Console.ReadLine();
                if (codeInput != "0")
                {
                    Console.WriteLine(InputCheck.CheckCodeVerification(codeInput));
                }
                else break;
            }
            /*
            SqlConnection medicineConnector = GetSqlConnection();
            medicineConnector.Close();
            medicineConnector.Dispose();
            */
            Console.Write("Press Any Key to Exit.");
            Console.ReadKey();
        }


        private static SqlConnection GetSqlConnection()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();

            scsb.DataSource = "LAPTOP-QQP3LJKA\\SQL_EXPRESS";   //SQL Server的服务器位置，此处为本地SQL Server。
            scsb.InitialCatalog = "TraditionalChineseMedicine"; //连接的数据库的名称。
            scsb.IntegratedSecurity = true;                     //连接SQL Server所用账号，此处使用Windows账户登陆。

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
    }
}
