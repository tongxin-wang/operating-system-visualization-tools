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
using WinFormMemAllocation;
using EX2;

namespace ProcesserScheduler
{
    public partial class MemoryChooseForm : Form
    {
        MainWindow mw;
        FormInit fi;
        EX2.Form1 f1;
        public MemoryChooseForm(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;

            //界面居中
            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
            (Screen.GetBounds(this).Height / 2) - (this.Height / 2),
            this.Width, this.Height, BoundsSpecified.Location);
        }

        
        private void ucBtn_back_BtnClick(object sender, EventArgs e)
        {
            this.Hide();
            mw.Show();
        }

        private void ucBtn_memoryFrom_BtnClick(object sender, EventArgs e)
        {
            fi = new FormInit();
            fi.Show();
            this.Hide();            
        }

        private void ucBtn_disk_BtnClick(object sender, EventArgs e)
        {
            f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
