using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankerAlgorithm
{
	public class Functions
	{
		public static bool AsB(Resourse a, Resourse b)
		{
			if (a.A <= b.A && a.B <= b.B && a.C <= b.C)
				return true;
			return false;
		}
		public static void AddTo(ref Resourse a, Resourse b)
		{
			a.A += b.A;
			a.B += b.B;
			a.C += b.C;
		}
		public static void MinTo(ref Resourse a, Resourse b)
		{
			a.A -= b.A;
			a.B -= b.B;
			a.C -= b.C;
		}

	}
	public class Resourse
	{
		public int A { get; set; }
		public int B { get; set; }
		public int C { get; set; }
		public Resourse(int a, int b, int c)
		{
			A = a;
			B = b;
			C = c;
		}
		public Resourse() { }
		//用于创建深拷贝副本，主要在传参时使用
		public Resourse Clone()
		{
			Resourse r = new Resourse(this.A, this.B, this.C);
			return r;
		}
	};
	public class Process
	{

		public string name;
		public Resourse Max=new Resourse();
		public Resourse Allocation = new Resourse(0, 0, 0);
		public Resourse Need;
		public Process(string name, int a, int b, int c)
		{
			this.name = name;
			Max.A = a;
			Max.B = b;
			Max.C = c;
			Need = Max.Clone();
		}
		public Process(string name, Resourse max)
		{
			this.name = name;
			Max = max;
			Need = Max.Clone();
		}
		public bool Demand(ref Resourse Available, Resourse demand)
		{
			//成功了才变，没成功不变
			if (Functions.AsB(demand, Available) && Functions.AsB(demand, this.Need))
			{
				//Console.WriteLine("1时的Max" + this.Max.A+ this.Max.B + this.Max.C );
				Functions.MinTo(ref Available, demand);
				//Console.WriteLine("2时的Max" + this.Max.A + this.Max.B + this.Max.C);
				Functions.AddTo(ref this.Allocation, demand);
				//Console.WriteLine("3时的Max" + this.Max.A + this.Max.B + this.Max.C);
				Functions.MinTo(ref this.Need, demand);
				//Console.WriteLine("4时的Max" + this.Max.A + this.Max.B + this.Max.C);
				return true;
			}
			else
			{
				return false;
			}
		}
		public Process Clone()
		{
			Process p = new Process(this.name, this.Max.Clone());
			p.Allocation = this.Allocation.Clone();
			p.Need = this.Need.Clone();
			return p;
		}
	};
    public class AlgorithmOperator
    {

		void init( List<Process> processList)
		{

			Process P0 = new Process("P0", 8, 5, 3);
			processList.Add(P0);
			Process P1 = new Process("P1", 3, 2, 3);
			processList.Add(P1);
			Process P2 = new Process("P2", 9, 0, 3);
			processList.Add(P2);
			Process P3 = new Process("P3", 2, 2, 2);
			processList.Add(P3);
			Process P4 = new Process("P4", 5, 3, 3);
			processList.Add(P4);
		}
		bool CheckNewDemand(string name, Resourse demand2, Resourse Available2, List<Process> processList2)
		{
			List<Process> processList = new List<Process>();
			processList2.ForEach(i => processList.Add(i.Clone()));
			//printPro(processList,available);
			Resourse Available = Available2.Clone();
			Resourse demand = demand2.Clone();
			//cout << "进入检查状态" << endl;
			for (int i = 0; i < processList.Count; i++)
			{
				if (processList[i].name != name)
					continue;
				if (!processList[i].Demand(ref Available, demand))//Demand 有问题
				{
					Console.WriteLine("错误出口1");
					return false;
				}
				else
				{
					//printPro(processList, Available);
					List<bool> map = new List<bool>(new bool[]{ false, false, false, false, false }) ;
					//map[i] = true;
					//cout << "进入复查状态" << endl;
					return CheckStatus(Available, processList,ref map);
				}
			}
			Console.WriteLine("错误出口2");
			return false;
		}
		bool CheckStatus(Resourse Available2, List<Process> processList2, ref List<bool> map)
		{

			List<Process> processList = new List<Process>();
			processList2.ForEach(i => processList.Add(i.Clone()));
			Resourse Available = Available2.Clone();
			//cout << "复查被调用"<<endl;
			//Console.WriteLine("map状态：" + map[0] + map[1] + map[2] + map[3] + map[4]);
			int count = 0;
			foreach (var each in map)
			{
				if (each == false)
					break;
				count++;
			}
			if (count == 5)
			{
				return true;
			}
			for (int i = 0; i < processList.Count; i++)
			{
				if (map[i] == true)
					continue;
				if (Functions.AsB(processList[i].Need, Available))
				{
					if (processList[i].Demand(ref Available, processList[i].Need))
					{
						map[i] = true;
						Functions.AddTo(ref Available, processList[i].Max);//这一步应当还原了available
						if (CheckStatus(Available, processList,ref map))
						{
							return true;
						}

					}
				}
				
			}
			Console.WriteLine("错误出口3");
			return false;
		}
		void printRes(Resourse r)
		{
				Console.Write(r.A + "," + r.B + "," + r.C + ";");
		}
		public void printPro(List<Process> processList, Resourse Available)
		{
			foreach (var each in processList)
			{
				Console.WriteLine("name:" + each.name);
				Console.Write("MAX:"); printRes(each.Max); Console.Write(" Allocation:"); printRes(each.Allocation); Console.Write("Need:"); printRes(each.Need);
				Console.WriteLine();
			}

			Console.WriteLine("Available:"+ Available.A+","+ Available.B+","+ Available.C);
		}
		public List<Process> ProcessList = new List<Process>();
		public Resourse available ;
		public AlgorithmOperator()
		{
			init(ProcessList);
			available = new Resourse(12, 5, 9);
			printPro(ProcessList, available);
		}
		public AlgorithmOperator(Dictionary<string,int> dic)
		{
			available = new Resourse(dic["SA"], dic["SB"], dic["SC"]);
			for(int i = 0; i < 5; i++)
			{
				Process process = new Process("P" + i, dic[i + "A"], dic[i + "B"], dic[i + "C"]);
				ProcessList.Add(process);
			}
		}
		/*
		 * -----------------------------------------------------------------------下方是异步绘制的区域---------------------------------------------------------------------------------------------------------------------------------------;
		 */

		#region
		//以下是所有的交由外部处理的事件接口
		public delegate void StrInfoTransferDelegate(string info);
		public event StrInfoTransferDelegate StrInfoTransfEvent;
		public delegate void DrawInfoTransferDelegate(int index, Resourse demand, Resourse historyHave, Resourse Max, Resourse available, int flag);
		public event DrawInfoTransferDelegate DrawInfoTransfEvent;
		public delegate void WarnInfoTransferDelegate(int index, string warn_word);
		public event WarnInfoTransferDelegate WarnInfoTransfEvent;
		public delegate void WithDrawTransferDelegate(Process process, List<bool> map, Resourse a, int index);
		public event WithDrawTransferDelegate WithDrawTransferEvent;
		public delegate void FlagChangeDelegate(int index,bool flag);
		public event FlagChangeDelegate FlagChangeEvent;
		public delegate void LabelChangeDelegate(Resourse available);
		public event LabelChangeDelegate LabelChangeEvent;

		public bool addRequestT(int A, int B, int C, string name)
		{
			Resourse demand = new Resourse(A, B, C);
			Task<bool> tMain = new Task<bool>(() => CheckNewDemandT(name, demand, available, ProcessList));
			tMain.Start();
			Task.WaitAll(tMain);
			if(tMain.Result)
			{
				//this.listBox.Items.Add("预分配成功！");
				StrInfoTransfEvent("预分配成功！");
				for (int i = 0; i < ProcessList.Count; i++)
				{
					Process each = ProcessList[i];
					if (each.name == name)
					{
						Functions.AddTo(ref each.Allocation, demand);
						Functions.MinTo(ref each.Need, demand);
						Functions.MinTo(ref available, demand);

					}
				}
				printPro(ProcessList, available);
				return true;
			}
			else
			{
				printPro(ProcessList, available);
				StrInfoTransfEvent("预分配失败！");
				return false;
			}

		}
		bool CheckNewDemandT(string name, Resourse demand2, Resourse Available2, List<Process> processList2)
		{
			List<Process> processList = new List<Process>();
			processList2.ForEach(i => processList.Add(i.Clone()));
			//printPro(processList,available);
			Resourse Available = Available2.Clone();
			Resourse demand = demand2.Clone();
			//遍历所有进程
			for (int i = 0; i < processList.Count; i++)
			{
				if (processList[i].name != name)
					continue;
				StrInfoTransfEvent("正在预分配中");
				DrawInfoTransfEvent(i, demand, processList[i].Allocation, processList[i].Max, this.available, 0);
				if (!processList[i].Demand(ref Available, demand))//找到了发出申请的进程
				{
					StrInfoTransfEvent("超出需要");
					WarnInfoTransfEvent(i, "数量错误,超出需要");
					return false;
				}
				else
				{
					//printPro(processList, Available);
					StrInfoTransfEvent("初步检测通过，开始进行预分配安全性检测");
					Thread.Sleep(500);
					List<bool> map = new List<bool>(new bool[] { false, false, false, false, false });
					//map[i] = true;
					//cout << "进入复查状态" << endl;
					return CheckStatusT(Available, processList, ref map);
				}
			}
			Console.WriteLine("错误出口2");
			return false;
		}
		bool CheckStatusT(Resourse Available2, List<Process> processList2, ref List<bool> map)
		{

			List<Process> processList = new List<Process>();
			processList2.ForEach(i => processList.Add(i.Clone()));
			Resourse Available = Available2.Clone();
			//cout << "复查被调用"<<endl;
			//Console.WriteLine("map状态：" + map[0] + map[1] + map[2] + map[3] + map[4]);
			int count = 0;
			for (int i=0;i < map.Count;i++)
			{
				if (map[i] == true)
					count++;
			}
			//drawAll(map);
			if (count == 5)
			{
				StrInfoTransfEvent("所有的进程所需资源均被满足");
				return true;
			}
			for (int i = 0; i < processList.Count; i++)
			{
				if (map[i] == true)
					continue;
				DrawInfoTransfEvent(i,Available, processList[i].Allocation, processList[i].Max, this.available, 1);
				//listBox.Items.Add("到达节点1");
				if (Functions.AsB(processList[i].Need, Available))//这个地方好像有点重复？
				{
					if (processList[i].Demand(ref Available, processList[i].Need))
					{
						map[i] = true;

						StrInfoTransfEvent("P" + (i) + "判定成功,释放资源");
						//drawFlag(pictureBoxes[i], map[i]);
						FlagChangeEvent(i, map[i]);
						
						Functions.AddTo(ref Available, processList[i].Max);
						LabelChangeEvent(Available);
						Thread.Sleep(1000);
						if (CheckStatusT(Available, processList, ref map))
						{
							return true;
						}

					}
					else
					{
						WarnInfoTransfEvent(i, "此进程暂时无法完全分配");
						StrInfoTransfEvent("P"+(i)+"判定失败，继续尝试");
						Thread.Sleep(1000);
						
						WithDrawTransferEvent( processList[i],map,Available,i);
						//drawAll(map);
						//drawFlag(pictureBoxes[i], map[i]);
						Thread.Sleep(500);
					}
				}
				else
				{
					WarnInfoTransfEvent(i, "此进程暂时无法完全分配");
					StrInfoTransfEvent("P" + (i) + "判定失败，继续尝试");
					Thread.Sleep(1000);
					WithDrawTransferEvent( processList[i],map,Available,i);
					//drawAll(map);
					//drawFlag(pictureBoxes[i], map[i]);
					Thread.Sleep(500);
				}

			}
			return false;
		}












        #endregion

        /*
		 * -----------------------------------------------------------------------上方是异步绘制的区域---------------------------------------------------------------------------------------------------------------------------------------; 
		 */

        public bool addRequest(int A,int B,int C, string name)
		{
			Resourse demand = new Resourse(A, B, C);
			if (CheckNewDemand(name, demand, available, ProcessList))
			{
				Console.WriteLine("分配成功!");
				for(int i = 0; i < ProcessList.Count; i++)
				{
					Process each = ProcessList[i];
					if (each.name == name)
					{
						Functions.AddTo(ref each.Allocation, demand);
						Functions.MinTo(ref each.Need, demand);
						Functions.MinTo(ref available, demand);

					}
				}
				printPro(ProcessList, available);
				return true;
			}
			else
			{
				printPro(ProcessList, available);
				Console.WriteLine("分配失败!");
				return false;
			}

		}
	}
}
