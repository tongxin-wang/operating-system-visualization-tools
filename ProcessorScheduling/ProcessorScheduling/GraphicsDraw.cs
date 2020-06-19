using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorScheduling
{
    public class GraphicsDraw
    {
        public Color BackColor { get; set; }
        public Graphics ReadyGraphics { get; set; }
        public Graphics FinishedGraphics { get; set; }
        public Graphics RunningGraphics { get; set; }

        public void ReadyPaint(List<Process> ReadyList)
        {
            ReadyGraphics.Clear(BackColor);
            //int x = pnl_ready.Left - 20;
            //int y = pnl_ready.Top - 30;
            int x = 4;
            int y = 5;
            DrawReadyProcesses(ReadyList, x, y, ReadyGraphics);
        }

        public void FinishedPaint(List<Process> FinishedList)
        {
            FinishedGraphics.Clear(BackColor);
            int x = 4;
            int y = 5;
            DrawFinishedProcesses(FinishedList, x, y, FinishedGraphics);
        }

        public void RunningPaint(Process RunningProcess)
        {
            RunningGraphics.Clear(BackColor);
            int x = 4;
            int y = 5;
            DrawRunningProcess(RunningProcess, x, y, RunningGraphics);
        }

        //绘制就绪队列
        public void DrawReadyProcesses(List<Process> list, int x, int y, Graphics g)
        {
            int initialX = x;
            int initialY = y;
            int count = 0;
            foreach(Process p in list)
            {
                x = initialX + count * 70;
                if(x > initialX + 210)
                {
                    x = initialX;
                    y = initialY + 70;
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
                if(n <= 0)
                {
                    n = 0;
                }
                switch(n)
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
        public void DrawFinishedProcesses(List<Process> list, int x, int y, Graphics g)
        {
            int initialX = x;
            int initialY = y;

            int count = 0;
            foreach(Process p in list)
            {
                x = initialX + count * 70;
                if(x > initialX + 210)
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
        public void DrawRunningProcess(Process p, int x, int y, Graphics g)
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
    }
}
