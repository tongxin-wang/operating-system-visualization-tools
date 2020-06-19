using HZH_Controls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessorScheduling;
using MemoryAllocation;
using EX2;

namespace OsVisualTools
{
    public partial class MainForm : Form
    {
        private void setMenu()
        {
            List<NavigationMenuItem> items = new List<NavigationMenuItem>();
            List<NavigationMenuItem> detailItems1 = new List<NavigationMenuItem>();
            List<NavigationMenuItem> detailItems2 = new List<NavigationMenuItem>();
            List<NavigationMenuItem> detailItems3 = new List<NavigationMenuItem>();
            List<NavigationMenuItem> detailItems4 = new List<NavigationMenuItem>();
            NavigationMenuItem detailItem = new NavigationMenuItem();//优先数调度，首次适应算法，位示图法，银行家算法
            detailItem.Text = "优先数调度";
            NavigationMenuItem detailItem2 = new NavigationMenuItem();
            detailItem2.Text = "首次适应算法";
            NavigationMenuItem detailItem3 = new NavigationMenuItem();
            detailItem3.Text = "位示图法";
            
            NavigationMenuItem detailItem4 = new NavigationMenuItem();
            detailItem4.Text = "银行家算法";
            detailItems1.Add(detailItem);
            detailItems2.Add(detailItem2);
            detailItems3.Add(detailItem3);
            detailItems4.Add(detailItem4);
            NavigationMenuItem menuItem = new NavigationMenuItem();
            menuItem.Text = "处理器调度";
            menuItem.Items = detailItems1.ToArray();
            NavigationMenuItem menuItem1 = new NavigationMenuItem();
            menuItem1.Text = "内存管理";
            menuItem1.Items = detailItems2.ToArray();
            NavigationMenuItem menuItem2 = new NavigationMenuItem();
            menuItem2.AnchorRight = true;
            menuItem2.Text = "磁盘管理";
            menuItem2.Items = detailItems3.ToArray();
            NavigationMenuItem menuItem3 = new NavigationMenuItem();
            menuItem3.AnchorRight = true;
            menuItem3.Text = "死锁预防";
            menuItem3.Items = detailItems4.ToArray();
            items.Add(menuItem);
            items.Add(menuItem1);
            items.Add(menuItem2);
            items.Add(menuItem3);
            ucNavigationMenu.Items = items.ToArray();
            ucNavigationMenu.ClickItemed += UcNavigationMenu_ClickItemed;
        }

        private void UcNavigationMenu_ClickItemed(object sender, EventArgs e)
        {
            //这不能用个switch吗？
            if(ucNavigationMenu.SelectItem.Text == "优先数调度")
            {
                ucBtnExt_PS_BtnClick(sender, e);              
            }
            else if (ucNavigationMenu.SelectItem.Text == "首次适应算法")
            {
                ucBtnExt_MA_BtnClick(sender, e);
            }
            else if(ucNavigationMenu.SelectItem.Text == "位示图法")
            {
                ucBtnExt_DM_BtnClick(sender, e);
            }
            else if(ucNavigationMenu.SelectItem.Text == "银行家算法")
            {
                ucBtnExt_BA_BtnClick(sender, e);
            }
        }

        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            setMenu();
        }

        private void ucBtnExt_PS_BtnClick(object sender, EventArgs e)
        {
            ProcessorScheduling.ProcessorMainForm processorMainForm = new ProcessorScheduling.ProcessorMainForm();
            processorMainForm.Show();
            processorMainForm.BacktoMainForm = showMainForm;
            processorMainForm.ClosetoMainForm = showMainForm;
            this.Hide();           
        }

        private void ucBtnExt_BA_BtnClick(object sender, EventArgs e)
        {
            BankerAlgorithm.FormBegin bankerAlgorithmForm = new BankerAlgorithm.FormBegin();
            bankerAlgorithmForm.backToCata += new BankerAlgorithm.FormBegin.Back(this.Show);
            bankerAlgorithmForm.Show();
            this.Hide();
        }

        private void ucBtnExt_MA_BtnClick(object sender, EventArgs e)
        {
            MemoryAllocation.FormInit formInit = new MemoryAllocation.FormInit();
            formInit.backToCata += new MemoryAllocation.FormInit.getBack(this.Show);
            formInit.Show();
            this.Hide();
        }

        private void ucBtnExt_DM_BtnClick(object sender, EventArgs e)
        {
            EX2.Form1 form = new EX2.Form1();
            form.Show();
            form.ClosetoMain = showMainForm;
            this.Hide();
        }

        private void ucNavigationMenu_ClickItemed(object sender, EventArgs e)
        {

        }

        public void showMainForm(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
