using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EX2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Init();
        }

        const int N = 9;
        Label[] lblbefore;
        Label[] lblafter;
        int[] numbefore;
        int[] numafter;
        string[] busyStr;
        int[] busyFlag;
        string[] busyLen;

        int availCount = (N - 1) * (N - 1);
        int busyCount = 0;

        public void Init()
        {
            lblbefore = new Label[N * N];
            lblafter = new Label[N * N];
            numbefore = new int[N * N];
            numafter = new int[N * N];
            busyStr = new string[(N - 1) * (N - 1)];
            busyFlag = new int[(N - 1) * (N - 1)];
            busyLen = new string[(N - 1) * (N - 1)];

            int x0 = 10, y0 = 25, w = 20, d = w + 5;

            for (int i = 0; i < lblbefore.Length; i++)
            {
                Label lbl = new Label();
                numbefore[i] = 0;
                numafter[i] = 0;

                int r = i / N;  //行
                int c = i % N;  //列

                lbl.Left = x0 + c * d;
                lbl.Top = y0 + r * d;
                lbl.Width = w;
                lbl.Height = w;

                lbl.Text = "0";
                lbl.Visible = true;
                lblbefore[i] = lbl;
                this.panel1.Controls.Add(lbl);
            }

            lblbefore[0].Visible = false;
            numbefore[0] = -1;
            numafter[0] = -1;
            for(int i = 1; i < 9; i++)
            {
                lblbefore[i].Text = (i - 1).ToString();
                lblbefore[i].BackColor=Color.Yellow;
                numbefore[i] = -1;
                numafter[i] = -1;
            }
            for (int i = 1; i < 9; i++)
            {
                lblbefore[9 * i].Text = (i - 1).ToString();
                lblbefore[9 * i].BackColor = Color.Yellow;
                numbefore[9 * i] = -1;
                numafter[9 * i] = -1;
            }

            int x1 = 10, y1 = 25;

            for (int i = 0; i < lblafter.Length; i++)
            {
                Label lbl = new Label();
                
                int r = i / N;  //行
                int c = i % N;  //列

                lbl.Left = x1 + c * d;
                lbl.Top = y1 + r * d;
                lbl.Width = w;
                lbl.Height = w;

                lbl.Text = "0";
                lbl.Visible = true;
                lblafter[i] = lbl;
                this.panel2.Controls.Add(lbl);
            }

            lblafter[0].Visible = false;
            for (int i = 1; i < 9; i++)
            {
                lblafter[i].Text = (i - 1).ToString();
                lblafter[i].BackColor = Color.Yellow;
            }
            for (int i = 1; i < 9; i++)
            {
                lblafter[9 * i].Text = (i - 1).ToString();
                lblafter[9 * i].BackColor = Color.Yellow;
            }

            busyLen[0] = "文件序号\t文件长度";
            busyFlag[0] = 1;
            busyStr[0] = " ";
            listBox1.Items.Add(busyStr[0]);
        }

        public void Swap()
        {
            for(int i = 11; i < N * N; i++)
            {
                lblbefore[i].Text = lblafter[i].Text;
                numbefore[i] = numafter[i];
            }
        } 

        public void myPrintIn(int busyCount)
        {
            lblin.Text = "";
            lblin.Text = busyStr[busyCount];
            lblout.Text = "";

            listBox1.Items.Clear();
            for (int i = 0; i < (N - 1) * (N - 1); i++)
            {
                if (busyFlag[i] > 0)
                    listBox1.Items.Add(busyLen[i]);
            }           
        }

        public void myPrintOut(int busyCount)
        {
            lblout.Text = "";
            lblout.Text = busyStr[busyCount];
            lblin.Text = "";

            listBox1.Items.Clear();
            for (int i = 0; i < (N - 1) * (N - 1); i++)
            {
                if (busyFlag[i] > 0)
                    listBox1.Items.Add(busyLen[i]);
            }
        }

        public void blockIn()
        {
            int len = Convert.ToInt32(textBox1.Text);

            if (len > availCount || len < 1)
            {
                MessageBox.Show("装入块长度不符合要求！");
                return;
            }

            Swap();

            availCount = availCount - len;

            busyCount++;
            busyStr[busyCount] = "";
            busyFlag[busyCount] = 1;
            busyLen[busyCount] = " " + busyCount.ToString() + "\t\t" + len.ToString();

            int count = 0;
            for (int i = 10; i < (N * N) && len > count; i++)
            {
                if (numafter[i] == 0)
                {
                    int a, b, c;
                    a = i / 9 - 1;
                    b = (i - 9 * (a + 1) - 1) / 4;
                    c = (i - 9 * (a + 1) - 1) % 4;

                    count++;
                    lblafter[i].Text = 1.ToString();
                    numafter[i] = busyCount;

                    if (count % 5 == 0)
                        busyStr[busyCount] = busyStr[busyCount] + "(" + a.ToString() + "、" +
                        b.ToString() + "、" + c.ToString() + ")\n";
                    else
                        busyStr[busyCount] = busyStr[busyCount] + "(" + a.ToString() + "、" +
                            b.ToString() + "、" + c.ToString() + ")  ";
                }
            }

            myPrintIn(busyCount);
        }

        public void blockOut()
        {
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("未输入删除作业序号！");
            }

            int num = Convert.ToInt32(textBox2.Text);

            if (busyFlag[num] == 0)
                MessageBox.Show("作业序号已不在内存中！");

            Swap();

            busyFlag[num] = 0;
            busyLen[num] = "";
            busyStr[num] = "";

            int count = 0;
            for (int i = 10; i < (N * N); i++)
            {
                if (numafter[i] == num)
                {
                    count++;

                    int a, b;
                    a = i / 9 - 1;
                    b = (i - 9 * (a + 1) - 1);

                    numafter[i] = 0;
                    lblafter[i].Text = 0.ToString();

                    if (count % 5 == 0)
                        busyStr[num] = busyStr[num] + "(" + a.ToString()
                        + "、" + b.ToString() + ")\n";
                    else
                    busyStr[num] = busyStr[num] + "(" + a.ToString()
                        + "、" + b.ToString() + ")  ";
                }
            }
            availCount = availCount + count;

            myPrintOut(num);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            blockIn();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            blockOut();
        }
    }
}
