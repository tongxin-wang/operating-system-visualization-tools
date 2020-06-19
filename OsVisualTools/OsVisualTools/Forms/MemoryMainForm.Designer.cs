namespace MemoryAllocation
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Request_panel = new System.Windows.Forms.Panel();
            this.ucSplitLabel1 = new HZH_Controls.Controls.UCSplitLabel();
            this.ucCombox1 = new HZH_Controls.Controls.UCCombox();
            this.RequestConfirm_ucBtnExt = new HZH_Controls.Controls.UCBtnExt();
            this.Unit_label = new System.Windows.Forms.Label();
            this.Request_textBox = new System.Windows.Forms.TextBox();
            this.DrawMem_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ucDataGridView1 = new HZH_Controls.Controls.UCDataGridView();
            this.ucSplitLabel2 = new HZH_Controls.Controls.UCSplitLabel();
            this.Edit_ucBtnExt = new HZH_Controls.Controls.UCBtnExt();
            this.Request_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Request_panel
            // 
            this.Request_panel.Controls.Add(this.ucSplitLabel1);
            this.Request_panel.Controls.Add(this.ucCombox1);
            this.Request_panel.Controls.Add(this.RequestConfirm_ucBtnExt);
            this.Request_panel.Controls.Add(this.Unit_label);
            this.Request_panel.Controls.Add(this.Request_textBox);
            this.Request_panel.Location = new System.Drawing.Point(32, 35);
            this.Request_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Request_panel.Name = "Request_panel";
            this.Request_panel.Size = new System.Drawing.Size(813, 64);
            this.Request_panel.TabIndex = 0;
            this.Request_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Request_panel_Paint);
            // 
            // ucSplitLabel1
            // 
            this.ucSplitLabel1.AutoSize = true;
            this.ucSplitLabel1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucSplitLabel1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.ucSplitLabel1.Location = new System.Drawing.Point(412, 32);
            this.ucSplitLabel1.MaximumSize = new System.Drawing.Size(0, 26);
            this.ucSplitLabel1.MinimumSize = new System.Drawing.Size(133, 26);
            this.ucSplitLabel1.Name = "ucSplitLabel1";
            this.ucSplitLabel1.Padding = new System.Windows.Forms.Padding(27, 0, 0, 0);
            this.ucSplitLabel1.Size = new System.Drawing.Size(133, 26);
            this.ucSplitLabel1.TabIndex = 6;
            this.ucSplitLabel1.Text = "Label1";
            // 
            // ucCombox1
            // 
            this.ucCombox1.BackColor = System.Drawing.Color.Transparent;
            this.ucCombox1.BackColorExt = System.Drawing.Color.Silver;
            this.ucCombox1.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ucCombox1.ConerRadius = 5;
            this.ucCombox1.DropPanelHeight = -1;
            this.ucCombox1.FillColor = System.Drawing.Color.Silver;
            this.ucCombox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucCombox1.IsRadius = true;
            this.ucCombox1.IsShowRect = true;
            this.ucCombox1.ItemWidth = 70;
            this.ucCombox1.Location = new System.Drawing.Point(65, 29);
            this.ucCombox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ucCombox1.Name = "ucCombox1";
            this.ucCombox1.RectColor = System.Drawing.Color.Silver;
            this.ucCombox1.RectWidth = 1;
            this.ucCombox1.SelectedIndex = -1;
            this.ucCombox1.SelectedValue = "";
            this.ucCombox1.Size = new System.Drawing.Size(228, 26);
            this.ucCombox1.Source = null;
            this.ucCombox1.TabIndex = 5;
            this.ucCombox1.TextValue = null;
            this.ucCombox1.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ucCombox1.SelectedChangedEvent += new System.EventHandler(this.ucCombox1_SelectedChangedEvent);
            // 
            // RequestConfirm_ucBtnExt
            // 
            this.RequestConfirm_ucBtnExt.BackColor = System.Drawing.Color.White;
            this.RequestConfirm_ucBtnExt.BtnBackColor = System.Drawing.Color.White;
            this.RequestConfirm_ucBtnExt.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RequestConfirm_ucBtnExt.BtnForeColor = System.Drawing.Color.White;
            this.RequestConfirm_ucBtnExt.BtnText = "确定";
            this.RequestConfirm_ucBtnExt.ConerRadius = 5;
            this.RequestConfirm_ucBtnExt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RequestConfirm_ucBtnExt.EnabledMouseEffect = false;
            this.RequestConfirm_ucBtnExt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.RequestConfirm_ucBtnExt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RequestConfirm_ucBtnExt.IsRadius = true;
            this.RequestConfirm_ucBtnExt.IsShowRect = true;
            this.RequestConfirm_ucBtnExt.IsShowTips = false;
            this.RequestConfirm_ucBtnExt.Location = new System.Drawing.Point(561, 29);
            this.RequestConfirm_ucBtnExt.Margin = new System.Windows.Forms.Padding(0);
            this.RequestConfirm_ucBtnExt.Name = "RequestConfirm_ucBtnExt";
            this.RequestConfirm_ucBtnExt.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.RequestConfirm_ucBtnExt.RectWidth = 1;
            this.RequestConfirm_ucBtnExt.Size = new System.Drawing.Size(93, 34);
            this.RequestConfirm_ucBtnExt.TabIndex = 4;
            this.RequestConfirm_ucBtnExt.TabStop = false;
            this.RequestConfirm_ucBtnExt.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.RequestConfirm_ucBtnExt.TipsText = "";
            this.RequestConfirm_ucBtnExt.BtnClick += new System.EventHandler(this.RequestConfirm_ucBtnExt_BtnClick);
            // 
            // Unit_label
            // 
            this.Unit_label.AutoSize = true;
            this.Unit_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Unit_label.Location = new System.Drawing.Point(369, 21);
            this.Unit_label.Name = "Unit_label";
            this.Unit_label.Size = new System.Drawing.Size(0, 20);
            this.Unit_label.TabIndex = 3;
            // 
            // Request_textBox
            // 
            this.Request_textBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Request_textBox.Location = new System.Drawing.Point(344, 31);
            this.Request_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Request_textBox.Name = "Request_textBox";
            this.Request_textBox.Size = new System.Drawing.Size(43, 31);
            this.Request_textBox.TabIndex = 1;
            // 
            // DrawMem_panel
            // 
            this.DrawMem_panel.Location = new System.Drawing.Point(645, 146);
            this.DrawMem_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DrawMem_panel.Name = "DrawMem_panel";
            this.DrawMem_panel.Size = new System.Drawing.Size(200, 351);
            this.DrawMem_panel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(705, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "描述过程";
            // 
            // ucDataGridView1
            // 
            this.ucDataGridView1.AutoScroll = true;
            this.ucDataGridView1.BackColor = System.Drawing.Color.White;
            this.ucDataGridView1.Columns = null;
            this.ucDataGridView1.DataSource = null;
            this.ucDataGridView1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucDataGridView1.HeadFont = new System.Drawing.Font("微软雅黑", 12F);
            this.ucDataGridView1.HeadHeight = 40;
            this.ucDataGridView1.HeadPadingLeft = 0;
            this.ucDataGridView1.HeadTextColor = System.Drawing.Color.Black;
            this.ucDataGridView1.IsShowCheckBox = false;
            this.ucDataGridView1.IsShowHead = true;
            this.ucDataGridView1.Location = new System.Drawing.Point(32, 146);
            this.ucDataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucDataGridView1.Name = "ucDataGridView1";
            this.ucDataGridView1.RowHeight = 40;
            this.ucDataGridView1.RowType = typeof(HZH_Controls.Controls.UCDataGridViewRow);
            this.ucDataGridView1.Size = new System.Drawing.Size(561, 351);
            this.ucDataGridView1.TabIndex = 4;
            // 
            // ucSplitLabel2
            // 
            this.ucSplitLabel2.AutoSize = true;
            this.ucSplitLabel2.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucSplitLabel2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.ucSplitLabel2.Location = new System.Drawing.Point(336, 8);
            this.ucSplitLabel2.MaximumSize = new System.Drawing.Size(0, 33);
            this.ucSplitLabel2.MinimumSize = new System.Drawing.Size(133, 33);
            this.ucSplitLabel2.Name = "ucSplitLabel2";
            this.ucSplitLabel2.Padding = new System.Windows.Forms.Padding(27, 0, 0, 0);
            this.ucSplitLabel2.Size = new System.Drawing.Size(202, 33);
            this.ucSplitLabel2.TabIndex = 5;
            this.ucSplitLabel2.Text = "ucSplitLabel2";
            // 
            // Edit_ucBtnExt
            // 
            this.Edit_ucBtnExt.BackColor = System.Drawing.Color.White;
            this.Edit_ucBtnExt.BtnBackColor = System.Drawing.Color.White;
            this.Edit_ucBtnExt.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Edit_ucBtnExt.BtnForeColor = System.Drawing.Color.White;
            this.Edit_ucBtnExt.BtnText = "修改内存";
            this.Edit_ucBtnExt.ConerRadius = 5;
            this.Edit_ucBtnExt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Edit_ucBtnExt.EnabledMouseEffect = false;
            this.Edit_ucBtnExt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.Edit_ucBtnExt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Edit_ucBtnExt.IsRadius = true;
            this.Edit_ucBtnExt.IsShowRect = true;
            this.Edit_ucBtnExt.IsShowTips = false;
            this.Edit_ucBtnExt.Location = new System.Drawing.Point(20, 8);
            this.Edit_ucBtnExt.Margin = new System.Windows.Forms.Padding(0);
            this.Edit_ucBtnExt.Name = "Edit_ucBtnExt";
            this.Edit_ucBtnExt.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Edit_ucBtnExt.RectWidth = 1;
            this.Edit_ucBtnExt.Size = new System.Drawing.Size(112, 31);
            this.Edit_ucBtnExt.TabIndex = 6;
            this.Edit_ucBtnExt.TabStop = false;
            this.Edit_ucBtnExt.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.Edit_ucBtnExt.TipsText = "";
            this.Edit_ucBtnExt.BtnClick += new System.EventHandler(this.Edit_ucBtnExt_BtnClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 524);
            this.Controls.Add(this.Edit_ucBtnExt);
            this.Controls.Add(this.ucSplitLabel2);
            this.Controls.Add(this.ucDataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DrawMem_panel);
            this.Controls.Add(this.Request_panel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "内存管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.Request_panel.ResumeLayout(false);
            this.Request_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Request_panel;
        private System.Windows.Forms.TextBox Request_textBox;
        private System.Windows.Forms.Panel DrawMem_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Unit_label;
        private HZH_Controls.Controls.UCBtnExt RequestConfirm_ucBtnExt;
        private HZH_Controls.Controls.UCDataGridView ucDataGridView1;
        private HZH_Controls.Controls.UCCombox ucCombox1;
        private HZH_Controls.Controls.UCSplitLabel ucSplitLabel1;
        private HZH_Controls.Controls.UCSplitLabel ucSplitLabel2;
        private HZH_Controls.Controls.UCBtnExt Edit_ucBtnExt;
    }
}

