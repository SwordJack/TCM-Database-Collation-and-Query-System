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

namespace Windows窗体访问中医药数据库
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

    
        /****查询****/

        //
        //通过药物名称查询药物信息。
        //
        private void BtSelMed_Click(object sender, EventArgs e)
        {
            tbSelMedName.Enabled = false;
            try
            {
                dataGridViewMain0.DataSource = dataGridViewMain1.DataSource = null;
                dataSetSel.Dispose();
                storedProcedureName = "Select_Medicine_By_Name";
                command = new SqlCommand(storedProcedureName, tcmConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@input", SqlDbType.VarChar, 20).Value = tbSelMedName.Text;
                tcmAdapter = new SqlDataAdapter(command);
                dataSetSel = new DataSet();
                tcmAdapter.Fill(dataSetSel);
                dataGridViewMain0.DataSource = dataSetSel.Tables[0];       //显示品名匹配表。
                if (dataSetSel.Tables.Count > 1)
                {
                    dataGridViewMain1.DataSource = dataSetSel.Tables[1];   //若返回的结果集数量大于1，则显示别名匹配表。
                }
                tcmAdapter.Dispose();
                if (tbSelMedName.Text != "")
                {
                    tbSelMessage.Text = String.Format("“{0}”关键字药物检索完成。", tbSelMedName.Text);
                }
                else
                {
                    tbSelMessage.Text = ("药物全信息检索完成。");
                }
            }
            catch (Exception exc)
            {
                tbSelMessage.Text = String.Format("错误！\r\n{0}", exc);

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
            tbSelMessage.Text = "消息窗口";
            dataGridViewMain0.DataSource = dataGridViewMain1.DataSource = null;
            dataSetSel.Clear();
        }

        /************/
    

        /****插入****/

        bool checkInsMedCode;              //待插入表中的中药代码是否匹配

        //
        //文本框的可用性，用于在运行数据库语句期间对文本框进行冻结。
        //
        private bool InsertTextboxStatus
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
                lblInsCheckCode.ForeColor = Color.Black;
                lblInsCheckCode.Text = "校验通过。";
                btInsMed.Enabled = true;
            }
            else if (tbInsTCMCode.Text == "")
            {
                lblInsCheckCode.ForeColor = Color.Black;
                lblInsCheckCode.Text = "请输入药物代码。";
                btInsMed.Enabled = false;
            }
            else
            {
                lblInsCheckCode.ForeColor = Color.Red;
                lblInsCheckCode.Text = "校验不通过！";
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
            lblInsCheckCode.ForeColor = Color.Black;
            lblInsCheckCode.Text = "请输入药物代码。";
        }

        //
        //如若切制规格为99，炮炙方法为00，则药材名等同品名。
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
            InsertTextboxStatus = false;
            tbInsMessage.Clear();
            if (!checkInsMedCode || tbInsCommodityName.Text == "" || tbInsSerialNumber.Text.Length != 5 || (tbInsRemark.Text != "A" && tbInsRemark.Text != "B"))
            {
                tbInsMessage.Text = "录入操作不可用！";
                btInsMed.Enabled = false;
                InsertTextboxStatus = true;
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
                InsertTextboxStatus = true;
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
                InsertTextboxStatus = true;
                btInsMed.Enabled = false;
                lblInsCheckCode.Text = "请输入药物代码。";
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
                InsertTextboxStatus = true;
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
            InsertTextboxStatus = true;
            btInsMed.Enabled = false;
            lblInsCheckCode.Text = "请输入药物代码。";
        }

        /************/
    

        /****删除****/

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
                if (cbDelConfirm.Checked) btDelMed.Enabled = true;
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
            tbDelTCMCode.Enabled = cbDelConfirm.Enabled = false;
            if (!checkDelMedCode)
            {
                tbDelTCMCode.Enabled = cbDelConfirm.Enabled = true;
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
                    tbDelMessage.Text = "已删除对应记录！";
                }
                else
                {
                    tbDelMessage.Text = "未找到需删除的记录。";
                }
                cbDelConfirm.Checked = false;
            }
            catch (Exception exc)
            {
                tbDelMessage.Text += String.Format("删除数据出错：\n{0}", exc);
            }

            tbDelTCMCode.Enabled = cbDelConfirm.Enabled = true;
        }

        //
        //重置“删除”标签页。
        //
        private void BtDelReset_Click(object sender, EventArgs e)
        {
            btDelMed.Enabled = false;
            tbDelTCMCode.Clear();
            cbDelConfirm.Checked = false;
            tbDelMessage.Text = "消息窗口";
            lblDelCheckCode.ForeColor = Color.Black;
            lblDelCheckCode.Text = "请输入药物代码。";
        }

        /************/
    

        /***查全表***/

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


        /************/
    }
}
