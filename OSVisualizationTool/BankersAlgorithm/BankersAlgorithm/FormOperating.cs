using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankerAlgorithm
{
   
    public partial class FormOperating : Form
    {
        public delegate void TransfDelegate();
        public event TransfDelegate TransfEvent;
        private AlgorithmOperator basic;
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<Label> avaiLables = new List<Label>();
        public string name;
        public Resourse demand { set; get; }
        public void newStrInfo(string info)
        {
            listBox1.Items.Add(info);
        }
        void Withdraw(Process process, List<bool> map, Resourse a, int index)
        {
            SolidBrush fix_brush = new SolidBrush(Color.LightGreen);
            SolidBrush change_brush = new SolidBrush(Color.LightSalmon);
            SolidBrush warn_brush = new SolidBrush(Color.Red);
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            Rectangle rectangle2 = new Rectangle(150, 10, 100, 100);
            Rectangle rectangle3 = new Rectangle(290, 10, 100, 100);
            Resourse Max = process.Max;
            Resourse Allocation = process.Allocation;
            float angleA = Allocation.A * 360 / (Max.A == 0 ? 1 : Max.A);
            float angleB = Allocation.B * 360 / (Max.B == 0 ? 1 : Max.B);
            float angleC = Allocation.C * 360 / (Max.C == 0 ? 1 : Max.C);
            PictureBox pictureBox = pictureBoxes[index];
            //Graphics g = pictureBoxes[4 - i].CreateGraphics();
            Bitmap img = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = img;
            Graphics g = Graphics.FromImage(img);
            g.Clear(Color.White);
            //Graphics g = pictureBox.CreateGraphics();
            g.FillPie(fix_brush, rectangle1, 0, 360);
            g.FillPie(change_brush, rectangle1, -90, angleA);
            if (Max.A == 0)
                g.FillPie(change_brush, rectangle1, 0, 360);
            g.DrawString(Allocation.A.ToString() + "/" + Max.A.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle1.X + 30, 115);
            g.FillPie(fix_brush, rectangle2, 0, 360);
            g.FillPie(change_brush, rectangle2, -90, angleB);
            if (Max.B == 0)
                g.FillPie(change_brush, rectangle2, 0, 360);
            g.DrawString(Allocation.B.ToString() + "/" + Max.B.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle2.X + 30, 115);
            g.FillPie(fix_brush, rectangle3, 0, 360);
            g.FillPie(change_brush, rectangle3, -90, angleC);
            if (Max.C == 0)
                g.FillPie(change_brush, rectangle3, 0, 360);
            g.DrawString(Allocation.C.ToString() + "/" + Max.C.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle3.X + 30, 115);
            setAvailableLabel(a);
            drawFlag(index, map[index]);
        }
        void DrawWarn(int index, string word)
        {
            Graphics g = pictureBoxes[index].CreateGraphics();
            g.DrawString(word, new Font("华文楷体", 25), new SolidBrush(Color.DarkRed), new PointF(10, 30));
        }
        public void drawFlag(int index, bool flag)
        {
            Graphics g = pictureBoxes[index].CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, 45, 15));
            SolidBrush red_Brush = new SolidBrush(Color.Red);
            SolidBrush black_Brush = new SolidBrush(Color.Black);
            if (flag == true)
                g.DrawString("已完成", new Font("Arial", 10), red_Brush, new Point(0, 2));
            else
                g.DrawString("未完成", new Font("Arial", 10), black_Brush, new Point(0, 2));
        }
        void drawAll()
        {
            for (int i = 0; i < 5; i++)
            {
                drawFlag(i, false);
            }
        }
        void setAvailableLabel(Resourse Available)
        {
            avaiLables[0].Text = Available.A < 0 ? "0" : Available.A.ToString();
            avaiLables[1].Text = Available.B < 0 ? "0" : Available.B.ToString();
            avaiLables[2].Text = Available.C < 0 ? "0" : Available.C.ToString();
        }
        public void drawSingleBox(int index, Resourse demand, Resourse historyHave, Resourse Max, Resourse available, int flag)
        {
            //                float angleA = Allocation.A * 360 / (Max.A == 0 ? 1 : Max.A);
            listBox1.Items.Add("myDrawPie被调用");
            Console.WriteLine(pictureBoxes[index].AccessibilityObject);

            Graphics g = this.pictureBoxes[index].CreateGraphics();
            SolidBrush fix_brush = new SolidBrush(Color.LightGreen);
            SolidBrush change_brush = new SolidBrush(Color.LightSalmon);
            SolidBrush warn_brush = new SolidBrush(Color.Red);
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            Rectangle rectangle2 = new Rectangle(150, 10, 100, 100);
            Rectangle rectangle3 = new Rectangle(290, 10, 100, 100);
            float angleA = historyHave.A * 360 / (Max.A == 0 ? 1 : Max.A);
            float angleB = historyHave.B * 360 / (Max.B == 0 ? 1 : Max.B);
            float angleC = historyHave.C * 360 / (Max.C == 0 ? 1 : Max.C);
            float addA = demand.A * 360 / (Max.A == 0 ? 1 : Max.A);
            float addB = demand.B * 360 / (Max.B == 0 ? 1 : Max.B);
            float addC = demand.C * 360 / (Max.C == 0 ? 1 : Max.C);
            Resourse after_add = new Resourse(historyHave.A + demand.A > Max.A ? Max.A : historyHave.A + demand.A, historyHave.B + demand.B > Max.B ? Max.B : historyHave.B + demand.B, historyHave.C + demand.C > Max.C ? Max.C : historyHave.C + demand.C);
            g.FillRectangle(new SolidBrush(Color.White), rectangle1.X, 115, 100, 20);
            g.DrawString(after_add.A.ToString() + "/" + Max.A.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle1.X + 30, 115);
            g.FillRectangle(new SolidBrush(Color.White), rectangle2.X, 115, 100, 20);
            g.DrawString(after_add.B.ToString() + "/" + Max.B.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle2.X + 30, 115);
            g.FillRectangle(new SolidBrush(Color.White), rectangle3.X, 115, 100, 20);
            g.DrawString(after_add.C.ToString() + "/" + Max.C.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle3.X + 30, 115);
            if (flag == 0)
            {
                //setAvailableLabel(new Resourse(available.A - demand.A, available.B - demand.B, available.C - demand.C));
                MyAnimation.SyncActiveDrawPie(g, change_brush, warn_brush, rectangle1, angleA - 90, addA, 10);
                MyAnimation.SyncActiveDrawPie(g, change_brush, warn_brush, rectangle2, angleB - 90, addB, 10);
                MyAnimation.SyncActiveDrawPie(g, change_brush, warn_brush, rectangle3, angleC - 90, addC, 10);

            }
            else if (flag == 1)
            {
                //setAvailableLabel(new Resourse(demand.A - Max.A + historyHave.A, demand.B - Max.B + historyHave.B, demand.C - Max.C + historyHave.C));
                MyAnimation.SyncPreDrawPie(g, change_brush, warn_brush, rectangle1, angleA - 90, addA, 10);
                MyAnimation.SyncPreDrawPie(g, change_brush, warn_brush, rectangle2, angleB - 90, addB, 10);
                MyAnimation.SyncPreDrawPie(g, change_brush, warn_brush, rectangle3, angleC - 90, addC, 10);

            }


        }
        public FormOperating(AlgorithmOperator b,Resourse d,string n)
        {
            InitializeComponent();
            this.demand = d;
            this.name = n;
            CheckForIllegalCrossThreadCalls = false;
            this.basic = b;
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    pictureBoxes.Add((PictureBox)control);

                }
            }

            Console.WriteLine(pictureBoxes.Count);
            foreach(Control control in this.groupBox1.Controls)
            {
                if (control is Label)
                {
                    //listBox1.Items.Add(control.Name);
                    avaiLables.Add((Label)control);
                }
            }

            this.label_avaiA.Text = basic.available.A.ToString();
            this.label_avaiB.Text = basic.available.B.ToString();
            this.label_avaiC.Text = basic.available.C.ToString();
            init_draw();
            //listBox1.CheckForIllegalCrossThreadCalls = false;
        }
        public void init_draw()
        {
            SolidBrush fix_brush = new SolidBrush(Color.LightGreen);
            SolidBrush change_brush = new SolidBrush(Color.LightSalmon);
            SolidBrush warn_brush = new SolidBrush(Color.Red);
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            Rectangle rectangle2 = new Rectangle(150, 10, 100, 100);
            Rectangle rectangle3 = new Rectangle(290, 10, 100, 100);
            for (int i = 0; i < 5; i++)
            {
                Resourse Max = basic.ProcessList[i].Max;
                Resourse Allocation = basic.ProcessList[i].Allocation;
                float angleA = Allocation.A * 360 / (Max.A == 0 ? 1 : Max.A);
                float angleB = Allocation.B * 360 / (Max.B == 0 ? 1 : Max.B);
                float angleC = Allocation.C * 360 / (Max.C == 0 ? 1 : Max.C);
                listBox1.Items.Add(angleA+","+angleB + "," + angleC);
                //Graphics g = pictureBoxes[4 - i].CreateGraphics();
                Bitmap img = new Bitmap(pictureBoxes[i].Width, pictureBoxes[i].Height);
                pictureBoxes[i].Image = img;
                Graphics g = Graphics.FromImage(img);
                g.Clear(Color.White);
                g.FillPie(fix_brush, rectangle1, 0, 360);
                g.FillPie(change_brush, rectangle1, -90 , angleA);
                if (Max.A == 0)
                    g.FillPie(change_brush, rectangle1, 0, 360);
                g.DrawString(Allocation.A.ToString() + "/" + Max.A.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle1.X + 30, 115);
                g.FillPie(fix_brush, rectangle2, 0, 360);
                g.FillPie(change_brush, rectangle2, -90, angleB);
                if (Max.B == 0)
                    g.FillPie(change_brush, rectangle2, 0, 360);
                g.DrawString(Allocation.B.ToString() + "/" + Max.B.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle2.X + 30, 115);
                // -90+history.A, angleA - history.A
                g.FillPie(fix_brush, rectangle3, 0, 360);
                g.FillPie(change_brush, rectangle3, -90 , angleC);
                if (Max.C == 0)
                    g.FillPie(change_brush, rectangle3, 0, 360);
                g.DrawString(Allocation.C.ToString() + "/" + Max.C.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle3.X + 30, 115);


            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button_run_Click(object sender, EventArgs e)
        {
            drawAll();
            this.basic.StrInfoTransfEvent += new AlgorithmOperator.StrInfoTransferDelegate(newStrInfo);
            this.basic.DrawInfoTransfEvent += new AlgorithmOperator.DrawInfoTransferDelegate(drawSingleBox);
            this.basic.WarnInfoTransfEvent += new AlgorithmOperator.WarnInfoTransferDelegate(DrawWarn);
            this.basic.WithDrawTransferEvent += new AlgorithmOperator.WithDrawTransferDelegate(Withdraw);
            this.basic.FlagChangeEvent += new AlgorithmOperator.FlagChangeDelegate(drawFlag);
            this.basic.LabelChangeEvent += new AlgorithmOperator.LabelChangeDelegate(setAvailableLabel);
           bool result = this.basic.addRequestT(this.demand.A, this.demand.B, this.demand.C, this.name);
            button_run.Enabled = false;
            if (result&&TransfEvent!=null)
                TransfEvent();

        }

        private void FormOperating_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}
