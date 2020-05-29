using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpAnimationTest1;


namespace ProcesserScheduler
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ucBtn_Processor_BtnClick(object sender, EventArgs e)
        {
            ProcessorMainForm PM = new ProcessorMainForm(this);
            this.Hide();
            PM.Show();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //界面居中
            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
            (Screen.GetBounds(this).Height / 2) - (this.Height / 2),
            this.Width, this.Height, BoundsSpecified.Location);
        }

        private void ucBtn_MemoryAllocation_BtnClick(object sender, EventArgs e)
        {
            MemoryChooseForm mc = new MemoryChooseForm(this);

            
            this.Hide();
            mc.Show();
        }

        private void ucBtn_BankerAlgorithm_BtnClick(object sender, EventArgs e)
        {
            CSharpAnimationTest1.FormBegin BankerForm = new FormBegin();
            this.Hide();
            BankerForm.Show();
        }
    }
}
