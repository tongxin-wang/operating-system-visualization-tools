using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorScheduling
{
    public enum STATE
    {
        READY,
        RUN,
        FINISH
    }


    public class Process
    {
        public string Name { get; set; }
        public int priority { get; set; }
        public int requestTime { get; set; }
        //表示状态  0-完成, 1-运行, 2-就绪
        public STATE state { get; set; }

        public Process(string name,int priority,int requestTime)
        {
            this.Name = name;
            this.priority = priority;
            this.requestTime = requestTime;
            this.state = STATE.READY;
        }


        //运行模拟
        public void Run()
        {
            //设置成运行态
            this.state = STATE.RUN;

            this.requestTime--;
            if (this.requestTime!=0)
            {
                this.priority--;
                this.state = STATE.READY;
            }
            else
            {
                //运行结束，当前进程完成
                this.state = STATE.FINISH;
            }
        }

        public int Cut(int num)
        {
            Random rd = new Random();
            int n = rd.Next(1, 3);
            if (num >= n)
            {
                return num - n;
            }
            else
            {
                return 0;
            }
        }
    }

}
