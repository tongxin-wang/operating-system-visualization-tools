using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessorScheduling
{

    public partial class ProcessorMainForm : Form
    {
        

        public List<Process> InitialList = new List<Process>();
        int count = 0;
        
        public EventHandler BacktoMainForm
        {
            set => this.ucBtn_back.BtnClick += value;
        }
        public FormClosedEventHandler ClosetoMainForm
        {
            set => this.FormClosed += value;
        }
        public ProcessorMainForm()
        {
            InitializeComponent();
            //this.mw = mw;
            //初始化控件
            Font font = this.lab_pro.Font;
            this.lab_request.Font = font;
            this.lab_A.Font = font;
            this.lab_B.Font = font;
            this.lab_C.Font = font;
            this.lab_D.Font = font;
            this.label1.Font = font;
        }
        

        private void ucBtn_ok_BtnClick(object sender, EventArgs e)
        {
            Process A = new Process(lab_A.Text, (int)(ucTrackBarApro.Value), (int)(ucTrackBarArunTime.Value));
            Process B = new Process(lab_B.Text, (int)(ucTrackBarBpro.Value), (int)(ucTrackBarBrunTime.Value));
            Process C = new Process(lab_C.Text, (int)(ucTrackBarCpro.Value), (int)(ucTrackBarCrunTime.Value));
            Process D = new Process(lab_D.Text, (int)(ucTrackBarDpro.Value), (int)(ucTrackBarDrunTime.Value));

            if (count == 0)
            {
                //装入list中
                this.InitialList.Add(A);
                this.InitialList.Add(B);
                this.InitialList.Add(C);
                this.InitialList.Add(D);

                ProcessorWorkForm form2 = new ProcessorWorkForm(InitialList, this);

                form2.Show();
                this.Hide();
            }


            count = 0;
        }

        //导入XML文件信息
        private void ucBtn_import_BtnClick(object sender, EventArgs e)
        {
            ucTrackBarApro.Value = 9;
            ucTrackBarBpro.Value = 5;
            ucTrackBarCpro.Value = 3;
            ucTrackBarDpro.Value = 11;
            ucTrackBarArunTime.Value = 5;
            ucTrackBarBrunTime.Value = 2;
            ucTrackBarCrunTime.Value = 4;
            ucTrackBarDrunTime.Value = 3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //界面居中
            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
            (Screen.GetBounds(this).Height / 2) - (this.Height / 2),
            this.Width, this.Height, BoundsSpecified.Location);

            ucTrackBarArunTime.Value = 1;
            ucTrackBarBrunTime.Value = 1;
            ucTrackBarCrunTime.Value = 1;
            ucTrackBarDrunTime.Value = 1;
        }

        private void ucBtn_back_BtnClick(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            //mw.Show();
        }

        private void ProcessorMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //mw.Show();
        }
    }
}
