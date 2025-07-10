namespace GUI
{
    partial class FormLeTan
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngKýLịchHẹnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmBệnhNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmBệnhNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.chứcNăngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1002, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngKýLịchHẹnToolStripMenuItem,
            this.thêmBệnhNhânToolStripMenuItem,
            this.tìmBệnhNhânToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // đăngKýLịchHẹnToolStripMenuItem
            // 
            this.đăngKýLịchHẹnToolStripMenuItem.Name = "đăngKýLịchHẹnToolStripMenuItem";
            this.đăngKýLịchHẹnToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.đăngKýLịchHẹnToolStripMenuItem.Text = "Đăng ký lịch hẹn";
            // 
            // thêmBệnhNhânToolStripMenuItem
            // 
            this.thêmBệnhNhânToolStripMenuItem.Name = "thêmBệnhNhânToolStripMenuItem";
            this.thêmBệnhNhânToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thêmBệnhNhânToolStripMenuItem.Text = "Thêm bệnh nhân";
            // 
            // tìmBệnhNhânToolStripMenuItem
            // 
            this.tìmBệnhNhânToolStripMenuItem.Name = "tìmBệnhNhânToolStripMenuItem";
            this.tìmBệnhNhânToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tìmBệnhNhânToolStripMenuItem.Text = "tìm bệnh nhân";
            // 
            // FormLeTan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 497);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormLeTan";
            this.Text = "FormLeTan";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngKýLịchHẹnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmBệnhNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmBệnhNhânToolStripMenuItem;
    }
}