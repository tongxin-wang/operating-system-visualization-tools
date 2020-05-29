using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace BankerAlgorithm
{
    public partial class FormTest : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer myTimer2 = new System.Windows.Forms.Timer();
        int i = 0;
        Pen skyBluePen = new Pen(Brushes.DeepSkyBlue);
        Graphics gChange;

        public FormTest()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void activeTick(object o, EventArgs e, Pen pen, Graphics g, ref System.Windows.Forms.Timer timer, ref int tick, float x1, float y1, float x2, float y2)
        {

            float width = x2 - x1;
            float height = y2 - y1;
            float cot;
            this.listBox1.Items.Add("activeTick" + tick);
            cot = x2 - x1 == 0 ? 0 : height / width;
            if (y1 > y2)
            {
                if (x1 + tick > x2 && y1 + tick * cot < y2)
                {
                    timer.Stop();
                    return;
                }
                float newX = x1 + tick + 5;
                float newY = y1 + (tick + 5) * cot;
                if (x1 + tick + 5 > x2 || y1 + (tick + 5) * cot < y2)
                {
                    newX = x2;
                    newY = y2;
                }
                //this.listBox1.Items.Add("activeTick" + tick);
                g.DrawLine(pen, x1 + tick, y1 + tick * cot, newX, newY);
                tick += 5;
                return;
            }
            if (cot != 0)
            {
                if (x1 + tick > x2 && y1 + tick * cot > y2)
                {
                    timer.Stop();
                    return;
                }
                float newX = x1 + tick + 5;
                float newY = y1 + (tick + 5) * cot;
                if (x1 + tick + 5 > x2 || y1 + (tick + 5) * cot > y2)
                {
                    newX = x2;
                    newY = y2;
                }
                //this.listBox1.Items.Add("activeTick" + tick);
                g.DrawLine(pen, x1 + tick, y1 + tick * cot, newX, newY);
            }
            if (width == 0)
            {
                float newY = y1 + tick + 5;
                if (y1 + tick + 5 > y2)
                    newY = y2;
                if (y1 + tick > y2)
                {
                    timer.Stop();
                    return;
                }
                //this.listBox1.Items.Add("activeTick" + tick);
                g.DrawLine(pen, x1, y1 + tick, x2, newY);
            }
            if (height == 0)
            {
                float newX = x1 + tick + 5;
                if (x1 + tick + 5 > x2)
                    newX = x2;
                if (x1 + tick > x2)
                {
                    timer.Stop();
                    return;
                }
                //this.listBox1.Items.Add("activeTick" + tick);
                g.DrawLine(pen, x1 + tick, y1, newX, y2);
            }
            tick = tick + 5;
        }
        private void ActiveDrawLine(Graphics g, Pen pen, int interval, float x1, float y1, float x2, float y2)
        {
            int tick = 0;
            //this.listBox1.Items.Add("activeDraw" + tick);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = interval;
            timer.Tick += new EventHandler((o, e) => { activeTick(o, e, pen, g, ref timer, ref tick, x1, y1, x2, y2); });
            timer.Start();

            this.listBox1.Items.Add(timer.Enabled);


        }
        private void tickEvent(object sender, EventArgs e)
        {
            i++;
            this.listBox1.Items.Add(i.ToString());
            //button2.Location=new Point(button2.Location.X+10*i,button2.Location.Y);
            button2.Left += 10 * i;
            if (i > 10)
            {
                myTimer.Stop();
            }
        }
        private void tickEvent2(object sender, EventArgs e)
        {
            i++;
            Graphics g = this.panel2.CreateGraphics();
            //g.Clear(Color.White);
            g.DrawRectangle(skyBluePen,
                new Rectangle(40 + i * 10, 40, 150, 200));
            if (i > 10)
            {
                myTimer.Stop();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Add("begin");
            
            this.button1.Text = "begin";
            myTimer.Interval = 1000;
            myTimer.Tick += tickEvent;
            myTimer.Start();
            //this.button1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Set the pen's width.
            skyBluePen.Width = 8.0F;

            // Set the LineJoin property.
            skyBluePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;

            // Draw a rectangle.
            Graphics g = this.panel2.CreateGraphics();
            g.DrawRectangle(skyBluePen,
                 new Rectangle(40, 40, 150, 200));
            myTimer.Interval = 1000;
            myTimer.Tick += tickEvent2;
            myTimer.Start();
            //Dispose of the pen.
            //skyBluePen.Dispose();
        }
        private int tick3 = 0;
        private int flag = 0;
        void tickEvent3(object o, EventArgs e)
        {
            if (tick3 >= 25)
            {
                flag = 1;
            }
            if (tick3 <= 1)
            {
                flag = 0;
            }
            _ = flag == 0 ? tick3++ : tick3--;
            myTimer2.Interval = 200;
            this.listBox1.Items.Add(tick3);
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.FromArgb(255, 0, tick3 * 10));//画刷
            gChange = this.panel3.CreateGraphics();
            gChange.Clear(Color.White);
            gChange.FillEllipse(myBrush, new Rectangle(5, 5, 60, 40));

        }
        private void button3_Click(object sender, EventArgs e)
        {
            myTimer2.Interval = 1000;
            myTimer2.Tick += tickEvent3;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.FromArgb(255, 0, tick3));//画刷
            Pen changingPen = new Pen(Color.FromArgb(255, 255, tick3));
            gChange = this.panel3.CreateGraphics();
            gChange.FillEllipse(myBrush, new Rectangle(5, 5, 60, 40));
            myTimer2.Start();

        }
        static System.Windows.Forms.Timer myTimer3 = new System.Windows.Forms.Timer();
        private int tick4 = 1;
        void tickEvent4(object o, EventArgs e)
        {
            if (tick4 > 10)
            {
                myTimer3.Stop();
                return;
            }
            tick4++;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.White);//画刷
            gChange = this.panel3.CreateGraphics();
            gChange.FillEllipse(myBrush, new Rectangle(5, 5, 6 * tick4, 4 * tick4));
        }
        private void button5_Click(object sender, EventArgs e)
        {
            myTimer3.Interval = 1000;
            myTimer3.Tick += tickEvent4;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.White);//画刷
            gChange = this.panel3.CreateGraphics();
            gChange.FillEllipse(myBrush, new Rectangle(5, 5, 6 * tick4, 4 * tick4));
            myTimer3.Start();
        }
        static System.Windows.Forms.Timer myTimer4 = new System.Windows.Forms.Timer();
        Graphics gFade;
        Pen pen = new Pen(Color.Black, 8f);
        private int tick5 = 0;
        void tickEvent5(object o, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            gFade = this.panel4.CreateGraphics();

            Rectangle[] r = { new Rectangle(10, 10, 60, 60), new Rectangle(10, 70, 60, 60) };
            gFade.DrawRectangles(pen, r);

            myTimer4.Interval = 500;
            myTimer4.Tick += tickEvent5; myTimer4.Start();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black, 8f);
            Graphics gActive = this.panel4.CreateGraphics();
            Pen red_pen = new Pen(Color.Red, 8f);
            gActive.DrawLine(red_pen, 10, 100, 100, 10);
            ActiveDrawLine(gActive, pen, 100, 10, 100, 100, 10);
        }
        private void activeTick2(Pen pen, Graphics g, int interval, float x1, float y1, float x2, float y2)
        {
            int tick = 0;
            while (true)
            {
                float width = x2 - x1;
                float height = y2 - y1;
                float cot;
                this.listBox1.Items.Add("activeTick" + tick);
                cot = x2 - x1 == 0 ? 0 : height / width;
                if (y1 > y2)
                {
                    if (x1 + tick > x2 && y1 + tick * cot < y2)
                    {
                        return;
                    }
                    float newX = x1 + tick + 5;
                    float newY = y1 + (tick + 5) * cot;
                    if (x1 + tick + 5 > x2 || y1 + (tick + 5) * cot < y2)
                    {
                        newX = x2;
                        newY = y2;
                    }
                    //this.listBox1.Items.Add("activeTick" + tick);
                    g.DrawLine(pen, x1 + tick, y1 + tick * cot, newX, newY);
                    tick += 5;
                    return;
                }
                if (cot != 0)
                {
                    if (x1 + tick > x2 && y1 + tick * cot > y2)
                    {
                        return;
                    }
                    float newX = x1 + tick + 5;
                    float newY = y1 + (tick + 5) * cot;
                    if (x1 + tick + 5 > x2 || y1 + (tick + 5) * cot > y2)
                    {
                        newX = x2;
                        newY = y2;
                    }
                    //this.listBox1.Items.Add("activeTick" + tick);
                    g.DrawLine(pen, x1 + tick, y1 + tick * cot, newX, newY);
                }
                if (width == 0)
                {
                    float newY = y1 + tick + 5;
                    if (y1 + tick + 5 > y2)
                        newY = y2;
                    if (y1 + tick > y2)
                    {
                        return;
                    }
                    //this.listBox1.Items.Add("activeTick" + tick);
                    g.DrawLine(pen, x1, y1 + tick, x2, newY);
                }
                if (height == 0)
                {
                    float newX = x1 + tick + 5;
                    if (x1 + tick + 5 > x2)
                        newX = x2;
                    if (x1 + tick > x2)
                    {
                        return;
                    }
                    //this.listBox1.Items.Add("activeTick" + tick);
                    g.DrawLine(pen, x1 + tick, y1, newX, y2);
                }
                tick = tick + 5;
                Thread.Sleep(interval);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black, 8f);
            Graphics gActive = this.panel5.CreateGraphics();
            Pen red_pen = new Pen(Color.Red, 8f);
            //gActive.DrawLine(red_pen, 10, 10, 10, 100);
            //gActive.DrawLine(red_pen, 10, 10, 100, 10);
            //gActive.DrawLine(red_pen, 100, 10, 100, 100);
            //gActive.DrawLine(red_pen, 10, 100, 100, 100);
            //activeTick2(pen, gActive,100, 10, 10, 10, 100);
            //Thread.Sleep(2000);
            //activeTick2(pen, gActive, 100, 10, 10, 100, 10);
            //Properties.Resources.
            //Image.FromFile
            //gActive.DrawImage()
            gActive.DrawImage(Properties.Resources.benefits, 50, 50);
            gActive.DrawImage(Properties.Resources.x, new Rectangle(50, 50, 80, 80));
            //Task t1 = new Task(() => ActiveDrawLine(gActive, pen, 10, 10, 10, 10, 100));
            //t1.Start();
            //t1.RunSynchronously();
            //Task.WaitAll(t1);
            //Thread.Sleep(1000);
            //Task t2 = new Task(() => ActiveDrawLine(gActive, pen, 10, 10, 10, 100, 10));
            //Task t3 = new Task(() => ActiveDrawLine(gActive, pen, 10, 100, 10, 100, 100));
            //t2.RunSynchronously();
            //t3.RunSynchronously();
            //Task.WaitAll(t2, t3);
            //Thread.Sleep(1000);
            //ActiveDrawLine(gActive, pen, 10, 10, 100, 100, 100);
            ////Thread.Sleep(1000);
            //ActiveDrawLine(gActive, pen, 10, 10, 10, 100, 100);
            ////Thread.Sleep(1000);
            //ActiveDrawLine(gActive, pen, 10, 10, 100, 100, 10);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormMain form2 = new FormMain();
            form2.Show();
        }
        private void activePieEvent(Graphics graphics, SolidBrush solidBrush, SolidBrush solidBrush2, Rectangle rectangle, float angle1, float angle2, System.Windows.Forms.Timer timer, ref int Tick)
        {
            //Console.WriteLine("被调用");
            if (Tick > angle2)
            {
                timer.Stop();
                Console.WriteLine("Finish");
                return;
            }
            if (Tick < 270 - angle1)
                graphics.FillPie(solidBrush, rectangle, angle1 + Tick, angle2 > Tick + 5 ? 5 : angle2 - Tick);
            else
                graphics.FillPie(solidBrush2, rectangle, angle1 + Tick, angle2 > Tick + 5 ? 5 : angle2 - Tick);
            Tick += 5;
        }
        public void activeDrawPie(Graphics graphics, SolidBrush solidBrush, SolidBrush solidBrush2, Rectangle rectangle, float angle1, float angle2, int interval)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = interval;
            int Tick = 0;
            timer.Tick += new EventHandler((o, e) => activePieEvent(graphics, solidBrush, solidBrush2, rectangle, angle1, angle2, timer, ref Tick));
            timer.Start();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.panel6.CreateGraphics();
            Pen red_pen = new Pen(Color.Red);
            SolidBrush red_brush = new SolidBrush(Color.Red);//画刷
            SolidBrush blue_brush = new SolidBrush(Color.Blue);

            activeDrawPie(graphics, red_brush, blue_brush, new Rectangle(10, 10, 100, 100), 50, 350, 10);
            //graphics.FillPie
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Graphics g = panel7.CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(Color.Red);
            Pen pen = new Pen(Color.Black);
            //g.FillRectangle(solidBrush, new Rectangle(0, 0, 10, 10));
            g.DrawString("已完成", new Font("华文楷体", 50), solidBrush, new Point(0, 2));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawImage(Properties.Resources._1, new Point(100, 100));
            g.DrawRectangle(new Pen(Color.Red, 10), new Rectangle(10, 10, 1000, 1000));
            // Properties.Resources.
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MyDictionary<string, int> testDic = new MyDictionary<string, int>();
            testDic["name"] = 321;
            testDic["price"] = 1;
            Export("test3.xml", testDic);
            Import("test3.xml");
        }
        public static void Export(string path, MyDictionary<string, int> test)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xS = new XmlSerializer(typeof(MyDictionary<string, int>));
                xS.Serialize(fs, test);

            }
        }
        public static MyDictionary<string, int> Import(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                XmlSerializer xS = new XmlSerializer(typeof(MyDictionary<string, int>));
                MyDictionary<string, int> file_order = (MyDictionary<string, int>)xS.Deserialize(fs);
                foreach (var o in file_order)
                {
                    Console.WriteLine(o.Key);
                }
                return file_order;



            }
        }
    }
}
