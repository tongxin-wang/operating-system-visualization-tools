using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpAnimationTest1
{

    public partial class Form2 : Form
    {
        public Basic basic;
        List<ListItem> items = new List<ListItem>();
        List<ListItem> defaultItems = new List<ListItem>();
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<AngleCollection> historys = new List<AngleCollection>();
        private void historyReset()
        {
            historys.Clear();
            for(int i=0;i<5;i++)
            {
                historys.Add(new AngleCollection(0, 0, 0));
            }
        }
        private void initAll()
        {
            historyReset();
            foreach (Control control in this.Controls)
            {
                if(control is PictureBox)
                {
                    pictureBoxes.Add((PictureBox)control);

                }
            }

            items.Add(new ListItem("0", "P0"));
            items.Add(new ListItem("1", "P1"));
            items.Add(new ListItem("2", "P2"));
            items.Add(new ListItem("3", "P3"));
            items.Add(new ListItem("4", "P4"));
            defaultItems.Add(new ListItem("0", "简单的成功申请"));
            defaultItems.Add(new ListItem("1", "超出资源需求的申请"));
            defaultItems.Add(new ListItem("2", "复杂的成功申请"));
            defaultItems.Add(new ListItem("3", "预分配产生死锁的申请"));
            comboBox2.DisplayMember = "Text";        //显示
            comboBox2.ValueMember = "Value";        //值
            comboBox2.DataSource = defaultItems;        //绑定数据
            comboBox2.SelectedIndex = -1;
            //items.Add(new ListItem("5", "Item_5_Text"));
            this.label_detail.Visible = false;
            this.listBox2.Visible = false;
            comboBox1.DisplayMember = "Text";        //显示
            comboBox1.ValueMember = "Value";        //值
            comboBox1.DataSource = items;        //绑定数据
            label_AM.Text = basic.available.A.ToString();
            label_BM.Text = basic.available.B.ToString();
            label_CM.Text = basic.available.C.ToString();
            trackBarA.Maximum = basic.available.A;
            trackBarB.Maximum = basic.available.B;
            trackBarC.Maximum = basic.available.C;
            init_draw();
        }
        public Form2()
        {
            InitializeComponent();
            //button2.Click += button1_Click;
            basic = new Basic();
            initAll();
            

        }
        public Form2(MyDictionary<string,int> dic)
        {
            InitializeComponent();
            //button2.Click += button1_Click;
            basic = new Basic(dic);
            initAll();
           
        }
        public void notMyTemp()
        {
            groupBox_default.Hide();
        }
        private static void activePieEvent(Graphics graphics, SolidBrush solidBrush, SolidBrush solidBrush2, Rectangle rectangle, float angle1, float angle2, Timer timer, ref int Tick)
        {
            //Console.WriteLine("被调用");
            if (Tick > angle2)
            {
                timer.Stop();
                //Console.WriteLine("Finish");
                return;
            }
            if (Tick < 270-angle1)
                graphics.FillPie(solidBrush, rectangle, angle1 + Tick, angle2 > Tick + 5 ? 5 : angle2 - Tick);
            else
                graphics.FillPie(solidBrush2, rectangle, angle1 + Tick, angle2 > Tick + 5 ? 5 : angle2 - Tick);
            Tick += 5;
        }
        public static void activeDrawPie(Graphics graphics, SolidBrush solidBrush, SolidBrush solidBrush2, Rectangle rectangle, float angle1, float angle2, int interval)
        {
            Timer timer = new Timer();
            timer.Interval = interval;
            int Tick = 0;
            timer.Tick += new EventHandler((o, e) => activePieEvent(graphics, solidBrush, solidBrush2, rectangle, angle1, angle2, timer, ref Tick));
            timer.Start();
        }
        public void refresh()
        {
            historyReset();
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
                //listBox1.Items.Add(angleA + "," + angleB + "," + angleC);
                //Graphics g = pictureBoxes[4 - i].CreateGraphics();
                Bitmap img = new Bitmap(pictureBoxes[i].Width, pictureBoxes[i].Height);
                pictureBoxes[i].Image = img;
                Graphics g = Graphics.FromImage(img);
                g.Clear(Color.White);
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
                // -90+history.A, angleA - history.A
                g.FillPie(fix_brush, rectangle3, 0, 360);
                g.FillPie(change_brush, rectangle3, -90, angleC);
                if (Max.C == 0)
                    g.FillPie(change_brush, rectangle3, 0, 360);
                g.DrawString(Allocation.C.ToString() + "/" + Max.C.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle3.X + 30, 115);


            }
            barReset();

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

                //Graphics g = pictureBoxes[4 - i].CreateGraphics();
                Bitmap img = new Bitmap(pictureBoxes[i].Width, pictureBoxes[i].Height);
                pictureBoxes[ i].Image = img;

                Graphics g = Graphics.FromImage(img);
                g.Clear(Color.White);
                //Graphics g = pictureBox.CreateGraphics();
                g.FillPie(fix_brush, rectangle1, 0, 360);
                if(Max.A==0)
                    g.FillPie(change_brush, rectangle1, 0, 360);
                g.DrawString(Allocation.A.ToString()+"/"+Max.A.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle1.X+30, 115);
                g.FillPie(fix_brush, rectangle2, 0, 360);
                if (Max.B == 0)
                    g.FillPie(change_brush, rectangle2, 0, 360);
                g.DrawString(Allocation.B.ToString() + "/" + Max.B.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle2.X + 30, 115);
                g.FillPie(fix_brush, rectangle3, 0, 360);
                if (Max.C == 0)
                    g.FillPie(change_brush, rectangle3, 0, 360);
                g.DrawString(Allocation.C.ToString() + "/" + Max.C.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle3.X + 30, 115);


            }
        }
            private void button1_Click(object sender, EventArgs e)
        {
            basic.printPro(basic.ProcessList, basic.available);
            SolidBrush fix_brush = new SolidBrush(Color.LightGreen);
            SolidBrush change_brush = new SolidBrush(Color.LightSalmon);
            SolidBrush warn_brush = new SolidBrush(Color.Red);
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            Rectangle rectangle2 = new Rectangle(150, 10, 100, 100);
            Rectangle rectangle3 = new Rectangle(290, 10, 100, 100);
            for (int i = 0; i < 5; i++)
            {
                AngleCollection history = historys[i];
                Resourse Max=basic.ProcessList[i].Max;
                Resourse Allocation = basic.ProcessList[i].Allocation;
                float angleA = Allocation.A * 360 / (Max.A == 0 ? 1 : Max.A);
                float angleB = Allocation.B * 360 / (Max.B == 0 ? 1 : Max.B);
                float angleC = Allocation.C * 360 / (Max.C == 0 ? 1 : Max.C);
                //this.listBox1.Items.Add(angleC);
                Graphics g=pictureBoxes[i].CreateGraphics();
                //Bitmap img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                //pictureBoxes[4 - i].Image = img;
                //Graphics g = Graphics.FromImage(img);
                //pictureBoxes[4 - i].Image= getBitMapFile(pictureBox1.Width, pictureBox1.Height);
               // g.FillPie(fix_brush, rectangle1, 0, 360);
                activeDrawPie(g,change_brush,warn_brush, rectangle1, -90+history.A, angleA - history.A,100);
                g.FillRectangle(new SolidBrush(Color.White), rectangle1.X, 115, 100, 20);
                g.DrawString(Allocation.A.ToString() + "/" + Max.A.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle1.X + 30, 115);
                //g.FillPie(fix_brush, rectangle2, 0, 360);
                activeDrawPie(g, change_brush, warn_brush, rectangle2, -90+history.B, angleB - history.B, 100);
                g.FillRectangle(new SolidBrush(Color.White), rectangle2.X, 115, 100, 20);
                g.DrawString(Allocation.B.ToString() + "/" + Max.B.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle2.X + 30, 115);
                //g.FillPie(fix_brush, rectangle3, 0, 360);
                activeDrawPie(g, change_brush, warn_brush, rectangle3, -90+history.C, angleC - history.C,100);
                g.FillRectangle(new SolidBrush(Color.White), rectangle3.X, 115, 100, 20);
                g.DrawString(Allocation.C.ToString() + "/" + Max.C.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle3.X + 30, 115);
                history.A = angleA;
                history.B = angleB;
                history.C = angleC;


            }
              //panels[3].CreateGraphics().DrawLine(new Pen(Color.Blue,10), 1, 1, 100, 100);
        }

        private void barReset()
        {
                trackBarA.Maximum = basic.available.A;
                trackBarB.Maximum = basic.available.B;
                trackBarC.Maximum = basic.available.C;
                label_AM.Text = basic.available.A.ToString();
                label_BM.Text = basic.available.B.ToString();
                label_CM.Text = basic.available.C.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (switchFlag == false)
            {
                if (basic.addRequest(trackBarA.Value, trackBarB.Value, trackBarC.Value, comboBox1.SelectedItem.ToString()))
                {
                    barReset();
                    button1_Click(sender, e);
                    foreach (Control control in this.Controls)
                    {
                        if (control is TrackBar)
                        {
                            TrackBar tb = (TrackBar)control;
                            tb.Value = 0;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请重新分配资源", "分配失败");
                }
            }
            else if(switchFlag==true)
            {
                button4_Click(sender, e);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label_Bval.Text=trackBarB.Value.ToString();
        }

        private void trackBarA_ValueChanged(object sender, EventArgs e)
        {
            label_Aval.Text = trackBarA.Value.ToString();
        }

        private void trackBarC_ValueChanged(object sender, EventArgs e)
        {
            label_Cval.Text = trackBarC.Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
              //listBox1.Items.Add( comboBox1.SelectedItem.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (Control control in this.Controls)
            //{
            //    if (control is TrackBar)
            //    {
            //        TrackBar tb = (TrackBar)control;
            //        tb.Value = 0;
            //    }
            //}
        }


        private void button4_Click(object sender, EventArgs e)
        {
            //basic.addRequest(1, 1, 1, "P4");
            //basic.addRequest(1, 1, 1, "P0");
            Form3 form3 = new Form3(this.basic,new Resourse(trackBarA.Value, trackBarB.Value, trackBarC.Value), comboBox1.SelectedItem.ToString());
            form3.Show();
            button1_Click(sender, e);
            form3.TransfEvent +=new Form3.TransfDelegate(refresh);
        }
        private static bool switchFlag = false;
        private void Switch_btn_Click(object sender, EventArgs e)
        {
            switchFlag = !switchFlag;
            if(switchFlag)
            {
                Switch_btn.BackgroundImage = Properties.Resources.switch_ON;
            }
            if (!switchFlag)
            {
                Switch_btn.BackgroundImage = Properties.Resources.switch_OFF__1_;
            }
            Console.WriteLine("Switchflag=" + switchFlag);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
            this.basic = new Basic();
            refresh();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox_default_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void groupBox_default_Enter(object sender, EventArgs e)
        {

        }

        private void addInfo(ListBox listBox,int index)
        {
                switch (index)
                {
                    case 0:
                        {
                        listBox.Items.Add("P0申请2,2,2");
                        listBox.Items.Add("P1申请1,0,1");
                        listBox.Items.Add("算法会在预分配后确定目前处于安全状态");
                        listBox.Items.Add("完成分配");
                        break;
                        }
                    case 1:
                        {
                        listBox.Items.Add("P3申请4,1,1");
                        listBox.Items.Add("申请的资源大于了需要的资源");
                        listBox.Items.Add("算法无法完成预分配");
                        break;
                        }
                    case 2:
                        {
                        listBox.Items.Add("P4申请3,3,3");
                        listBox.Items.Add("P0申请7,0,0");
                        listBox.Items.Add("算法会在预分配后发现目前处于安全状态");
                        listBox.Items.Add("完成分配");
                        break;
                        }
                    case 3:
                        {
                            listBox.Items.Add("P4申请3,3,3");
                            listBox.Items.Add("P0申请8,0,0");
                            listBox.Items.Add("算法会在预分配后发现目前处于不安全状态");
                            listBox.Items.Add("分配失败");
                            break;
                        }
                default:
                        {
                            listBox.Items.Add("出现了问题");
                            break;
                        }
                }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                this.label_detail.Visible = true ;
                this.listBox2.Visible = true;
                listBox2.Items.Clear();
                addInfo(listBox2, comboBox2.SelectedIndex);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case -1:
                    {
                        MessageBox.Show("还未选择默认模板");
                        break;
                    }
                case 0:
                    {
                        basic.addRequest(2, 2, 2, "P0");
                        Form3 form3 = new Form3(this.basic, new Resourse(1,0,1),"P1");
                        form3.Show();
                        button1_Click(sender, e);
                        form3.TransfEvent += new Form3.TransfDelegate(refresh);
                        break;
                    }
                case 1:
                    {

                        Form3 form3 = new Form3(this.basic, new Resourse(4, 1, 1), "P3");
                        form3.Show();
                        button1_Click(sender, e);
                        form3.TransfEvent += new Form3.TransfDelegate(refresh);
                        break;
                    }
                case 2:
                    {
                        basic.addRequest(3, 3, 3, "P4");
                        Form3 form3 = new Form3(this.basic, new Resourse(7, 0, 0), "P0");
                        form3.Show();
                        button1_Click(sender, e);
                        form3.TransfEvent += new Form3.TransfDelegate(refresh);
                        break;
                    }
                case 3:
                    {
                        basic.addRequest(3, 3, 3, "P4");
                        Form3 form3 = new Form3(this.basic, new Resourse(8, 0, 0), "P0");
                        form3.Show();
                        button1_Click(sender, e);
                        form3.TransfEvent += new Form3.TransfDelegate(refresh);
                        break;
                    }
                default:
                    {
                        listBox2.Items.Add("出现了问题");
                        break;
                    }
            }
        }
    }
    public class AngleCollection
    {
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public AngleCollection(float a, float b, float c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}
