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
using BankerAlgorithm;

namespace OsVisualTools
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
        public static void AsyncActiveDrawPie(MyDrawParam myDrawParam)//三个资源同步绘制
        {
            Timer timer = new Timer();
            timer.Interval = myDrawParam.interval;
            int Tick = 0;
            timer.Tick += new EventHandler((o, e) => AsyncactivePieEvent(myDrawParam, timer, ref Tick));
            timer.Start();
        }
        private static void AsyncactivePieEvent(MyDrawParam myDrawParam, Timer timer, ref int Tick)//同步绘制的时钟事件
        {
            if (Tick > myDrawParam.angleIncrease)
            {
                timer.Stop();
                //Console.WriteLine("Finish");
                return;
            }
            if (Tick < 270 - myDrawParam.angleBegin)//正常绘制
                myDrawParam.graphics.FillPie(myDrawParam.mainBrush, myDrawParam.positionRectangle, myDrawParam.angleBegin + Tick, myDrawParam.angleIncrease > Tick + 5 ? 5 : myDrawParam.angleIncrease - Tick);
            else//超出最大值则换为警示颜色
                myDrawParam.graphics.FillPie(myDrawParam.backupBrush, myDrawParam.positionRectangle, myDrawParam.angleBegin + Tick, myDrawParam.angleIncrease > Tick + 5 ? 5 : myDrawParam.angleIncrease - Tick);
            Tick += 5;
        }
        public static void SyncPreDrawPie(MyDrawParam myDrawParam)//尝试分配资源的三个资源异步绘制
        {
            float Tick = 0;
            //Console.WriteLine("被调用");
            while (true)
            {
                if (Tick == myDrawParam.angleIncrease)//正好够时作为特殊情况判断
                {
                    if (Tick < 270 - myDrawParam.angleBegin)//空闲资源不够满足进程
                    {
                        myDrawParam.graphics.DrawImage(Properties.Resources.x, myDrawParam.positionRectangle);//显示叉号
                        myDrawParam.graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Gray)), 0, 0, 405, 148);
                        //Console.WriteLine("Tick=" + Tick + " angleEnd=" + angleEnd);
                        return;
                        //Console.WriteLine("Finish");
                    }
                    else
                    {
                        myDrawParam.graphics.DrawImage(Properties.Resources.benefits, myDrawParam.positionRectangle);//打勾
                        return;
                    }
                }
                if (Tick < 270 - myDrawParam.angleBegin)//没够，继续画
                    myDrawParam.graphics.FillPie(myDrawParam.mainBrush, myDrawParam.positionRectangle, myDrawParam.angleBegin + Tick, myDrawParam.angleIncrease > Tick + 5 ? 5 : myDrawParam.angleIncrease - Tick);
                else
                {
                    myDrawParam.graphics.DrawImage(Properties.Resources.benefits, myDrawParam.positionRectangle);//打勾
                    return;
                }
                Tick += (myDrawParam.angleIncrease > Tick + 5 ? 5 : myDrawParam.angleIncrease - Tick);//下一帧绘制的角度
                Thread.Sleep(myDrawParam.interval);
            }
        }
        public static void SyncActiveDrawPie(MyDrawParam myDrawParam)//直接分配资源的三个资源异步绘制
        {
            int Tick = 0;
            //if(angleEnd==0)

            //Console.WriteLine("被调用");
            while (true)
            {
                if (Tick > myDrawParam.angleIncrease)
                {
                    return;
                    //Console.WriteLine("Finish");
                }
                if (Tick < 270 - myDrawParam.angleBegin)
                    myDrawParam.graphics.FillPie(myDrawParam.mainBrush, myDrawParam.positionRectangle, myDrawParam.angleBegin + Tick, myDrawParam.angleIncrease > Tick + 5 ? 5 : myDrawParam.angleIncrease - Tick);
                else
                    myDrawParam.graphics.FillPie(myDrawParam.backupBrush, myDrawParam.positionRectangle, myDrawParam.angleBegin + Tick, myDrawParam.angleIncrease > Tick + 5 ? 5 : myDrawParam.angleIncrease - Tick);
                Tick += 5;
                Thread.Sleep(myDrawParam.interval);
            }
        }


    }
}
