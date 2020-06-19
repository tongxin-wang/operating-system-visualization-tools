using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocation
{

  public  class Area
    {
        private string[] states = { "空闲", "忙碌" };
     public    int ID { set; get; }
     public    int Start { set; get; }
     public   int Length { set; get; }
     public   int State { set; get; }
        public string States { get => states[State]; }
    }
}
