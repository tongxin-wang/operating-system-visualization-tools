using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace BankerAlgorithm
{
    public partial class FormChoose : Form
    {
        public delegate void TransfDelegate(MyDictionary<string,int> dic,string name);
        public event TransfDelegate TransfEvent;
        MyDictionary<string, int> dic; 
        List<ListItem> listItems=new List<ListItem>();
        public FormChoose()
        {
            InitializeComponent();

            comboBox1.DisplayMember = "Text";        //显示
            comboBox1.ValueMember = "Value";        //值

            string path = @"./";
            DirectoryInfo d = new DirectoryInfo(path);
            List<FileInfo> list = new List<FileInfo>(d.GetFiles());
            foreach(FileInfo f in list)
            {
                if(f.Name.Remove(0,f.Name.Length-4)==".xml")
                    listItems.Add(new ListItem("0", f.Name.Remove(f.Name.Length-4)));
            }
            comboBox1.DataSource = listItems;        //绑定数据 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(TransfEvent!=null)
                TransfEvent(dic,comboBox1.SelectedItem.ToString());
            this.Dispose();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = comboBox1.SelectedItem.ToString()+".xml";
            dic=FormTest.Import(path);
            listBox1.Items.Clear();
            listBox1.Items.Add("Available:  " + dic["SA"] + "," + dic["SB"] + "," + dic["SC"]);
            for (int i = 0; i < 5; i++)
            {
                string str = $"{"P" + i}:  {dic[i + "A"]},{dic[i + "B"]},{dic[i + "C"]}";
                listBox1.Items.Add(str);
            }
        }
    }
}
