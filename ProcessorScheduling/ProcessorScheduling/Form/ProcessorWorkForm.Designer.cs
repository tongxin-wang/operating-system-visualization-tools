namespace ProcessorScheduling
{
    partial class ProcessorWorkForm
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
            if(disposing && (components != null))
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
            this.lab_ready = new System.Windows.Forms.Label();
            this.pnl_ready = new System.Windows.Forms.Panel();
            this.lab_info = new System.Windows.Forms.Label();
            this.pnl_finished = new System.Windows.Forms.Panel();
            this.lab_finish = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lab_request = new System.Windows.Forms.Label();
            this.rtx_prompt = new System.Windows.Forms.RichTextBox();
            this.lab_pro = new System.Windows.Forms.Label();
            this.pnl_running = new System.Windows.Forms.Panel();
            this.lab_current = new System.Windows.Forms.Label();
            this.ucBtn_start = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtn_back = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtn_replay = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtn_add = new HZH_Controls.Controls.UCBtnExt();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lab_ready
            // 
            this.lab_ready.AutoSize = true;
            this.lab_ready.Font = new System.Drawing.Font("华文中宋", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_ready.Location = new System.Drawing.Point(27, 40);
            this.lab_ready.Name = "lab_ready";
            this.lab_ready.Size = new System.Drawing.Size(187, 27);
            this.lab_ready.TabIndex = 0;
            this.lab_ready.Text = "就绪队列排序：";
            // 
            // pnl_ready
            // 
            this.pnl_ready.Location = new System.Drawing.Point(32, 69);
            this.pnl_ready.Name = "pnl_ready";
            this.pnl_ready.Size = new System.Drawing.Size(394, 170);
            this.pnl_ready.TabIndex = 1;
            this.pnl_ready.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_ready_Paint);
            // 
            // lab_info
            // 
            this.lab_info.AutoSize = true;
            this.lab_info.Font = new System.Drawing.Font("华文中宋", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_info.Location = new System.Drawing.Point(29, 437);
            this.lab_info.Name = "lab_info";
            this.lab_info.Size = new System.Drawing.Size(137, 27);
            this.lab_info.TabIndex = 2;
            this.lab_info.Text = "提示信息：";
            // 
            // pnl_finished
            // 
            this.pnl_finished.Location = new System.Drawing.Point(32, 265);
            this.pnl_finished.Name = "pnl_finished";
            this.pnl_finished.Size = new System.Drawing.Size(394, 168);
            this.pnl_finished.TabIndex = 3;
            // 
            // lab_finish
            // 
            this.lab_finish.AutoSize = true;
            this.lab_finish.Font = new System.Drawing.Font("华文中宋", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_finish.Location = new System.Drawing.Point(29, 242);
            this.lab_finish.Name = "lab_finish";
            this.lab_finish.Size = new System.Drawing.Size(187, 27);
            this.lab_finish.TabIndex = 4;
            this.lab_finish.Text = "已完成的进程：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lab_request);
            this.panel3.Controls.Add(this.rtx_prompt);
            this.panel3.Controls.Add(this.lab_pro);
            this.panel3.Location = new System.Drawing.Point(32, 466);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(394, 100);
            this.panel3.TabIndex = 0;
            // 
            // lab_request
            // 
            this.lab_request.AutoSize = true;
            this.lab_request.Location = new System.Drawing.Point(640, 31);
            this.lab_request.Name = "lab_request";
            this.lab_request.Size = new System.Drawing.Size(67, 15);
            this.lab_request.TabIndex = 19;
            this.lab_request.Text = "运行时间";
            // 
            // rtx_prompt
            // 
            this.rtx_prompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtx_prompt.Location = new System.Drawing.Point(0, 0);
            this.rtx_prompt.Name = "rtx_prompt";
            this.rtx_prompt.ReadOnly = true;
            this.rtx_prompt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtx_prompt.Size = new System.Drawing.Size(394, 100);
            this.rtx_prompt.TabIndex = 9;
            this.rtx_prompt.Text = "";
            // 
            // lab_pro
            // 
            this.lab_pro.AutoSize = true;
            this.lab_pro.Location = new System.Drawing.Point(451, 31);
            this.lab_pro.Name = "lab_pro";
            this.lab_pro.Size = new System.Drawing.Size(52, 15);
            this.lab_pro.TabIndex = 18;
            this.lab_pro.Text = "优先数";
            // 
            // pnl_running
            // 
            this.pnl_running.Location = new System.Drawing.Point(485, 80);
            this.pnl_running.Name = "pnl_running";
            this.pnl_running.Size = new System.Drawing.Size(287, 299);
            this.pnl_running.TabIndex = 7;
            // 
            // lab_current
            // 
            this.lab_current.AutoSize = true;
            this.lab_current.Font = new System.Drawing.Font("华文中宋", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_current.Location = new System.Drawing.Point(482, 51);
            this.lab_current.Name = "lab_current";
            this.lab_current.Size = new System.Drawing.Size(187, 27);
            this.lab_current.TabIndex = 8;
            this.lab_current.Text = "当前运行进程：";
            // 
            // ucBtn_start
            // 
            this.ucBtn_start.BackColor = System.Drawing.Color.White;
            this.ucBtn_start.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_start.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_start.BtnForeColor = System.Drawing.Color.White;
            this.ucBtn_start.BtnText = "开始";
            this.ucBtn_start.ConerRadius = 5;
            this.ucBtn_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_start.EnabledMouseEffect = false;
            this.ucBtn_start.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucBtn_start.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_start.IsRadius = true;
            this.ucBtn_start.IsShowRect = true;
            this.ucBtn_start.IsShowTips = false;
            this.ucBtn_start.Location = new System.Drawing.Point(32, 578);
            this.ucBtn_start.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_start.Name = "ucBtn_start";
            this.ucBtn_start.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.ucBtn_start.RectWidth = 1;
            this.ucBtn_start.Size = new System.Drawing.Size(111, 60);
            this.ucBtn_start.TabIndex = 24;
            this.ucBtn_start.TabStop = false;
            this.ucBtn_start.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_start.TipsText = "";
            this.ucBtn_start.BtnClick += new System.EventHandler(this.ucBtn_start_BtnClick);
            // 
            // ucBtn_back
            // 
            this.ucBtn_back.BackColor = System.Drawing.Color.White;
            this.ucBtn_back.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_back.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_back.BtnForeColor = System.Drawing.Color.White;
            this.ucBtn_back.BtnText = "返回";
            this.ucBtn_back.ConerRadius = 5;
            this.ucBtn_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_back.EnabledMouseEffect = false;
            this.ucBtn_back.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucBtn_back.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_back.IsRadius = true;
            this.ucBtn_back.IsShowRect = true;
            this.ucBtn_back.IsShowTips = false;
            this.ucBtn_back.Location = new System.Drawing.Point(336, 578);
            this.ucBtn_back.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_back.Name = "ucBtn_back";
            this.ucBtn_back.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.ucBtn_back.RectWidth = 1;
            this.ucBtn_back.Size = new System.Drawing.Size(111, 60);
            this.ucBtn_back.TabIndex = 24;
            this.ucBtn_back.TabStop = false;
            this.ucBtn_back.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_back.TipsText = "";
            this.ucBtn_back.BtnClick += new System.EventHandler(this.ucBtn_back_BtnClick);
            // 
            // ucBtn_replay
            // 
            this.ucBtn_replay.BackColor = System.Drawing.Color.White;
            this.ucBtn_replay.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_replay.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_replay.BtnForeColor = System.Drawing.Color.White;
            this.ucBtn_replay.BtnText = "再看一次";
            this.ucBtn_replay.ConerRadius = 5;
            this.ucBtn_replay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_replay.EnabledMouseEffect = false;
            this.ucBtn_replay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucBtn_replay.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_replay.IsRadius = true;
            this.ucBtn_replay.IsShowRect = true;
            this.ucBtn_replay.IsShowTips = false;
            this.ucBtn_replay.Location = new System.Drawing.Point(175, 578);
            this.ucBtn_replay.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_replay.Name = "ucBtn_replay";
            this.ucBtn_replay.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.ucBtn_replay.RectWidth = 1;
            this.ucBtn_replay.Size = new System.Drawing.Size(111, 60);
            this.ucBtn_replay.TabIndex = 24;
            this.ucBtn_replay.TabStop = false;
            this.ucBtn_replay.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_replay.TipsText = "";
            this.ucBtn_replay.BtnClick += new System.EventHandler(this.ucBtn_replay_BtnClick);
            // 
            // ucBtn_add
            // 
            this.ucBtn_add.BackColor = System.Drawing.Color.White;
            this.ucBtn_add.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_add.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_add.BtnForeColor = System.Drawing.Color.White;
            this.ucBtn_add.BtnText = "添加进程";
            this.ucBtn_add.ConerRadius = 5;
            this.ucBtn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_add.EnabledMouseEffect = false;
            this.ucBtn_add.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucBtn_add.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_add.IsRadius = true;
            this.ucBtn_add.IsShowRect = true;
            this.ucBtn_add.IsShowTips = false;
            this.ucBtn_add.Location = new System.Drawing.Point(583, 578);
            this.ucBtn_add.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_add.Name = "ucBtn_add";
            this.ucBtn_add.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.ucBtn_add.RectWidth = 1;
            this.ucBtn_add.Size = new System.Drawing.Size(111, 60);
            this.ucBtn_add.TabIndex = 25;
            this.ucBtn_add.TabStop = false;
            this.ucBtn_add.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_add.TipsText = "";
            this.ucBtn_add.BtnClick += new System.EventHandler(this.ucBtn_add_BtnClick);
            // 
            // ProcessorWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 652);
            this.Controls.Add(this.ucBtn_add);
            this.Controls.Add(this.ucBtn_start);
            this.Controls.Add(this.ucBtn_replay);
            this.Controls.Add(this.ucBtn_back);
            this.Controls.Add(this.lab_current);
            this.Controls.Add(this.pnl_running);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lab_finish);
            this.Controls.Add(this.pnl_finished);
            this.Controls.Add(this.lab_info);
            this.Controls.Add(this.pnl_ready);
            this.Controls.Add(this.lab_ready);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProcessorWorkForm";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_ready;
        private System.Windows.Forms.Panel pnl_ready;
        private System.Windows.Forms.Label lab_info;
        private System.Windows.Forms.Panel pnl_finished;
        private System.Windows.Forms.Label lab_finish;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnl_running;
        private System.Windows.Forms.RichTextBox rtx_prompt;
        private System.Windows.Forms.Label lab_current;
        private System.Windows.Forms.Label lab_request;
        private System.Windows.Forms.Label lab_pro;
        private HZH_Controls.Controls.UCBtnExt ucBtn_start;
        private HZH_Controls.Controls.UCBtnExt ucBtn_back;
        private HZH_Controls.Controls.UCBtnExt ucBtn_replay;
        private HZH_Controls.Controls.UCBtnExt ucBtn_add;
    }
}