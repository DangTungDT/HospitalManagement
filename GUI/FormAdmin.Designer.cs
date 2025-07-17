namespace GUI
{
    partial class FormAdmin
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
            this.quảnLýTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bệnhNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bảngLươngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phátLươngNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýChứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCơSởVậtChấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýTàiKhoảnToolStripMenuItem,
            this.quảnLýChứcNăngToolStripMenuItem,
            this.quảnLýCơSởVậtChấtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(174, 450);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýTàiKhoảnToolStripMenuItem
            // 
            this.quảnLýTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AccountToolStripMenuItem,
            this.nhânViênToolStripMenuItem,
            this.bệnhNhânToolStripMenuItem,
            this.bảngLươngToolStripMenuItem,
            this.phátLươngNhânViênToolStripMenuItem});
            this.quảnLýTàiKhoảnToolStripMenuItem.Name = "quảnLýTàiKhoảnToolStripMenuItem";
            this.quảnLýTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.quảnLýTàiKhoảnToolStripMenuItem.Text = "Quản lý nhân sự";
            // 
            // AccountToolStripMenuItem
            // 
            this.AccountToolStripMenuItem.Name = "AccountToolStripMenuItem";
            this.AccountToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.AccountToolStripMenuItem.Text = "Tài khoản";
            this.AccountToolStripMenuItem.Click += new System.EventHandler(this.AccountToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // bệnhNhânToolStripMenuItem
            // 
            this.bệnhNhânToolStripMenuItem.Name = "bệnhNhânToolStripMenuItem";
            this.bệnhNhânToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.bệnhNhânToolStripMenuItem.Text = "Bệnh nhân";
            this.bệnhNhânToolStripMenuItem.Click += new System.EventHandler(this.bệnhNhânToolStripMenuItem_Click);
            // 
            // bảngLươngToolStripMenuItem
            // 
            this.bảngLươngToolStripMenuItem.Name = "bảngLươngToolStripMenuItem";
            this.bảngLươngToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.bảngLươngToolStripMenuItem.Text = "Bảng lương";
            this.bảngLươngToolStripMenuItem.Click += new System.EventHandler(this.bảngLươngToolStripMenuItem_Click);
            // 
            // phátLươngNhânViênToolStripMenuItem
            // 
            this.phátLươngNhânViênToolStripMenuItem.Name = "phátLươngNhânViênToolStripMenuItem";
            this.phátLươngNhânViênToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.phátLươngNhânViênToolStripMenuItem.Text = "phát lương nhân viên";
            this.phátLươngNhânViênToolStripMenuItem.Click += new System.EventHandler(this.phátLươngNhânViênToolStripMenuItem_Click);
            // 
            // quảnLýChứcNăngToolStripMenuItem
            // 
            this.quảnLýChứcNăngToolStripMenuItem.Name = "quảnLýChứcNăngToolStripMenuItem";
            this.quảnLýChứcNăngToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.quảnLýChứcNăngToolStripMenuItem.Text = "Quản lý chức năng";
            // 
            // quảnLýCơSởVậtChấtToolStripMenuItem
            // 
            this.quảnLýCơSởVậtChấtToolStripMenuItem.Name = "quảnLýCơSởVậtChấtToolStripMenuItem";
            this.quảnLýCơSởVậtChấtToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.quảnLýCơSởVậtChấtToolStripMenuItem.Text = "Quản lý cơ sở vật chất";
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdmin_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bệnhNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýChứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýCơSởVậtChấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bảngLươngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phátLươngNhânViênToolStripMenuItem;
    }
}