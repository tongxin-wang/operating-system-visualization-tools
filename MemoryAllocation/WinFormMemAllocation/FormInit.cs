using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoryAllocation;

namespace WinFormMemAllocation
{
    public partial class FormInit : Form
    {
        public int Request { set; get; }
        public FormInit()
        {
            InitializeComponent();
            this.Data_textBox.DataBindings.Add("Text", this, "Request");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormMain(Request).Show();
        }
    }
}
