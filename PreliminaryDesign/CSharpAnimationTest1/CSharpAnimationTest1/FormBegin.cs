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
namespace CSharpAnimationTest1
{
    public partial class FormBegin : Form
    {
        public FormBegin()
        {
            InitializeComponent();
            init();
        }
        private MyDictionary<string, int> dic;
        private string templateName;
        private void FormBegin_Load(object sender, EventArgs e)
        {

        }
        private  void resetAll()
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
        private void init()
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
        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }
        private bool checkInput()
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
        private void reset(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.BackColor = Color.White;
            templateName = "NONE";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormChoose formChoose = new FormChoose();
            formChoose.Show();
            formChoose.TransfEvent += new FormChoose.TransfDelegate(setDefaultToText);
            //textBoxSA.Text = 12.ToString();
            //textBoxSB.Text = 5.ToString();
            //textBoxSC.Text = 9.ToString();
            //textBox0A.Text = 8.ToString();
            //textBox0B.Text = 5.ToString();
            //textBox0C.Text = 3.ToString();
            //textBox1A.Text = 3.ToString();
            //textBox1B.Text = 2.ToString();
            //textBox1C.Text = 3.ToString();
            //textBox2A.Text = 9.ToString();
            //textBox2B.Text = 0.ToString();
            //textBox2C.Text = 3.ToString();
            //textBox3A.Text = 2.ToString();
            //textBox3B.Text = 2.ToString();
            //textBox3C.Text = 2.ToString();
            //textBox4A.Text = 5.ToString();
            //textBox4B.Text = 3.ToString();
            //textBox4C.Text = 3.ToString();
        }
        private void setDefaultToText(MyDictionary<string,int> dic,string n)
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                MessageBox.Show("输入有误，请检查出错的输入框");
            }
            else
            {
                setDic();
                Form2 form2 = new Form2(dic);
                if (templateName != "default")
                    form2.notMyTemp();
                form2.Show();
                this.Hide();
            }
        }
        private void setDic()
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
        private void button4_Click(object sender, EventArgs e)
        {
            if (checkInput())
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
                    foreach (FileInfo f in list)
                    {
                        if (f.Name.Remove(0, f.Name.Length - 4) == ".xml")
                            if (name + ".xml" == f.Name)
                            {
                                MessageBox.Show("命名重复，请重新命名","失败");
                                return;
                            }
                    }
                    Form1.Export(name+".xml", dic);
                    MessageBox.Show("导出成功");
                    //Form1.Import("test3.xml");
                }
                //Form1.Export("test3.xml", dic);
                //Form1.Import("test3.xml");
            }
        }
    }
}
