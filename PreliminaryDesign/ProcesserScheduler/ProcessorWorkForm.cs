using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Timers;
using System.Threading;
using System.Runtime.InteropServices;
using HZH_Controls;
using System.Drawing.Drawing2D;

namespace ProcesserScheduler
{
    public partial class ProcessorWorkForm : Form
    {
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指定动画持续的时间</param>
        /// <param name="dwFlags">指定动画类型，可以是一个或多个标志的组合。</param>
        /// <returns></returns>
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        //下面是可用的常量，根据不同的动画效果声明自己需要的
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果

        //public List<Processer> RepeatList { get; set; }

        ProcessorMainForm mainForm;
        public List<Processer> ReadyList { get; set; }
        public List<Processer> FinishedList { get; set; }
        public Processer RunningProcess { get; set; }
        public Graphics ReadyGraphics;
        public Graphics FinishedGraphics;
        public Graphics RunningGraphics;
        public Thread ProcessorThread;
        public ProcessorWorkForm()
        {
            InitializeComponent();
            //初始化控件     
            Rectangle re = new Rectangle(0, 0, 10, 10);
            Graphics g = this.CreateGraphics();
            Draw(re, g, 2);
        }

        public ProcessorWorkForm(List<Processer> processerList,ProcessorMainForm mainForm):this()
        {
            this.mainForm = mainForm;
            ReadyList = SortListByPriority(processerList);
            //RepeatList = ReadyList;
            FinishedList = new List<Processer>();
            RunningProcess = null;
            
        }

        List<Processer> SortListByPriority(List<Processer> processerList)
        {
            List<Processer> SortList = (from a in processerList
                                        orderby a.priority descending
                                        select a
                                        ).ToList();
            return SortList;
        }

        //绘制圆角矩形
        public  GraphicsPath GetRoundRectPath(int x, int y, int width, int height, int radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, radius, radius, 180, 90);
            gp.AddArc(width - radius, y, radius, radius, 270, 90);
            gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            gp.AddArc(x, height - radius, radius, radius, 90, 90);
            gp.CloseAllFigures();
            return gp;
        }

        private void Draw(Rectangle rectangle, Graphics g, int _radius)
        {
            Pen shadowPen = new Pen(Color.Blue);
            g.DrawPath(shadowPen, GetRoundRectPath(rectangle.X, rectangle.Y, rectangle.Width - 2, rectangle.Height - 1, _radius));
        }

        public void ReadyPaint()
        {
            if(ReadyGraphics == null) ReadyGraphics = this.pnl_ready.CreateGraphics();
            ReadyGraphics.Clear(BackColor);
            //int x = pnl_ready.Left - 20;
            //int y = pnl_ready.Top - 30;
            int x = 4;
            int y = 5;
            DrawReadyProcesser(ReadyList, x, y, ReadyGraphics);
        }

        public void FinishedPaint()
        {
            if(FinishedGraphics == null) FinishedGraphics = this.pnl_finished.CreateGraphics();
            FinishedGraphics.Clear(BackColor);
            int x = 4;
            int y = 5;
            DrawFinishedProcesser(FinishedList, x, y, FinishedGraphics);
        }

        public void RunningPaint()
        {
            if(RunningGraphics == null) RunningGraphics = this.pnl_running.CreateGraphics();
            RunningGraphics.Clear(BackColor);
            int x = 4;
            int y = 5;
            DrawRunningProcesser(RunningProcess, x, y, RunningGraphics);
        }

        //绘制就绪队列
        public void DrawReadyProcesser(List<Processer> list,int x, int y,Graphics g)
        {
            int initialX = x;
            int initialY = y;
            int count = 0;
            foreach (Processer p in list)
            {
                x = initialX + count * 70;
                if (x > initialX + 210)
                {
                    x = initialX;
                    y = initialY +  70;
                }
                //优先级次序  1-3 黄  4-6 橙 7-9 红 10-12 紫
                SolidBrush purpleb = new SolidBrush(Color.Purple);
                SolidBrush redb = new SolidBrush(Color.Red);
                SolidBrush orangeb = new SolidBrush(Color.Orange);
                SolidBrush yellowb = new SolidBrush(Color.Yellow);
                SolidBrush blackb = new SolidBrush(Color.Black);


                Font font = new Font("宋体", 24);
                Rectangle rec = new Rectangle(x, y, 50, 50);
                g.DrawRectangle(new Pen(Color.Black), rec);
                int n = (p.priority - 1) / 3;
                if (n <= 0)
                {
                    n = 0;
                }
                switch (n)
                {
                    case 0:
                        g.FillRectangle(yellowb, rec);
                        break;
                    case 1:
                        g.FillRectangle(orangeb, rec);
                        break;
                    case 2:
                        g.FillRectangle(redb, rec);
                        break;
                    case 3:
                        g.FillRectangle(purpleb, rec);
                        break;
                }

                //绘制字符
                g.DrawString(p.Name, font, blackb, x, y);
                count++;
            }
        }

        //绘制结束队列
        public void DrawFinishedProcesser(List<Processer> list, int x, int y, Graphics g)
        {
            int initialX = x;
            int initialY = y;
                        
            int count = 0;
            foreach(Processer p in list)
            {
                x = initialX + count * 70;
                if (x > initialX + 210)
                {
                    x = initialX;
                    y = initialY + 70;
                }
                SolidBrush whiteb = new SolidBrush(Color.White);
                SolidBrush blackb = new SolidBrush(Color.Black);

                Font font = new Font("宋体", 24);
                Rectangle rec = new Rectangle(x, y, 50, 50);
                g.DrawRectangle(new Pen(Color.Black), rec);
                g.FillRectangle(whiteb, rec);
                //绘制字符
                g.DrawString(p.Name, font, blackb, x, y);
                count++;
            }
        }

        //绘制正在运行进程
        public void DrawRunningProcesser(Processer p, int x, int y, Graphics g)
        {
            if(p == null)
            {
                return;
            }

            x += 70;

            SolidBrush greenb = new SolidBrush(Color.Green);
            SolidBrush blackb = new SolidBrush(Color.Black);

            Font font = new Font("宋体", 64);
            Rectangle rec = new Rectangle(x, y, 100, 100);
            g.DrawRectangle(new Pen(Color.Black), rec);
            g.FillRectangle(greenb, rec);

            //绘制字符
            g.DrawString(p.Name, font, blackb, x, y);
        }

        //更新提示信息
        public void UpdatePrompt(string info)
        {
            this.rtx_prompt.AppendText(info);
            this.rtx_prompt.ScrollToCaret();
        }

        public void ProcessorScheduling()
        { 
            //开始进程调度
            while(ReadyList.Count > 0)
            {
                RunningProcess = ReadyList[0];
                lock(ReadyList)
                {
                    ReadyList.RemoveAt(0);
                }

                if(this.rtx_prompt.InvokeRequired)
                {
                    Action<string> action = this.UpdatePrompt;
                    this.Invoke(action, new object[] { $"当前运行进程为{RunningProcess.Name}\n" });
                }
                else
                {
                    UpdatePrompt($"当前运行进程为{RunningProcess.Name}\n");
                }

                ReadyPaint();
                RunningPaint();
                RunningProcess.Run();

                //一段很不好的等待方法，很粗暴
                DateTime now = DateTime.Now;
                DateTime end = now.AddSeconds(2);
                do
                {

                } while((DateTime.Now - end).Seconds < 0);

                if(RunningProcess.state == STATE.FINISH)
                {
                    FinishedList.Add(RunningProcess);

                    if(this.rtx_prompt.InvokeRequired)
                    {
                        Action<string> action = this.UpdatePrompt;
                        this.Invoke(action, new object[] { $"进程{RunningProcess.Name}运行结束\n" });
                    }
                    else
                    {
                        UpdatePrompt($"进程{RunningProcess.Name}运行结束\n");
                    }

                    RunningProcess = null;
                    FinishedPaint();
                    RunningPaint();
                }
                else
                {
                    lock(ReadyList)
                    {
                        ReadyList.Add(RunningProcess);
                        ReadyList = SortListByPriority(ReadyList);
                    }

                    if(this.rtx_prompt.InvokeRequired)
                    {
                        Action<string> action = this.UpdatePrompt;
                        this.Invoke(action, new object[] { $"进程{RunningProcess.Name}重新插入到就绪队列\n" });
                        this.Invoke(action, new object[] { $"当前优先数为{RunningProcess.priority}，剩余运行时间为{RunningProcess.requestTime}\n" });
                    }
                    else
                    {
                        UpdatePrompt($"进程{RunningProcess.Name}重新插入到就绪队列\n");
                        UpdatePrompt($"当前优先数为{RunningProcess.priority}，剩余运行时间为{RunningProcess.requestTime}\n");
                    }

                    RunningProcess = null;
                    ReadyPaint();
                    RunningPaint();
                }

                //一段很不好的等待方法，很粗暴
                now = DateTime.Now;
                end = now.AddSeconds(2);
                do
                {

                } while((DateTime.Now - end).Seconds < 0);
            }

            if(this.rtx_prompt.InvokeRequired)
            {
                Action<string> action = this.UpdatePrompt;
                this.Invoke(action, new object[] { "就绪队列为空，所有进程运行结束\n" });
            }
            else
            {
                UpdatePrompt("就绪队列为空，所有进程运行结束\n");
            }
        }

        //从Form2也能直接退出
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //开始前显示就绪队列
        private void pnl_ready_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            int x = 4;
            int y = 5;
            DrawReadyProcesser(ReadyList, x, y, e.Graphics);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //界面居中
            this.SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
            (Screen.GetBounds(this).Height / 2) - (this.Height / 2),
            this.Width, this.Height, BoundsSpecified.Location);

            //窗体加载动画效果
            AnimateWindow(this.Handle, 300, AW_SLIDE | AW_ACTIVE | AW_VER_POSITIVE);
        }

        private void ucBtn_start_BtnClick(object sender, EventArgs e)
        {
            ProcessorThread = new Thread(this.ProcessorScheduling);
            ProcessorThread.Start();
        }

        private void ucBtn_replay_BtnClick(object sender, EventArgs e)
        {
            //因为List深拷贝的原因暂时没实现
            //ReadyList = RepeatList;
            //FinishedList.Clear();
            //RunningProcess = null;
            //this.rtx_prompt.Clear();
            //ReadyPaint();
            //FinishedPaint();
            //RunningPaint();
            //ProcessorScheduling();
        }

        private void ucBtn_back_BtnClick(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            mainForm.Show();
        }

        private void ucBtn_add_BtnClick(object sender, EventArgs e)
        {
            //string name = this.txt_name.Text;
            //int priority = Convert.ToInt16(this.txt_priority.Text);
            //int time = Convert.ToInt16(this.txt_time.Text);
            //Processer p = new Processer(name, priority, time);
            bool ThreadAlive;
            int flag = 0;
            string name;
            int priority;
            int time;
            string title = "添加进程";
            string[] inputLabels = { "进程名", "优先数", "要求运行时间" };
            List<string> mustIputs = new List<string>();
            Dictionary<string, TextInputType> inTypes = new Dictionary<string, TextInputType>();

            //添加必选项
            foreach (string var in inputLabels)
            {
                mustIputs.Add(var);
            }

            if (ProcessorThread != null)
            {
                if (ThreadAlive = ProcessorThread.IsAlive)
                {
                    ProcessorThread.Suspend();
                    UpdatePrompt($"等待加入新进程...\n");
                }
            }
            else
            {
                ThreadAlive = false;
            }

            HZH_Controls.Forms.FrmInputs addForm = new HZH_Controls.Forms.FrmInputs
                                                       (title, inputLabels,null,null,null,mustIputs,null);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                //简单的参数获取实现
                foreach(Processer var in ReadyList)
                {
                    if (var.Name == addForm.Values[0])
                    {
                        //第一效果应该是消息提示
                        //HZH_Controls.Forms.FrmTips.ShowTipsInfo(this, "不允许出现相同进程名");
                        flag = 1;
                        //这里通过自己添加数字消除重复
                        addForm.Values[0] = addForm.Values[0] + "1";
                        break;
                    }
                }

                name = addForm.Values[0];
                priority = Convert.ToInt32(addForm.Values[1]);
                time = Convert.ToInt32(addForm.Values[2]);
    
                if (ThreadAlive)
                {
                    ProcessorThread.Resume();
                }
            }              
            else
            {
                if (ThreadAlive)
                {
                    ProcessorThread.Resume();
                }
                return;
            }
            Processer p = new Processer(name, priority, time);
            lock (ReadyList)
            {
                ReadyList.Add(p);
                ReadyList = SortListByPriority(ReadyList);
            }
            UpdatePrompt($"进程{name}加入就绪队列\n");
            ReadyPaint();

        }
    }
}
