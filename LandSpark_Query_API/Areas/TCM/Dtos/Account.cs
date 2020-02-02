using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;


namespace LandSpark_Query_API.Areas.TCM.Dtos
{
    public class Account
    {
        string _username;   //用户名
        string _password;   //密码
        int _authorized;   //是否是授权用户。
        int _memberGroup;   //用户组（留待拓展）

        /// <summary>
        /// 空构造函数。
        /// </summary>
        private Account() { }

        /// <summary>
        /// UserAccount类用于登录的构造函数。
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Account(string username, string password)
        {
            this._username = username;
            this._password = password;
        }

        /// <summary>
        /// UserAccount类用于登出的构造函数。
        /// </summary>
        /// <param name="username"></param>
        public Account(string username)
        {
            this._username = username;
            this._authorized = -1;
        }

        /// <summary>
        /// 记录用户是否通过授权。
        /// </summary>
        public int Authorized
        {
            get
            {
                return this._authorized;
            }

            set
            {
                this._authorized = value;
            }
        }

        /// <summary>
        /// 用户名。
        /// </summary>
        public string Username
        {
            get { return this._username; }
        }

        /// <summary>
        /// 密码的密文。
        /// </summary>
        public string PwdEncrypted
        {
            get
            {
                return this.PasswordEncryption(this._password);
            }
        }

        /// <summary>
        /// 用SHA256算法对密码进行加密处理。
        /// </summary>
        /// <param name="pwdPlainText">密码的明文</param>
        /// <returns></returns>
        string PasswordEncryption(string pwdPlainText)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(pwdPlainText);
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
        /// 返回登录状态，包含Username和Authorized属性。
        /// </summary>
        /// <returns></returns>
        public DataTable GetAccountStatus()
        {
            using (DataTable table = new DataTable("AccountStatus"))
            {
                string colUsername = "Username";
                string colAuthorized = "Authorized";

                DataRow dataRow = table.NewRow();
                table.Columns.Add(colUsername);
                table.Columns.Add(colAuthorized);

                dataRow[colUsername] = this.Username;       //添加“用户名”字段的值。
                dataRow[colAuthorized] = this.Authorized;   //添加“授权”字段的值。
                table.Rows.Add(dataRow.ItemArray);          //将行的值添加到表中。

                return table;
            }
        }
    }
}
