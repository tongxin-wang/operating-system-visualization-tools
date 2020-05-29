namespace ProcesserScheduler
{
    partial class MainWindow
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
            this.ucBtn_Processor = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtn_BankerAlgorithm = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtn_MemoryAllocation = new HZH_Controls.Controls.UCBtnExt();
            this.SuspendLayout();
            // 
            // ucBtn_Processor
            // 
            this.ucBtn_Processor.BackColor = System.Drawing.Color.White;
            this.ucBtn_Processor.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_Processor.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_Processor.BtnForeColor = System.Drawing.Color.White;
            this.ucBtn_Processor.BtnText = "进程调度";
            this.ucBtn_Processor.ConerRadius = 5;
            this.ucBtn_Processor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_Processor.EnabledMouseEffect = false;
            this.ucBtn_Processor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucBtn_Processor.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_Processor.IsRadius = true;
            this.ucBtn_Processor.IsShowRect = true;
            this.ucBtn_Processor.IsShowTips = false;
            this.ucBtn_Processor.Location = new System.Drawing.Point(189, 86);
            this.ucBtn_Processor.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_Processor.Name = "ucBtn_Processor";
            this.ucBtn_Processor.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.ucBtn_Processor.RectWidth = 1;
            this.ucBtn_Processor.Size = new System.Drawing.Size(184, 60);
            this.ucBtn_Processor.TabIndex = 0;
            this.ucBtn_Processor.TabStop = false;
            this.ucBtn_Processor.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_Processor.TipsText = "";
            this.ucBtn_Processor.BtnClick += new System.EventHandler(this.ucBtn_Processor_BtnClick);
            // 
            // ucBtn_BankerAlgorithm
            // 
            this.ucBtn_BankerAlgorithm.BackColor = System.Drawing.Color.White;
            this.ucBtn_BankerAlgorithm.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_BankerAlgorithm.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_BankerAlgorithm.BtnForeColor = System.Drawing.Color.White;
            this.ucBtn_BankerAlgorithm.BtnText = "银行家算法";
            this.ucBtn_BankerAlgorithm.ConerRadius = 5;
            this.ucBtn_BankerAlgorithm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_BankerAlgorithm.EnabledMouseEffect = false;
            this.ucBtn_BankerAlgorithm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucBtn_BankerAlgorithm.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_BankerAlgorithm.IsRadius = true;
            this.ucBtn_BankerAlgorithm.IsShowRect = true;
            this.ucBtn_BankerAlgorithm.IsShowTips = false;
            this.ucBtn_BankerAlgorithm.Location = new System.Drawing.Point(189, 275);
            this.ucBtn_BankerAlgorithm.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_BankerAlgorithm.Name = "ucBtn_BankerAlgorithm";
            this.ucBtn_BankerAlgorithm.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.ucBtn_BankerAlgorithm.RectWidth = 1;
            this.ucBtn_BankerAlgorithm.Size = new System.Drawing.Size(184, 60);
            this.ucBtn_BankerAlgorithm.TabIndex = 1;
            this.ucBtn_BankerAlgorithm.TabStop = false;
            this.ucBtn_BankerAlgorithm.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_BankerAlgorithm.TipsText = "";
            this.ucBtn_BankerAlgorithm.BtnClick += new System.EventHandler(this.ucBtn_BankerAlgorithm_BtnClick);
            // 
            // ucBtn_MemoryAllocation
            // 
            this.ucBtn_MemoryAllocation.BackColor = System.Drawing.Color.White;
            this.ucBtn_MemoryAllocation.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_MemoryAllocation.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_MemoryAllocation.BtnForeColor = System.Drawing.Color.White;
            this.ucBtn_MemoryAllocation.BtnText = "存储管理";
            this.ucBtn_MemoryAllocation.ConerRadius = 5;
            this.ucBtn_MemoryAllocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_MemoryAllocation.EnabledMouseEffect = false;
            this.ucBtn_MemoryAllocation.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucBtn_MemoryAllocation.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_MemoryAllocation.IsRadius = true;
            this.ucBtn_MemoryAllocation.IsShowRect = true;
            this.ucBtn_MemoryAllocation.IsShowTips = false;
            this.ucBtn_MemoryAllocation.Location = new System.Drawing.Point(189, 179);
            this.ucBtn_MemoryAllocation.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_MemoryAllocation.Name = "ucBtn_MemoryAllocation";
            this.ucBtn_MemoryAllocation.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.ucBtn_MemoryAllocation.RectWidth = 1;
            this.ucBtn_MemoryAllocation.Size = new System.Drawing.Size(184, 60);
            this.ucBtn_MemoryAllocation.TabIndex = 2;
            this.ucBtn_MemoryAllocation.TabStop = false;
            this.ucBtn_MemoryAllocation.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_MemoryAllocation.TipsText = "";
            this.ucBtn_MemoryAllocation.BtnClick += new System.EventHandler(this.ucBtn_MemoryAllocation_BtnClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 450);
            this.Controls.Add(this.ucBtn_MemoryAllocation);
            this.Controls.Add(this.ucBtn_BankerAlgorithm);
            this.Controls.Add(this.ucBtn_Processor);
            this.Name = "MainWindow";
            this.Text = "操作系统实验模拟";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCBtnExt ucBtn_Processor;
        private HZH_Controls.Controls.UCBtnExt ucBtn_BankerAlgorithm;
        private HZH_Controls.Controls.UCBtnExt ucBtn_MemoryAllocation;
    }
}