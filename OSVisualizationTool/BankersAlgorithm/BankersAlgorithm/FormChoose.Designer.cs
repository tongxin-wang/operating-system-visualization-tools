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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_ok = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_chooseTemp
            // 
            this.comboBox_chooseTemp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_chooseTemp.FormattingEnabled = true;
            this.comboBox_chooseTemp.Location = new System.Drawing.Point(28, 24);
            this.comboBox_chooseTemp.Name = "comboBox_chooseTemp";
            this.comboBox_chooseTemp.Size = new System.Drawing.Size(189, 20);
            this.comboBox_chooseTemp.TabIndex = 0;
            this.comboBox_chooseTemp.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listBox_showAllTemplate
            // 
            this.listBox_showAllTemplate.FormattingEnabled = true;
            this.listBox_showAllTemplate.ItemHeight = 12;
            this.listBox_showAllTemplate.Location = new System.Drawing.Point(28, 76);
            this.listBox_showAllTemplate.Name = "listBox_showAllTemplate";
            this.listBox_showAllTemplate.Size = new System.Drawing.Size(189, 232);
            this.listBox_showAllTemplate.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.listBox_showAllTemplate);
            this.panel2.Controls.Add(this.comboBox_chooseTemp);
            this.panel2.Location = new System.Drawing.Point(42, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 338);
            this.panel2.TabIndex = 3;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(245, 369);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "确认";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 404);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.panel2);
            this.Name = "FormChoose";
            this.Text = "FormChoose";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_chooseTemp;
        private System.Windows.Forms.ListBox listBox_showAllTemplate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_ok;
    }
}