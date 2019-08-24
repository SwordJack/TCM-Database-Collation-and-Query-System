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

namespace 中医药数据库查询
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();

        //
        //在单击“进入查询”按钮后，传递参数给MainForm窗体，执行响应。
        //
        private void BtLogin_Click(object sender, EventArgs e)
        {
            btLogin.Enabled = false;
            scsb.DataSource = "49.234.214.35,1433";
            scsb.InitialCatalog = "TraditionalChineseMedicine";
            scsb.UserID = "Spectator";
            MainForm mainForm = new MainForm();
            bool connState = mainForm.ConnectToServer(scsb);  //将数据库连接字符串传递给目标窗体。
            lblTip.ForeColor = Color.Black;
            if (connState)                          //若连接建立成功，则关闭当前窗口，打开新窗口。
            {
                this.Visible = false;
                mainForm.ShowDialog();
                mainForm.Dispose();
                this.Visible = true;
                lblTip.Text = "已断开连接。";
                btLogin.Enabled = true;
            }
            else                                    //若连接建立失败，则解除新窗口的占用。
            {
                lblTip.ForeColor = Color.Red;
                lblTip.Text = "连接建立失败！";
                mainForm.Close();
                mainForm.Dispose();
                btLogin.Enabled = true;
            }
        }

    }
}
