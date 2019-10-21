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
using TCMServerConstructionAuxiliary;

namespace 中医药数据库查询
{
    
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        SqlConnection tcmConnection;    //数据库的连接
        SqlDataAdapter tcmAdapter;      //适配器
        //SqlDataReader tcmReader;        //读取器
        SqlCommand command;             //数据库查询命令

        string currentUserName;         //当前用户的用户名
        string storedProcedureName;     //存储过程名

        //
        //连接到数据库。
        //
        public bool ConnectToServer(SqlConnectionStringBuilder scsb)
        {
            tcmConnection = new SqlConnection(scsb.ToString());
            try
            {
                if (tcmConnection.State == System.Data.ConnectionState.Closed)
                {
                    tcmConnection.Open();  //若连接未打开，则打开连接。
                    currentUserName = scsb.UserID;
                    if (scsb.IntegratedSecurity == true) currentUserName = "Administrator";
                    lblUid.Text = "当前用户：" + currentUserName;

                }

                if (tcmConnection.State == System.Data.ConnectionState.Open)
                {
                    return (true);
                }
                else return (false);
            }
            catch
            {
                return (false);
            }
        }

        //
        //在关闭窗体时断开数据库连接并解除占用。
        //
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcmConnection.Close();
            tcmConnection.Dispose();
        }


        #region 查询药物信息

        //
        //通过药物名称查询药物信息。
        //
        private void BtSelMed_Click(object sender, EventArgs e)
        {
            tbSelMedName.Enabled = false;
            try
            {
                dataGridViewMain0.DataSource = dataGridViewMain1.DataSource = null;
                dataSetMedSel.Dispose();
                storedProcedureName = "Select_Medicine_By_Name";
                command = new SqlCommand(storedProcedureName, tcmConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@input", SqlDbType.VarChar, 48).Value = tbSelMedName.Text;
                tcmAdapter = new SqlDataAdapter(command);
                dataSetMedSel = new DataSet();
                tcmAdapter.Fill(dataSetMedSel);
                dataGridViewMain0.DataSource = dataSetMedSel.Tables[0];       //显示品名匹配表。
                if (dataSetMedSel.Tables.Count > 1)
                {
                    dataGridViewMain1.DataSource = dataSetMedSel.Tables[1];   //若返回的结果集数量大于1，则显示别名匹配表。
                }


                tcmAdapter.Dispose();
                if (tbSelMedName.Text != "")
                {
                    tbSelMedMessage.Text = String.Format("“{0}”关键字药物检索完成。", tbSelMedName.Text);
                }
                else
                {
                    tbSelMedMessage.Text = ("药物全信息检索完成。");
                }
            }
            catch (Exception exc)
            {
                tbSelMedMessage.Text = String.Format("错误！\r\n{0}", exc);

            }
            finally
            {
                tbSelMedName.Enabled = true;
            }
        }

        //
        //重置查询结果表单信息。
        //
        private void BtSelReset_Click(object sender, EventArgs e)
        {
            tbSelMedName.Clear();
            tbSelMedMessage.Text = "消息窗口";
            dataGridViewMain0.DataSource = dataGridViewMain1.DataSource = null;
            dataSetMedSel.Clear();
        }

        #endregion


        #region 插入药物信息

        bool checkInsMedCode;              //待插入表中的中药代码是否匹配

        //
        //文本框的可用性，用于在运行数据库语句期间对文本框进行冻结。
        //
        private bool InsertMedTextboxStatus
        {
            set
            {
                tbInsTCMCode.Enabled
                = tbInsSerialNumber.Enabled
                = tbInsCommodityName.Enabled
                = tbInsMedicinalMaterialName.Enabled
                = tbInsSourceArea.Enabled
                = tbInsRemark.Enabled
                = tbInsIllustration.Enabled
                = tbInsMedicineAlias.Enabled = value;
            }
        }

        //
        //对药物代码的校验情况做出响应。
        //
        private void TbInsTCMCode_Leave(object sender, EventArgs e)
        {
            checkInsMedCode = InputCheck.CheckCodeVerification(tbInsTCMCode.Text) && tbInsTCMCode.Text.Length == 17;
            if (checkInsMedCode)
            {
                lblMedInsCheckCode.ForeColor = Color.Black;
                lblMedInsCheckCode.Text = "校验通过。";
                btInsMed.Enabled = true;
            }
            else if (tbInsTCMCode.Text == "")
            {
                lblMedInsCheckCode.ForeColor = Color.Black;
                lblMedInsCheckCode.Text = "请输入药物代码。";
                btInsMed.Enabled = false;
            }
            else
            {
                lblMedInsCheckCode.ForeColor = Color.Red;
                lblMedInsCheckCode.Text = "校验不通过！";
                btInsMed.Enabled = false;
            }
        }

        //
        //重置录入内容。
        //
        private void BtInsReset_Click(object sender, EventArgs e)
        {
            tbInsTCMCode.Clear();
            tbInsSerialNumber.Clear();
            tbInsCommodityName.Clear();
            tbInsMedicinalMaterialName.Clear();
            tbInsSourceArea.Clear();
            tbInsRemark.Clear();
            tbInsIllustration.Clear();
            tbInsMedicineAlias.Clear();
            tbInsMessage.Clear();
            btInsMed.Enabled = false;
            lblMedInsCheckCode.ForeColor = Color.Black;
            lblMedInsCheckCode.Text = "请输入药物代码。";
        }

        //
        //如若炮炙方法为00，则药材名等同品名。
        //
        private void TbCommodityName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (checkInsMedCode && tbInsTCMCode.Text.Substring(14, 2) == "00")
                    tbInsMedicinalMaterialName.Text = tbInsCommodityName.Text;
            }
            catch
            {
                return;
            }
        }

        //
        //将药物信息和药物别名信息插入表中。
        //
        private void BtInsMed_Click(object sender, EventArgs e)
        {
            if (tbInsMedicineAlias.Text == "")
            {
                if (MessageBox.Show("你确定这味药物没有别名吗？", "录入确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                {
                    return;
                }
            }
            InsertMedTextboxStatus = false;
            tbInsMessage.Clear();
            if (!checkInsMedCode || tbInsCommodityName.Text == "" || tbInsSerialNumber.Text.Length != 5 || (tbInsRemark.Text != "A" && tbInsRemark.Text != "B"))
            {
                tbInsMessage.Text = "录入操作不可用！";
                btInsMed.Enabled = false;
                InsertMedTextboxStatus = true;
                return;
            }
            int recordsAffected;

            /****一、药物表单（Medicine）录入****/
            storedProcedureName = "Insert_Medicine_Information";
            try
            {
                command = new SqlCommand(storedProcedureName, tcmConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@TCM_Code", SqlDbType.Char, 17).Value = tbInsTCMCode.Text;                                  //中药代码
                command.Parameters.Add("@Serial_Num", SqlDbType.Char, 5).Value = tbInsSerialNumber.Text;                               //顺序号
                command.Parameters.Add("@Commodity_Name", SqlDbType.VarChar, 50).Value = tbInsCommodityName.Text;                      //品名
                command.Parameters.Add("@MedicinalMaterialName", SqlDbType.VarChar, 50).Value = tbInsMedicinalMaterialName.Text;      //药材名
                if (tbInsSourceArea.Text != "")                //若“原产地”不为空，则添加“原产地”参数。
                    command.Parameters.Add("@SourceArea", SqlDbType.VarChar, 20).Value = tbInsSourceArea.Text;                         //原产地
                command.Parameters.Add("@Remark", SqlDbType.Char, 1).Value = tbInsRemark.Text;                                         //备注
                if (tbInsIllustration.Text != "")              //若“说明”不为空，则添加“说明”参数。
                    command.Parameters.AddWithValue("@Illustration", tbInsIllustration.Text);                                         //说明
                command.Parameters.AddWithValue("@DataConstructer", currentUserName);                                               //数据建设者
                recordsAffected = command.ExecuteNonQuery();
                command.Dispose();
                tbInsMessage.Text += String.Format(@"已向“药物信息”表单插入数据，{0}行受影响：
药物代码：{1}
顺序号：{2}
品名：{3}
药材名：{4}
原产地：{5}
备注：{6}

", recordsAffected, tbInsTCMCode.Text, tbInsSerialNumber.Text, tbInsCommodityName.Text, tbInsMedicinalMaterialName.Text, tbInsSourceArea.Text, tbInsRemark.Text);

            }
            catch (Exception exc)
            {
                tbInsMessage.Text += String.Format("“药物信息”表单插入数据出错：\r\n{0}", exc);
                InsertMedTextboxStatus = true;
                return;
            }
            /***********/

            if (tbInsMedicineAlias.Text == "")             //若药物别名未添加，则插入操作结束。
            {
                tbInsTCMCode.Clear();
                tbInsSerialNumber.Clear();
                tbInsCommodityName.Clear();
                tbInsMedicinalMaterialName.Clear();
                tbInsSourceArea.Clear();
                tbInsRemark.Clear();
                tbInsIllustration.Clear();
                tbInsMedicineAlias.Clear();
                InsertMedTextboxStatus = true;
                btInsMed.Enabled = false;
                lblMedInsCheckCode.Text = "请输入药物代码。";
                return;
            }

            /****二、药物别名表单（Medicine_Alias）录入****/
            recordsAffected = 0;
            storedProcedureName = "Insert_Medicine_Alias";
            try
            {
                foreach (string medAlias in tbInsMedicineAlias.Lines)               //获取文本框中的一行内容。
                {
                    if (medAlias.Length > 1)                                     //若该行有字符，则将字符内容录入。
                    {
                        command = new SqlCommand(storedProcedureName, tcmConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        command.Parameters.AddWithValue("@TCM_Code", tbInsTCMCode.Text);
                        command.Parameters.AddWithValue("@Medicine_Alias_Name", medAlias);
                        recordsAffected += command.ExecuteNonQuery();
                        command.Dispose();
                    }
                }
                tbInsMessage.Text += String.Format(@"已向“药物别名”表单插入数据，{0}行受影响：
{1}", recordsAffected, tbInsMedicineAlias.Text);
            }
            catch (Exception exc)
            {
                tbInsMessage.Text += String.Format("“药物别名”表单插入数据出错：\n{0}", exc);
                InsertMedTextboxStatus = true;
                return;
            }
            /***********/

            tbInsTCMCode.Clear();
            tbInsSerialNumber.Clear();
            tbInsCommodityName.Clear();
            tbInsMedicinalMaterialName.Clear();
            tbInsSourceArea.Clear();
            tbInsRemark.Clear();
            tbInsIllustration.Clear();
            tbInsMedicineAlias.Clear();
            InsertMedTextboxStatus = true;
            btInsMed.Enabled = false;
            lblMedInsCheckCode.Text = "请输入药物代码。";
        }

        #endregion


        #region 删除药物信息

        bool checkDelMedCode;

        //
        //对待删除的药物代码的校验情况做出响应。
        //
        private void BtDelMed_Enabled_Check_Manual(object sender, EventArgs e)
        {
            checkDelMedCode = InputCheck.CheckCodeVerification(tbDelTCMCode.Text)
                && (tbDelTCMCode.Text.Length == 17);

            if (checkDelMedCode)
            {
                lblDelCheckCode.ForeColor = Color.Black;
                lblDelCheckCode.Text = "校验通过。";
                if (cbDelMedConfirm.Checked) btDelMed.Enabled = true;
                else btDelMed.Enabled = false;
            }
            else if (tbDelTCMCode.Text == "")
            {
                lblDelCheckCode.ForeColor = Color.Black;
                lblDelCheckCode.Text = "请输入药物代码。";
                btDelMed.Enabled = false;
            }
            else
            {
                lblDelCheckCode.ForeColor = Color.Red;
                lblDelCheckCode.Text = "校验不通过！";
                btDelMed.Enabled = false;
            }
        }

        //
        //从数据库中删除对应记录。
        //
        private void BtDelMed_Click(object sender, EventArgs e)
        {
            tbDelTCMCode.Enabled = cbDelMedConfirm.Enabled = false;
            if (!checkDelMedCode)
            {
                tbDelTCMCode.Enabled = cbDelMedConfirm.Enabled = true;
                return;
            }
            int recordsAffected;
            storedProcedureName = "Delete_Medicine_Records";
            command = new SqlCommand(storedProcedureName, tcmConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("@TCM_Code", SqlDbType.Char, 17).Value = tbDelTCMCode.Text;

            try
            {
                recordsAffected = command.ExecuteNonQuery();
                if (recordsAffected > 0)
                {
                    tbDelMedMessage.Text = "已删除对应记录！";
                }
                else
                {
                    tbDelMedMessage.Text = "未找到需删除的记录。";
                }
                cbDelMedConfirm.Checked = false;
            }
            catch (Exception exc)
            {
                tbDelMedMessage.Text += String.Format("删除数据出错：\n{0}", exc);
            }

            tbDelTCMCode.Enabled = cbDelMedConfirm.Enabled = true;
        }

        //
        //重置“药物信息删除”标签页。
        //
        private void BtDelReset_Click(object sender, EventArgs e)
        {
            btDelMed.Enabled = false;
            tbDelTCMCode.Clear();
            cbDelMedConfirm.Checked = false;
            tbDelMedMessage.Text = "消息窗口";
            lblDelCheckCode.ForeColor = Color.Black;
            lblDelCheckCode.Text = "请输入药物代码。";
        }

        #endregion


        #region 查全表

        //
        //当“查全表”标签页中有选项选中时，查询按钮被激活。
        //
        private void RbSAllOption_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSAllCuttingSpecification.Checked
                || rbSAllDrugProcessing.Checked
                || rbSAllMedicinalPart.Checked
                || rbSAllMedicinalSource.Checked
                || rbSAllMedicine.Checked
                || rbSAllPrescriptionFunction.Checked)
            {
                btSAllTable.Enabled = true;
            }
            else btSAllTable.Enabled = false;
        }

        //
        //查询全表数据。
        //
        private void BtSAllTable_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewMain2.DataSource = null;
                dataSetSAll.Dispose();
                storedProcedureName = "Select_All_";
                if (rbSAllCuttingSpecification.Checked) storedProcedureName += "CuttingSpecification";
                else if (rbSAllDrugProcessing.Checked) storedProcedureName += "DrugProcessing";
                else if (rbSAllMedicinalPart.Checked) storedProcedureName += "MedicinalPart";
                else if (rbSAllMedicinalSource.Checked) storedProcedureName += "MedicinalSource";
                else if (rbSAllMedicine.Checked) storedProcedureName += "Medicine";
                else if (rbSAllPrescriptionFunction.Checked) storedProcedureName += "PrescriptionFunction";
                else return;
                command = new SqlCommand(storedProcedureName, tcmConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                tcmAdapter = new SqlDataAdapter(command);
                dataSetSAll = new DataSet();
                tcmAdapter.Fill(dataSetSAll);
                dataGridViewMain2.DataSource = dataSetSAll.Tables[0];
                tbSAllMessage.Text = "检索完成。";
            }
            catch (Exception exc)
            {
                tbSAllMessage.Text = String.Format("检索出错！\r\n{0}", exc);
            }
            finally
            {
                tcmAdapter.Dispose();
            }
        }

        //
        //重置标签页状态。
        //
        private void BtSAllReset_Click(object sender, EventArgs e)
        {
            rbSAllCuttingSpecification.Checked
                = rbSAllDrugProcessing.Checked
                = rbSAllMedicinalPart.Checked
                = rbSAllMedicinalSource.Checked
                = rbSAllMedicine.Checked
                = rbSAllPrescriptionFunction.Checked = false;
            dataGridViewMain2.DataSource = null;
            dataSetSAll.Clear();
            tbSAllMessage.Text = "消息窗口";
        }


        #endregion


        #region 方剂信息查询

        //
        //方剂信息查询。
        //
        private void BtSelPre_Click(object sender, EventArgs e)
        {
            tbSelPreName.Enabled = false;
            try
            {
                dataGridViewMain4.DataSource = dataGridViewMain3.DataSource = null;
                dataSetPreSel.Dispose();
                storedProcedureName = "Select_Prescription_By_Name";
                command = new SqlCommand(storedProcedureName, tcmConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@input", SqlDbType.VarChar, 48).Value = tbSelPreName.Text;
                tcmAdapter = new SqlDataAdapter(command);
                dataSetPreSel = new DataSet();
                tcmAdapter.Fill(dataSetPreSel);
                dataGridViewMain3.DataSource = dataSetPreSel.Tables[0];       //显示方剂名称匹配表。
                if (dataSetPreSel.Tables.Count > 1)
                {
                    dataGridViewMain4.DataSource = dataSetPreSel.Tables[1];   //数据库暂无此功能。
                }
                tcmAdapter.Dispose();
                if (tbSelPreName.Text != "")
                {
                    tbSelPreMessage.Text = String.Format("“{0}”关键字方剂检索完成。", tbSelPreName.Text);
                }
                else
                {
                    tbSelPreMessage.Text = ("方剂基本信息检索完成。");
                }
            }
            catch (Exception exc)
            {
                tbSelPreMessage.Text = String.Format("错误！\r\n{0}", exc);

            }
            finally
            {
                tbSelPreName.Enabled = true;
            }
        }

        //
        //重置查询结果表单信息。
        //
        private void BtSelPreReset_Click(object sender, EventArgs e)
        {
            tbSelPreName.Clear();
            tbSelPreMessage.Text = "消息窗口";
            dataGridViewMain3.DataSource = dataGridViewMain4.DataSource = null;
            dataSetPreSel.Clear();
        }

        #endregion


        #region 插入方剂信息

        bool checkInsPreCode;       //待插入表中的方剂代码是否匹配。
        int handleTextCount = 0;    //记录处理文本的次数，每点击一次“处理文本”则加一，每点击“录入”则归零。

        //
        //文本框的可用性，用于在运行数据库语句期间对文本框进行冻结。
        //
        private bool InsertPreTextboxStatus
        {
            set
            {
                tbInsPreCode.Enabled
                    = tbPreName.Enabled
                    = tbPreSource.Enabled
                    = tbEfficacy.Enabled
                    = tbIndication.Enabled
                    = tbInsPreIllustration.Enabled
                    = dataGridViewPrescriptionAlias.Enabled
                    = tbInsPreCompatibility.Enabled = value;
            }
        }

        //
        //对方剂代码的校验情况进行响应。
        //
        private void TbInsPreCode_Leave(object sender, EventArgs e)
        {
            checkInsPreCode = InputCheck.CheckCodeVerification(tbInsPreCode.Text) && tbInsPreCode.Text.Length == 10;
            if (checkInsPreCode)
            {
                lblPreInsCheckCode.ForeColor = Color.Black;
                lblPreInsCheckCode.Text = "校验通过。";
                btInsPre.Enabled = true;
            }
            else if (tbInsTCMCode.Text == "")
            {
                lblPreInsCheckCode.ForeColor = Color.Black;
                lblPreInsCheckCode.Text = "请输入方剂代码。";
                btInsPre.Enabled = false;
            }
            else
            {
                lblPreInsCheckCode.ForeColor = Color.Red;
                lblPreInsCheckCode.Text = "校验不通过！";
                btInsPre.Enabled = false;
            }
        }

        //
        //向表中插入方剂基本信息、方剂别名信息和方剂配伍信息。
        //
        private void BtInsPre_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrescriptionAlias.Rows.Count == 0)
            {
                if (MessageBox.Show("你确定该方剂没有别名吗？", "录入确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                {
                    return;
                }
            }
            InsertPreTextboxStatus = false;
            tbInsPreMessage.Clear();
            if (!checkInsPreCode || tbPreName.Text == "" || tbPreSource.Text == "" || tbInsPreCompatibility.Text == "" || handleTextCount < 1)
            {
                tbInsPreMessage.Text = "录入操作不可用！";
                InsertPreTextboxStatus = true;
                return;
            }
            int recordsAffected;
            handleTextCount = 0;

            /***方剂基本信息（Prescription）录入***/
            storedProcedureName = "Insert_Prescription_Information";
            try
            {
                command = new SqlCommand(storedProcedureName, tcmConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Prescription_Code", tbInsPreCode.Text);	            //方剂代码
                command.Parameters.AddWithValue("@Prescription_Name", tbPreName.Text);                  //方剂名
                command.Parameters.AddWithValue("@Prescription_Source", tbPreSource.Text);      		//方剂来源
                if (tbEfficacy.Text != "")                //若“功效”不为空，则添加“功效”参数。
                    command.Parameters.AddWithValue("@Efficacy", tbEfficacy.Text);                  	//功效
                if (tbIndication.Text != "")              //若“主治”不为空，则添加“主治”参数。
                    command.Parameters.AddWithValue("@Indication", tbIndication.Text);                  //主治
                if (tbInsPreIllustration.Text != "")      //若“说明”不为空，则添加“说明”参数。
                    command.Parameters.AddWithValue("@Illustration", tbInsPreIllustration.Text);        //说明
                command.Parameters.AddWithValue("@DataConstructer", currentUserName);                   //数据建设者
                recordsAffected = command.ExecuteNonQuery();
                command.Dispose();
                tbInsPreMessage.Text += String.Format(@"已向“方剂基本信息”表单插入数据，{0}行受影响：
方剂代码：{1}
方剂名称：{2}
来源：{3}
功效：{4}
主治：{5}
说明：{6}

", recordsAffected, tbInsPreCode.Text, tbPreName.Text, tbPreSource.Text, tbEfficacy.Text, tbIndication.Text, tbInsPreIllustration.Text);

            }
            catch (Exception exc)
            {
                tbInsPreMessage.Text += String.Format("“药物信息”表单插入数据出错：\r\n{0}", exc);
                InsertPreTextboxStatus = true;
                return;
            }


            /***方剂配伍表单（Prescription_Compatibility）录入***/
            recordsAffected = 0;
            storedProcedureName = "Insert_Prescription_Compatibility";
            try
            {
                foreach (string Commodity_Name in tbInsPreCompatibility.Lines)         //获取文本框中的一行内容。
                {
                    if (Commodity_Name.Length > 1)                                     //若该行有字符，则将字符内容录入。
                    {
                        command = new SqlCommand(storedProcedureName, tcmConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        command.Parameters.AddWithValue("@Prescription_Code", tbInsPreCode.Text);
                        command.Parameters.AddWithValue("@Commodity_Name", Commodity_Name);
                        recordsAffected += command.ExecuteNonQuery();
                        command.Dispose();
                    }
                }
                tbInsPreMessage.Text += String.Format(@"已向“方剂配伍”表单插入数据，{0}行受影响：
{1}", recordsAffected, tbInsPreCompatibility.Text);
            }
            catch (Exception exc)
            {
                tbInsPreMessage.Text += String.Format("“方剂配伍”表单插入数据出错：\n{0}", exc);
                InsertPreTextboxStatus = true;
                return;
            }


            /***方剂别名表单（Prescription_Alias）录入***/
            if (dataGridViewPrescriptionAlias.Rows.Count == 0)      //若没有别名信息，则录入过程结束。
            {
                tbInsPreCode.Clear();
                tbPreName.Clear();
                tbPreSource.Clear();
                tbEfficacy.Clear();
                tbIndication.Clear();
                tbInsPreIllustration.Clear();
                tbInsPreCompatibility.Clear();
                InsertPreTextboxStatus = true;
                btInsPre.Enabled = false;
                return;
            }

            recordsAffected = 0;
            try
            {
                storedProcedureName = "Insert_Prescription_Alias";
                int aliasCount = dataGridViewPrescriptionAlias.Rows.Count;
                for (int i = 0; i < aliasCount; i++)
                {
                    if (dataGridViewPrescriptionAlias[0, i].Value != null)
                    {
                        command = new SqlCommand(storedProcedureName, tcmConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        command.Parameters.AddWithValue("@Prescription_Code", tbInsPreCode.Text);
                        command.Parameters.AddWithValue("@PrescriptionAlias_Name", dataGridViewPrescriptionAlias[0, i].Value.ToString());
                        if (dataGridViewPrescriptionAlias[1, i].Value != null)
                            command.Parameters.AddWithValue("@PrescriptionAlias_Source", dataGridViewPrescriptionAlias[1, i].Value.ToString());
                        if (dataGridViewPrescriptionAlias[2, i].Value != null)
                            command.Parameters.AddWithValue("@illustration", dataGridViewPrescriptionAlias[2, i].Value.ToString());
                        recordsAffected += command.ExecuteNonQuery();
                        command.Dispose();
                    }
                }
                tbInsPreMessage.Text += String.Format(@"

已向“方剂别名”表单插入数据，{0}行受影响。", recordsAffected);
            }
            catch(Exception exc)
            {
                tbInsPreMessage.Text += String.Format(@"

“方剂别名”表单插入数据出错：\n{0}", exc);
                InsertPreTextboxStatus = true;
                return;
            }

            /**************/

            tbInsPreCode.Clear();
            tbPreName.Clear();
            tbPreSource.Clear();
            tbEfficacy.Clear();
            tbIndication.Clear();
            tbInsPreIllustration.Clear();
            tbInsPreCompatibility.Clear();
            dataGridViewPrescriptionAlias.Rows.Clear();
            lblPreInsCheckCode.Text = "请输入方剂代码。";
            InsertPreTextboxStatus = true;
            btInsPre.Enabled = false;
        }

        //
        //重置录入内容。
        //
        private void BtInsPreReset_Click(object sender, EventArgs e)
        {
            tbInsPreCode.Clear();
            tbPreName.Clear();
            tbPreSource.Clear();
            tbEfficacy.Clear();
            tbIndication.Clear();
            tbInsPreIllustration.Clear();
            tbInsPreCompatibility.Clear();
            dataGridViewPrescriptionAlias.Rows.Clear();
            tbInsPreMessage.Text = "消息窗口";
            lblPreInsCheckCode.ForeColor = Color.Black;
            lblPreInsCheckCode.Text = "请输入方剂代码。";
            InsertPreTextboxStatus = true;
            btInsPre.Enabled = false;
        }

        //
        //一键处理文本格式。
        //
        private void BtSelPreHandlingText_Click(object sender, EventArgs e)
        {
            /***处理换行***/
            tbPreName.Text = tbPreName.Text.Replace("\r\n", "");
            tbPreSource.Text = tbPreSource.Text.Replace("\r\n", "");
            tbEfficacy.Text = tbEfficacy.Text.Replace("\r\n", "");
            tbIndication.Text = tbIndication.Text.Replace("\r\n", "");
            tbInsPreIllustration.Text = tbInsPreIllustration.Text.Replace("\r\n", "");

            /***处理英文逗号***/
            tbPreName.Text = tbPreName.Text.Replace(',', '，');
            tbEfficacy.Text = tbEfficacy.Text.Replace(',', '，');
            tbIndication.Text = tbIndication.Text.Replace(',', '，');
            tbInsPreIllustration.Text = tbInsPreIllustration.Text.Replace(',', '，');

            /***处理英文分号***/
            tbEfficacy.Text = tbEfficacy.Text.Replace(';', '；');
            tbIndication.Text = tbIndication.Text.Replace(';', '；');
            tbInsPreIllustration.Text = tbInsPreIllustration.Text.Replace(';', '；');

            /***处理无意义空格***/
            tbPreName.Text = tbPreName.Text.Replace(" ", "");
            tbPreSource.Text = tbPreSource.Text.Replace(" ", "");
            tbEfficacy.Text = tbEfficacy.Text.Replace(" ", "");
            tbIndication.Text = tbIndication.Text.Replace(" ", "");
            tbInsPreIllustration.Text = tbInsPreIllustration.Text.Replace(" ", "");

            /***处理英文括号***/
            tbPreName.Text = tbPreName.Text.Replace("(", "（").Replace(")", "）");
            tbPreSource.Text = tbPreSource.Text.Replace("(", "（").Replace(")", "）");
            tbEfficacy.Text = tbEfficacy.Text.Replace("(", "（").Replace(")", "）");
            tbIndication.Text = tbIndication.Text.Replace("(", "（").Replace(")", "）");
            tbInsPreIllustration.Text = tbInsPreIllustration.Text.Replace("(", "（").Replace(")", "）");

            /***处理英文句号***/
            tbPreName.Text = tbPreName.Text.Replace(".", "");
            tbEfficacy.Text = tbEfficacy.Text.Replace(".", "");
            tbIndication.Text = tbIndication.Text.Replace(".", "");
            tbInsPreIllustration.Text = tbInsPreIllustration.Text.Replace(".", "");

            /***处理书名号***/
            tbPreSource.Text = tbPreSource.Text.Replace("《", "");
            tbPreSource.Text = tbPreSource.Text.Replace("》", "");

            /***句尾加上中文句号***/
            if (tbEfficacy.Text.Length > 0 && tbEfficacy.Text.Substring(tbEfficacy.Text.Length - 1, 1) != "。") tbEfficacy.Text += "。";
            if (tbIndication.Text.Length > 0 && tbIndication.Text.Substring(tbIndication.Text.Length - 1, 1) != "。") tbIndication.Text += "。";
            if (tbInsPreIllustration.Text.Length > 0 && tbInsPreIllustration.Text.Substring(tbInsPreIllustration.Text.Length - 1, 1) != "。") tbInsPreIllustration.Text += "。";

            /***处理方剂别名DataGridView中文字***/
            int aliasCount = dataGridViewPrescriptionAlias.Rows.Count;
            for (int i = 0; i < aliasCount; i++)
            {
                if (dataGridViewPrescriptionAlias[0, i].Value != null)
                {
                    if (dataGridViewPrescriptionAlias[0, i].Value != null)
                        dataGridViewPrescriptionAlias[0, i].Value = dataGridViewPrescriptionAlias[0, i].Value.ToString().Replace(" ", "").Replace("\r\n", "").Replace("《", "").Replace("》", "").Replace("“", "").Replace("”", "").Replace("(", "").Replace(")", "");
                    if (dataGridViewPrescriptionAlias[1, i].Value != null)
                        dataGridViewPrescriptionAlias[1, i].Value = dataGridViewPrescriptionAlias[1, i].Value.ToString().Replace(" ", "").Replace("\r\n", "").Replace("《", "").Replace("》", "").Replace("“", "").Replace("”", "").Replace("(", "").Replace(")", "");
                    if (dataGridViewPrescriptionAlias[2, i].Value != null)
                        dataGridViewPrescriptionAlias[2, i].Value = dataGridViewPrescriptionAlias[2, i].Value.ToString().Replace(" ", "").Replace("\r\n", "").Replace("“", "").Replace("”", "").Replace("(", "").Replace(")", "");
                }
            }

            handleTextCount++;   //文本处理次数加一。
        }

        #endregion


        #region 删除方剂信息
        bool checkDelPreCode;

        //
        //对待删除的方剂代码的校验情况做出响应。
        //
        private void BtDelPre_Enabled_Check_Manual(object sender, EventArgs e)
        {
            checkDelPreCode = InputCheck.CheckCodeVerification(tbDelPreCode.Text)
                && (tbDelPreCode.Text.Length == 10);

            if (checkDelPreCode)
            {
                lblDelPreCheckCode.ForeColor = Color.Black;
                lblDelPreCheckCode.Text = "校验通过。";
                if (cbDelPreConfirm.Checked) btDelPre.Enabled = true;
                else btDelPre.Enabled = false;
            }
            else if (tbDelPreCode.Text == "")
            {
                lblDelPreCheckCode.ForeColor = Color.Black;
                lblDelPreCheckCode.Text = "请输入方剂代码。";
                btDelPre.Enabled = false;
            }
            else
            {
                lblDelPreCheckCode.ForeColor = Color.Red;
                lblDelPreCheckCode.Text = "校验不通过！";
                btDelPre.Enabled = false;
            }
        }

        //
        //从数据库中删除对应方剂信息。
        //
        private void BtDelPre_Click(object sender, EventArgs e)
        {
            tbDelPreCode.Enabled = cbDelPreConfirm.Enabled = false;
            if (!checkDelPreCode)
            {
                tbDelPreCode.Enabled = cbDelPreConfirm.Enabled = true;
                return;
            }
            int recordsAffected;
            storedProcedureName = "Delete_Prescription_Records";
            command = new SqlCommand(storedProcedureName, tcmConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Prescription_Code", tbDelPreCode.Text);

            try
            {
                recordsAffected = command.ExecuteNonQuery();
                if (recordsAffected > 0)
                {
                    tbDelPreMessage.Text = "已删除对应记录！";
                }
                else
                {
                    tbDelPreMessage.Text = "未找到需删除的记录。";
                }
                cbDelPreConfirm.Checked = false;
            }
            catch (Exception exc)
            {
                tbDelPreMessage.Text += String.Format("删除数据出错：\n{0}", exc);
            }

            tbDelPreCode.Enabled = cbDelPreConfirm.Enabled = true;
        }

        //
        //重置“方剂信息标签页”。
        //
        private void BtDelPreReset_Click(object sender, EventArgs e)
        {
            btDelPre.Enabled = false;
            tbDelPreCode.Clear();
            cbDelPreConfirm.Checked = false;
            tbDelPreMessage.Text = "消息窗口";
            lblDelPreCheckCode.ForeColor = Color.Black;
            lblDelPreCheckCode.Text = "请输入方剂代码。";
        }


        #endregion
    }
}
