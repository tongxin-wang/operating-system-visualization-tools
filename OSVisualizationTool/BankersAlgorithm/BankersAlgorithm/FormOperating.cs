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
            this.basic.setBoard(pictureBoxes);
            this.basic.listBox = listBox1;
            foreach(Control control in this.groupBox1.Controls)
            {
                if (control is Label)
                {
                    //listBox1.Items.Add(control.Name);
                    avaiLables.Add((Label)control);
                }
            }
            this.basic.labels = avaiLables;
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
        public static void activeDrawPie(Graphics graphics, SolidBrush solidBrush, SolidBrush solidBrush2, Rectangle rectangle, float angle1, float angle2,int interval)
        {
            int Tick = 0;
            //if(angle2==0)

            //Console.WriteLine("被调用");
            while (true)
            {
                if (Tick > angle2)
                {
                    return;
                    //Console.WriteLine("Finish");
                }
                if (Tick < 270 - angle1)
                    graphics.FillPie(solidBrush, rectangle, angle1 + Tick, angle2 > Tick + 5 ? 5 : angle2 - Tick);
                else
                    graphics.FillPie(solidBrush2, rectangle, angle1 + Tick, angle2 > Tick + 5 ? 5 : angle2 - Tick);
                Tick += 5;
                Thread.Sleep(interval);
            }
        }
        public static void preDrawPie(Graphics graphics, SolidBrush solidBrush, SolidBrush solidBrush2, Rectangle rectangle, float angle1, float angle2, int interval)
        {
            float Tick = 0;
            //Console.WriteLine("被调用");
            while (true)
            {
                if (Tick == angle2 )
                {
                    if (Tick < 270 - angle1)
                    {
                        graphics.DrawImage(Properties.Resources.x, rectangle);
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Gray)), 0, 0, 405, 148);
                        //Console.WriteLine("Tick=" + Tick + " angle2=" + angle2);
                        return;
                        //Console.WriteLine("Finish");
                    }
                    else
                    {
                        graphics.DrawImage(Properties.Resources.benefits, rectangle);
                        return;
                    }
                }
                if (Tick < 270 - angle1)
                    graphics.FillPie(solidBrush, rectangle, angle1 + Tick, angle2 > Tick + 5 ? 5 : angle2 - Tick);
                else
                {
                    graphics.DrawImage(Properties.Resources.benefits, rectangle);
                    return;
                }
                Tick += (angle2 > Tick + 5 ? 5 : angle2 - Tick);
                Thread.Sleep(interval);
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_run_Click(object sender, EventArgs e)
        {
            Task<bool> t2 = new Task<bool>( () => 
                this.basic.addRequestT(this.demand.A,this.demand.B,this.demand.C,this.name)
            );
            t2.Start();
            button_run.Enabled = false;
            //t2.Wait()
            
            Task.WaitAll(t2);
            if (t2.Result&&TransfEvent!=null)
                TransfEvent();

        }

    }
}
