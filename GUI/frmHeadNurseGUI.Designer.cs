namespace GUI
{
    partial class frmHeadNurseGUI
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
            this.btnInpatientManagement = new System.Windows.Forms.Button();
            this.btnMedicalInventory = new System.Windows.Forms.Button();
            this.btnTaskAssignment = new System.Windows.Forms.Button();
            this.btnDailyCare = new System.Windows.Forms.Button();
            this.btnMedicalRecord = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSignout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel_Body = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInpatientManagement
            // 
            this.btnInpatientManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnInpatientManagement.Location = new System.Drawing.Point(-1, 177);
            this.btnInpatientManagement.Name = "btnInpatientManagement";
            this.btnInpatientManagement.Size = new System.Drawing.Size(187, 73);
            this.btnInpatientManagement.TabIndex = 1;
            this.btnInpatientManagement.Text = "Bệnh Nhân Nội Chú ";
            this.btnInpatientManagement.UseVisualStyleBackColor = false;
            this.btnInpatientManagement.Click += new System.EventHandler(this.btnInpatientManagement_Click);
            // 
            // btnMedicalInventory
            // 
            this.btnMedicalInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMedicalInventory.Location = new System.Drawing.Point(-1, 461);
            this.btnMedicalInventory.Name = "btnMedicalInventory";
            this.btnMedicalInventory.Size = new System.Drawing.Size(187, 73);
            this.btnMedicalInventory.TabIndex = 2;
            this.btnMedicalInventory.Text = "Quản Lý Thuốc Và Vật Tư";
            this.btnMedicalInventory.UseVisualStyleBackColor = false;
            this.btnMedicalInventory.Click += new System.EventHandler(this.btnMedicalInventory_Click);
            // 
            // btnTaskAssignment
            // 
            this.btnTaskAssignment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTaskAssignment.Location = new System.Drawing.Point(-1, 391);
            this.btnTaskAssignment.Name = "btnTaskAssignment";
            this.btnTaskAssignment.Size = new System.Drawing.Size(187, 73);
            this.btnTaskAssignment.TabIndex = 3;
            this.btnTaskAssignment.Text = "Phân Công Công Việc";
            this.btnTaskAssignment.UseVisualStyleBackColor = false;
            this.btnTaskAssignment.Click += new System.EventHandler(this.btnTaskAssignment_Click);
            // 
            // btnDailyCare
            // 
            this.btnDailyCare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDailyCare.Location = new System.Drawing.Point(-1, 320);
            this.btnDailyCare.Name = "btnDailyCare";
            this.btnDailyCare.Size = new System.Drawing.Size(187, 73);
            this.btnDailyCare.TabIndex = 4;
            this.btnDailyCare.Text = "Chăm Sóc Hằng Ngày\r\n";
            this.btnDailyCare.UseVisualStyleBackColor = false;
            this.btnDailyCare.Click += new System.EventHandler(this.btnDailyCare_Click);
            // 
            // btnMedicalRecord
            // 
            this.btnMedicalRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMedicalRecord.Location = new System.Drawing.Point(-1, 248);
            this.btnMedicalRecord.Name = "btnMedicalRecord";
            this.btnMedicalRecord.Size = new System.Drawing.Size(187, 73);
            this.btnMedicalRecord.TabIndex = 5;
            this.btnMedicalRecord.Text = "Quản Lý Y Bệnh";
            this.btnMedicalRecord.UseVisualStyleBackColor = false;
            this.btnMedicalRecord.Click += new System.EventHandler(this.btnMedicalRecord_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.Location = new System.Drawing.Point(0, 384);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 73);
            this.button3.TabIndex = 3;
            this.button3.Text = "Task Assignment";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnSignout);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnInpatientManagement);
            this.panel2.Controls.Add(this.btnMedicalInventory);
            this.panel2.Controls.Add(this.btnMedicalRecord);
            this.panel2.Controls.Add(this.btnTaskAssignment);
            this.panel2.Controls.Add(this.btnDailyCare);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 728);
            this.panel2.TabIndex = 8;
            // 
            // btnSignout
            // 
            this.btnSignout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSignout.Location = new System.Drawing.Point(0, 531);
            this.btnSignout.Name = "btnSignout";
            this.btnSignout.Size = new System.Drawing.Size(187, 73);
            this.btnSignout.TabIndex = 7;
            this.btnSignout.Text = "Đăng Xuất";
            this.btnSignout.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::GUI.Properties.Resources.logonursing;
            this.pictureBox1.InitialImage = global::GUI.Properties.Resources.logonursing;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(187, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 181);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1079, 181);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel_Body
            // 
            this.panel_Body.BackColor = System.Drawing.Color.White;
            this.panel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Body.Location = new System.Drawing.Point(187, 181);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(1079, 547);
            this.panel_Body.TabIndex = 10;
            // 
            // frmHeadNurseGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 728);
            this.Controls.Add(this.panel_Body);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "frmHeadNurseGUI";
            this.Text = "frmHeadNurse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHeadNurse_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInpatientManagement;
        private System.Windows.Forms.Button btnMedicalInventory;
        private System.Windows.Forms.Button btnTaskAssignment;
        private System.Windows.Forms.Button btnDailyCare;
        private System.Windows.Forms.Button btnMedicalRecord;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel_Body;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSignout;
    }
}