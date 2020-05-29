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
using Timer = System.Windows.Forms.Timer;

namespace BankerAlgorithm
{
    public class MyAnimation
    {
        private Form form;
        public MyAnimation(Form form)
        {
            if(form is FormMain)
            {
                this.form = (FormMain)form;
                
            }

        }
        public static void AsyncActiveDrawPie(Graphics graphics, SolidBrush solidBrush, SolidBrush solidBrush2, Rectangle rectangle, float angle1, float angle2, int interval)
        {
            Timer timer = new Timer();
            timer.Interval = interval;
            int Tick = 0;
            timer.Tick += new EventHandler((o, e) => AsyncactivePieEvent(graphics, solidBrush, solidBrush2, rectangle, angle1, angle2, timer, ref Tick));
            timer.Start();
        }
        private static void AsyncactivePieEvent(Graphics graphics, SolidBrush solidBrush, SolidBrush solidBrush2, Rectangle rectangle, float angle1, float angle2, Timer timer, ref int Tick)
        {
            //Console.WriteLine("被调用");
            if (Tick > angle2)
            {
                timer.Stop();
                //Console.WriteLine("Finish");
                return;
            }
            if (Tick < 270 - angle1)
                graphics.FillPie(solidBrush, rectangle, angle1 + Tick, angle2 > Tick + 5 ? 5 : angle2 - Tick);
            else
                graphics.FillPie(solidBrush2, rectangle, angle1 + Tick, angle2 > Tick + 5 ? 5 : angle2 - Tick);
            Tick += 5;
        }
        public static void SyncPreDrawPie(Graphics graphics, SolidBrush solidBrush, SolidBrush solidBrush2, Rectangle rectangle, float angle1, float angle2, int interval)
        {
            float Tick = 0;
            //Console.WriteLine("被调用");
            while (true)
            {
                if (Tick == angle2)
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
        public static void SyncActiveDrawPie(Graphics graphics, SolidBrush solidBrush, SolidBrush solidBrush2, Rectangle rectangle, float angle1, float angle2, int interval)
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


    }
}
