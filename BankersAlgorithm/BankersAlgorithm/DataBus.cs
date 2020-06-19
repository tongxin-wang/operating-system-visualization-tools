using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankerAlgorithm
{
    /*
     * 存储了配置的静态参数，方便修改。
     */
    public class DataBus
    {
        public static Color mainColor = Color.LightSalmon;
        public static Color backupColor = Color.Red;
        public static Color fixColor = Color.LightGreen;
        public static int FormMainActiveInterval = 50;
        public static int FormOperatingActiveInterval = 10;
    }
}
