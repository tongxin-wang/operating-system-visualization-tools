using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocation
{
   public class DulAreaList
    {
        public Area area;
        public DulAreaList prior;
        public DulAreaList next;


        public void InitDulAreaList()
        {
            DulAreaList firstNode = new DulAreaList();
            firstNode.area = new Area { ID = 0, Start = 0, Length = 128, State = 0 };
            this.next = firstNode;
            firstNode.prior = this;
        }

        public void InitDulAreaList(int length)
        {
            DulAreaList firstNode = new DulAreaList();
            firstNode.area = new Area { ID = 0, Start = 0, Length = length, State = 0 };
            this.next = firstNode;
            firstNode.prior = this;
        }

        public void ShowArea()
        {
            Console.WriteLine("----------------------空闲表如下---------------------\n");
            Console.WriteLine("分区号\t起始地址\t分区大小\t状态");
            Console.WriteLine();
            DulAreaList q = this.next;
            while (q != null)
            {
                Console.Write("   " + q.area.ID + "\t");
                Console.Write("   " + q.area.Start + "\t\t");
                Console.Write(" " + q.area.Length + "KB\t\t");
                Console.Write( q.area.States + "\n\n");
                q = q.next;
            }
            Console.WriteLine("------------------------------------------------------\n");
        }

        public void First_Fit(int request)
        {
            if (request <= 0)
            {
                throw new Exception("请求参数有误！");
            }
            DulAreaList q = this.next;
            while (q != null)
            {
                if (q.area.State == 0 && q.area.Length == request)
                {
                    q.area.State = 0;
                    return;
                }
                else if (q.area.State == 0 && q.area.Length > request)
                {
                    int length = q.area.Length;
                    q.area.Length = request;
                    q.area.State = 1;
                    DulAreaList temp = new DulAreaList();
                    temp.area = new Area { ID = q.area.ID + 1, Start = q.area.Start + q.area.Length, Length = length - request, State = 0 };
                    if (q.next == null)
                    {
                        q.next = temp;
                        temp.prior = q;
                    }
                    else
                    {
                        temp.prior = q;
                        temp.next = q.next;
                        q.next.prior = temp;
                        q.next = temp;
                    }
                    return;
                }
                q = q.next;
            }
            Console.WriteLine("内存不足，分配失败\n");
            throw new Exception("内存不足，分配失败");
        }

        public void RecycleMem(int requestID)
        {
            if (requestID < 0)
            {
                throw new Exception("请求参数有误！");
            }
            DulAreaList q = this.next;
            bool isChange = false;
            for(int i = 0; i < requestID; i++)
            {
                q = q.next;
                if (q == null)
                {
                    Console.WriteLine("申请分区号大于最大分区号");
                    // return;
                    throw new Exception("申请分区号大于最大分区号");
                }
            }
            if (q.area.State == 0)
            {
                Console.WriteLine("该分区空闲，不能回收");
                //return;
                throw new Exception("该分区空闲，不能回收");
            }
            q.area.State = 0;
            if (q.prior != this && q.prior.area.State == 0)
            {
                q.prior.area.Length += q.area.Length;
                if (q.next != null)
                {
                    q.prior.next = q.next;
                    q.next.prior = q.prior;
                    q = q.prior;
                }
                else
                {
                    q.prior.next = null;
                    q = q.prior;
                }
                isChange = true;
            }
            if (q.next != null && q.next.area.State == 0)
            {
                q.area.Length += q.next.area.Length;
                if (q.next.next != null)
                {
                    q.next.next.prior = q;
                    q.next = q.next.next;
                }
                else
                {
                    q.next = null;
                }
                isChange = true;
            }
            while (isChange && q.next != null)
            {
                q.next.area.ID = q.area.ID + 1;
                q = q.next;
            }
        }
    }
}
