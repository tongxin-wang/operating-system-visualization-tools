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
        public event TransfDelegate TransfEvent;//将该页面的处理结果传递给上一界面
        private AlgorithmOperator myOperator;
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<Label> avaiLables = new List<Label>();
        public string name;
        public Resourse demand { set; get; }
        #region 绘图部分
        
        
        public void newStrInfo(string info)//算法的提示字符串处理函数
        {
            listBox1.Items.Add(info);
        }
        
        
        void Withdraw(Process process, List<bool> map, Resourse a, int index)//分配尝试失败时恢复现场
        {
            SolidBrush fix_brush = new SolidBrush(DataBus.fixColor);
            SolidBrush change_brush = new SolidBrush(DataBus.mainColor);
            SolidBrush warn_brush = new SolidBrush(DataBus.backupColor);
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
        void DrawWarn(int index, string word)//绘制警告字
        {
            Graphics g = pictureBoxes[index].CreateGraphics();
            g.DrawString(word, new Font("华文楷体", 25), new SolidBrush(Color.DarkRed), new PointF(10, 30));
        }
        public void drawFlag(int index, bool flag)//绘制进程完成情况
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
        void drawAll()//绘制所有进程完成情况
        {
            for (int i = 0; i < 5; i++)
            {
                drawFlag(i, false);
            }
        }
        void setAvailableLabel(Resourse Available)//更新空闲资源的显示标签
        {
            avaiLables[0].Text = Available.A < 0 ? "0" : Available.A.ToString();
            avaiLables[1].Text = Available.B < 0 ? "0" : Available.B.ToString();
            avaiLables[2].Text = Available.C < 0 ? "0" : Available.C.ToString();
        }
        public void drawSingleBox(int index, Resourse demand, Resourse historyHave, Resourse Max, Resourse available, int flag)//按照运行给出的数据动态展示算法运行到的当前进程的变化情况
        {
            //                float angleA = Allocation.A * 360 / (Max.A == 0 ? 1 : Max.A);
            //listBox1.Items.Add("myDrawPie被调用");
            Console.WriteLine(pictureBoxes[index].AccessibilityObject);

            Graphics g = this.pictureBoxes[index].CreateGraphics();
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            Rectangle rectangle2 = new Rectangle(150, 10, 100, 100);
            Rectangle rectangle3 = new Rectangle(290, 10, 100, 100);
            float angleA = historyHave.A * 360 / (Max.A == 0 ? 1 : Max.A);
            float angleB = historyHave.B * 360 / (Max.B == 0 ? 1 : Max.B);
            float angleC = historyHave.C * 360 / (Max.C == 0 ? 1 : Max.C);
            Resourse after_add = new Resourse(historyHave.A + demand.A > Max.A ? Max.A : historyHave.A + demand.A, historyHave.B + demand.B > Max.B ? Max.B : historyHave.B + demand.B, historyHave.C + demand.C > Max.C ? Max.C : historyHave.C + demand.C);
            g.FillRectangle(new SolidBrush(Color.White), rectangle1.X, 115, 100, 20);
            g.DrawString(after_add.A.ToString() + "/" + Max.A.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle1.X + 30, 115);
            g.FillRectangle(new SolidBrush(Color.White), rectangle2.X, 115, 100, 20);
            g.DrawString(after_add.B.ToString() + "/" + Max.B.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle2.X + 30, 115);
            g.FillRectangle(new SolidBrush(Color.White), rectangle3.X, 115, 100, 20);
            g.DrawString(after_add.C.ToString() + "/" + Max.C.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle3.X + 30, 115);
            MyDrawParam param1 = new MyDrawParam(g);
            param1.positionRectangle = new Rectangle(10, 10, 100, 100);
            param1.angleBegin = angleA - 90;
            param1.angleIncrease = demand.A * 360 / (Max.A == 0 ? 1 : Max.A);
            param1.interval = DataBus.FormOperatingActiveInterval;
            MyDrawParam param2 = new MyDrawParam(g);
            param2.positionRectangle = new Rectangle(150, 10, 100, 100);
            param2.angleBegin = angleB - 90;
            param2.angleIncrease = demand.B * 360 / (Max.B == 0 ? 1 : Max.B);
            param2.interval = DataBus.FormOperatingActiveInterval;
            MyDrawParam param3 = new MyDrawParam(g);
            param3.positionRectangle = new Rectangle(290, 10, 100, 100);
            param3.angleBegin = angleC - 90;
            param3.angleIncrease = demand.C * 360 / (Max.C == 0 ? 1 : Max.C);
            param3.interval = DataBus.FormOperatingActiveInterval;
            if (flag == 1)
            {
                MyAnimation.SyncPreDrawPie(param1);
                MyAnimation.SyncPreDrawPie(param2);
                MyAnimation.SyncPreDrawPie(param3);
            }
            else
            {
                MyAnimation.SyncActiveDrawPie(param1);
                MyAnimation.SyncActiveDrawPie(param2);
                MyAnimation.SyncActiveDrawPie(param3);
            }


        }
        #endregion
        public FormOperating(AlgorithmOperator b,Resourse d,string n)//初始化各控件和属性
        {
            InitializeComponent();
            this.demand = d;
            this.name = n;
            CheckForIllegalCrossThreadCalls = false;
            this.myOperator = b;
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

            this.label_avaiA.Text = myOperator.available.A.ToString();
            this.label_avaiB.Text = myOperator.available.B.ToString();
            this.label_avaiC.Text = myOperator.available.C.ToString();
            init_draw();
            //listBox1.CheckForIllegalCrossThreadCalls = false;
        }
        public void init_draw()//初始化绘制
        {
            SolidBrush fix_brush = new SolidBrush(DataBus.fixColor);
            SolidBrush change_brush = new SolidBrush(Color.LightSalmon);
            SolidBrush warn_brush = new SolidBrush(Color.Red);
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            Rectangle rectangle2 = new Rectangle(150, 10, 100, 100);
            Rectangle rectangle3 = new Rectangle(290, 10, 100, 100);
            for (int i = 0; i < 5; i++)
            {
                Resourse Max = myOperator.ProcessList[i].Max;
                Resourse Allocation = myOperator.ProcessList[i].Allocation;
                float angleA = Allocation.A * 360 / (Max.A == 0 ? 1 : Max.A);
                float angleB = Allocation.B * 360 / (Max.B == 0 ? 1 : Max.B);
                float angleC = Allocation.C * 360 / (Max.C == 0 ? 1 : Max.C);
                //listBox1.Items.Add(angleA+","+angleB + "," + angleC);
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
        private void button_run_Click(object sender, EventArgs e)//开始运行
        {
            drawAll();
            this.myOperator.StrInfoTransfEvent += new AlgorithmOperator.StrInfoTransferDelegate(newStrInfo);
            this.myOperator.DrawInfoTransfEvent += new AlgorithmOperator.DrawInfoTransferDelegate(drawSingleBox);
            this.myOperator.WarnInfoTransfEvent += new AlgorithmOperator.WarnInfoTransferDelegate(DrawWarn);
            this.myOperator.WithDrawTransferEvent += new AlgorithmOperator.WithDrawTransferDelegate(Withdraw);
            this.myOperator.FlagChangeEvent += new AlgorithmOperator.FlagChangeDelegate(drawFlag);
            this.myOperator.LabelChangeEvent += new AlgorithmOperator.LabelChangeDelegate(setAvailableLabel);
           bool result = this.myOperator.addRequestT(this.demand.A, this.demand.B, this.demand.C, this.name);
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
