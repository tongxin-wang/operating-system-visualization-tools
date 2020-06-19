namespace EX2
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lblin = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lblout = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ucBtn_load = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtnExt_move = new HZH_Controls.Controls.UCBtnExt();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(31, 445);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(706, 184);
            this.listBox1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(31, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 320);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(413, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 320);
            this.panel2.TabIndex = 4;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(60, 21);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(112, 15);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "输入文件大小：";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(57, 51);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(112, 15);
            this.lbl2.TabIndex = 6;
            this.lbl2.Text = "删除文件序号：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(178, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 25);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(178, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(229, 25);
            this.textBox2.TabIndex = 8;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(28, 655);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(172, 15);
            this.lbl3.TabIndex = 11;
            this.lbl3.Text = "本次分配磁盘物理地址：";
            // 
            // lblin
            // 
            this.lblin.AutoSize = true;
            this.lblin.Location = new System.Drawing.Point(251, 655);
            this.lblin.Name = "lblin";
            this.lblin.Size = new System.Drawing.Size(55, 15);
            this.lblin.TabIndex = 12;
            this.lblin.Text = "label1";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(28, 724);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(202, 15);
            this.lbl4.TabIndex = 13;
            this.lbl4.Text = "归还块对应的字节号和位数：";
            // 
            // lblout
            // 
            this.lblout.AutoSize = true;
            this.lblout.Location = new System.Drawing.Point(251, 724);
            this.lblout.Name = "lblout";
            this.lblout.Size = new System.Drawing.Size(55, 15);
            this.lblout.TabIndex = 14;
            this.lblout.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 679);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "（柱面号、磁道号、物理记录号）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 749);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "（字节号、位数）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "before";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(546, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "after";
            // 
            // ucBtn_load
            // 
            this.ucBtn_load.BackColor = System.Drawing.Color.White;
            this.ucBtn_load.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_load.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_load.BtnForeColor = System.Drawing.Color.White;
            this.ucBtn_load.BtnText = "装入";
            this.ucBtn_load.ConerRadius = 5;
            this.ucBtn_load.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_load.EnabledMouseEffect = false;
            this.ucBtn_load.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ucBtn_load.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_load.IsRadius = true;
            this.ucBtn_load.IsShowRect = true;
            this.ucBtn_load.IsShowTips = false;
            this.ucBtn_load.Location = new System.Drawing.Point(430, 12);
            this.ucBtn_load.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_load.Name = "ucBtn_load";
            this.ucBtn_load.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ucBtn_load.RectWidth = 1;
            this.ucBtn_load.Size = new System.Drawing.Size(83, 25);
            this.ucBtn_load.TabIndex = 19;
            this.ucBtn_load.TabStop = false;
            this.ucBtn_load.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_load.TipsText = "";
            this.ucBtn_load.BtnClick += new System.EventHandler(this.ucBtn_load_BtnClick);
            // 
            // ucBtnExt_move
            // 
            this.ucBtnExt_move.BackColor = System.Drawing.Color.White;
            this.ucBtnExt_move.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt_move.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt_move.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt_move.BtnText = "移出";
            this.ucBtnExt_move.ConerRadius = 5;
            this.ucBtnExt_move.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt_move.EnabledMouseEffect = false;
            this.ucBtnExt_move.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ucBtnExt_move.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExt_move.IsRadius = true;
            this.ucBtnExt_move.IsShowRect = true;
            this.ucBtnExt_move.IsShowTips = false;
            this.ucBtnExt_move.Location = new System.Drawing.Point(431, 43);
            this.ucBtnExt_move.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt_move.Name = "ucBtnExt_move";
            this.ucBtnExt_move.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ucBtnExt_move.RectWidth = 1;
            this.ucBtnExt_move.Size = new System.Drawing.Size(82, 27);
            this.ucBtnExt_move.TabIndex = 20;
            this.ucBtnExt_move.TabStop = false;
            this.ucBtnExt_move.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt_move.TipsText = "";
            this.ucBtnExt_move.BtnClick += new System.EventHandler(this.ucBtnExt_move_BtnClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 819);
            this.Controls.Add(this.ucBtnExt_move);
            this.Controls.Add(this.ucBtn_load);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblout);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lblin);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "磁盘管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lblin;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lblout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private HZH_Controls.Controls.UCBtnExt ucBtn_load;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt_move;
    }
}

