using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HZH_Controls;
using HZH_Controls.Controls;

namespace MemoryAllocation
{
    public partial class FormMain : Form
    {
        //public  int RequestQuantity { set; get; }
        public DulAreaList headNode;
        Graphics graphics;
        private int MemorySize;

        public FormMain()
        {
            InitializeComponent();
           // this.Request_textBox.DataBindings.Add("Text", this, "RequestQuantity");
            this.Request_panel.Controls.Add(this.Request_textBox);
            this.Request_panel.Controls.Add(this.RequestConfirm_ucBtnExt);
            this.headNode = new DulAreaList();
            headNode.InitDulAreaList();
           // this.UpdateRows();
        }
        public FormMain(int request) 
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ucSplitLabel1.Text = null;
            this.ucSplitLabel2.Text = "内存分配（首次适应算法）";
            List<DataGridViewColumnEntity> clmn = new List<DataGridViewColumnEntity>();
           clmn.Add(new DataGridViewColumnEntity() { DataField = "AreaID", HeadText = "分区号", Width = 50, WidthType = SizeType.AutoSize });
            clmn.Add(new DataGridViewColumnEntity() { DataField = "Start", HeadText = "起始地址", Width = 50, WidthType = SizeType.AutoSize});
            clmn.Add(new DataGridViewColumnEntity() { DataField = "Length", HeadText = "分区大小", Width = 50, WidthType = SizeType.AutoSize });
            clmn.Add(new DataGridViewColumnEntity() { DataField = "State", HeadText = "状态", Width = 50, WidthType = SizeType.AutoSize});
            this.ucDataGridView1.Columns = clmn;
            //this.Request_textBox.DataBindings.Add("Text", this, "RequestQuantity");
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("0", "请求分配"));
            keyValues.Add(new KeyValuePair<string, string>("1", "请求回收"));
            this.ucCombox1.Source = keyValues;
            this.Request_panel.Controls.Add(this.Request_textBox);
            this.Request_panel.Controls.Add(this.RequestConfirm_ucBtnExt);
            this.headNode = new DulAreaList();
            headNode.InitDulAreaList(request);
            this.MemorySize = request;
            //this.UpdateRows();
            this.UpdateRow();
        }


        private void UpdateRow()
        {
            List<object> rows = new List<object>();
            DulAreaList q = this.headNode.next;
            while (q != null)
            {
                rows.Add(new RowModel() { AreaID = q.area.ID, Start = q.area.Start,
                    Length = q.area.Length, State = q.area.States });
                q = q.next;
            }
            this.ucDataGridView1.DataSource = rows;
        }

        private void DrawMemory()
        {
            Brush brush;
            Font font = new Font("微软雅黑", 11, FontStyle.Regular);
            Brush br = Brushes.White;
            Pen pen = new Pen(Color.Black);
            DulAreaList q = headNode.next;
            float height = 0;
            float temp;
            while (q != null)
            {
                 temp = (float)(q.area.Length *1.0/ this.MemorySize * this.DrawMem_panel.Height);
                if (q.area.State == 0)
                {
                    brush = new SolidBrush(Color.Gray);
                    graphics.FillRectangle(brush, 0, height, this.DrawMem_panel.Width,this.DrawMem_panel.Height);
                }
                if (q.area.State == 1)
                {
                    brush = new SolidBrush(Color.Blue);
                    graphics.FillRectangle(brush, 0, height, this.DrawMem_panel.Width, this.DrawMem_panel.Height);
                }
                graphics.DrawString(q.area.Length.ToString()+"KB", font, br, this.DrawMem_panel.Width/2-15, height+temp/2-10);
                graphics.DrawLine(pen, 0, height, this.DrawMem_panel.Width, height);
                // height += q.area.Length;
                height += temp;
                q = q.next;
            }
        }
        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
             graphics = this.DrawMem_panel.CreateGraphics();
            Brush brush = new SolidBrush(Color.Gray);
            graphics.FillRectangle(brush,0,0, this.DrawMem_panel.Width, this.DrawMem_panel.Height);
            Font font = new Font("微软雅黑", 10, FontStyle.Bold);
            Brush br = Brushes.White;
            graphics.DrawString(MemorySize.ToString() + "KB", font, br, this.DrawMem_panel.Width / 2 - 15, this.DrawMem_panel.Height/2-10);

        }



        private void RequestConfirm_ucBtnExt_BtnClick(object sender, EventArgs e)
        {
            try
            {
                switch (this.ucCombox1.SelectedIndex)
                {
                    case 0:
                       // this.headNode.First_Fit(RequestQuantity);
                        this.headNode.First_Fit(Convert.ToInt32(this.Request_textBox.Text));
                        break;
                    case 1:
                        //this.headNode.RecycleMem(RequestQuantity);
                        this.headNode.RecycleMem(Convert.ToInt32(this.Request_textBox.Text));
                        break;
                }
                //this.UpdateRows();
                this.UpdateRow();
                this.DrawMemory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //RequestQuantity = 0;

            }
        }

        private void ucCombox1_SelectedChangedEvent(object sender, EventArgs e)
        {
            switch (this.ucCombox1.SelectedIndex)
            {
                case 0:
                    //this.Unit_label.Text = "KB";
                    this.ucSplitLabel1.Text = "KB";
                    break;
                case 1:
                    //this.Unit_label.Text = "ID";
                    this.ucSplitLabel1.Text = "ID";
                    break;
            }
        }

        private void Request_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Edit_ucBtnExt_BtnClick(object sender, EventArgs e)
        {
            FormEdit formEdit = new FormEdit();
            if (formEdit.ShowDialog() == DialogResult.OK)
            {
                this.MemorySize = formEdit.Modify;
                this.headNode = new DulAreaList();
                this.headNode.InitDulAreaList(MemorySize);
                this.UpdateRow();
                this.DrawMemory();
            }    
        }
        public delegate void Transfer();
        public event Transfer backToCata;
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            backToCata();
        }
    }
}
