namespace BankerAlgorithm
{
    partial class FormChoose
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
            this.comboBox_chooseTemp = new System.Windows.Forms.ComboBox();
            this.listBox_showAllTemplate = new System.Windows.Forms.ListBox();
            this.ucBtn_confirm = new HZH_Controls.Controls.UCBtnExt();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_chooseTemp
            // 
            this.comboBox_chooseTemp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_chooseTemp.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_chooseTemp.FormattingEnabled = true;
            this.comboBox_chooseTemp.Location = new System.Drawing.Point(69, 70);
            this.comboBox_chooseTemp.Name = "comboBox_chooseTemp";
            this.comboBox_chooseTemp.Size = new System.Drawing.Size(189, 28);
            this.comboBox_chooseTemp.TabIndex = 0;
            this.comboBox_chooseTemp.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listBox_showAllTemplate
            // 
            this.listBox_showAllTemplate.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_showAllTemplate.FormattingEnabled = true;
            this.listBox_showAllTemplate.ItemHeight = 20;
            this.listBox_showAllTemplate.Location = new System.Drawing.Point(69, 104);
            this.listBox_showAllTemplate.Name = "listBox_showAllTemplate";
            this.listBox_showAllTemplate.Size = new System.Drawing.Size(189, 224);
            this.listBox_showAllTemplate.TabIndex = 1;
            // 
            // ucBtn_confirm
            // 
            this.ucBtn_confirm.BackColor = System.Drawing.Color.White;
            this.ucBtn_confirm.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_confirm.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_confirm.BtnForeColor = System.Drawing.Color.White;
            this.ucBtn_confirm.BtnText = "确认";
            this.ucBtn_confirm.ConerRadius = 5;
            this.ucBtn_confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_confirm.EnabledMouseEffect = false;
            this.ucBtn_confirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ucBtn_confirm.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtn_confirm.IsRadius = true;
            this.ucBtn_confirm.IsShowRect = true;
            this.ucBtn_confirm.IsShowTips = false;
            this.ucBtn_confirm.Location = new System.Drawing.Point(262, 352);
            this.ucBtn_confirm.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_confirm.Name = "ucBtn_confirm";
            this.ucBtn_confirm.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ucBtn_confirm.RectWidth = 1;
            this.ucBtn_confirm.Size = new System.Drawing.Size(60, 28);
            this.ucBtn_confirm.TabIndex = 57;
            this.ucBtn_confirm.TabStop = false;
            this.ucBtn_confirm.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_confirm.TipsText = "";
            this.ucBtn_confirm.BtnClick += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ucBtn_confirm);
            this.panel2.Controls.Add(this.listBox_showAllTemplate);
            this.panel2.Controls.Add(this.comboBox_chooseTemp);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 413);
            this.panel2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(125, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 26);
            this.label3.TabIndex = 58;
            this.label3.Text = "模板选择";
            // 
            // FormChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 404);
            this.Controls.Add(this.panel2);
            this.Name = "FormChoose";
            this.Text = "FormChoose";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_chooseTemp;
        private System.Windows.Forms.ListBox listBox_showAllTemplate;
        private HZH_Controls.Controls.UCBtnExt ucBtn_confirm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
    }
}