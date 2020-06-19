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
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Data_textBox.DataBindings.Add("Text", this, "Request");
        }
        public delegate void getBack();
        public event getBack backToCata;//用于返回选择界面
        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            Console.WriteLine(this.Data_textBox.Text);
            FormMain formMain = new FormMain(Convert.ToInt32(this.Data_textBox.Text));
            formMain.backToCata += new FormMain.Transfer(backToCata);
            this.Hide();
            formMain.Show();
        }


        private void FormInit_FormClosing(object sender, FormClosingEventArgs e)
        {
            backToCata();
        }
    }
}
