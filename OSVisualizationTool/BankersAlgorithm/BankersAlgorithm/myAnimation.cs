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
        public static void AsyncActiveDrawPie(MyDrawParam myDrawParam)
        {
            Timer timer = new Timer();
            timer.Interval = myDrawParam.interval;
            int Tick = 0;
            timer.Tick += new EventHandler((o, e) => AsyncactivePieEvent(myDrawParam, timer, ref Tick));
            timer.Start();
        }
        private static void AsyncactivePieEvent(MyDrawParam myDrawParam, Timer timer, ref int Tick)
        {
            //Console.WriteLine("被调用");
            if (Tick > myDrawParam.angleEnd)
            {
                timer.Stop();
                //Console.WriteLine("Finish");
                return;
            }
            if (Tick < 270 - myDrawParam.angleBegin)
                myDrawParam.graphics.FillPie(myDrawParam.mainBrush, myDrawParam.positionRectangle, myDrawParam.angleBegin + Tick, myDrawParam.angleEnd > Tick + 5 ? 5 : myDrawParam.angleEnd - Tick);
            else
                myDrawParam.graphics.FillPie(myDrawParam.backupBrush, myDrawParam.positionRectangle, myDrawParam.angleBegin + Tick, myDrawParam.angleEnd > Tick + 5 ? 5 : myDrawParam.angleEnd - Tick);
            Tick += 5;
        }
        public static void SyncPreDrawPie(MyDrawParam myDrawParam)
        {
            float Tick = 0;
            //Console.WriteLine("被调用");
            while (true)
            {
                if (Tick == myDrawParam.angleEnd)
                {
                    if (Tick < 270 - myDrawParam.angleBegin)
                    {
                        myDrawParam.graphics.DrawImage(Properties.Resources.x, myDrawParam.positionRectangle);
                        myDrawParam.graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Gray)), 0, 0, 405, 148);
                        //Console.WriteLine("Tick=" + Tick + " angleEnd=" + angleEnd);
                        return;
                        //Console.WriteLine("Finish");
                    }
                    else
                    {
                        myDrawParam.graphics.DrawImage(Properties.Resources.benefits, myDrawParam.positionRectangle);
                        return;
                    }
                }
                if (Tick < 270 - myDrawParam.angleBegin)
                    myDrawParam.graphics.FillPie(myDrawParam.mainBrush, myDrawParam.positionRectangle, myDrawParam.angleBegin + Tick, myDrawParam.angleEnd > Tick + 5 ? 5 : myDrawParam.angleEnd - Tick);
                else
                {
                    myDrawParam.graphics.DrawImage(Properties.Resources.benefits, myDrawParam.positionRectangle);
                    return;
                }
                Tick += (myDrawParam.angleEnd > Tick + 5 ? 5 : myDrawParam.angleEnd - Tick);
                Thread.Sleep(myDrawParam.interval);
            }
        }
        public static void SyncActiveDrawPie(MyDrawParam myDrawParam)
        {
            int Tick = 0;
            //if(angleEnd==0)

            //Console.WriteLine("被调用");
            while (true)
            {
                if (Tick > myDrawParam.angleEnd)
                {
                    return;
                    //Console.WriteLine("Finish");
                }
                if (Tick < 270 - myDrawParam.angleBegin)
                    myDrawParam.graphics.FillPie(myDrawParam.mainBrush, myDrawParam.positionRectangle, myDrawParam.angleBegin + Tick, myDrawParam.angleEnd > Tick + 5 ? 5 : myDrawParam.angleEnd - Tick);
                else
                    myDrawParam.graphics.FillPie(myDrawParam.backupBrush, myDrawParam.positionRectangle, myDrawParam.angleBegin + Tick, myDrawParam.angleEnd > Tick + 5 ? 5 : myDrawParam.angleEnd - Tick);
                Tick += 5;
                Thread.Sleep(myDrawParam.interval);
            }
        }


    }
}
