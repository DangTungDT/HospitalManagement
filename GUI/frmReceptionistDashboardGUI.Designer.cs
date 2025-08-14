namespace GUI
{
    partial class frmReceptionistDashboardGUI
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
            this.btnAppointmentManagement = new System.Windows.Forms.Button();
            this.btnInpatientAdmission = new System.Windows.Forms.Button();
            this.btnMedicalRegistration = new System.Windows.Forms.Button();
            this.btnDischarge = new System.Windows.Forms.Button();
            this.btnPatientAdmission = new System.Windows.Forms.Button();
            this.btnSignout = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPatientSearch = new System.Windows.Forms.Button();
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
            // btnAppointmentManagement
            // 
            this.btnAppointmentManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAppointmentManagement.Location = new System.Drawing.Point(-1, 260);
            this.btnAppointmentManagement.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAppointmentManagement.Name = "btnAppointmentManagement";
            this.btnAppointmentManagement.Size = new System.Drawing.Size(140, 59);
            this.btnAppointmentManagement.TabIndex = 4;
            this.btnAppointmentManagement.Text = "Quản Lý Lịch Hẹn";
            this.btnAppointmentManagement.UseVisualStyleBackColor = false;
            this.btnAppointmentManagement.Click += new System.EventHandler(this.btnAppointmentManagement_Click);
            // 
            // btnInpatientAdmission
            // 
            this.btnInpatientAdmission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnInpatientAdmission.Location = new System.Drawing.Point(-1, 318);
            this.btnInpatientAdmission.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInpatientAdmission.Name = "btnInpatientAdmission";
            this.btnInpatientAdmission.Size = new System.Drawing.Size(140, 59);
            this.btnInpatientAdmission.TabIndex = 3;
            this.btnInpatientAdmission.Text = "Nhập Viện";
            this.btnInpatientAdmission.UseVisualStyleBackColor = false;
            // 
            // btnMedicalRegistration
            // 
            this.btnMedicalRegistration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMedicalRegistration.Location = new System.Drawing.Point(-1, 202);
            this.btnMedicalRegistration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMedicalRegistration.Name = "btnMedicalRegistration";
            this.btnMedicalRegistration.Size = new System.Drawing.Size(140, 59);
            this.btnMedicalRegistration.TabIndex = 5;
            this.btnMedicalRegistration.Text = "Đăng Ký Khám";
            this.btnMedicalRegistration.UseVisualStyleBackColor = false;
            this.btnMedicalRegistration.Click += new System.EventHandler(this.btnMedicalRegistration_Click);
            // 
            // btnDischarge
            // 
            this.btnDischarge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDischarge.Location = new System.Drawing.Point(-1, 375);
            this.btnDischarge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDischarge.Name = "btnDischarge";
            this.btnDischarge.Size = new System.Drawing.Size(140, 59);
            this.btnDischarge.TabIndex = 2;
            this.btnDischarge.Text = "Xuất Viện ";
            this.btnDischarge.UseVisualStyleBackColor = false;
            // 
            // btnPatientAdmission
            // 
            this.btnPatientAdmission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPatientAdmission.Location = new System.Drawing.Point(-1, 144);
            this.btnPatientAdmission.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPatientAdmission.Name = "btnPatientAdmission";
            this.btnPatientAdmission.Size = new System.Drawing.Size(140, 59);
            this.btnPatientAdmission.TabIndex = 1;
            this.btnPatientAdmission.Text = "Tiếp Nhận Bệnh Nhân";
            this.btnPatientAdmission.UseVisualStyleBackColor = false;
            this.btnPatientAdmission.Click += new System.EventHandler(this.btnPatientAdmission_Click);
            // 
            // btnSignout
            // 
            this.btnSignout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSignout.Location = new System.Drawing.Point(0, 489);
            this.btnSignout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSignout.Name = "btnSignout";
            this.btnSignout.Size = new System.Drawing.Size(140, 59);
            this.btnSignout.TabIndex = 7;
            this.btnSignout.Text = "Đăng Xuất";
            this.btnSignout.UseVisualStyleBackColor = false;
            this.btnSignout.Click += new System.EventHandler(this.btnSignout_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnPatientSearch);
            this.panel2.Controls.Add(this.btnSignout);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnPatientAdmission);
            this.panel2.Controls.Add(this.btnDischarge);
            this.panel2.Controls.Add(this.btnMedicalRegistration);
            this.panel2.Controls.Add(this.btnInpatientAdmission);
            this.panel2.Controls.Add(this.btnAppointmentManagement);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 592);
            this.panel2.TabIndex = 12;
            // 
            // btnPatientSearch
            // 
            this.btnPatientSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPatientSearch.Location = new System.Drawing.Point(0, 431);
            this.btnPatientSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPatientSearch.Name = "btnPatientSearch";
            this.btnPatientSearch.Size = new System.Drawing.Size(140, 59);
            this.btnPatientSearch.TabIndex = 8;
            this.btnPatientSearch.Text = "Tìm Kiếm Bệnh Nhân";
            this.btnPatientSearch.UseVisualStyleBackColor = false;
            this.btnPatientSearch.Click += new System.EventHandler(this.btnPatientSearch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::GUI.Properties.Resources.logoRexeption;
            this.pictureBox1.InitialImage = global::GUI.Properties.Resources.logonursing;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(140, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 142);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(810, 142);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel_Body
            // 
            this.panel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Body.Location = new System.Drawing.Point(140, 142);
            this.panel_Body.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(810, 450);
            this.panel_Body.TabIndex = 17;
            // 
            // frmReceptionistDashboardGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 592);
            this.Controls.Add(this.panel_Body);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmReceptionistDashboardGUI";
            this.Text = "frmReceptionistDashboardGUI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReceptionistDashboardGUI_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAppointmentManagement;
        private System.Windows.Forms.Button btnInpatientAdmission;
        private System.Windows.Forms.Button btnMedicalRegistration;
        private System.Windows.Forms.Button btnDischarge;
        private System.Windows.Forms.Button btnPatientAdmission;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSignout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnPatientSearch;
        private System.Windows.Forms.Panel panel_Body;
    }
}