namespace 中医药数据库查询
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
            this.tabCtrlMain = new System.Windows.Forms.TabControl();
            this.tpMedSelect = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbSelMedByCode = new System.Windows.Forms.RadioButton();
            this.rbSelMedByName = new System.Windows.Forms.RadioButton();
            this.btMedReset = new System.Windows.Forms.Button();
            this.dataGridViewMain1 = new System.Windows.Forms.DataGridView();
            this.btSelMed = new System.Windows.Forms.Button();
            this.dataGridViewMain0 = new System.Windows.Forms.DataGridView();
            this.tbSelMedMessage = new System.Windows.Forms.TextBox();
            this.tbSelMed = new System.Windows.Forms.TextBox();
            this.tpPreSelect = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbSelPreBySource = new System.Windows.Forms.RadioButton();
            this.rbSelPreByFunction = new System.Windows.Forms.RadioButton();
            this.rbSelPreByCode = new System.Windows.Forms.RadioButton();
            this.rbSelPreByName = new System.Windows.Forms.RadioButton();
            this.btSelPreReset = new System.Windows.Forms.Button();
            this.dataGridViewMain3 = new System.Windows.Forms.DataGridView();
            this.btSelPre = new System.Windows.Forms.Button();
            this.dataGridViewMain4 = new System.Windows.Forms.DataGridView();
            this.tbSelPreMessage = new System.Windows.Forms.TextBox();
            this.tbSelPre = new System.Windows.Forms.TextBox();
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
            this.dataSetMedSel = new System.Data.DataSet();
            this.dataSetSAll = new System.Data.DataSet();
            this.dataSetPreSel = new System.Data.DataSet();
            this.tabCtrlMain.SuspendLayout();
            this.tpMedSelect.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain0)).BeginInit();
            this.tpPreSelect.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain4)).BeginInit();
            this.tpSelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMedSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPreSel)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtrlMain
            // 
            this.tabCtrlMain.Controls.Add(this.tpMedSelect);
            this.tabCtrlMain.Controls.Add(this.tpPreSelect);
            this.tabCtrlMain.Controls.Add(this.tpSelAll);
            this.tabCtrlMain.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabCtrlMain.Location = new System.Drawing.Point(14, 12);
            this.tabCtrlMain.Name = "tabCtrlMain";
            this.tabCtrlMain.SelectedIndex = 0;
            this.tabCtrlMain.Size = new System.Drawing.Size(981, 536);
            this.tabCtrlMain.TabIndex = 1;
            // 
            // tpMedSelect
            // 
            this.tpMedSelect.Controls.Add(this.panel2);
            this.tpMedSelect.Controls.Add(this.btMedReset);
            this.tpMedSelect.Controls.Add(this.dataGridViewMain1);
            this.tpMedSelect.Controls.Add(this.btSelMed);
            this.tpMedSelect.Controls.Add(this.dataGridViewMain0);
            this.tpMedSelect.Controls.Add(this.tbSelMedMessage);
            this.tpMedSelect.Controls.Add(this.tbSelMed);
            this.tpMedSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpMedSelect.Location = new System.Drawing.Point(4, 26);
            this.tpMedSelect.Name = "tpMedSelect";
            this.tpMedSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tpMedSelect.Size = new System.Drawing.Size(973, 506);
            this.tpMedSelect.TabIndex = 0;
            this.tpMedSelect.Text = "药物信息查询";
            this.tpMedSelect.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbSelMedByCode);
            this.panel2.Controls.Add(this.rbSelMedByName);
            this.panel2.Location = new System.Drawing.Point(6, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 114);
            this.panel2.TabIndex = 6;
            // 
            // rbSelMedByCode
            // 
            this.rbSelMedByCode.AutoSize = true;
            this.rbSelMedByCode.Location = new System.Drawing.Point(184, 48);
            this.rbSelMedByCode.Name = "rbSelMedByCode";
            this.rbSelMedByCode.Size = new System.Drawing.Size(123, 18);
            this.rbSelMedByCode.TabIndex = 1;
            this.rbSelMedByCode.TabStop = true;
            this.rbSelMedByCode.Text = "按代码精确查询";
            this.rbSelMedByCode.UseVisualStyleBackColor = true;
            // 
            // rbSelMedByName
            // 
            this.rbSelMedByName.AutoSize = true;
            this.rbSelMedByName.Location = new System.Drawing.Point(39, 48);
            this.rbSelMedByName.Name = "rbSelMedByName";
            this.rbSelMedByName.Size = new System.Drawing.Size(95, 18);
            this.rbSelMedByName.TabIndex = 0;
            this.rbSelMedByName.TabStop = true;
            this.rbSelMedByName.Text = "按名称查询";
            this.rbSelMedByName.UseVisualStyleBackColor = true;
            // 
            // btMedReset
            // 
            this.btMedReset.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btMedReset.Location = new System.Drawing.Point(278, 31);
            this.btMedReset.Name = "btMedReset";
            this.btMedReset.Size = new System.Drawing.Size(75, 23);
            this.btMedReset.TabIndex = 5;
            this.btMedReset.Text = "重置";
            this.btMedReset.UseVisualStyleBackColor = true;
            this.btMedReset.Click += new System.EventHandler(this.BtSelReset_Click);
            // 
            // dataGridViewMain1
            // 
            this.dataGridViewMain1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewMain1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain1.Location = new System.Drawing.Point(359, 6);
            this.dataGridViewMain1.Name = "dataGridViewMain1";
            this.dataGridViewMain1.RowTemplate.Height = 23;
            this.dataGridViewMain1.Size = new System.Drawing.Size(608, 265);
            this.dataGridViewMain1.TabIndex = 4;
            // 
            // btSelMed
            // 
            this.btSelMed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSelMed.Location = new System.Drawing.Point(197, 31);
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
            this.dataGridViewMain0.Location = new System.Drawing.Point(6, 277);
            this.dataGridViewMain0.Name = "dataGridViewMain0";
            this.dataGridViewMain0.RowTemplate.Height = 23;
            this.dataGridViewMain0.Size = new System.Drawing.Size(961, 223);
            this.dataGridViewMain0.TabIndex = 3;
            // 
            // tbSelMedMessage
            // 
            this.tbSelMedMessage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSelMedMessage.Location = new System.Drawing.Point(6, 196);
            this.tbSelMedMessage.Multiline = true;
            this.tbSelMedMessage.Name = "tbSelMedMessage";
            this.tbSelMedMessage.ReadOnly = true;
            this.tbSelMedMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSelMedMessage.Size = new System.Drawing.Size(347, 75);
            this.tbSelMedMessage.TabIndex = 2;
            this.tbSelMedMessage.Text = "消息窗口";
            // 
            // tbSelMed
            // 
            this.tbSelMed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSelMed.Location = new System.Drawing.Point(6, 31);
            this.tbSelMed.MaxLength = 48;
            this.tbSelMed.Name = "tbSelMed";
            this.tbSelMed.Size = new System.Drawing.Size(185, 23);
            this.tbSelMed.TabIndex = 1;
            // 
            // tpPreSelect
            // 
            this.tpPreSelect.Controls.Add(this.panel3);
            this.tpPreSelect.Controls.Add(this.btSelPreReset);
            this.tpPreSelect.Controls.Add(this.dataGridViewMain3);
            this.tpPreSelect.Controls.Add(this.btSelPre);
            this.tpPreSelect.Controls.Add(this.dataGridViewMain4);
            this.tpPreSelect.Controls.Add(this.tbSelPreMessage);
            this.tpPreSelect.Controls.Add(this.tbSelPre);
            this.tpPreSelect.Location = new System.Drawing.Point(4, 26);
            this.tpPreSelect.Name = "tpPreSelect";
            this.tpPreSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tpPreSelect.Size = new System.Drawing.Size(973, 506);
            this.tpPreSelect.TabIndex = 6;
            this.tpPreSelect.Text = "方剂信息查询";
            this.tpPreSelect.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbSelPreBySource);
            this.panel3.Controls.Add(this.rbSelPreByFunction);
            this.panel3.Controls.Add(this.rbSelPreByCode);
            this.panel3.Controls.Add(this.rbSelPreByName);
            this.panel3.Location = new System.Drawing.Point(7, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(346, 114);
            this.panel3.TabIndex = 13;
            // 
            // rbSelPreBySource
            // 
            this.rbSelPreBySource.AutoSize = true;
            this.rbSelPreBySource.Location = new System.Drawing.Point(12, 73);
            this.rbSelPreBySource.Name = "rbSelPreBySource";
            this.rbSelPreBySource.Size = new System.Drawing.Size(138, 20);
            this.rbSelPreBySource.TabIndex = 3;
            this.rbSelPreBySource.TabStop = true;
            this.rbSelPreBySource.Text = "按方剂出处查询";
            this.rbSelPreBySource.UseVisualStyleBackColor = true;
            // 
            // rbSelPreByFunction
            // 
            this.rbSelPreByFunction.AutoSize = true;
            this.rbSelPreByFunction.Location = new System.Drawing.Point(156, 73);
            this.rbSelPreByFunction.Name = "rbSelPreByFunction";
            this.rbSelPreByFunction.Size = new System.Drawing.Size(186, 20);
            this.rbSelPreByFunction.TabIndex = 2;
            this.rbSelPreByFunction.TabStop = true;
            this.rbSelPreByFunction.Text = "按功效、主治证候查询";
            this.rbSelPreByFunction.UseVisualStyleBackColor = true;
            // 
            // rbSelPreByCode
            // 
            this.rbSelPreByCode.AutoSize = true;
            this.rbSelPreByCode.Location = new System.Drawing.Point(156, 17);
            this.rbSelPreByCode.Name = "rbSelPreByCode";
            this.rbSelPreByCode.Size = new System.Drawing.Size(138, 20);
            this.rbSelPreByCode.TabIndex = 1;
            this.rbSelPreByCode.TabStop = true;
            this.rbSelPreByCode.Text = "按代码精确查询";
            this.rbSelPreByCode.UseVisualStyleBackColor = true;
            // 
            // rbSelPreByName
            // 
            this.rbSelPreByName.AutoSize = true;
            this.rbSelPreByName.Location = new System.Drawing.Point(12, 17);
            this.rbSelPreByName.Name = "rbSelPreByName";
            this.rbSelPreByName.Size = new System.Drawing.Size(106, 20);
            this.rbSelPreByName.TabIndex = 0;
            this.rbSelPreByName.TabStop = true;
            this.rbSelPreByName.Text = "按名称查询";
            this.rbSelPreByName.UseVisualStyleBackColor = true;
            // 
            // btSelPreReset
            // 
            this.btSelPreReset.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSelPreReset.Location = new System.Drawing.Point(278, 30);
            this.btSelPreReset.Name = "btSelPreReset";
            this.btSelPreReset.Size = new System.Drawing.Size(75, 23);
            this.btSelPreReset.TabIndex = 12;
            this.btSelPreReset.Text = "重置";
            this.btSelPreReset.UseVisualStyleBackColor = true;
            this.btSelPreReset.Click += new System.EventHandler(this.BtSelPreReset_Click);
            // 
            // dataGridViewMain3
            // 
            this.dataGridViewMain3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewMain3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain3.Location = new System.Drawing.Point(359, 6);
            this.dataGridViewMain3.Name = "dataGridViewMain3";
            this.dataGridViewMain3.RowTemplate.Height = 23;
            this.dataGridViewMain3.Size = new System.Drawing.Size(608, 265);
            this.dataGridViewMain3.TabIndex = 11;
            // 
            // btSelPre
            // 
            this.btSelPre.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSelPre.Location = new System.Drawing.Point(197, 30);
            this.btSelPre.Name = "btSelPre";
            this.btSelPre.Size = new System.Drawing.Size(75, 23);
            this.btSelPre.TabIndex = 8;
            this.btSelPre.Text = "查询";
            this.btSelPre.UseVisualStyleBackColor = true;
            this.btSelPre.Click += new System.EventHandler(this.BtSelPre_Click);
            // 
            // dataGridViewMain4
            // 
            this.dataGridViewMain4.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewMain4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain4.Location = new System.Drawing.Point(6, 277);
            this.dataGridViewMain4.Name = "dataGridViewMain4";
            this.dataGridViewMain4.RowTemplate.Height = 23;
            this.dataGridViewMain4.Size = new System.Drawing.Size(961, 223);
            this.dataGridViewMain4.TabIndex = 10;
            // 
            // tbSelPreMessage
            // 
            this.tbSelPreMessage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSelPreMessage.Location = new System.Drawing.Point(6, 196);
            this.tbSelPreMessage.Multiline = true;
            this.tbSelPreMessage.Name = "tbSelPreMessage";
            this.tbSelPreMessage.ReadOnly = true;
            this.tbSelPreMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSelPreMessage.Size = new System.Drawing.Size(347, 75);
            this.tbSelPreMessage.TabIndex = 9;
            this.tbSelPreMessage.Text = "消息窗口";
            // 
            // tbSelPre
            // 
            this.tbSelPre.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSelPre.Location = new System.Drawing.Point(6, 31);
            this.tbSelPre.Name = "tbSelPre";
            this.tbSelPre.Size = new System.Drawing.Size(185, 23);
            this.tbSelPre.TabIndex = 7;
            // 
            // tpSelAll
            // 
            this.tpSelAll.Controls.Add(this.tbSAllMessage);
            this.tpSelAll.Controls.Add(this.dataGridViewMain2);
            this.tpSelAll.Controls.Add(this.panel1);
            this.tpSelAll.Location = new System.Drawing.Point(4, 26);
            this.tpSelAll.Name = "tpSelAll";
            this.tpSelAll.Padding = new System.Windows.Forms.Padding(3);
            this.tpSelAll.Size = new System.Drawing.Size(973, 506);
            this.tpSelAll.TabIndex = 3;
            this.tpSelAll.Text = "辅助表全表查询";
            this.tpSelAll.UseVisualStyleBackColor = true;
            // 
            // tbSAllMessage
            // 
            this.tbSAllMessage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSAllMessage.Location = new System.Drawing.Point(288, 399);
            this.tbSAllMessage.Multiline = true;
            this.tbSAllMessage.Name = "tbSAllMessage";
            this.tbSAllMessage.ReadOnly = true;
            this.tbSAllMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSAllMessage.Size = new System.Drawing.Size(679, 101);
            this.tbSAllMessage.TabIndex = 21;
            this.tbSAllMessage.Text = "消息窗口";
            // 
            // dataGridViewMain2
            // 
            this.dataGridViewMain2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMain2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewMain2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain2.Location = new System.Drawing.Point(288, 6);
            this.dataGridViewMain2.Name = "dataGridViewMain2";
            this.dataGridViewMain2.RowTemplate.Height = 23;
            this.dataGridViewMain2.Size = new System.Drawing.Size(679, 387);
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
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 494);
            this.panel1.TabIndex = 0;
            // 
            // btSAllReset
            // 
            this.btSAllReset.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSAllReset.Location = new System.Drawing.Point(154, 444);
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
            this.btSAllTable.Location = new System.Drawing.Point(48, 444);
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
            this.lblSAllOption.Location = new System.Drawing.Point(3, 22);
            this.lblSAllOption.Name = "lblSAllOption";
            this.lblSAllOption.Size = new System.Drawing.Size(77, 14);
            this.lblSAllOption.TabIndex = 6;
            this.lblSAllOption.Text = "选择表单：";
            // 
            // rbSAllPrescriptionFunction
            // 
            this.rbSAllPrescriptionFunction.AutoSize = true;
            this.rbSAllPrescriptionFunction.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSAllPrescriptionFunction.Location = new System.Drawing.Point(48, 324);
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
            this.rbSAllMedicinalSource.Location = new System.Drawing.Point(48, 261);
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
            this.rbSAllMedicinalPart.Location = new System.Drawing.Point(48, 198);
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
            this.rbSAllDrugProcessing.Location = new System.Drawing.Point(48, 135);
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
            this.rbSAllCuttingSpecification.Location = new System.Drawing.Point(48, 72);
            this.rbSAllCuttingSpecification.Name = "rbSAllCuttingSpecification";
            this.rbSAllCuttingSpecification.Size = new System.Drawing.Size(81, 18);
            this.rbSAllCuttingSpecification.TabIndex = 0;
            this.rbSAllCuttingSpecification.TabStop = true;
            this.rbSAllCuttingSpecification.Text = "切制规格";
            this.rbSAllCuttingSpecification.UseVisualStyleBackColor = true;
            this.rbSAllCuttingSpecification.CheckedChanged += new System.EventHandler(this.RbSAllOption_CheckedChanged);
            // 
            // dataSetMedSel
            // 
            this.dataSetMedSel.DataSetName = "DataSetMedSel";
            // 
            // dataSetSAll
            // 
            this.dataSetSAll.DataSetName = "DataSetSAll";
            // 
            // dataSetPreSel
            // 
            this.dataSetPreSel.DataSetName = "dataSetPreSel";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 556);
            this.Controls.Add(this.tabCtrlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中医药数据库查询";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabCtrlMain.ResumeLayout(false);
            this.tpMedSelect.ResumeLayout(false);
            this.tpMedSelect.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain0)).EndInit();
            this.tpPreSelect.ResumeLayout(false);
            this.tpPreSelect.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain4)).EndInit();
            this.tpSelAll.ResumeLayout(false);
            this.tpSelAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMedSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPreSel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabCtrlMain;
        private System.Windows.Forms.TabPage tpMedSelect;
        private System.Windows.Forms.TextBox tbSelMedMessage;
        private System.Data.DataSet dataSetMedSel;
        private System.Windows.Forms.DataGridView dataGridViewMain0;
        private System.Windows.Forms.Button btSelMed;
        private System.Windows.Forms.TextBox tbSelMed;
        private System.Windows.Forms.DataGridView dataGridViewMain1;
        private System.Windows.Forms.Button btMedReset;
        private System.Windows.Forms.TabPage tpSelAll;
        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.TabPage tpPreSelect;
        private System.Windows.Forms.Button btSelPreReset;
        private System.Windows.Forms.DataGridView dataGridViewMain3;
        private System.Windows.Forms.Button btSelPre;
        private System.Windows.Forms.DataGridView dataGridViewMain4;
        private System.Windows.Forms.TextBox tbSelPreMessage;
        private System.Windows.Forms.TextBox tbSelPre;
        private System.Data.DataSet dataSetPreSel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbSelMedByCode;
        private System.Windows.Forms.RadioButton rbSelMedByName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbSelPreBySource;
        private System.Windows.Forms.RadioButton rbSelPreByFunction;
        private System.Windows.Forms.RadioButton rbSelPreByCode;
        private System.Windows.Forms.RadioButton rbSelPreByName;
    }
}