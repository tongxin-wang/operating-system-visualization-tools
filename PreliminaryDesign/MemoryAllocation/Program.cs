using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocation
{
    class Program
    {
        static void Main()
        {
            DulAreaList headNode = new DulAreaList();
            headNode.InitDulAreaList();
            int choice, request;
            bool flag = true;
            while (flag)
            {
                Console.Write("0：退出，1：分配请求，2：回收请求：");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        Console.Write("请输入申请空间的大小(KB):");
                        request = Convert.ToInt32(Console.ReadLine());
                        headNode.First_Fit(request);
                        break;
                    case 2:
                        Console.Write("请输入需要回收的分区号:");
                        request = Convert.ToInt32(Console.ReadLine());
                        headNode.RecycleMem(request);
                        break;
                }
                if (choice != 0)
                {
                    headNode.ShowArea();
                }
            }
        }
    }
}
