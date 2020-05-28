namespace WinFormMemAllocation
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
            this.RequestConfirm_button = new System.Windows.Forms.Button();
            this.Request_textBox = new System.Windows.Forms.TextBox();
            this.Request_comboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrawMem_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Unit_label = new System.Windows.Forms.Label();
            this.Request_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Request_panel
            // 
            this.Request_panel.Controls.Add(this.Unit_label);
            this.Request_panel.Controls.Add(this.RequestConfirm_button);
            this.Request_panel.Controls.Add(this.Request_textBox);
            this.Request_panel.Controls.Add(this.Request_comboBox);
            this.Request_panel.Location = new System.Drawing.Point(36, 42);
            this.Request_panel.Name = "Request_panel";
            this.Request_panel.Size = new System.Drawing.Size(915, 76);
            this.Request_panel.TabIndex = 0;
            // 
            // RequestConfirm_button
            // 
            this.RequestConfirm_button.Location = new System.Drawing.Point(543, 9);
            this.RequestConfirm_button.Name = "RequestConfirm_button";
            this.RequestConfirm_button.Size = new System.Drawing.Size(103, 41);
            this.RequestConfirm_button.TabIndex = 2;
            this.RequestConfirm_button.Text = "确定";
            this.RequestConfirm_button.UseVisualStyleBackColor = true;
            this.RequestConfirm_button.Click += new System.EventHandler(this.RequestConfirm_button_Click);
            // 
            // Request_textBox
            // 
            this.Request_textBox.Location = new System.Drawing.Point(361, 17);
            this.Request_textBox.Name = "Request_textBox";
            this.Request_textBox.Size = new System.Drawing.Size(48, 28);
            this.Request_textBox.TabIndex = 1;
            // 
            // Request_comboBox
            // 
            this.Request_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Request_comboBox.FormattingEnabled = true;
            this.Request_comboBox.Items.AddRange(new object[] {
            "请求分配",
            "请求回收"});
            this.Request_comboBox.Location = new System.Drawing.Point(113, 17);
            this.Request_comboBox.Name = "Request_comboBox";
            this.Request_comboBox.Size = new System.Drawing.Size(242, 26);
            this.Request_comboBox.TabIndex = 0;
            this.Request_comboBox.SelectedIndexChanged += new System.EventHandler(this.Request_comboBox_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(36, 169);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(695, 422);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "分区号";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "起始地址";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "分区大小";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "状态";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // DrawMem_panel
            // 
            this.DrawMem_panel.Location = new System.Drawing.Point(765, 169);
            this.DrawMem_panel.Name = "DrawMem_panel";
            this.DrawMem_panel.Size = new System.Drawing.Size(225, 422);
            this.DrawMem_panel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(834, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "描述过程";
            // 
            // Unit_label
            // 
            this.Unit_label.AutoSize = true;
            this.Unit_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Unit_label.Location = new System.Drawing.Point(415, 25);
            this.Unit_label.Name = "Unit_label";
            this.Unit_label.Size = new System.Drawing.Size(0, 24);
            this.Unit_label.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 628);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DrawMem_panel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Request_panel);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.Request_panel.ResumeLayout(false);
            this.Request_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Request_panel;
        private System.Windows.Forms.Button RequestConfirm_button;
        private System.Windows.Forms.TextBox Request_textBox;
        private System.Windows.Forms.ComboBox Request_comboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Panel DrawMem_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Unit_label;
    }
}

