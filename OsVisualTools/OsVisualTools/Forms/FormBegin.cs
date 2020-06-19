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
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
namespace BankerAlgorithm
{
    public partial class FormBegin : Form
    {
        public FormBegin()
        {
            InitializeComponent();
            init();
        }
        private MyDictionary<string, int> dic;//方便存储
        private string templateName; //传输到下一界面的参数，使其可以判定是否为默认模板。
        private void FormBegin_Load(object sender, EventArgs e)
        {
            
            this.Location = new Point(Screen.GetBounds(this).Width/2-this.Width/2, Screen.GetBounds(this).Height / 2 - this.Height / 2);//调整位置
        }
        private  void resetAll()//重置全部输入框
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox t = (TextBox)control;
                    t.Text = "";
                    t.BackColor = Color.White;
                }
            }
        }
        private void init()//初始化页面属性的函数
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox t = (TextBox)control;
                    t.TextChanged += reset;
                }
            }
        }

        private bool checkInput()//判断输入是否为空或有误，如果有则返回false并将错误的输入框背景变红以提示用户
        {
            bool hasProblem = false;

            foreach(var control in this.Controls)
            {
                if(control is TextBox)
                {
                    TextBox t = (TextBox)control;
                    int num;
                    if(!int.TryParse(t.Text, out num))
                    {
                        t.BackColor = Color.Red;
                        hasProblem = true;
                    }
                }
            }
            return hasProblem;
        }
        private void reset(object sender, EventArgs e)//重置sender
        {
            TextBox t = (TextBox)sender;
            t.BackColor = Color.White;
            templateName = "NONE";
        }
        private void ShowFormChoose(object sender, EventArgs e)//模板选择界面初始化并显示
        {
            FormChoose formChoose = new FormChoose();
            formChoose.TransfEvent += new FormChoose.TransfDelegate(setDefaultToText);
            formChoose.StartPosition = FormStartPosition.CenterScreen;
            formChoose.ShowDialog();

        }
        private void setDefaultToText(MyDictionary<string,int> dic,string n)//将所选模板内容显示在输入框中
        {
            foreach(var d in dic)
            {
                Controls["textBox" + d.Key].Text = d.Value.ToString();
            }
            templateName = n;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            resetAll();
        }
        private void ShowSituation(int flag)
        {
            if(flag == 0)
            {
                this.Show();
            }
            else
            {
                backToCata();
            }
        }
        private void GoToMain(object sender, EventArgs e)//运行到主界面
        {
            if (checkInput())
            {
                MessageBox.Show("输入有误，请检查出错的输入框");
            }
            else
            {
                setDic();
                FormMain form2 = new FormMain(dic);
                form2.getBack += new FormMain.BackDel(this.ShowSituation);
                form2.StartPosition = FormStartPosition.CenterScreen;
                if (templateName != "default")
                    form2.notMyTemp();
                form2.Show();
                this.Hide();
            }
        }
        private void setDic()//用字典记录所有输入框中内容
        {
            dic = new MyDictionary<string, int>(); ;
            foreach (var control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox t = (TextBox)control;
                    string b = t.Name.Remove(0, t.Name.Length - 2);
                    dic[b] = int.Parse(t.Text);


                }
            }
        }
        private void ExportTemp(object sender, EventArgs e)//将目前输入框内容导出为模板
        {
            if (checkInput())//先检查输入信息
            {
                MessageBox.Show("输入有误，请检查出错的输入框", "失败");
                return;
            }
            else
            {
                setDic();
                string name = Interaction.InputBox("请给你即将导出的模板参数值组起个名字", "提示信息", "", -1, -1);
                if (name.Length != 0)
                {
                    string path = @"./";
                    DirectoryInfo d = new DirectoryInfo(path);
                    List<FileInfo> list = new List<FileInfo>(d.GetFiles());
                    foreach (FileInfo f in list)//对名字进行判断
                    {
                        if (f.Name.Remove(0, f.Name.Length - 4) == ".xml")
                            if (name + ".xml" == f.Name)
                            {
                                MessageBox.Show("命名重复，请重新命名","失败");
                                return;
                            }
                    }
                    OsManager.Export(name+".xml", dic);
                    MessageBox.Show("导出成功");
                    //Form1.Import("test3.xml");
                }
            }
        }
        public delegate void Back();
        public event Back backToCata;//用于返回选择界面
        private void FormBegin_FormClosing(object sender, FormClosingEventArgs e)
        {
            backToCata();
        }
    }
}
