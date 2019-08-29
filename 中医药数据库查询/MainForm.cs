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
            storedProcedureName = "";
            tbSelMed.Enabled = false;
            try
            {
                dataGridViewMain0.DataSource = dataGridViewMain1.DataSource = null;
                dataSetMedSel.Dispose();
                if (rbSelMedByName.Checked) storedProcedureName = "Select_Medicine_By_Name";        //选择存储过程名。
                else if (rbSelMedByCode.Checked) storedProcedureName = "Select_Medicine_By_Code";
                else return;
                command = new SqlCommand(storedProcedureName, tcmConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@input", SqlDbType.VarChar, 48).Value = tbSelMed.Text.Replace("\'", "");    //过滤单引号。
                tcmAdapter = new SqlDataAdapter(command);
                dataSetMedSel = new DataSet();
                tcmAdapter.Fill(dataSetMedSel);
                if (dataSetPreSel.Tables.Count > 0) dataGridViewMain0.DataSource = dataSetMedSel.Tables[0];       //显示第一张表。
                if (dataSetMedSel.Tables.Count > 1)
                {
                    dataGridViewMain1.DataSource = dataSetMedSel.Tables[1];   //若返回的结果集数量大于1，则显示第二张表。
                }
                tcmAdapter.Dispose();
                if (rbSelMedByName.Checked)
                {
                    if (tbSelMed.Text != "") tbSelMedMessage.Text = String.Format("“{0}”关键字药物检索完成。", tbSelMed.Text);
                    else tbSelMedMessage.Text = ("药物全信息检索完成。");
                }
                else if (rbSelMedByCode.Checked)
                {
                    if (tbSelMed.Text.Length == 17) tbSelMedMessage.Text = ("药物信息精确检索完成。");
                    else tbSelMedMessage.Text = ("代码长度不正确，检索无结果。");
                }
                command.Dispose();
            }
            catch (Exception exc)
            {
                tbSelMedMessage.Text = String.Format("错误！\r\n{0}", exc);
                command.Dispose();
            }
            finally
            {
                tbSelMed.Enabled = true;
            }
        }

        //
        //重置查询结果表单信息。
        //
        private void BtSelReset_Click(object sender, EventArgs e)
        {
            tbSelMed.Clear();
            tbSelMedMessage.Text = "消息窗口";
            dataGridViewMain0.DataSource = dataGridViewMain1.DataSource = null;
            dataSetMedSel.Clear();
            rbSelMedByCode.Checked = rbSelMedByName.Checked = false;
        }

        #endregion


        #region 方剂信息查询

        //
        //方剂信息查询。
        //
        private void BtSelPre_Click(object sender, EventArgs e)
        {
            tbSelPre.Enabled = false;
            storedProcedureName = "";
            try
            {
                dataGridViewMain4.DataSource = dataGridViewMain3.DataSource = null;
                dataSetPreSel.Dispose();
                if (rbSelPreByName.Checked)             //根据选项匹配存储过程名。
                    storedProcedureName = "Select_Prescription_By_Name";
                else if (rbSelPreByCode.Checked)
                    storedProcedureName = "Select_Prescription_By_Code";
                else if (rbSelPreByFunction.Checked)
                    storedProcedureName = "Select_Prescription_By_Function";
                else if (rbSelPreBySource.Checked)
                    storedProcedureName = "Select_Prescription_By_Source";
                else return;
                command = new SqlCommand(storedProcedureName, tcmConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@input", SqlDbType.VarChar, 48).Value = tbSelPre.Text.Replace("\'", "");    //过滤单引号。
                tcmAdapter = new SqlDataAdapter(command);
                dataSetPreSel = new DataSet();
                tcmAdapter.Fill(dataSetPreSel);
                if (dataSetPreSel.Tables.Count > 0) dataGridViewMain3.DataSource = dataSetPreSel.Tables[0];       //显示方剂名称匹配表。
                if (dataSetPreSel.Tables.Count > 1)
                {
                    dataGridViewMain4.DataSource = dataSetPreSel.Tables[1];   //若返回结果集数量大于1，则返回第2张表。
                }
                tcmAdapter.Dispose();
                if (rbSelPreByCode.Checked)
                {
                    if (tbSelPre.Text.Length == 10) tbSelPreMessage.Text = "方剂信息精确检索完成！";
                    else tbSelPreMessage.Text = "代码长度有误，检索无结果。";
                }
                else
                {
                    if (tbSelPre.Text != "")
                    {
                        tbSelPreMessage.Text = String.Format("“{0}”关键字方剂检索完成。", tbSelPre.Text);
                    }
                    else
                    {
                        tbSelPreMessage.Text = ("方剂基本信息检索完成。");
                    }
                    command.Dispose();
                }
            }
            catch (Exception exc)
            {
                tbSelPreMessage.Text = String.Format("错误！\r\n{0}", exc);
                command.Dispose();
            }
            finally
            {
                tbSelPre.Enabled = true;
            }
        }

        //
        //重置查询结果表单信息。
        //
        private void BtSelPreReset_Click(object sender, EventArgs e)
        {
            tbSelPre.Clear();
            tbSelPreMessage.Text = "消息窗口";
            dataGridViewMain3.DataSource = dataGridViewMain4.DataSource = null;
            dataSetPreSel.Clear();
            rbSelPreByCode.Checked = rbSelPreByFunction.Checked = rbSelPreByName.Checked = rbSelPreBySource.Checked = false;
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
                command.Dispose();
            }
            catch (Exception exc)
            {
                tbSAllMessage.Text = String.Format("检索出错！\r\n{0}", exc);
                command.Dispose();
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
                = rbSAllPrescriptionFunction.Checked = false;
            dataGridViewMain2.DataSource = null;
            dataSetSAll.Clear();
            tbSAllMessage.Text = "消息窗口";
        }


        #endregion

    }
}
