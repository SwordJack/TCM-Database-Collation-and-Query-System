namespace 中医药数据库查询
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.btLogin = new System.Windows.Forms.Button();
            this.lblServerAddress = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblLoginMethod = new System.Windows.Forms.Label();
            this.lblUID = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.tbUID = new System.Windows.Forms.TextBox();
            this.cbLoginMethod = new System.Windows.Forms.ComboBox();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.lblTip = new System.Windows.Forms.Label();
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.cbServerAddress = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btLogin
            // 
            this.btLogin.Enabled = false;
            this.btLogin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btLogin.Location = new System.Drawing.Point(214, 152);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(130, 29);
            this.btLogin.TabIndex = 4;
            this.btLogin.Text = "连接";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.BtLogin_Click);
            // 
            // lblServerAddress
            // 
            this.lblServerAddress.AutoSize = true;
            this.lblServerAddress.Location = new System.Drawing.Point(24, 24);
            this.lblServerAddress.Name = "lblServerAddress";
            this.lblServerAddress.Size = new System.Drawing.Size(77, 12);
            this.lblServerAddress.TabIndex = 5;
            this.lblServerAddress.Text = "数据服务器：";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(24, 50);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(77, 12);
            this.lblDatabase.TabIndex = 6;
            this.lblDatabase.Text = "数据库名称：";
            // 
            // lblLoginMethod
            // 
            this.lblLoginMethod.AutoSize = true;
            this.lblLoginMethod.Location = new System.Drawing.Point(36, 76);
            this.lblLoginMethod.Name = "lblLoginMethod";
            this.lblLoginMethod.Size = new System.Drawing.Size(65, 12);
            this.lblLoginMethod.TabIndex = 7;
            this.lblLoginMethod.Text = "身份验证：";
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(72, 102);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(53, 12);
            this.lblUID.TabIndex = 8;
            this.lblUID.Text = "用户名：";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(84, 128);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(41, 12);
            this.lblPwd.TabIndex = 9;
            this.lblPwd.Text = "密码：";
            // 
            // tbPwd
            // 
            this.tbPwd.Enabled = false;
            this.tbPwd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPwd.Location = new System.Drawing.Point(150, 125);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '●';
            this.tbPwd.Size = new System.Drawing.Size(194, 21);
            this.tbPwd.TabIndex = 3;
            this.tbPwd.TextChanged += new System.EventHandler(this.TbLoginInformation_TextChanged);
            // 
            // tbUID
            // 
            this.tbUID.Enabled = false;
            this.tbUID.Location = new System.Drawing.Point(150, 99);
            this.tbUID.Name = "tbUID";
            this.tbUID.Size = new System.Drawing.Size(194, 21);
            this.tbUID.TabIndex = 2;
            this.tbUID.TextChanged += new System.EventHandler(this.TbLoginInformation_TextChanged);
            // 
            // cbLoginMethod
            // 
            this.cbLoginMethod.FormattingEnabled = true;
            this.cbLoginMethod.Items.AddRange(new object[] {
            "Windows 身份验证",
            "SQL Server 身份验证"});
            this.cbLoginMethod.Location = new System.Drawing.Point(131, 73);
            this.cbLoginMethod.Name = "cbLoginMethod";
            this.cbLoginMethod.Size = new System.Drawing.Size(213, 20);
            this.cbLoginMethod.TabIndex = 1;
            this.cbLoginMethod.SelectedIndexChanged += new System.EventHandler(this.CbLoginPath_SelectedIndexChanged);
            // 
            // tbDatabase
            // 
            this.tbDatabase.Location = new System.Drawing.Point(131, 48);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.ReadOnly = true;
            this.tbDatabase.Size = new System.Drawing.Size(213, 21);
            this.tbDatabase.TabIndex = 9;
            this.tbDatabase.Text = "TraditionalChineseMedicine";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(24, 169);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(0, 12);
            this.lblTip.TabIndex = 11;
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Location = new System.Drawing.Point(26, 187);
            this.tbConnectionString.Multiline = true;
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.ReadOnly = true;
            this.tbConnectionString.Size = new System.Drawing.Size(318, 62);
            this.tbConnectionString.TabIndex = 12;
            // 
            // cbServerAddress
            // 
            this.cbServerAddress.FormattingEnabled = true;
            this.cbServerAddress.Items.AddRange(new object[] {
            "Ser-TCMAssembly",
            "Local（Administrator Only）"});
            this.cbServerAddress.Location = new System.Drawing.Point(131, 21);
            this.cbServerAddress.Name = "cbServerAddress";
            this.cbServerAddress.Size = new System.Drawing.Size(213, 20);
            this.cbServerAddress.TabIndex = 0;
            this.cbServerAddress.SelectedIndexChanged += new System.EventHandler(this.CbLoginPath_SelectedIndexChanged);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 277);
            this.Controls.Add(this.cbServerAddress);
            this.Controls.Add(this.tbConnectionString);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.tbDatabase);
            this.Controls.Add(this.cbLoginMethod);
            this.Controls.Add(this.tbUID);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblUID);
            this.Controls.Add(this.lblLoginMethod);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblServerAddress);
            this.Controls.Add(this.btLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中医药数据库整理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Label lblServerAddress;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblLoginMethod;
        private System.Windows.Forms.Label lblUID;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.TextBox tbUID;
        private System.Windows.Forms.ComboBox cbLoginMethod;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.ComboBox cbServerAddress;
    }
}