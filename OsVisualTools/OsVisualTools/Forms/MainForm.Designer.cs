namespace OsVisualTools
{
    partial class MainForm
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
            HZH_Controls.Controls.NavigationMenuItem navigationMenuItem5 = new HZH_Controls.Controls.NavigationMenuItem();
            HZH_Controls.Controls.NavigationMenuItem navigationMenuItem6 = new HZH_Controls.Controls.NavigationMenuItem();
            HZH_Controls.Controls.NavigationMenuItem navigationMenuItem7 = new HZH_Controls.Controls.NavigationMenuItem();
            HZH_Controls.Controls.NavigationMenuItem navigationMenuItem8 = new HZH_Controls.Controls.NavigationMenuItem();
            this.ucNavigationMenu = new HZH_Controls.Controls.UCNavigationMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucNavigationMenu
            // 
            this.ucNavigationMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ucNavigationMenu.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucNavigationMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            navigationMenuItem5.AnchorRight = false;
            navigationMenuItem5.DataSource = null;
            navigationMenuItem5.HasSplitLintAtTop = false;
            navigationMenuItem5.Icon = null;
            navigationMenuItem5.Items = null;
            navigationMenuItem5.ItemWidth = 100;
            navigationMenuItem5.ShowTip = false;
            navigationMenuItem5.Text = "菜单1";
            navigationMenuItem5.TipText = null;
            navigationMenuItem6.AnchorRight = false;
            navigationMenuItem6.DataSource = null;
            navigationMenuItem6.HasSplitLintAtTop = false;
            navigationMenuItem6.Icon = null;
            navigationMenuItem6.Items = null;
            navigationMenuItem6.ItemWidth = 100;
            navigationMenuItem6.ShowTip = false;
            navigationMenuItem6.Text = "菜单2";
            navigationMenuItem6.TipText = null;
            navigationMenuItem7.AnchorRight = true;
            navigationMenuItem7.DataSource = null;
            navigationMenuItem7.HasSplitLintAtTop = false;
            navigationMenuItem7.Icon = null;
            navigationMenuItem7.Items = null;
            navigationMenuItem7.ItemWidth = 100;
            navigationMenuItem7.ShowTip = false;
            navigationMenuItem7.Text = "菜单3";
            navigationMenuItem7.TipText = null;
            navigationMenuItem8.AnchorRight = true;
            navigationMenuItem8.DataSource = null;
            navigationMenuItem8.HasSplitLintAtTop = false;
            navigationMenuItem8.Icon = null;
            navigationMenuItem8.Items = null;
            navigationMenuItem8.ItemWidth = 100;
            navigationMenuItem8.ShowTip = false;
            navigationMenuItem8.Text = "菜单4";
            navigationMenuItem8.TipText = null;
            this.ucNavigationMenu.Items = new HZH_Controls.Controls.NavigationMenuItem[] {
        navigationMenuItem5,
        navigationMenuItem6,
        navigationMenuItem7,
        navigationMenuItem8};
            this.ucNavigationMenu.Location = new System.Drawing.Point(0, -2);
            this.ucNavigationMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucNavigationMenu.Name = "ucNavigationMenu";
            this.ucNavigationMenu.Padding = new System.Windows.Forms.Padding(27, 0, 0, 0);
            this.ucNavigationMenu.Size = new System.Drawing.Size(703, 102);
            this.ucNavigationMenu.TabIndex = 4;
            this.ucNavigationMenu.TipColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.ucNavigationMenu.ClickItemed += new System.EventHandler(this.ucNavigationMenu_ClickItemed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(201, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "操作系统实验可视化工具";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 364);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucNavigationMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "首页";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private HZH_Controls.Controls.UCNavigationMenu ucNavigationMenu;
        private System.Windows.Forms.Label label1;
    }
}

