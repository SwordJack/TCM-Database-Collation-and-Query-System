using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Windows窗体访问中医药数据库
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();

        //
        //文本框的可用性，用于在连接数据库语句运行期间对文本框和组合框进行冻结。
        //
        private bool HomeBoxStaus
        {
            set
            {
                cbServerAddress.Enabled
                    = cbLoginMethod.Enabled
                    = tbUID.Enabled
                    = tbPwd.Enabled = value;
            }
        }

        //
        //对cbLoginMethod组合框的选项变化做出响应（选择登录方式）。
        //
        private void CbLoginPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoginMethod.SelectedIndex == -1) return;
            lblTip.Text = "";
            if (cbLoginMethod.SelectedIndex == 1 && cbServerAddress.Text != "")     //激活连接按钮，须通过登录方式组合框与目标服务器组合框的双重限定。
            {
                tbUID.Enabled = tbPwd.Enabled = true;
                btLogin.Enabled = false;
            }
            else if (cbLoginMethod.SelectedIndex == 0 && cbServerAddress.Text != "")
            {
                tbUID.Clear();
                tbPwd.Clear();
                tbUID.Enabled = tbPwd.Enabled = false;
                btLogin.Enabled = true;
            }
            else
            {
                tbUID.Enabled = tbPwd.Enabled = false;
                btLogin.Enabled = false;
            }
            BuildConnectionString(cbLoginMethod.SelectedIndex);
        }

        //
        //拼接数据库连接字符串。
        //
        private void BuildConnectionString(int connectionCode)
        {
            scsb.Clear();
            if (cbServerAddress.SelectedIndex == 1) scsb.DataSource = "LAPTOP-QQP3LJKA\\SQL_EXPRESS";   //本地数据库服务器。
            else scsb.DataSource = "49.234.214.35,1433\\SQL_TCMASSEMBLY";       //远程数据库服务器。
            scsb.InitialCatalog = tbDatabase.Text;
            if (connectionCode == 0)
            {
                scsb.IntegratedSecurity = true;
                tbConnectionString.Text = String.Format(scsb.ToString());
            }
            else if (connectionCode == 1)
            {
                scsb.UserID = tbUID.Text;
                scsb.Password = tbPwd.Text;
                tbConnectionString.Text = String.Format(scsb.ToString().Substring(0, scsb.ToString().IndexOf("Password=")) + "Password=*");     //遮掩字符串中的密码。
            }
            
        }

        //
        //对用户名、密码文本框的变化做出响应。
        //
        private void TbLoginInformation_TextChanged(object sender, EventArgs e)
        {
            lblTip.Text = "";
            if (tbUID.Text != "") btLogin.Enabled = true;
            else btLogin.Enabled = false;                
            BuildConnectionString(cbLoginMethod.SelectedIndex);
        }

        //
        //在单击“连接”按钮后，传递参数给MainForm窗体，执行响应。
        //
        private void BtLogin_Click(object sender, EventArgs e)
        {
            HomeBoxStaus = false;
            MainForm mainForm = new MainForm();
            bool connState = mainForm.ConnectToServer(scsb);  //将数据库连接字符串传递给目标窗体。
            lblTip.ForeColor = Color.Black;
            if (connState)                          //若连接建立成功，则关闭当前窗口，打开新窗口。
            {
                HomeBoxStaus = true;
                this.Visible = false;
                mainForm.ShowDialog();
                mainForm.Dispose();
                this.Visible = true;
                lblTip.Text = "已断开连接。";
                if (cbLoginMethod.SelectedIndex == 0) tbUID.Enabled = tbPwd.Enabled = false;
            }
            else                                    //若连接建立失败，则解除新窗口的占用。
            {
                lblTip.ForeColor = Color.Red;
                lblTip.Text = "连接建立失败！";
                mainForm.Close();
                mainForm.Dispose();
                HomeBoxStaus = true;
            }
        }

    }
}
