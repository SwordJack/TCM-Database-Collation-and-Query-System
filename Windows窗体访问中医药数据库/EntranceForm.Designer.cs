namespace 中医药数据库查询
{
    partial class EntranceForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntranceForm));
            this.panelInstitution = new System.Windows.Forms.Panel();
            this.lblInstitution = new System.Windows.Forms.Label();
            this.pbInstitution = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.timerEntrance = new System.Windows.Forms.Timer(this.components);
            this.panelInstitution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInstitution)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInstitution
            // 
            this.panelInstitution.BackColor = System.Drawing.Color.Transparent;
            this.panelInstitution.Controls.Add(this.lblInstitution);
            this.panelInstitution.Controls.Add(this.pbInstitution);
            this.panelInstitution.Location = new System.Drawing.Point(390, 373);
            this.panelInstitution.Name = "panelInstitution";
            this.panelInstitution.Size = new System.Drawing.Size(421, 65);
            this.panelInstitution.TabIndex = 0;
            // 
            // lblInstitution
            // 
            this.lblInstitution.AutoSize = true;
            this.lblInstitution.BackColor = System.Drawing.Color.Transparent;
            this.lblInstitution.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInstitution.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblInstitution.Location = new System.Drawing.Point(66, 15);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(351, 38);
            this.lblInstitution.TabIndex = 1;
            this.lblInstitution.Text = "华东理工大学药学院\r\n            大学生暑期社会实践团";
            // 
            // pbInstitution
            // 
            this.pbInstitution.BackColor = System.Drawing.Color.Transparent;
            this.pbInstitution.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbInstitution.Image = global::中医药数据库查询.Properties.Resources.Badge_White_Reversed;
            this.pbInstitution.Location = new System.Drawing.Point(5, 5);
            this.pbInstitution.Name = "pbInstitution";
            this.pbInstitution.Size = new System.Drawing.Size(55, 55);
            this.pbInstitution.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInstitution.TabIndex = 0;
            this.pbInstitution.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("黑体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(81, 144);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(661, 96);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "中医药数据库整理\r\n        ——数据库管理系统";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.BackColor = System.Drawing.Color.Transparent;
            this.lblInstruction.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblInstruction.Location = new System.Drawing.Point(12, 385);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(353, 48);
            this.lblInstruction.TabIndex = 3;
            this.lblInstruction.Text = "CopyLeft 2019 - Forever, Zhong Y. Jie.\r\nPartial Rights Reserved, Licensed Under G" +
    "NU GPL v3.\r\n本应用及其相关内容不用于且不可以任何理由用于任何商业目的；\r\n作者对其使用不收取任何费用，对其造成之后果不担负任何责任。";
            // 
            // timerEntrance
            // 
            this.timerEntrance.Interval = 3000;
            this.timerEntrance.Tick += new System.EventHandler(this.TimerEntrance_Tick);
            // 
            // EntranceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(66)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(823, 450);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelInstitution);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EntranceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "程序初始页";
            this.Load += new System.EventHandler(this.EntranceForm_Load);
            this.panelInstitution.ResumeLayout(false);
            this.panelInstitution.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInstitution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelInstitution;
        private System.Windows.Forms.PictureBox pbInstitution;
        private System.Windows.Forms.Label lblInstitution;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Timer timerEntrance;
    }
}

