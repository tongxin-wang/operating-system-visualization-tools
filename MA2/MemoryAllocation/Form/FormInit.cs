using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MemoryAllocation
{
    public partial class FormInit : Form
    {
       // public int Request { set; get; }
        public FormInit()
        {
            InitializeComponent();
            //this.Data_textBox.DataBindings.Add("Text", this, "Request");
        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            Console.WriteLine(this.Data_textBox.Text);
            new FormMain(Convert.ToInt32(this.Data_textBox.Text)).Show();
        }
    }
}
