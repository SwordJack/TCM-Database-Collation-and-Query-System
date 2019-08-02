using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows窗体设计_测试_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            tbOutput.Clear();
            foreach(string i in tbInput.Lines)
            {
                tbOutput.Text += String.Format("{0}，", i);
            }
        }
    }
}
