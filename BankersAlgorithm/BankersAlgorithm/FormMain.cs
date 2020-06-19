using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankerAlgorithm
{

    public partial class FormMain : Form
    {
        public delegate void  BackDel(int flag);
        public event BackDel getBack;//用于返回选择界面
        private bool outFlag = false;//用于判断界面close的方式
        public AlgorithmOperator myOperator;
        List<ListItem> items = new List<ListItem>();
        List<ListItem> defaultItems = new List<ListItem>();
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<AngleCollection> historys = new List<AngleCollection>();//记录上一次的各参数情况
        private static bool switchFlag = false;//switch按钮的情况
        private MyDictionary<string, int> dic;
        private void historyReset()//更新历史数据的值
        {
            historys.Clear();
            for(int i=0;i<5;i++)
            {
                historys.Add(new AngleCollection(0, 0, 0));
            }
        }
        private void initAll()//初始化界面和界面属性内容
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
            comboBox_selectTemp.DisplayMember = "Text";        //显示
            comboBox_selectTemp.ValueMember = "Value";        //值
            comboBox_selectTemp.DataSource = defaultItems;        //绑定数据
            comboBox_selectTemp.SelectedIndex = -1;
            //items.Add(new ListItem("5", "Item_5_Text"));
            this.label_detail.Visible = false;
            this.listBox_tempDetail.Visible = false;
            comboBox_selectProcess.DisplayMember = "Text";        //显示
            comboBox_selectProcess.ValueMember = "Value";        //值
            comboBox_selectProcess.DataSource = items;        //绑定数据
            label_AM.Text = myOperator.available.A.ToString();
            label_BM.Text = myOperator.available.B.ToString();
            label_CM.Text = myOperator.available.C.ToString();
            trackBarA.Maximum = myOperator.available.A;
            trackBarB.Maximum = myOperator.available.B;
            trackBarC.Maximum = myOperator.available.C;
            init_draw();
        }
        //测试用的重载
        public FormMain()
        {
            InitializeComponent();
            //button2.Click += button1_Click;
            myOperator = new AlgorithmOperator();
            initAll();
            

        }
        public FormMain(MyDictionary<string,int> dic)
        {
            InitializeComponent();
            this.dic = dic;
            //button2.Click += button1_Click;
            myOperator = new AlgorithmOperator(dic);
            initAll();
           
        }
        public void notMyTemp()//隐藏请求模板
        {
            groupBox_default.Hide();
        }
        public void refresh()//立刻更新所有的显示值和绘制情况
        {
            historyReset();
            SolidBrush fix_brush = new SolidBrush(DataBus.fixColor);
            SolidBrush change_brush = new SolidBrush(DataBus.mainColor);
            SolidBrush warn_brush = new SolidBrush(DataBus.backupColor);
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
        public void init_draw()//绘制的初始化
        {
            SolidBrush fix_brush = new SolidBrush(DataBus.fixColor);
            SolidBrush change_brush = new SolidBrush(DataBus.mainColor);
            SolidBrush warn_brush = new SolidBrush(DataBus.backupColor);
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            Rectangle rectangle2 = new Rectangle(150, 10, 100, 100);
            Rectangle rectangle3 = new Rectangle(290, 10, 100, 100);
            for (int i = 0; i < 5; i++)
            {
                Resourse Max = myOperator.ProcessList[i].Max;
                Resourse Allocation = myOperator.ProcessList[i].Allocation;

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
         private void update_draw(object sender, EventArgs e)//动态的绘制更新
        {
            myOperator.printPro(myOperator.ProcessList, myOperator.available);
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            Rectangle rectangle2 = new Rectangle(150, 10, 100, 100);
            Rectangle rectangle3 = new Rectangle(290, 10, 100, 100);
            for (int i = 0; i < 5; i++)
            {
                AngleCollection history = historys[i];
                Resourse Max=myOperator.ProcessList[i].Max;
                Resourse Allocation = myOperator.ProcessList[i].Allocation;
                float angleA = Allocation.A * 360 / (Max.A == 0 ? 1 : Max.A);
                float angleB = Allocation.B * 360 / (Max.B == 0 ? 1 : Max.B);
                float angleC = Allocation.C * 360 / (Max.C == 0 ? 1 : Max.C);
                Graphics g=pictureBoxes[i].CreateGraphics();
                MyDrawParam param1 = new MyDrawParam(g);
                param1.positionRectangle = rectangle1;
                param1.angleBegin = -90 + history.A;
                param1.angleIncrease = angleA - history.A;
                param1.interval = DataBus.FormMainActiveInterval;
                MyAnimation.AsyncActiveDrawPie(param1);
                g.FillRectangle(new SolidBrush(Color.White), rectangle1.X, 115, 100, 20);
                g.DrawString(Allocation.A.ToString() + "/" + Max.A.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle1.X + 30, 115);
                MyDrawParam param2 = new MyDrawParam(g);
                param2.positionRectangle = rectangle2;
                param2.angleBegin = -90 + history.B;
                param2.angleIncrease = angleB - history.B;
                param2.interval = DataBus.FormMainActiveInterval;
                MyAnimation.AsyncActiveDrawPie(param2);
                g.FillRectangle(new SolidBrush(Color.White), rectangle2.X, 115, 100, 20);
                g.DrawString(Allocation.B.ToString() + "/" + Max.B.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle2.X + 30, 115);
                MyDrawParam param3 = new MyDrawParam(g);
                param3.positionRectangle = rectangle2;
                param3.angleBegin = -90 + history.B;
                param3.angleIncrease = angleB - history.B;
                param3.interval = DataBus.FormMainActiveInterval;
                MyAnimation.AsyncActiveDrawPie(param3);
                //activeDrawPie(g, change_brush, warn_brush, rectangle3, -90+history.C, angleC - history.C,100);
                g.FillRectangle(new SolidBrush(Color.White), rectangle3.X, 115, 100, 20);
                g.DrawString(Allocation.C.ToString() + "/" + Max.C.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle3.X + 30, 115);
                history.A = angleA;
                history.B = angleB;
                history.C = angleC;


            }
        }

        private void barReset()//更新trackbar
        {
                trackBarA.Maximum = myOperator.available.A;
                trackBarB.Maximum = myOperator.available.B;
                trackBarC.Maximum = myOperator.available.C;
                label_AM.Text = myOperator.available.A.ToString();
                label_BM.Text = myOperator.available.B.ToString();
                label_CM.Text = myOperator.available.C.ToString();
        }
        private void button_confrim_click(object sender, EventArgs e)//开始按钮被点击
        {
            if (switchFlag == false)//判断使用的是静态
            {
                if (myOperator.addRequest(trackBarA.Value, trackBarB.Value, trackBarC.Value, comboBox_selectProcess.SelectedItem.ToString()))//申请成功
                {
                    //更新数据，绘制图形
                    barReset();
                    update_draw(sender, e);
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
            else if(switchFlag==true)//判断使用的是动态
            {
                ActiveRun(sender, e);//使用动态方式
            }
        }
        //实时更新trackbar对应的label
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


        private void ActiveRun(object sender, EventArgs e)//算法动态展示
        {
            FormOperating formOperating = new FormOperating(this.myOperator,new Resourse(trackBarA.Value, trackBarB.Value, trackBarC.Value), comboBox_selectProcess.SelectedItem.ToString());
            formOperating.StartPosition = FormStartPosition.CenterScreen;
            formOperating.Show();
            update_draw(sender, e);
            formOperating.TransfEvent +=new FormOperating.TransfDelegate(refresh);
        }
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

        private void ResetAll(object sender, EventArgs e)//重置所有值
        {
            
            this.myOperator = new AlgorithmOperator(dic);
            refresh();
        }


        private void groupBox_default_Paint(object sender, PaintEventArgs e)//将背景初始化为白色
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void addInfo(ListBox listBox,int index)//默认模板的内容
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
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//模板选择模块的逻辑处理
        {
            if (comboBox_selectTemp.SelectedIndex != -1)
            {
                this.label_detail.Visible = true ;
                this.listBox_tempDetail.Visible = true;
                listBox_tempDetail.Items.Clear();
                addInfo(listBox_tempDetail, comboBox_selectTemp.SelectedIndex);

            }
        }

        private void useTemp_Click(object sender, EventArgs e)//使用模板运行按钮被点击
        {
            if(this.myOperator.available.A!=12|| this.myOperator.available.B != 5|| this.myOperator.available.C != 9)
            {
                MessageBox.Show("无法使用模板，因为你已经进行过资源分配，请点击刷新键重置后再使用模板");
                return;
            }
            switch (comboBox_selectTemp.SelectedIndex)//模板内容配置并以此生成算法动态展示界面
            {
                case -1:
                    {
                        MessageBox.Show("还未选择默认模板");
                        break;
                    }
                case 0:
                    {
                        myOperator.addRequest(2, 2, 2, "P0");
                        FormOperating formOperating = new FormOperating(this.myOperator, new Resourse(1,0,1),"P1");
                        formOperating.StartPosition = FormStartPosition.CenterScreen;
                        formOperating.Show();
                        update_draw(sender, e);
                        formOperating.TransfEvent += new FormOperating.TransfDelegate(refresh);
                        break;
                    }
                case 1:
                    {

                        FormOperating formOperating = new FormOperating(this.myOperator, new Resourse(4, 1, 1), "P3");
                        formOperating.Show();
                        update_draw(sender, e);
                        formOperating.TransfEvent += new FormOperating.TransfDelegate(refresh);
                        break;
                    }
                case 2:
                    {
                        myOperator.addRequest(3, 3, 3, "P4");
                        FormOperating formOperating = new FormOperating(this.myOperator, new Resourse(7, 0, 0), "P0");
                        formOperating.Show();
                        update_draw(sender, e);
                        formOperating.TransfEvent += new FormOperating.TransfDelegate(refresh);
                        break;
                    }
                case 3:
                    {
                        myOperator.addRequest(3, 3, 3, "P4");
                        FormOperating formOperating = new FormOperating(this.myOperator, new Resourse(8, 0, 0), "P0");
                        formOperating.Show();
                        update_draw(sender, e);
                        formOperating.TransfEvent += new FormOperating.TransfDelegate(refresh);
                        break;
                    }
                default:
                    {
                        listBox_tempDetail.Items.Add("出现了问题");
                        break;
                    }
            }
        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)//处理不同的退出该界面的情况
        {

            Console.WriteLine("Closed");
            if (outFlag == true)
            {
                //正常关闭
                Console.WriteLine("isButton");
            }
            //else if (this.button1.is)
            else
            {
                //是右上角关闭，则结束所有进程
                Console.WriteLine("Kill");
                getBack(1);
                //System.Diagnostics.Process.GetCurrentProcess().Kill(); // 杀掉进程
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)//返回上一界面重新配置参数
        {
            outFlag = true;
            this.Close();
            getBack(0);
            this.Dispose();
        }

    }
    //为方便处理而建立的角度集合类
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
