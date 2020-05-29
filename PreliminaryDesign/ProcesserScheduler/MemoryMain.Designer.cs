namespace ProcesserScheduler
{
    partial class MemoryMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.DrawMem_panel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Request_panel = new System.Windows.Forms.Panel();
            this.Unit_label = new System.Windows.Forms.Label();
            this.RequestConfirm_button = new System.Windows.Forms.Button();
            this.Request_textBox = new System.Windows.Forms.TextBox();
            this.Request_comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Request_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(722, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "描述过程";
            // 
            // DrawMem_panel
            // 
            this.DrawMem_panel.Location = new System.Drawing.Point(661, 132);
            this.DrawMem_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DrawMem_panel.Name = "DrawMem_panel";
            this.DrawMem_panel.Size = new System.Drawing.Size(200, 352);
            this.DrawMem_panel.TabIndex = 6;
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
            this.dataGridView1.Location = new System.Drawing.Point(13, 132);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(618, 352);
            this.dataGridView1.TabIndex = 5;
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
            // Request_panel
            // 
            this.Request_panel.Controls.Add(this.Unit_label);
            this.Request_panel.Controls.Add(this.RequestConfirm_button);
            this.Request_panel.Controls.Add(this.Request_textBox);
            this.Request_panel.Controls.Add(this.Request_comboBox);
            this.Request_panel.Location = new System.Drawing.Point(13, 26);
            this.Request_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Request_panel.Name = "Request_panel";
            this.Request_panel.Size = new System.Drawing.Size(813, 63);
            this.Request_panel.TabIndex = 4;
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
            // RequestConfirm_button
            // 
            this.RequestConfirm_button.Location = new System.Drawing.Point(483, 7);
            this.RequestConfirm_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RequestConfirm_button.Name = "RequestConfirm_button";
            this.RequestConfirm_button.Size = new System.Drawing.Size(92, 34);
            this.RequestConfirm_button.TabIndex = 2;
            this.RequestConfirm_button.Text = "确定";
            this.RequestConfirm_button.UseVisualStyleBackColor = true;
            this.RequestConfirm_button.Click += new System.EventHandler(this.RequestConfirm_button_Click_1);
            // 
            // Request_textBox
            // 
            this.Request_textBox.Location = new System.Drawing.Point(321, 14);
            this.Request_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Request_textBox.Name = "Request_textBox";
            this.Request_textBox.Size = new System.Drawing.Size(43, 25);
            this.Request_textBox.TabIndex = 1;
            // 
            // Request_comboBox
            // 
            this.Request_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Request_comboBox.FormattingEnabled = true;
            this.Request_comboBox.Items.AddRange(new object[] {
            "请求分配",
            "请求回收"});
            this.Request_comboBox.Location = new System.Drawing.Point(100, 14);
            this.Request_comboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Request_comboBox.Name = "Request_comboBox";
            this.Request_comboBox.Size = new System.Drawing.Size(216, 23);
            this.Request_comboBox.TabIndex = 0;
            // 
            // MemoryMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 510);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DrawMem_panel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Request_panel);
            this.Name = "MemoryMain";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Request_panel.ResumeLayout(false);
            this.Request_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel DrawMem_panel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Panel Request_panel;
        private System.Windows.Forms.Label Unit_label;
        private System.Windows.Forms.Button RequestConfirm_button;
        private System.Windows.Forms.TextBox Request_textBox;
        private System.Windows.Forms.ComboBox Request_comboBox;
    }
}