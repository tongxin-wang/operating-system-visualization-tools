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

namespace ProcessorScheduling
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

        //public List<Process> RepeatList { get; set; }

        ProcessorMainForm mainForm;
        public GraphicsDraw graphicsDraw;
        public Algorithm algorithm;
        public Thread ProcessorThread;
        public ProcessorWorkForm()
        {
            InitializeComponent();
            Graphics ReadyGraphics = this.pnl_ready.CreateGraphics();
            Graphics FinishedGraphics = this.pnl_finished.CreateGraphics();
            Graphics RunningGraphics = this.pnl_running.CreateGraphics();
            graphicsDraw = new GraphicsDraw
            {
                BackColor = this.BackColor,
                ReadyGraphics = ReadyGraphics,
                FinishedGraphics = FinishedGraphics,
                RunningGraphics = RunningGraphics
            };
        }

        public ProcessorWorkForm(List<Process> InitialList,ProcessorMainForm mainForm):this()
        {
            this.mainForm = mainForm;

            algorithm = new Algorithm(InitialList);
            algorithm.Prompt += UpdatePrompt;
            algorithm.ReadyDraw += graphicsDraw.ReadyPaint;
            algorithm.FinishedDraw += graphicsDraw.FinishedPaint;
            algorithm.RunningDraw += graphicsDraw.RunningPaint;
        }

        List<Process> SortListByPriority(List<Process> processesList)
        {
            List<Process> SortList = (from a in processesList
                                        orderby a.priority descending
                                        select a
                                        ).ToList();
            return SortList;
        }

        //更新提示信息
        public void UpdatePrompt(string info)
        {
            Action action = () =>
            {
                this.rtx_prompt.AppendText(info);
                this.rtx_prompt.ScrollToCaret();
            };

            if(this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        //从Form2也能直接退出
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Close();
        }

        //开始前显示就绪队列
        private void pnl_ready_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            int x = 4;
            int y = 5;
            graphicsDraw.DrawReadyProcesses(algorithm.ReadyList, x, y, e.Graphics);
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
            ProcessorThread = new Thread(algorithm.ProcessorScheduling);
            ProcessorThread.Start();
        }

        private void ucBtn_replay_BtnClick(object sender, EventArgs e)
        {
            //因为List深拷贝的原因暂时没实现
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
            //Process p = new Process(name, priority, time);
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
                foreach(Process var in algorithm.ReadyList)
                {
                    if (var.Name == addForm.Values[0])
                    {
                        //第一效果应该是消息提示
                        //HZH_Controls.Forms.FrmTips.ShowTipsInfo(this, "不允许出现相同进程名");
                        flag = 1;
                        //这里通过自己添加数字消除重复
                        addForm.Values[0] = addForm.Values[0] + "1";
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

            algorithm.AddReadyProcess(name, priority, time);
        }
    }
}
