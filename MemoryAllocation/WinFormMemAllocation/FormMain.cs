using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoryAllocation;

namespace WinFormMemAllocation
{
    public partial class FormMain : Form
    {
        public  int RequestQuantity { set; get; }
        public DulAreaList headNode;
        Graphics graphics;
        private int MemorySize;
        public FormMain()
        {
            InitializeComponent();
            this.Request_textBox.DataBindings.Add("Text", this, "RequestQuantity");
            this.Request_panel.Controls.Add(this.Request_comboBox);
            this.Request_panel.Controls.Add(this.Request_textBox);
            this.Request_panel.Controls.Add(this.RequestConfirm_button);
            this.headNode = new DulAreaList();
            headNode.InitDulAreaList();
            this.UpdateRows();
        }
        public FormMain(int request) 
        {
            InitializeComponent();
            this.Request_textBox.DataBindings.Add("Text", this, "RequestQuantity");
            this.Request_panel.Controls.Add(this.Request_comboBox);
            this.Request_panel.Controls.Add(this.Request_textBox);
            this.Request_panel.Controls.Add(this.RequestConfirm_button);
            this.headNode = new DulAreaList();
            headNode.InitDulAreaList(request);
            this.MemorySize = request;
            this.UpdateRows();
        }
        private void UpdateRows()
        {
            int index;
            DulAreaList q = this.headNode.next;
            for(int i = this.dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                dataGridView1.Rows.RemoveAt(i);
            }
            while (q != null)
            {
                index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = q.area.ID;
                this.dataGridView1.Rows[index].Cells[1].Value = q.area.Start;
                this.dataGridView1.Rows[index].Cells[2].Value = q.area.Length;
                this.dataGridView1.Rows[index].Cells[3].Value = q.area.States;
                q = q.next;
            }
        }

        private void RequestConfirm_button_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.Request_comboBox.SelectedIndex)
                {
                    case 0:
                        this.headNode.First_Fit(RequestQuantity);
                        break;
                    case 1:
                        this.headNode.RecycleMem(RequestQuantity);
                        break;
                }
                this.UpdateRows();
                this.DrawMemory();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //RequestQuantity = 0;
                
            }
        }
        private void DrawMemory()
        {
            Brush brush;
            Font font = new Font("微软雅黑", 10, FontStyle.Bold);
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

        private void Request_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.Request_comboBox.SelectedIndex)
            {
                case 0:
                    this.Unit_label.Text = "KB";
                    break;
                case 1:
                    this.Unit_label.Text = "ID";
                    break;
            }
        }
    }
}
