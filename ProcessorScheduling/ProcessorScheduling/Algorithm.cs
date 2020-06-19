using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorScheduling
{
    public class Algorithm
    {
        public event Action<string> Prompt;
        public event Action<List<Process>> ReadyDraw;
        public event Action<List<Process>> FinishedDraw;
        public event Action<Process> RunningDraw;

        public List<Process> ReadyList { get; set; }
        public List<Process> FinishedList { get; set; }
        public Process RunningProcess { get; set; }

        public Algorithm(List<Process> InitialList)
        {
            ReadyList = SortListByPriority(InitialList);
            FinishedList = new List<Process>();
            RunningProcess = null;
        }

        public void AddReadyProcess(string name, int priority, int time)
        {
            Process p = new Process(name, priority, time);
            lock(ReadyList)
            {
                ReadyList.Add(p);
                ReadyList = SortListByPriority(ReadyList);
            }
            Prompt($"进程{name}加入就绪队列\n");
            ReadyDraw(ReadyList);
        }

        public List<Process> SortListByPriority(List<Process> processesList)
        {
            List<Process> SortList = (from a in processesList
                                      orderby a.priority descending
                                      select a
                                        ).ToList();
            return SortList;
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

                Prompt($"当前运行进程为{RunningProcess.Name}\n");

                ReadyDraw(ReadyList);
                RunningDraw(RunningProcess);
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

                    Prompt($"进程{RunningProcess.Name}运行结束\n");

                    RunningProcess = null;
                    FinishedDraw(FinishedList);
                    RunningDraw(RunningProcess);
                }
                else
                {
                    lock(ReadyList)
                    {
                        ReadyList.Add(RunningProcess);
                        ReadyList = SortListByPriority(ReadyList);
                    }

                    Prompt($"进程{RunningProcess.Name}重新插入到就绪队列\n");
                    Prompt($"当前优先数为{RunningProcess.priority}，剩余运行时间为{RunningProcess.requestTime}\n");

                    RunningProcess = null;
                    ReadyDraw(ReadyList);
                    RunningDraw(RunningProcess);
                }

                //一段很不好的等待方法，很粗暴
                now = DateTime.Now;
                end = now.AddSeconds(2);
                do
                {

                } while((DateTime.Now - end).Seconds < 0);
            }

            Prompt("就绪队列为空，所有进程运行结束\n");
        }
    }
}
