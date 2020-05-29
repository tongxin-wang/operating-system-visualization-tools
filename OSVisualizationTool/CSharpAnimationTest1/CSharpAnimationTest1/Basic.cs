using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpAnimationTest1
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
    public class Basic
    {
		public ListBox listBox;
		private List<PictureBox> pictureBoxes;
		public void setBoard(List<PictureBox> pictureBoxes)
		{
			this.pictureBoxes = pictureBoxes;
			
		}
		public List<Label> labels { set; get; }
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
		void listPrintRes(Resourse r,ListBox listBox)
		{
			listBox.Items.Add(r.A + "," + r.B + "," + r.C + ";");
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
		public Basic()
		{
			init(ProcessList);
			available = new Resourse(12, 5, 9);
			printPro(ProcessList, available);
		}
		public Basic(Dictionary<string,int> dic)
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


        public bool addRequestT(int A, int B, int C, string name)
		{
			Resourse demand = new Resourse(A, B, C);
			Task<bool> tMain = new Task<bool>(() => CheckNewDemandT(name, demand, available, ProcessList));
			tMain.Start();
			Task.WaitAll(tMain);
			if(tMain.Result)
			{
				this.listBox.Items.Add("预分配成功！");
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
				this.listBox.Items.Add("预分配失败！");
				return false;
			}

		}
		void setAvailableLabel(Resourse Available)
		{
			labels[0].Text = Available.A<0?"0":Available.A.ToString();
			labels[1].Text = Available.B < 0 ? "0" : Available.B.ToString();
			labels[2].Text = Available.C < 0 ? "0" : Available.C.ToString();
		}
		void myDrawPie(PictureBox pictureBox,Resourse demand,Resourse historyHave,Resourse Max,int flag)
		{
			//                float angleA = Allocation.A * 360 / (Max.A == 0 ? 1 : Max.A);
			listBox.Items.Add("myDrawPie被调用");
			Graphics g = pictureBox.CreateGraphics();
			SolidBrush fix_brush = new SolidBrush(Color.LightGreen);
			SolidBrush change_brush = new SolidBrush(Color.LightSalmon);
			SolidBrush warn_brush = new SolidBrush(Color.Red);
			Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
			Rectangle rectangle2 = new Rectangle(150, 10, 100, 100);
			Rectangle rectangle3 = new Rectangle(290, 10, 100, 100);
			float angleA = historyHave.A * 360 / (Max.A == 0 ? 1 : Max.A);
			float angleB = historyHave.B * 360 / (Max.B == 0 ? 1 : Max.B);
			float angleC = historyHave.C * 360 / (Max.C == 0 ? 1 : Max.C);
			float addA = demand.A * 360 / (Max.A == 0 ? 1 : Max.A);
			float addB = demand.B * 360 / (Max.B == 0 ? 1 : Max.B);
			float addC = demand.C * 360 / (Max.C == 0 ? 1 : Max.C);
			Resourse after_add = new Resourse(historyHave.A + demand.A>Max.A?Max.A:historyHave.A + demand.A, historyHave.B + demand.B > Max.B ? Max.B : historyHave.B + demand.B, historyHave.C + demand.C > Max.C ? Max.C : historyHave.C + demand.C);
			g.FillRectangle(new SolidBrush(Color.White), rectangle1.X, 115, 100, 20);
			g.DrawString(after_add.A.ToString() + "/" + Max.A.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle1.X + 30, 115);
			g.FillRectangle(new SolidBrush(Color.White), rectangle2.X, 115, 100, 20);
			g.DrawString(after_add.B.ToString() + "/" + Max.B.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle2.X + 30, 115);
			g.FillRectangle(new SolidBrush(Color.White), rectangle3.X, 115, 100, 20);
			g.DrawString(after_add.C.ToString() + "/" + Max.C.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle3.X + 30, 115);
			if (flag == 0)
			{
				setAvailableLabel(new Resourse(available.A-demand.A , available.B - demand.B, available.C - demand.C));
				Form3.activeDrawPie(g, change_brush, warn_brush, rectangle1, angleA-90, addA, 10);
				Form3.activeDrawPie(g, change_brush, warn_brush, rectangle2, angleB-90, addB, 10);
				Form3.activeDrawPie(g, change_brush, warn_brush, rectangle3, angleC-90, addC, 10);

			}
			else if(flag==1)
			{
				setAvailableLabel(new Resourse(demand.A-Max.A+historyHave.A, demand.B - Max.B + historyHave.B, demand.C - Max.C + historyHave.C));
				Form3.preDrawPie(g, change_brush, warn_brush, rectangle1, angleA-90, addA, 10);
				Form3.preDrawPie(g, change_brush, warn_brush, rectangle2, angleB-90, addB, 10);
				Form3.preDrawPie(g, change_brush, warn_brush, rectangle3, angleC-90, addC, 10);

			}


		}
		void DrawWarn1(PictureBox pictureBox,string word)
		{	
			Graphics g = pictureBox.CreateGraphics();
			g.DrawString(word, new Font("华文楷体", 25), new SolidBrush(Color.DarkRed), new PointF(10, 30));
		}
		void Withdraw(PictureBox pictureBox,Process process, List<bool> map,Resourse a,int index)
		{
			SolidBrush fix_brush = new SolidBrush(Color.LightGreen);
			SolidBrush change_brush = new SolidBrush(Color.LightSalmon);
			SolidBrush warn_brush = new SolidBrush(Color.Red);
			Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
			Rectangle rectangle2 = new Rectangle(150, 10, 100, 100);
			Rectangle rectangle3 = new Rectangle(290, 10, 100, 100);

			//for (int i = 0; i < 5; i++)
			//{
			//	Resourse Max = this.ProcessList[i].Max;
			//	Resourse Allocation = this.ProcessList[i].Allocation;
			//	float angleA = Allocation.A * 360 / (Max.A == 0 ? 1 : Max.A);
			//	float angleB = Allocation.B * 360 / (Max.B == 0 ? 1 : Max.B);
			//	float angleC = Allocation.C * 360 / (Max.C == 0 ? 1 : Max.C);
			//	//Graphics g = pictureBoxes[4 - i].CreateGraphics();
			//	Bitmap img = new Bitmap(pictureBoxes[i].Width, pictureBoxes[i].Height);
			//	pictureBoxes[i].Image = img;
			//	Graphics g = Graphics.FromImage(img);
			//	g.Clear(Color.White);
			//	//Graphics g = pictureBox.CreateGraphics();
			//	g.FillPie(fix_brush, rectangle1, 0, 360);
			//	g.FillPie(change_brush, rectangle1, -90, angleA);
			//	if (Max.A == 0)
			//		g.FillPie(change_brush, rectangle1, 0, 360);
			//	g.DrawString(Allocation.A.ToString() + "/" + Max.A.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle1.X + 30, 115);
			//	g.FillPie(fix_brush, rectangle2, 0, 360);
			//	g.FillPie(change_brush, rectangle2, -90, angleB);
			//	if (Max.B == 0)
			//		g.FillPie(change_brush, rectangle2, 0, 360);
			//	g.DrawString(Allocation.B.ToString() + "/" + Max.B.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle2.X + 30, 115);
			//	g.FillPie(fix_brush, rectangle3, 0, 360);
			//	g.FillPie(change_brush, rectangle3, -90, angleC);
			//	if (Max.C == 0)
			//		g.FillPie(change_brush, rectangle3, 0, 360);
			//	g.DrawString(Allocation.C.ToString() + "/" + Max.C.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle3.X + 30, 115);

			//	drawFlag(pictureBoxes[i], map[i]);
			//}

			Resourse Max = process.Max;
			Resourse Allocation = process.Allocation;
			float angleA = Allocation.A * 360 / (Max.A == 0 ? 1 : Max.A);
			float angleB = Allocation.B * 360 / (Max.B == 0 ? 1 : Max.B);
			float angleC = Allocation.C * 360 / (Max.C == 0 ? 1 : Max.C);
			//Graphics g = pictureBoxes[4 - i].CreateGraphics();
			Bitmap img = new Bitmap(pictureBox.Width, pictureBox.Height);
			pictureBox.Image = img;
			Graphics g = Graphics.FromImage(img);
			g.Clear(Color.White);
			//Graphics g = pictureBox.CreateGraphics();
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
			g.FillPie(fix_brush, rectangle3, 0, 360);
			g.FillPie(change_brush, rectangle3, -90, angleC);
			if (Max.C == 0)
				g.FillPie(change_brush, rectangle3, 0, 360);
			g.DrawString(Allocation.C.ToString() + "/" + Max.C.ToString(), new Font("等线", 14), new SolidBrush(Color.Black), rectangle3.X + 30, 115);

			drawFlag(pictureBox, map[index]);

			setAvailableLabel(a);
		}
		void drawFlag(PictureBox pictureBox,bool flag)
		{
			Graphics g = pictureBox.CreateGraphics();
			g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, 45, 15));
			SolidBrush red_Brush = new SolidBrush(Color.Red);
			SolidBrush black_Brush = new SolidBrush(Color.Black);
			if (flag == true)
				g.DrawString("已完成", new Font("Arial", 10), red_Brush, new Point(0, 2));
			else
				g.DrawString("未完成", new Font("Arial", 10), black_Brush, new Point(0, 2));
		}
		void drawAll(List<bool> maps)
		{
			for(int i=0;i<5;i++)
			{
				drawFlag(pictureBoxes[i],maps[i]);
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
				//Task t1 = new Task(() => myDrawPie(pictureBoxes[i], demand, processList[i].Allocation, processList[i].Max,0));
				//t1.Start();
				//Task.WaitAll(t1);
				myDrawPie(pictureBoxes[i], demand, processList[i].Allocation, processList[i].Max, 0);
				listBox.Items.Add("此时等待2000ms");
				Thread.Sleep(2000);
				if (!processList[i].Demand(ref Available, demand))//找到了发出申请的进程
				{
					listBox.Items.Add("超出需要");
					DrawWarn1(pictureBoxes[i], "数量错误,超出需要");
					//初始数量不对
					return false;
				}
				else
				{
					//printPro(processList, Available);
					listBox.Items.Add("初步检测通过，开始进行预分配安全性检测");
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
			drawAll(map);
			if (count == 5)
			{
				return true;
			}
			for (int i = 0; i < processList.Count; i++)
			{
				if (map[i] == true)
					continue;
				//listBox.Items.Add("进入预分配阶段,i="+i);
				//Task t2=new Task(()=>myDrawPie(pictureBoxes[i], Available, processList[i].Allocation, processList[i].Max,1));
				//t2.Start();
				//Task.WaitAll(t2);
				myDrawPie(pictureBoxes[i], Available, processList[i].Allocation, processList[i].Max, 1);
				//listBox.Items.Add("到达节点1");
				if (Functions.AsB(processList[i].Need, Available))//这个地方好像有点重复？
				{
					if (processList[i].Demand(ref Available, processList[i].Need))
					{
						map[i] = true;

						listBox.Items.Add("判定成功,释放资源,此时等待3000ms");
						drawAll(map);
						Functions.AddTo(ref Available, processList[i].Max);
						setAvailableLabel(Available);
						Thread.Sleep(3000);
						if (CheckStatusT(Available, processList, ref map))
						{
							return true;
						}

					}
					else
					{
						DrawWarn1(pictureBoxes[i], "此进程暂时无法完全分配后释放资源,此时等待1000ms1");
						Thread.Sleep(1000);
						Withdraw(pictureBoxes[i], processList[i],map,Available,i);
						drawAll(map);
						//drawFlag(pictureBoxes[i], map[i]);
						Thread.Sleep(1000);
					}
				}
				else
				{
					DrawWarn1(pictureBoxes[i], "此进程暂时无法完全分配后释放资源,此时等待1000ms2");
					Thread.Sleep(1000);
					Withdraw(pictureBoxes[i], processList[i],map,Available,i);
					drawAll(map);
					//drawFlag(pictureBoxes[i], map[i]);
					Thread.Sleep(1000);
				}

			}
			Console.WriteLine("错误出口3");
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
		public void BaseBox(ListBox listbox)
		{
			this.listBox = listbox;
		}
	}
}
