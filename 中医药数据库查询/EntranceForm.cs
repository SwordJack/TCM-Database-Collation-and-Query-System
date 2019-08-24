using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 中医药数据库查询
{
    public partial class EntranceForm : Form
    {
        public EntranceForm()
        {
            InitializeComponent();
        }

        private void TimerEntrance_Tick(object sender, EventArgs e)
        {
            timerEntrance.Enabled = false;
            this.Dispose();
        }

        private void EntranceForm_Load(object sender, EventArgs e)
        {
            timerEntrance.Enabled = true;
        }
    }
}
