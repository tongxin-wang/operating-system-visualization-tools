namespace ProcessorScheduling
{
    partial class ProcessorMainForm
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
            if(disposing && (components != null))
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
            this.label1 = new System.Windows.Forms.Label();
            this.lab_A = new System.Windows.Forms.Label();
            this.lab_B = new System.Windows.Forms.Label();
            this.lab_C = new System.Windows.Forms.Label();
            this.lab_D = new System.Windows.Forms.Label();
            this.lab_pro = new System.Windows.Forms.Label();
            this.lab_request = new System.Windows.Forms.Label();
            this.ucBtn_ok = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtn_import = new HZH_Controls.Controls.UCBtnExt();
            this.ucTrackBarApro = new HZH_Controls.Controls.UCTrackBar();
            this.ucTrackBarDpro = new HZH_Controls.Controls.UCTrackBar();
            this.ucTrackBarCpro = new HZH_Controls.Controls.UCTrackBar();
            this.ucTrackBarBpro = new HZH_Controls.Controls.UCTrackBar();
            this.ucTrackBarDrunTime = new HZH_Controls.Controls.UCTrackBar();
            this.ucTrackBarCrunTime = new HZH_Controls.Controls.UCTrackBar();
            this.ucTrackBarBrunTime = new HZH_Controls.Controls.UCTrackBar();
            this.ucTrackBarArunTime = new HZH_Controls.Controls.UCTrackBar();
            this.ucBtn_back = new HZH_Controls.Controls.UCBtnExt();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入优先数和要求运行时间：";
            // 
            // lab_A
            // 
            this.lab_A.AutoSize = true;
            this.lab_A.Location = new System.Drawing.Point(85, 114);
            this.lab_A.Name = "lab_A";
            this.lab_A.Size = new System.Drawing.Size(15, 15);
            this.lab_A.TabIndex = 1;
            this.lab_A.Text = "A";
            // 
            // lab_B
            // 
            this.lab_B.AutoSize = true;
            this.lab_B.Location = new System.Drawing.Point(85, 165);
            this.lab_B.Name = "lab_B";
            this.lab_B.Size = new System.Drawing.Size(15, 15);
            this.lab_B.TabIndex = 2;
            this.lab_B.Text = "B";
            // 
            // lab_C
            // 
            this.lab_C.AutoSize = true;
            this.lab_C.Location = new System.Drawing.Point(85, 213);
            this.lab_C.Name = "lab_C";
            this.lab_C.Size = new System.Drawing.Size(15, 15);
            this.lab_C.TabIndex = 3;
            this.lab_C.Text = "C";
            // 
            // lab_D
            // 
            this.lab_D.AutoSize = true;
            this.lab_D.Location = new System.Drawing.Point(85, 268);
            this.lab_D.Name = "lab_D";
            this.lab_D.Size = new System.Drawing.Size(15, 15);
            this.lab_D.TabIndex = 4;
            this.lab_D.Text = "D";
            // 
            // lab_pro
            // 
            this.lab_pro.AutoSize = true;
            this.lab_pro.Font = new System.Drawing.Font("华文中宋", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_pro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.lab_pro.Location = new System.Drawing.Point(181, 80);
            this.lab_pro.Name = "lab_pro";
            this.lab_pro.Size = new System.Drawing.Size(87, 27);
            this.lab_pro.TabIndex = 13;
            this.lab_pro.Text = "优先数";
            // 
            // lab_request
            // 
            this.lab_request.AutoSize = true;
            this.lab_request.Font = new System.Drawing.Font("华文中宋", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_request.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.lab_request.Location = new System.Drawing.Point(380, 80);
            this.lab_request.Name = "lab_request";
            this.lab_request.Size = new System.Drawing.Size(112, 27);
            this.lab_request.TabIndex = 14;
            this.lab_request.Text = "运行时间";
            // 
            // ucBtn_ok
            // 
            this.ucBtn_ok.BackColor = System.Drawing.Color.White;
            this.ucBtn_ok.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_ok.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_ok.BtnForeColor = System.Drawing.Color.White;
            this.ucBtn_ok.BtnText = "确认";
            this.ucBtn_ok.ConerRadius = 5;
            this.ucBtn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_ok.EnabledMouseEffect = false;
            this.ucBtn_ok.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ucBtn_ok.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_ok.IsRadius = true;
            this.ucBtn_ok.IsShowRect = true;
            this.ucBtn_ok.IsShowTips = false;
            this.ucBtn_ok.Location = new System.Drawing.Point(199, 350);
            this.ucBtn_ok.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_ok.Name = "ucBtn_ok";
            this.ucBtn_ok.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ucBtn_ok.RectWidth = 1;
            this.ucBtn_ok.Size = new System.Drawing.Size(133, 60);
            this.ucBtn_ok.TabIndex = 17;
            this.ucBtn_ok.TabStop = false;
            this.ucBtn_ok.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_ok.TipsText = "";
            this.ucBtn_ok.BtnClick += new System.EventHandler(this.ucBtn_ok_BtnClick);
            // 
            // ucBtn_import
            // 
            this.ucBtn_import.BackColor = System.Drawing.Color.White;
            this.ucBtn_import.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_import.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_import.BtnForeColor = System.Drawing.Color.White;
            this.ucBtn_import.BtnText = "使用默认参数";
            this.ucBtn_import.ConerRadius = 5;
            this.ucBtn_import.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_import.EnabledMouseEffect = false;
            this.ucBtn_import.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ucBtn_import.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_import.IsRadius = true;
            this.ucBtn_import.IsShowRect = true;
            this.ucBtn_import.IsShowTips = false;
            this.ucBtn_import.Location = new System.Drawing.Point(374, 350);
            this.ucBtn_import.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_import.Name = "ucBtn_import";
            this.ucBtn_import.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ucBtn_import.RectWidth = 1;
            this.ucBtn_import.Size = new System.Drawing.Size(144, 60);
            this.ucBtn_import.TabIndex = 2;
            this.ucBtn_import.TabStop = false;
            this.ucBtn_import.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_import.TipsText = "";
            this.ucBtn_import.BtnClick += new System.EventHandler(this.ucBtn_import_BtnClick);
            // 
            // ucTrackBarApro
            // 
            this.ucTrackBarApro.DcimalDigits = 0;
            this.ucTrackBarApro.IsShowTips = true;
            this.ucTrackBarApro.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrackBarApro.LineWidth = 10F;
            this.ucTrackBarApro.Location = new System.Drawing.Point(162, 114);
            this.ucTrackBarApro.MaxValue = 12F;
            this.ucTrackBarApro.MinValue = 0F;
            this.ucTrackBarApro.Name = "ucTrackBarApro";
            this.ucTrackBarApro.Size = new System.Drawing.Size(151, 30);
            this.ucTrackBarApro.TabIndex = 18;
            this.ucTrackBarApro.Text = "ucTrackBar1";
            this.ucTrackBarApro.TipsFormat = null;
            this.ucTrackBarApro.Value = 0F;
            this.ucTrackBarApro.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            // 
            // ucTrackBarDpro
            // 
            this.ucTrackBarDpro.DcimalDigits = 0;
            this.ucTrackBarDpro.IsShowTips = true;
            this.ucTrackBarDpro.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrackBarDpro.LineWidth = 10F;
            this.ucTrackBarDpro.Location = new System.Drawing.Point(162, 268);
            this.ucTrackBarDpro.MaxValue = 12F;
            this.ucTrackBarDpro.MinValue = 0F;
            this.ucTrackBarDpro.Name = "ucTrackBarDpro";
            this.ucTrackBarDpro.Size = new System.Drawing.Size(151, 30);
            this.ucTrackBarDpro.TabIndex = 20;
            this.ucTrackBarDpro.Text = "ucTrackBar3";
            this.ucTrackBarDpro.TipsFormat = null;
            this.ucTrackBarDpro.Value = 0F;
            this.ucTrackBarDpro.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            // 
            // ucTrackBarCpro
            // 
            this.ucTrackBarCpro.DcimalDigits = 0;
            this.ucTrackBarCpro.IsShowTips = true;
            this.ucTrackBarCpro.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrackBarCpro.LineWidth = 10F;
            this.ucTrackBarCpro.Location = new System.Drawing.Point(162, 218);
            this.ucTrackBarCpro.MaxValue = 12F;
            this.ucTrackBarCpro.MinValue = 0F;
            this.ucTrackBarCpro.Name = "ucTrackBarCpro";
            this.ucTrackBarCpro.Size = new System.Drawing.Size(151, 30);
            this.ucTrackBarCpro.TabIndex = 21;
            this.ucTrackBarCpro.Text = "ucTrackBar4";
            this.ucTrackBarCpro.TipsFormat = null;
            this.ucTrackBarCpro.Value = 0F;
            this.ucTrackBarCpro.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            // 
            // ucTrackBarBpro
            // 
            this.ucTrackBarBpro.DcimalDigits = 0;
            this.ucTrackBarBpro.IsShowTips = true;
            this.ucTrackBarBpro.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrackBarBpro.LineWidth = 10F;
            this.ucTrackBarBpro.Location = new System.Drawing.Point(162, 170);
            this.ucTrackBarBpro.MaxValue = 12F;
            this.ucTrackBarBpro.MinValue = 0F;
            this.ucTrackBarBpro.Name = "ucTrackBarBpro";
            this.ucTrackBarBpro.Size = new System.Drawing.Size(151, 30);
            this.ucTrackBarBpro.TabIndex = 22;
            this.ucTrackBarBpro.Text = "ucTrackBar5";
            this.ucTrackBarBpro.TipsFormat = null;
            this.ucTrackBarBpro.Value = 0F;
            this.ucTrackBarBpro.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            // 
            // ucTrackBarDrunTime
            // 
            this.ucTrackBarDrunTime.DcimalDigits = 0;
            this.ucTrackBarDrunTime.IsShowTips = true;
            this.ucTrackBarDrunTime.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrackBarDrunTime.LineWidth = 10F;
            this.ucTrackBarDrunTime.Location = new System.Drawing.Point(374, 268);
            this.ucTrackBarDrunTime.MaxValue = 6F;
            this.ucTrackBarDrunTime.MinValue = 1F;
            this.ucTrackBarDrunTime.Name = "ucTrackBarDrunTime";
            this.ucTrackBarDrunTime.Size = new System.Drawing.Size(162, 30);
            this.ucTrackBarDrunTime.TabIndex = 23;
            this.ucTrackBarDrunTime.Text = "ucTrackBar6";
            this.ucTrackBarDrunTime.TipsFormat = null;
            this.ucTrackBarDrunTime.Value = 0F;
            this.ucTrackBarDrunTime.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            // 
            // ucTrackBarCrunTime
            // 
            this.ucTrackBarCrunTime.DcimalDigits = 0;
            this.ucTrackBarCrunTime.IsShowTips = true;
            this.ucTrackBarCrunTime.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrackBarCrunTime.LineWidth = 10F;
            this.ucTrackBarCrunTime.Location = new System.Drawing.Point(374, 213);
            this.ucTrackBarCrunTime.MaxValue = 6F;
            this.ucTrackBarCrunTime.MinValue = 1F;
            this.ucTrackBarCrunTime.Name = "ucTrackBarCrunTime";
            this.ucTrackBarCrunTime.Size = new System.Drawing.Size(162, 30);
            this.ucTrackBarCrunTime.TabIndex = 24;
            this.ucTrackBarCrunTime.Text = "ucTrackBar7";
            this.ucTrackBarCrunTime.TipsFormat = null;
            this.ucTrackBarCrunTime.Value = 0F;
            this.ucTrackBarCrunTime.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            // 
            // ucTrackBarBrunTime
            // 
            this.ucTrackBarBrunTime.DcimalDigits = 0;
            this.ucTrackBarBrunTime.IsShowTips = true;
            this.ucTrackBarBrunTime.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrackBarBrunTime.LineWidth = 10F;
            this.ucTrackBarBrunTime.Location = new System.Drawing.Point(374, 165);
            this.ucTrackBarBrunTime.MaxValue = 5F;
            this.ucTrackBarBrunTime.MinValue = 1F;
            this.ucTrackBarBrunTime.Name = "ucTrackBarBrunTime";
            this.ucTrackBarBrunTime.Size = new System.Drawing.Size(162, 30);
            this.ucTrackBarBrunTime.TabIndex = 25;
            this.ucTrackBarBrunTime.Text = "ucTrackBar8";
            this.ucTrackBarBrunTime.TipsFormat = null;
            this.ucTrackBarBrunTime.Value = 0F;
            this.ucTrackBarBrunTime.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            // 
            // ucTrackBarArunTime
            // 
            this.ucTrackBarArunTime.DcimalDigits = 0;
            this.ucTrackBarArunTime.IsShowTips = true;
            this.ucTrackBarArunTime.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrackBarArunTime.LineWidth = 10F;
            this.ucTrackBarArunTime.Location = new System.Drawing.Point(374, 114);
            this.ucTrackBarArunTime.MaxValue = 5F;
            this.ucTrackBarArunTime.MinValue = 1F;
            this.ucTrackBarArunTime.Name = "ucTrackBarArunTime";
            this.ucTrackBarArunTime.Size = new System.Drawing.Size(162, 30);
            this.ucTrackBarArunTime.TabIndex = 19;
            this.ucTrackBarArunTime.Text = "ucTrackBar2";
            this.ucTrackBarArunTime.TipsFormat = null;
            this.ucTrackBarArunTime.Value = 0F;
            this.ucTrackBarArunTime.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
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
            this.ucBtn_back.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ucBtn_back.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_back.IsRadius = true;
            this.ucBtn_back.IsShowRect = true;
            this.ucBtn_back.IsShowTips = false;
            this.ucBtn_back.Location = new System.Drawing.Point(41, 350);
            this.ucBtn_back.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_back.Name = "ucBtn_back";
            this.ucBtn_back.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ucBtn_back.RectWidth = 1;
            this.ucBtn_back.Size = new System.Drawing.Size(109, 60);
            this.ucBtn_back.TabIndex = 26;
            this.ucBtn_back.TabStop = false;
            this.ucBtn_back.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_back.TipsText = "";
            this.ucBtn_back.BtnClick += new System.EventHandler(this.ucBtn_back_BtnClick);
            // 
            // ProcessorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.ucBtn_back);
            this.Controls.Add(this.ucTrackBarBrunTime);
            this.Controls.Add(this.ucTrackBarCrunTime);
            this.Controls.Add(this.ucTrackBarDrunTime);
            this.Controls.Add(this.ucTrackBarBpro);
            this.Controls.Add(this.ucTrackBarCpro);
            this.Controls.Add(this.ucTrackBarDpro);
            this.Controls.Add(this.ucTrackBarArunTime);
            this.Controls.Add(this.ucTrackBarApro);
            this.Controls.Add(this.ucBtn_import);
            this.Controls.Add(this.ucBtn_ok);
            this.Controls.Add(this.lab_request);
            this.Controls.Add(this.lab_pro);
            this.Controls.Add(this.lab_D);
            this.Controls.Add(this.lab_C);
            this.Controls.Add(this.lab_B);
            this.Controls.Add(this.lab_A);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProcessorMainForm";
            this.Text = "处理器调度";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProcessorMainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_A;
        private System.Windows.Forms.Label lab_B;
        private System.Windows.Forms.Label lab_C;
        private System.Windows.Forms.Label lab_D;
        private System.Windows.Forms.Label lab_pro;
        private System.Windows.Forms.Label lab_request;
        private HZH_Controls.Controls.UCBtnExt ucBtn_ok;
        private HZH_Controls.Controls.UCBtnExt ucBtn_import;
        private HZH_Controls.Controls.UCTrackBar ucTrackBarApro;
        private HZH_Controls.Controls.UCTrackBar ucTrackBarDpro;
        private HZH_Controls.Controls.UCTrackBar ucTrackBarCpro;
        private HZH_Controls.Controls.UCTrackBar ucTrackBarBpro;
        private HZH_Controls.Controls.UCTrackBar ucTrackBarDrunTime;
        private HZH_Controls.Controls.UCTrackBar ucTrackBarCrunTime;
        private HZH_Controls.Controls.UCTrackBar ucTrackBarBrunTime;
        private HZH_Controls.Controls.UCTrackBar ucTrackBarArunTime;
        private HZH_Controls.Controls.UCBtnExt ucBtn_back;
    }
}

