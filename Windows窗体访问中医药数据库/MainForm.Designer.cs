namespace Windows窗体访问中医药数据库
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblUid = new System.Windows.Forms.Label();
            this.tabCtrlMain = new System.Windows.Forms.TabControl();
            this.tpSelect = new System.Windows.Forms.TabPage();
            this.btSelReset = new System.Windows.Forms.Button();
            this.dataGridViewMain1 = new System.Windows.Forms.DataGridView();
            this.btSelMed = new System.Windows.Forms.Button();
            this.dataGridViewMain0 = new System.Windows.Forms.DataGridView();
            this.tbSelMessage = new System.Windows.Forms.TextBox();
            this.tbSelMedName = new System.Windows.Forms.TextBox();
            this.lblSelMedName = new System.Windows.Forms.Label();
            this.tpInsert = new System.Windows.Forms.TabPage();
            this.tbInsMessage = new System.Windows.Forms.TextBox();
            this.btInsReset = new System.Windows.Forms.Button();
            this.btInsMed = new System.Windows.Forms.Button();
            this.tbMedicineAlias = new System.Windows.Forms.TextBox();
            this.lblInsCheckCode = new System.Windows.Forms.Label();
            this.lblCommodityAliasName = new System.Windows.Forms.Label();
            this.tbIllustration = new System.Windows.Forms.TextBox();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.tbSourceArea = new System.Windows.Forms.TextBox();
            this.tbMedicinalMaterialName = new System.Windows.Forms.TextBox();
            this.tbCommodityName = new System.Windows.Forms.TextBox();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.tbInsTCMCode = new System.Windows.Forms.TextBox();
            this.lblIllustration = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblSourceArea = new System.Windows.Forms.Label();
            this.lblMedicinalMaterialName = new System.Windows.Forms.Label();
            this.lblCommodityName = new System.Windows.Forms.Label();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.lblInsTCMCode = new System.Windows.Forms.Label();
            this.tpDelete = new System.Windows.Forms.TabPage();
            this.btDelReset = new System.Windows.Forms.Button();
            this.tbDelMessage = new System.Windows.Forms.TextBox();
            this.cbBindAlias = new System.Windows.Forms.CheckBox();
            this.btDelMed = new System.Windows.Forms.Button();
            this.lblDelCheckCode = new System.Windows.Forms.Label();
            this.tbDelTCMCode = new System.Windows.Forms.TextBox();
            this.lblDelTCMCode = new System.Windows.Forms.Label();
            this.tpSelAll = new System.Windows.Forms.TabPage();
            this.tbSAllMessage = new System.Windows.Forms.TextBox();
            this.dataGridViewMain2 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSAllReset = new System.Windows.Forms.Button();
            this.btSAllTable = new System.Windows.Forms.Button();
            this.lblSAllOption = new System.Windows.Forms.Label();
            this.rbSAllPrescriptionFunction = new System.Windows.Forms.RadioButton();
            this.rbSAllMedicinalSource = new System.Windows.Forms.RadioButton();
            this.rbSAllMedicinalPart = new System.Windows.Forms.RadioButton();
            this.rbSAllDrugProcessing = new System.Windows.Forms.RadioButton();
            this.rbSAllCuttingSpecification = new System.Windows.Forms.RadioButton();
            this.rbSAllMedicine = new System.Windows.Forms.RadioButton();
            this.dataSetSel = new System.Data.DataSet();
            this.dataSetSAll = new System.Data.DataSet();
            this.tabCtrlMain.SuspendLayout();
            this.tpSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain0)).BeginInit();
            this.tpInsert.SuspendLayout();
            this.tpDelete.SuspendLayout();
            this.tpSelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSAll)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUid
            // 
            this.lblUid.AutoSize = true;
            this.lblUid.Location = new System.Drawing.Point(13, 13);
            this.lblUid.Name = "lblUid";
            this.lblUid.Size = new System.Drawing.Size(65, 12);
            this.lblUid.TabIndex = 0;
            this.lblUid.Text = "当前用户：";
            // 
            // tabCtrlMain
            // 
            this.tabCtrlMain.Controls.Add(this.tpSelect);
            this.tabCtrlMain.Controls.Add(this.tpInsert);
            this.tabCtrlMain.Controls.Add(this.tpDelete);
            this.tabCtrlMain.Controls.Add(this.tpSelAll);
            this.tabCtrlMain.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabCtrlMain.Location = new System.Drawing.Point(15, 53);
            this.tabCtrlMain.Name = "tabCtrlMain";
            this.tabCtrlMain.SelectedIndex = 0;
            this.tabCtrlMain.Size = new System.Drawing.Size(857, 456);
            this.tabCtrlMain.TabIndex = 1;
            // 
            // tpSelect
            // 
            this.tpSelect.Controls.Add(this.btSelReset);
            this.tpSelect.Controls.Add(this.dataGridViewMain1);
            this.tpSelect.Controls.Add(this.btSelMed);
            this.tpSelect.Controls.Add(this.dataGridViewMain0);
            this.tpSelect.Controls.Add(this.tbSelMessage);
            this.tpSelect.Controls.Add(this.tbSelMedName);
            this.tpSelect.Controls.Add(this.lblSelMedName);
            this.tpSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpSelect.Location = new System.Drawing.Point(4, 26);
            this.tpSelect.Name = "tpSelect";
            this.tpSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tpSelect.Size = new System.Drawing.Size(849, 426);
            this.tpSelect.TabIndex = 0;
            this.tpSelect.Text = "药物全信息查询";
            this.tpSelect.UseVisualStyleBackColor = true;
            // 
            // btSelReset
            // 
            this.btSelReset.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSelReset.Location = new System.Drawing.Point(115, 161);
            this.btSelReset.Name = "btSelReset";
            this.btSelReset.Size = new System.Drawing.Size(75, 23);
            this.btSelReset.TabIndex = 5;
            this.btSelReset.Text = "重置";
            this.btSelReset.UseVisualStyleBackColor = true;
            this.btSelReset.Click += new System.EventHandler(this.BtSelReset_Click);
            // 
            // dataGridViewMain1
            // 
            this.dataGridViewMain1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewMain1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain1.Location = new System.Drawing.Point(422, 6);
            this.dataGridViewMain1.Name = "dataGridViewMain1";
            this.dataGridViewMain1.RowTemplate.Height = 23;
            this.dataGridViewMain1.Size = new System.Drawing.Size(421, 189);
            this.dataGridViewMain1.TabIndex = 4;
            // 
            // btSelMed
            // 
            this.btSelMed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSelMed.Location = new System.Drawing.Point(21, 161);
            this.btSelMed.Name = "btSelMed";
            this.btSelMed.Size = new System.Drawing.Size(75, 23);
            this.btSelMed.TabIndex = 2;
            this.btSelMed.Text = "查询";
            this.btSelMed.UseVisualStyleBackColor = true;
            this.btSelMed.Click += new System.EventHandler(this.BtSelMed_Click);
            // 
            // dataGridViewMain0
            // 
            this.dataGridViewMain0.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewMain0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain0.Location = new System.Drawing.Point(6, 201);
            this.dataGridViewMain0.Name = "dataGridViewMain0";
            this.dataGridViewMain0.RowTemplate.Height = 23;
            this.dataGridViewMain0.Size = new System.Drawing.Size(837, 223);
            this.dataGridViewMain0.TabIndex = 3;
            // 
            // tbSelMessage
            // 
            this.tbSelMessage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSelMessage.Location = new System.Drawing.Point(218, 6);
            this.tbSelMessage.Multiline = true;
            this.tbSelMessage.Name = "tbSelMessage";
            this.tbSelMessage.ReadOnly = true;
            this.tbSelMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSelMessage.Size = new System.Drawing.Size(198, 189);
            this.tbSelMessage.TabIndex = 2;
            this.tbSelMessage.Text = "消息窗口";
            // 
            // tbSelMedName
            // 
            this.tbSelMedName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSelMedName.Location = new System.Drawing.Point(102, 49);
            this.tbSelMedName.Name = "tbSelMedName";
            this.tbSelMedName.Size = new System.Drawing.Size(100, 23);
            this.tbSelMedName.TabIndex = 1;
            // 
            // lblSelMedName
            // 
            this.lblSelMedName.AutoSize = true;
            this.lblSelMedName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelMedName.Location = new System.Drawing.Point(19, 52);
            this.lblSelMedName.Name = "lblSelMedName";
            this.lblSelMedName.Size = new System.Drawing.Size(77, 14);
            this.lblSelMedName.TabIndex = 0;
            this.lblSelMedName.Text = "药物名称：";
            // 
            // tpInsert
            // 
            this.tpInsert.Controls.Add(this.tbInsMessage);
            this.tpInsert.Controls.Add(this.btInsReset);
            this.tpInsert.Controls.Add(this.btInsMed);
            this.tpInsert.Controls.Add(this.tbMedicineAlias);
            this.tpInsert.Controls.Add(this.lblInsCheckCode);
            this.tpInsert.Controls.Add(this.lblCommodityAliasName);
            this.tpInsert.Controls.Add(this.tbIllustration);
            this.tpInsert.Controls.Add(this.tbRemark);
            this.tpInsert.Controls.Add(this.tbSourceArea);
            this.tpInsert.Controls.Add(this.tbMedicinalMaterialName);
            this.tpInsert.Controls.Add(this.tbCommodityName);
            this.tpInsert.Controls.Add(this.tbSerialNumber);
            this.tpInsert.Controls.Add(this.tbInsTCMCode);
            this.tpInsert.Controls.Add(this.lblIllustration);
            this.tpInsert.Controls.Add(this.lblRemark);
            this.tpInsert.Controls.Add(this.lblSourceArea);
            this.tpInsert.Controls.Add(this.lblMedicinalMaterialName);
            this.tpInsert.Controls.Add(this.lblCommodityName);
            this.tpInsert.Controls.Add(this.lblSerialNumber);
            this.tpInsert.Controls.Add(this.lblInsTCMCode);
            this.tpInsert.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpInsert.Location = new System.Drawing.Point(4, 26);
            this.tpInsert.Name = "tpInsert";
            this.tpInsert.Padding = new System.Windows.Forms.Padding(3);
            this.tpInsert.Size = new System.Drawing.Size(849, 426);
            this.tpInsert.TabIndex = 1;
            this.tpInsert.Text = "录入";
            this.tpInsert.UseVisualStyleBackColor = true;
            // 
            // tbInsMessage
            // 
            this.tbInsMessage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInsMessage.Location = new System.Drawing.Point(520, 281);
            this.tbInsMessage.Multiline = true;
            this.tbInsMessage.Name = "tbInsMessage";
            this.tbInsMessage.ReadOnly = true;
            this.tbInsMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInsMessage.Size = new System.Drawing.Size(280, 117);
            this.tbInsMessage.TabIndex = 20;
            this.tbInsMessage.Text = "消息窗口";
            // 
            // btInsReset
            // 
            this.btInsReset.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btInsReset.Location = new System.Drawing.Point(439, 375);
            this.btInsReset.Name = "btInsReset";
            this.btInsReset.Size = new System.Drawing.Size(75, 23);
            this.btInsReset.TabIndex = 19;
            this.btInsReset.Text = "重置";
            this.btInsReset.UseVisualStyleBackColor = true;
            this.btInsReset.Click += new System.EventHandler(this.BtInsReset_Click);
            // 
            // btInsMed
            // 
            this.btInsMed.Enabled = false;
            this.btInsMed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btInsMed.Location = new System.Drawing.Point(314, 375);
            this.btInsMed.Name = "btInsMed";
            this.btInsMed.Size = new System.Drawing.Size(75, 23);
            this.btInsMed.TabIndex = 18;
            this.btInsMed.Text = "录入";
            this.btInsMed.UseVisualStyleBackColor = true;
            this.btInsMed.Click += new System.EventHandler(this.BtInsMed_Click);
            // 
            // tbMedicineAlias
            // 
            this.tbMedicineAlias.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMedicineAlias.Location = new System.Drawing.Point(520, 178);
            this.tbMedicineAlias.Multiline = true;
            this.tbMedicineAlias.Name = "tbMedicineAlias";
            this.tbMedicineAlias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMedicineAlias.Size = new System.Drawing.Size(280, 97);
            this.tbMedicineAlias.TabIndex = 17;
            // 
            // lblInsCheckCode
            // 
            this.lblInsCheckCode.AutoSize = true;
            this.lblInsCheckCode.Font = new System.Drawing.Font("宋体", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInsCheckCode.Location = new System.Drawing.Point(116, 59);
            this.lblInsCheckCode.Name = "lblInsCheckCode";
            this.lblInsCheckCode.Size = new System.Drawing.Size(101, 12);
            this.lblInsCheckCode.TabIndex = 16;
            this.lblInsCheckCode.Text = "请输入药物代码。";
            // 
            // lblCommodityAliasName
            // 
            this.lblCommodityAliasName.AutoSize = true;
            this.lblCommodityAliasName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCommodityAliasName.Location = new System.Drawing.Point(311, 181);
            this.lblCommodityAliasName.Name = "lblCommodityAliasName";
            this.lblCommodityAliasName.Size = new System.Drawing.Size(203, 14);
            this.lblCommodityAliasName.TabIndex = 15;
            this.lblCommodityAliasName.Text = "药物别名（换行输入下一个）：";
            // 
            // tbIllustration
            // 
            this.tbIllustration.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbIllustration.Location = new System.Drawing.Point(398, 33);
            this.tbIllustration.Multiline = true;
            this.tbIllustration.Name = "tbIllustration";
            this.tbIllustration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbIllustration.Size = new System.Drawing.Size(402, 139);
            this.tbIllustration.TabIndex = 14;
            // 
            // tbRemark
            // 
            this.tbRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRemark.Location = new System.Drawing.Point(118, 323);
            this.tbRemark.MaxLength = 1;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(100, 23);
            this.tbRemark.TabIndex = 13;
            // 
            // tbSourceArea
            // 
            this.tbSourceArea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSourceArea.Location = new System.Drawing.Point(118, 265);
            this.tbSourceArea.Name = "tbSourceArea";
            this.tbSourceArea.Size = new System.Drawing.Size(100, 23);
            this.tbSourceArea.TabIndex = 12;
            // 
            // tbMedicinalMaterialName
            // 
            this.tbMedicinalMaterialName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMedicinalMaterialName.Location = new System.Drawing.Point(118, 207);
            this.tbMedicinalMaterialName.Name = "tbMedicinalMaterialName";
            this.tbMedicinalMaterialName.Size = new System.Drawing.Size(100, 23);
            this.tbMedicinalMaterialName.TabIndex = 11;
            // 
            // tbCommodityName
            // 
            this.tbCommodityName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCommodityName.Location = new System.Drawing.Point(118, 149);
            this.tbCommodityName.Name = "tbCommodityName";
            this.tbCommodityName.Size = new System.Drawing.Size(100, 23);
            this.tbCommodityName.TabIndex = 10;
            this.tbCommodityName.Leave += new System.EventHandler(this.TbCommodityName_Leave);
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSerialNumber.Location = new System.Drawing.Point(118, 91);
            this.tbSerialNumber.MaxLength = 5;
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(100, 23);
            this.tbSerialNumber.TabIndex = 9;
            // 
            // tbInsTCMCode
            // 
            this.tbInsTCMCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInsTCMCode.Location = new System.Drawing.Point(118, 33);
            this.tbInsTCMCode.MaxLength = 17;
            this.tbInsTCMCode.Name = "tbInsTCMCode";
            this.tbInsTCMCode.Size = new System.Drawing.Size(143, 23);
            this.tbInsTCMCode.TabIndex = 8;
            this.tbInsTCMCode.Leave += new System.EventHandler(this.TbTCMCode_Leave);
            // 
            // lblIllustration
            // 
            this.lblIllustration.AutoSize = true;
            this.lblIllustration.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIllustration.Location = new System.Drawing.Point(311, 36);
            this.lblIllustration.Name = "lblIllustration";
            this.lblIllustration.Size = new System.Drawing.Size(49, 14);
            this.lblIllustration.TabIndex = 7;
            this.lblIllustration.Text = "说明：";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemark.Location = new System.Drawing.Point(35, 326);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(49, 14);
            this.lblRemark.TabIndex = 6;
            this.lblRemark.Text = "备注：";
            // 
            // lblSourceArea
            // 
            this.lblSourceArea.AutoSize = true;
            this.lblSourceArea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSourceArea.Location = new System.Drawing.Point(35, 268);
            this.lblSourceArea.Name = "lblSourceArea";
            this.lblSourceArea.Size = new System.Drawing.Size(63, 14);
            this.lblSourceArea.TabIndex = 5;
            this.lblSourceArea.Text = "原产地：";
            // 
            // lblMedicinalMaterialName
            // 
            this.lblMedicinalMaterialName.AutoSize = true;
            this.lblMedicinalMaterialName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMedicinalMaterialName.Location = new System.Drawing.Point(35, 210);
            this.lblMedicinalMaterialName.Name = "lblMedicinalMaterialName";
            this.lblMedicinalMaterialName.Size = new System.Drawing.Size(63, 14);
            this.lblMedicinalMaterialName.TabIndex = 4;
            this.lblMedicinalMaterialName.Text = "药材名：";
            // 
            // lblCommodityName
            // 
            this.lblCommodityName.AutoSize = true;
            this.lblCommodityName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCommodityName.Location = new System.Drawing.Point(35, 152);
            this.lblCommodityName.Name = "lblCommodityName";
            this.lblCommodityName.Size = new System.Drawing.Size(49, 14);
            this.lblCommodityName.TabIndex = 3;
            this.lblCommodityName.Text = "品名：";
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSerialNumber.Location = new System.Drawing.Point(35, 94);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(63, 14);
            this.lblSerialNumber.TabIndex = 2;
            this.lblSerialNumber.Text = "顺序号：";
            // 
            // lblInsTCMCode
            // 
            this.lblInsTCMCode.AutoSize = true;
            this.lblInsTCMCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInsTCMCode.Location = new System.Drawing.Point(35, 36);
            this.lblInsTCMCode.Name = "lblInsTCMCode";
            this.lblInsTCMCode.Size = new System.Drawing.Size(77, 14);
            this.lblInsTCMCode.TabIndex = 1;
            this.lblInsTCMCode.Text = "药物代码：";
            // 
            // tpDelete
            // 
            this.tpDelete.Controls.Add(this.btDelReset);
            this.tpDelete.Controls.Add(this.tbDelMessage);
            this.tpDelete.Controls.Add(this.cbBindAlias);
            this.tpDelete.Controls.Add(this.btDelMed);
            this.tpDelete.Controls.Add(this.lblDelCheckCode);
            this.tpDelete.Controls.Add(this.tbDelTCMCode);
            this.tpDelete.Controls.Add(this.lblDelTCMCode);
            this.tpDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpDelete.Location = new System.Drawing.Point(4, 26);
            this.tpDelete.Name = "tpDelete";
            this.tpDelete.Padding = new System.Windows.Forms.Padding(3);
            this.tpDelete.Size = new System.Drawing.Size(849, 426);
            this.tpDelete.TabIndex = 2;
            this.tpDelete.Text = "删除";
            this.tpDelete.UseVisualStyleBackColor = true;
            // 
            // btDelReset
            // 
            this.btDelReset.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDelReset.Location = new System.Drawing.Point(173, 189);
            this.btDelReset.Name = "btDelReset";
            this.btDelReset.Size = new System.Drawing.Size(75, 23);
            this.btDelReset.TabIndex = 23;
            this.btDelReset.Text = "重置";
            this.btDelReset.UseVisualStyleBackColor = true;
            this.btDelReset.Click += new System.EventHandler(this.BtDelReset_Click);
            // 
            // tbDelMessage
            // 
            this.tbDelMessage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDelMessage.Location = new System.Drawing.Point(24, 251);
            this.tbDelMessage.Multiline = true;
            this.tbDelMessage.Name = "tbDelMessage";
            this.tbDelMessage.ReadOnly = true;
            this.tbDelMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDelMessage.Size = new System.Drawing.Size(248, 117);
            this.tbDelMessage.TabIndex = 22;
            this.tbDelMessage.Text = "消息窗口";
            // 
            // cbBindAlias
            // 
            this.cbBindAlias.AutoSize = true;
            this.cbBindAlias.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBindAlias.Location = new System.Drawing.Point(25, 126);
            this.cbBindAlias.Name = "cbBindAlias";
            this.cbBindAlias.Size = new System.Drawing.Size(120, 16);
            this.cbBindAlias.TabIndex = 21;
            this.cbBindAlias.Text = "同时删除药物别名";
            this.cbBindAlias.UseVisualStyleBackColor = true;
            // 
            // btDelMed
            // 
            this.btDelMed.Enabled = false;
            this.btDelMed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDelMed.Location = new System.Drawing.Point(24, 189);
            this.btDelMed.Name = "btDelMed";
            this.btDelMed.Size = new System.Drawing.Size(75, 23);
            this.btDelMed.TabIndex = 20;
            this.btDelMed.Text = "删除";
            this.btDelMed.UseVisualStyleBackColor = true;
            this.btDelMed.Click += new System.EventHandler(this.BtDelMed_Click);
            // 
            // lblDelCheckCode
            // 
            this.lblDelCheckCode.AutoSize = true;
            this.lblDelCheckCode.Font = new System.Drawing.Font("宋体", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDelCheckCode.Location = new System.Drawing.Point(103, 57);
            this.lblDelCheckCode.Name = "lblDelCheckCode";
            this.lblDelCheckCode.Size = new System.Drawing.Size(101, 12);
            this.lblDelCheckCode.TabIndex = 19;
            this.lblDelCheckCode.Text = "请输入药物代码。";
            // 
            // tbDelTCMCode
            // 
            this.tbDelTCMCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDelTCMCode.Location = new System.Drawing.Point(105, 31);
            this.tbDelTCMCode.MaxLength = 17;
            this.tbDelTCMCode.Name = "tbDelTCMCode";
            this.tbDelTCMCode.Size = new System.Drawing.Size(143, 23);
            this.tbDelTCMCode.TabIndex = 18;
            this.tbDelTCMCode.Leave += new System.EventHandler(this.TbDelTCMCode_Leave);
            // 
            // lblDelTCMCode
            // 
            this.lblDelTCMCode.AutoSize = true;
            this.lblDelTCMCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDelTCMCode.Location = new System.Drawing.Point(22, 34);
            this.lblDelTCMCode.Name = "lblDelTCMCode";
            this.lblDelTCMCode.Size = new System.Drawing.Size(77, 14);
            this.lblDelTCMCode.TabIndex = 17;
            this.lblDelTCMCode.Text = "药物代码：";
            // 
            // tpSelAll
            // 
            this.tpSelAll.Controls.Add(this.tbSAllMessage);
            this.tpSelAll.Controls.Add(this.dataGridViewMain2);
            this.tpSelAll.Controls.Add(this.panel1);
            this.tpSelAll.Location = new System.Drawing.Point(4, 26);
            this.tpSelAll.Name = "tpSelAll";
            this.tpSelAll.Padding = new System.Windows.Forms.Padding(3);
            this.tpSelAll.Size = new System.Drawing.Size(849, 426);
            this.tpSelAll.TabIndex = 3;
            this.tpSelAll.Text = "全表查询";
            this.tpSelAll.UseVisualStyleBackColor = true;
            // 
            // tbSAllMessage
            // 
            this.tbSAllMessage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSAllMessage.Location = new System.Drawing.Point(233, 343);
            this.tbSAllMessage.Multiline = true;
            this.tbSAllMessage.Name = "tbSAllMessage";
            this.tbSAllMessage.ReadOnly = true;
            this.tbSAllMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSAllMessage.Size = new System.Drawing.Size(610, 77);
            this.tbSAllMessage.TabIndex = 21;
            this.tbSAllMessage.Text = "消息窗口";
            // 
            // dataGridViewMain2
            // 
            this.dataGridViewMain2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain2.Location = new System.Drawing.Point(233, 6);
            this.dataGridViewMain2.Name = "dataGridViewMain2";
            this.dataGridViewMain2.RowTemplate.Height = 23;
            this.dataGridViewMain2.Size = new System.Drawing.Size(610, 331);
            this.dataGridViewMain2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btSAllReset);
            this.panel1.Controls.Add(this.btSAllTable);
            this.panel1.Controls.Add(this.lblSAllOption);
            this.panel1.Controls.Add(this.rbSAllPrescriptionFunction);
            this.panel1.Controls.Add(this.rbSAllMedicinalSource);
            this.panel1.Controls.Add(this.rbSAllMedicinalPart);
            this.panel1.Controls.Add(this.rbSAllDrugProcessing);
            this.panel1.Controls.Add(this.rbSAllCuttingSpecification);
            this.panel1.Controls.Add(this.rbSAllMedicine);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 418);
            this.panel1.TabIndex = 0;
            // 
            // btSAllReset
            // 
            this.btSAllReset.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSAllReset.Location = new System.Drawing.Point(126, 368);
            this.btSAllReset.Name = "btSAllReset";
            this.btSAllReset.Size = new System.Drawing.Size(75, 23);
            this.btSAllReset.TabIndex = 8;
            this.btSAllReset.Text = "重置";
            this.btSAllReset.UseVisualStyleBackColor = true;
            this.btSAllReset.Click += new System.EventHandler(this.BtSAllReset_Click);
            // 
            // btSAllTable
            // 
            this.btSAllTable.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSAllTable.Location = new System.Drawing.Point(20, 368);
            this.btSAllTable.Name = "btSAllTable";
            this.btSAllTable.Size = new System.Drawing.Size(75, 23);
            this.btSAllTable.TabIndex = 7;
            this.btSAllTable.Text = "查询";
            this.btSAllTable.UseVisualStyleBackColor = true;
            this.btSAllTable.Click += new System.EventHandler(this.BtSAllTable_Click);
            // 
            // lblSAllOption
            // 
            this.lblSAllOption.AutoSize = true;
            this.lblSAllOption.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSAllOption.Location = new System.Drawing.Point(3, 14);
            this.lblSAllOption.Name = "lblSAllOption";
            this.lblSAllOption.Size = new System.Drawing.Size(77, 14);
            this.lblSAllOption.TabIndex = 6;
            this.lblSAllOption.Text = "选择表单：";
            // 
            // rbSAllPrescriptionFunction
            // 
            this.rbSAllPrescriptionFunction.AutoSize = true;
            this.rbSAllPrescriptionFunction.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSAllPrescriptionFunction.Location = new System.Drawing.Point(19, 313);
            this.rbSAllPrescriptionFunction.Name = "rbSAllPrescriptionFunction";
            this.rbSAllPrescriptionFunction.Size = new System.Drawing.Size(81, 18);
            this.rbSAllPrescriptionFunction.TabIndex = 5;
            this.rbSAllPrescriptionFunction.TabStop = true;
            this.rbSAllPrescriptionFunction.Text = "方剂功用";
            this.rbSAllPrescriptionFunction.UseVisualStyleBackColor = true;
            this.rbSAllPrescriptionFunction.CheckedChanged += new System.EventHandler(this.RbSAllOption_CheckedChanged);
            // 
            // rbSAllMedicinalSource
            // 
            this.rbSAllMedicinalSource.AutoSize = true;
            this.rbSAllMedicinalSource.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSAllMedicinalSource.Location = new System.Drawing.Point(19, 211);
            this.rbSAllMedicinalSource.Name = "rbSAllMedicinalSource";
            this.rbSAllMedicinalSource.Size = new System.Drawing.Size(81, 18);
            this.rbSAllMedicinalSource.TabIndex = 3;
            this.rbSAllMedicinalSource.TabStop = true;
            this.rbSAllMedicinalSource.Text = "药物来源";
            this.rbSAllMedicinalSource.UseVisualStyleBackColor = true;
            this.rbSAllMedicinalSource.CheckedChanged += new System.EventHandler(this.RbSAllOption_CheckedChanged);
            // 
            // rbSAllMedicinalPart
            // 
            this.rbSAllMedicinalPart.AutoSize = true;
            this.rbSAllMedicinalPart.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSAllMedicinalPart.Location = new System.Drawing.Point(19, 160);
            this.rbSAllMedicinalPart.Name = "rbSAllMedicinalPart";
            this.rbSAllMedicinalPart.Size = new System.Drawing.Size(81, 18);
            this.rbSAllMedicinalPart.TabIndex = 2;
            this.rbSAllMedicinalPart.TabStop = true;
            this.rbSAllMedicinalPart.Text = "药用部位";
            this.rbSAllMedicinalPart.UseVisualStyleBackColor = true;
            this.rbSAllMedicinalPart.CheckedChanged += new System.EventHandler(this.RbSAllOption_CheckedChanged);
            // 
            // rbSAllDrugProcessing
            // 
            this.rbSAllDrugProcessing.AutoSize = true;
            this.rbSAllDrugProcessing.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSAllDrugProcessing.Location = new System.Drawing.Point(19, 109);
            this.rbSAllDrugProcessing.Name = "rbSAllDrugProcessing";
            this.rbSAllDrugProcessing.Size = new System.Drawing.Size(81, 18);
            this.rbSAllDrugProcessing.TabIndex = 1;
            this.rbSAllDrugProcessing.TabStop = true;
            this.rbSAllDrugProcessing.Text = "炮炙方法";
            this.rbSAllDrugProcessing.UseVisualStyleBackColor = true;
            this.rbSAllDrugProcessing.CheckedChanged += new System.EventHandler(this.RbSAllOption_CheckedChanged);
            // 
            // rbSAllCuttingSpecification
            // 
            this.rbSAllCuttingSpecification.AutoSize = true;
            this.rbSAllCuttingSpecification.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSAllCuttingSpecification.Location = new System.Drawing.Point(19, 58);
            this.rbSAllCuttingSpecification.Name = "rbSAllCuttingSpecification";
            this.rbSAllCuttingSpecification.Size = new System.Drawing.Size(81, 18);
            this.rbSAllCuttingSpecification.TabIndex = 0;
            this.rbSAllCuttingSpecification.TabStop = true;
            this.rbSAllCuttingSpecification.Text = "切制规格";
            this.rbSAllCuttingSpecification.UseVisualStyleBackColor = true;
            this.rbSAllCuttingSpecification.CheckedChanged += new System.EventHandler(this.RbSAllOption_CheckedChanged);
            // 
            // rbSAllMedicine
            // 
            this.rbSAllMedicine.AutoSize = true;
            this.rbSAllMedicine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSAllMedicine.Location = new System.Drawing.Point(19, 262);
            this.rbSAllMedicine.Name = "rbSAllMedicine";
            this.rbSAllMedicine.Size = new System.Drawing.Size(109, 18);
            this.rbSAllMedicine.TabIndex = 4;
            this.rbSAllMedicine.TabStop = true;
            this.rbSAllMedicine.Text = "药物基本信息";
            this.rbSAllMedicine.UseVisualStyleBackColor = true;
            this.rbSAllMedicine.CheckedChanged += new System.EventHandler(this.RbSAllOption_CheckedChanged);
            // 
            // dataSetSel
            // 
            this.dataSetSel.DataSetName = "DataSetSel";
            // 
            // dataSetSAll
            // 
            this.dataSetSAll.DataSetName = "DataSetSAll";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 521);
            this.Controls.Add(this.tabCtrlMain);
            this.Controls.Add(this.lblUid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中医药数据库整理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabCtrlMain.ResumeLayout(false);
            this.tpSelect.ResumeLayout(false);
            this.tpSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain0)).EndInit();
            this.tpInsert.ResumeLayout(false);
            this.tpInsert.PerformLayout();
            this.tpDelete.ResumeLayout(false);
            this.tpDelete.PerformLayout();
            this.tpSelAll.ResumeLayout(false);
            this.tpSelAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSAll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUid;
        private System.Windows.Forms.TabControl tabCtrlMain;
        private System.Windows.Forms.TabPage tpSelect;
        private System.Windows.Forms.TabPage tpInsert;
        private System.Windows.Forms.TextBox tbSelMessage;
        private System.Data.DataSet dataSetSel;
        private System.Windows.Forms.DataGridView dataGridViewMain0;
        private System.Windows.Forms.Button btSelMed;
        private System.Windows.Forms.TextBox tbSelMedName;
        private System.Windows.Forms.Label lblSelMedName;
        private System.Windows.Forms.DataGridView dataGridViewMain1;
        private System.Windows.Forms.Button btSelReset;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.TextBox tbInsTCMCode;
        private System.Windows.Forms.Label lblIllustration;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblSourceArea;
        private System.Windows.Forms.Label lblMedicinalMaterialName;
        private System.Windows.Forms.Label lblCommodityName;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblInsTCMCode;
        private System.Windows.Forms.Label lblCommodityAliasName;
        private System.Windows.Forms.TextBox tbIllustration;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.TextBox tbSourceArea;
        private System.Windows.Forms.TextBox tbMedicinalMaterialName;
        private System.Windows.Forms.TextBox tbCommodityName;
        private System.Windows.Forms.Label lblInsCheckCode;
        private System.Windows.Forms.TextBox tbMedicineAlias;
        private System.Windows.Forms.Button btInsReset;
        private System.Windows.Forms.Button btInsMed;
        private System.Windows.Forms.TextBox tbInsMessage;
        private System.Windows.Forms.TabPage tpDelete;
        private System.Windows.Forms.Label lblDelCheckCode;
        private System.Windows.Forms.TextBox tbDelTCMCode;
        private System.Windows.Forms.Label lblDelTCMCode;
        private System.Windows.Forms.Button btDelMed;
        private System.Windows.Forms.CheckBox cbBindAlias;
        private System.Windows.Forms.TextBox tbDelMessage;
        private System.Windows.Forms.Button btDelReset;
        private System.Windows.Forms.TabPage tpSelAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbSAllMedicine;
        private System.Windows.Forms.RadioButton rbSAllCuttingSpecification;
        private System.Windows.Forms.DataGridView dataGridViewMain2;
        private System.Windows.Forms.Button btSAllTable;
        private System.Windows.Forms.Label lblSAllOption;
        private System.Windows.Forms.RadioButton rbSAllPrescriptionFunction;
        private System.Windows.Forms.RadioButton rbSAllMedicinalSource;
        private System.Windows.Forms.RadioButton rbSAllMedicinalPart;
        private System.Windows.Forms.RadioButton rbSAllDrugProcessing;
        private System.Data.DataSet dataSetSAll;
        private System.Windows.Forms.TextBox tbSAllMessage;
        private System.Windows.Forms.Button btSAllReset;
    }
}