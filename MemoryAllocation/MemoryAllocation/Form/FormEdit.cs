using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HZH_Controls;


namespace MemoryAllocation
{
    public partial class FormEdit : Form
    {
        public int Modify { set; get; }
        public FormEdit()
        {
            InitializeComponent();
            this.textBoxEx1.DataBindings.Add("Text", this, "Modify");
        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
