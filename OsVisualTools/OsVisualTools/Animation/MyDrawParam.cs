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
using System.Reflection;
namespace BankerAlgorithm
{
    //在使用我的绘制函数时作为传递的参数
    public class MyDrawParam
    {
        public Graphics graphics { get; set; }
        public SolidBrush mainBrush { get; set; }
        public SolidBrush backupBrush { get; set; }
        public Rectangle positionRectangle { get; set; }
        public float angleBegin { get; set; }
        public float angleIncrease { get; set; }
        public int interval { get; set; }
        public MyDrawParam(Graphics g)
        {
            graphics = g;
            mainBrush = new SolidBrush(DataBus.mainColor);
            backupBrush = new SolidBrush(DataBus.backupColor);
        }

    }
}
