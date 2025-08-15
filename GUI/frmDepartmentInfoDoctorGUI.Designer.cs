namespace GUI
{
    partial class frmDepartmentInfoDoctorGUI
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlStatistics = new System.Windows.Forms.Panel();
            this.lblPatientCount = new System.Windows.Forms.Label();
            this.txtPatientCount = new System.Windows.Forms.TextBox();
            this.lblRoomCount = new System.Windows.Forms.Label();
            this.txtRoomCount = new System.Windows.Forms.TextBox();
            this.lblStaffCount = new System.Windows.Forms.Label();
            this.txtStaffCount = new System.Windows.Forms.TextBox();
            this.pnlDoctorInfo = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDegree = new System.Windows.Forms.Label();
            this.txtDegree = new System.Windows.Forms.TextBox();
            this.lblQualification = new System.Windows.Forms.Label();
            this.txtQualification = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.txtDoctorName = new System.Windows.Forms.TextBox();
            this.lblDoctorID = new System.Windows.Forms.Label();
            this.txtDoctorID = new System.Windows.Forms.TextBox();
            this.pnlDepartmentInfo = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.lblDepartmentID = new System.Windows.Forms.Label();
            this.txtDepartmentID = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlStatistics.SuspendLayout();
            this.pnlDoctorInfo.SuspendLayout();
            this.pnlDepartmentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(306, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông Tin Khoa Công Tác";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlStatistics);
            this.pnlMain.Controls.Add(this.pnlDoctorInfo);
            this.pnlMain.Controls.Add(this.pnlDepartmentInfo);
            this.pnlMain.Location = new System.Drawing.Point(20, 70);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(760, 460);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlStatistics
            // 
            this.pnlStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.pnlStatistics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatistics.Controls.Add(this.lblPatientCount);
            this.pnlStatistics.Controls.Add(this.txtPatientCount);
            this.pnlStatistics.Controls.Add(this.lblRoomCount);
            this.pnlStatistics.Controls.Add(this.txtRoomCount);
            this.pnlStatistics.Controls.Add(this.lblStaffCount);
            this.pnlStatistics.Controls.Add(this.txtStaffCount);
            this.pnlStatistics.Location = new System.Drawing.Point(20, 380);
            this.pnlStatistics.Name = "pnlStatistics";
            this.pnlStatistics.Padding = new System.Windows.Forms.Padding(15);
            this.pnlStatistics.Size = new System.Drawing.Size(720, 60);
            this.pnlStatistics.TabIndex = 2;
            // 
            // lblPatientCount
            // 
            this.lblPatientCount.AutoSize = true;
            this.lblPatientCount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPatientCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPatientCount.Location = new System.Drawing.Point(491, 25);
            this.lblPatientCount.Name = "lblPatientCount";
            this.lblPatientCount.Size = new System.Drawing.Size(112, 20);
            this.lblPatientCount.TabIndex = 4;
            this.lblPatientCount.Text = "Số Bệnh Nhân:";
            // 
            // txtPatientCount
            // 
            this.txtPatientCount.BackColor = System.Drawing.Color.White;
            this.txtPatientCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPatientCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtPatientCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.txtPatientCount.Location = new System.Drawing.Point(609, 23);
            this.txtPatientCount.Name = "txtPatientCount";
            this.txtPatientCount.ReadOnly = true;
            this.txtPatientCount.Size = new System.Drawing.Size(100, 25);
            this.txtPatientCount.TabIndex = 5;
            this.txtPatientCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRoomCount
            // 
            this.lblRoomCount.AutoSize = true;
            this.lblRoomCount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRoomCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRoomCount.Location = new System.Drawing.Point(262, 28);
            this.lblRoomCount.Name = "lblRoomCount";
            this.lblRoomCount.Size = new System.Drawing.Size(79, 20);
            this.lblRoomCount.TabIndex = 2;
            this.lblRoomCount.Text = "Số Phòng:";
            // 
            // txtRoomCount
            // 
            this.txtRoomCount.BackColor = System.Drawing.Color.White;
            this.txtRoomCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoomCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtRoomCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.txtRoomCount.Location = new System.Drawing.Point(357, 23);
            this.txtRoomCount.Name = "txtRoomCount";
            this.txtRoomCount.ReadOnly = true;
            this.txtRoomCount.Size = new System.Drawing.Size(100, 25);
            this.txtRoomCount.TabIndex = 3;
            this.txtRoomCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblStaffCount
            // 
            this.lblStaffCount.AutoSize = true;
            this.lblStaffCount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStaffCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStaffCount.Location = new System.Drawing.Point(20, 25);
            this.lblStaffCount.Name = "lblStaffCount";
            this.lblStaffCount.Size = new System.Drawing.Size(107, 20);
            this.lblStaffCount.TabIndex = 0;
            this.lblStaffCount.Text = "Số Nhân Viên:";
            // 
            // txtStaffCount
            // 
            this.txtStaffCount.BackColor = System.Drawing.Color.White;
            this.txtStaffCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtStaffCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txtStaffCount.Location = new System.Drawing.Point(133, 25);
            this.txtStaffCount.Name = "txtStaffCount";
            this.txtStaffCount.ReadOnly = true;
            this.txtStaffCount.Size = new System.Drawing.Size(100, 25);
            this.txtStaffCount.TabIndex = 1;
            this.txtStaffCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlDoctorInfo
            // 
            this.pnlDoctorInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlDoctorInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDoctorInfo.Controls.Add(this.lblStatus);
            this.pnlDoctorInfo.Controls.Add(this.txtStatus);
            this.pnlDoctorInfo.Controls.Add(this.lblStartDate);
            this.pnlDoctorInfo.Controls.Add(this.dtpStartDate);
            this.pnlDoctorInfo.Controls.Add(this.lblDegree);
            this.pnlDoctorInfo.Controls.Add(this.txtDegree);
            this.pnlDoctorInfo.Controls.Add(this.lblQualification);
            this.pnlDoctorInfo.Controls.Add(this.txtQualification);
            this.pnlDoctorInfo.Controls.Add(this.lblPosition);
            this.pnlDoctorInfo.Controls.Add(this.txtPosition);
            this.pnlDoctorInfo.Controls.Add(this.lblDoctorName);
            this.pnlDoctorInfo.Controls.Add(this.txtDoctorName);
            this.pnlDoctorInfo.Controls.Add(this.lblDoctorID);
            this.pnlDoctorInfo.Controls.Add(this.txtDoctorID);
            this.pnlDoctorInfo.Location = new System.Drawing.Point(20, 160);
            this.pnlDoctorInfo.Name = "pnlDoctorInfo";
            this.pnlDoctorInfo.Padding = new System.Windows.Forms.Padding(15);
            this.pnlDoctorInfo.Size = new System.Drawing.Size(720, 200);
            this.pnlDoctorInfo.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatus.Location = new System.Drawing.Point(20, 145);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(87, 20);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Trạng Thái:";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.White;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStatus.Location = new System.Drawing.Point(150, 143);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(150, 25);
            this.txtStatus.TabIndex = 13;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStartDate.Location = new System.Drawing.Point(420, 105);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(80, 20);
            this.lblStartDate.TabIndex = 10;
            this.lblStartDate.Text = "Ngày Vào:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(530, 103);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 25);
            this.dtpStartDate.TabIndex = 11;
            // 
            // lblDegree
            // 
            this.lblDegree.AutoSize = true;
            this.lblDegree.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDegree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDegree.Location = new System.Drawing.Point(20, 105);
            this.lblDegree.Name = "lblDegree";
            this.lblDegree.Size = new System.Drawing.Size(79, 20);
            this.lblDegree.TabIndex = 8;
            this.lblDegree.Text = "Bằng Cấp:";
            // 
            // txtDegree
            // 
            this.txtDegree.BackColor = System.Drawing.Color.White;
            this.txtDegree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDegree.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDegree.Location = new System.Drawing.Point(150, 103);
            this.txtDegree.Name = "txtDegree";
            this.txtDegree.ReadOnly = true;
            this.txtDegree.Size = new System.Drawing.Size(250, 25);
            this.txtDegree.TabIndex = 9;
            // 
            // lblQualification
            // 
            this.lblQualification.AutoSize = true;
            this.lblQualification.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblQualification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblQualification.Location = new System.Drawing.Point(420, 65);
            this.lblQualification.Name = "lblQualification";
            this.lblQualification.Size = new System.Drawing.Size(73, 20);
            this.lblQualification.TabIndex = 6;
            this.lblQualification.Text = "Trình Độ:";
            // 
            // txtQualification
            // 
            this.txtQualification.BackColor = System.Drawing.Color.White;
            this.txtQualification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQualification.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtQualification.Location = new System.Drawing.Point(530, 63);
            this.txtQualification.Name = "txtQualification";
            this.txtQualification.ReadOnly = true;
            this.txtQualification.Size = new System.Drawing.Size(150, 25);
            this.txtQualification.TabIndex = 7;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPosition.Location = new System.Drawing.Point(20, 65);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(71, 20);
            this.lblPosition.TabIndex = 4;
            this.lblPosition.Text = "Chức Vụ:";
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.Color.White;
            this.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPosition.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPosition.Location = new System.Drawing.Point(150, 63);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.ReadOnly = true;
            this.txtPosition.Size = new System.Drawing.Size(250, 25);
            this.txtPosition.TabIndex = 5;
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDoctorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDoctorName.Location = new System.Drawing.Point(20, 25);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(83, 20);
            this.lblDoctorName.TabIndex = 0;
            this.lblDoctorName.Text = "Tên Bác Sĩ:";
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.BackColor = System.Drawing.Color.White;
            this.txtDoctorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDoctorName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDoctorName.Location = new System.Drawing.Point(150, 23);
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.ReadOnly = true;
            this.txtDoctorName.Size = new System.Drawing.Size(250, 25);
            this.txtDoctorName.TabIndex = 1;
            // 
            // lblDoctorID
            // 
            this.lblDoctorID.AutoSize = true;
            this.lblDoctorID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDoctorID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDoctorID.Location = new System.Drawing.Point(420, 25);
            this.lblDoctorID.Name = "lblDoctorID";
            this.lblDoctorID.Size = new System.Drawing.Size(80, 20);
            this.lblDoctorID.TabIndex = 2;
            this.lblDoctorID.Text = "Mã Bác Sĩ:";
            // 
            // txtDoctorID
            // 
            this.txtDoctorID.BackColor = System.Drawing.Color.White;
            this.txtDoctorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDoctorID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDoctorID.Location = new System.Drawing.Point(530, 23);
            this.txtDoctorID.Name = "txtDoctorID";
            this.txtDoctorID.ReadOnly = true;
            this.txtDoctorID.Size = new System.Drawing.Size(150, 25);
            this.txtDoctorID.TabIndex = 3;
            // 
            // pnlDepartmentInfo
            // 
            this.pnlDepartmentInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlDepartmentInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDepartmentInfo.Controls.Add(this.lblDescription);
            this.pnlDepartmentInfo.Controls.Add(this.rtbDescription);
            this.pnlDepartmentInfo.Controls.Add(this.lblDepartmentName);
            this.pnlDepartmentInfo.Controls.Add(this.txtDepartmentName);
            this.pnlDepartmentInfo.Controls.Add(this.lblDepartmentID);
            this.pnlDepartmentInfo.Controls.Add(this.txtDepartmentID);
            this.pnlDepartmentInfo.Location = new System.Drawing.Point(20, 20);
            this.pnlDepartmentInfo.Name = "pnlDepartmentInfo";
            this.pnlDepartmentInfo.Padding = new System.Windows.Forms.Padding(15);
            this.pnlDepartmentInfo.Size = new System.Drawing.Size(720, 120);
            this.pnlDepartmentInfo.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescription.Location = new System.Drawing.Point(20, 65);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(54, 20);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Mô tả:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.BackColor = System.Drawing.Color.White;
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbDescription.Location = new System.Drawing.Point(150, 63);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.Size = new System.Drawing.Size(530, 40);
            this.rtbDescription.TabIndex = 5;
            this.rtbDescription.Text = "";
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoSize = true;
            this.lblDepartmentName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDepartmentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDepartmentName.Location = new System.Drawing.Point(20, 25);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(78, 20);
            this.lblDepartmentName.TabIndex = 0;
            this.lblDepartmentName.Text = "Tên Khoa:";
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.BackColor = System.Drawing.Color.White;
            this.txtDepartmentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartmentName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDepartmentName.Location = new System.Drawing.Point(150, 23);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.ReadOnly = true;
            this.txtDepartmentName.Size = new System.Drawing.Size(250, 25);
            this.txtDepartmentName.TabIndex = 1;
            // 
            // lblDepartmentID
            // 
            this.lblDepartmentID.AutoSize = true;
            this.lblDepartmentID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDepartmentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDepartmentID.Location = new System.Drawing.Point(420, 25);
            this.lblDepartmentID.Name = "lblDepartmentID";
            this.lblDepartmentID.Size = new System.Drawing.Size(75, 20);
            this.lblDepartmentID.TabIndex = 2;
            this.lblDepartmentID.Text = "Mã Khoa:";
            // 
            // txtDepartmentID
            // 
            this.txtDepartmentID.BackColor = System.Drawing.Color.White;
            this.txtDepartmentID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartmentID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDepartmentID.Location = new System.Drawing.Point(530, 23);
            this.txtDepartmentID.Name = "txtDepartmentID";
            this.txtDepartmentID.ReadOnly = true;
            this.txtDepartmentID.Size = new System.Drawing.Size(150, 25);
            this.txtDepartmentID.TabIndex = 3;
            // 
            // frmDepartmentInfoDoctorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDepartmentInfoDoctorGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Khoa Công Tác - Hệ Thống Quản Lý Bệnh Viện";
            this.pnlMain.ResumeLayout(false);
            this.pnlStatistics.ResumeLayout(false);
            this.pnlStatistics.PerformLayout();
            this.pnlDoctorInfo.ResumeLayout(false);
            this.pnlDoctorInfo.PerformLayout();
            this.pnlDepartmentInfo.ResumeLayout(false);
            this.pnlDepartmentInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlDepartmentInfo;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.Label lblDepartmentID;
        private System.Windows.Forms.TextBox txtDepartmentID;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Panel pnlDoctorInfo;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.TextBox txtDoctorName;
        private System.Windows.Forms.Label lblDoctorID;
        private System.Windows.Forms.TextBox txtDoctorID;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblQualification;
        private System.Windows.Forms.TextBox txtQualification;
        private System.Windows.Forms.Label lblDegree;
        private System.Windows.Forms.TextBox txtDegree;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Panel pnlStatistics;
        private System.Windows.Forms.Label lblStaffCount;
        private System.Windows.Forms.TextBox txtStaffCount;
        private System.Windows.Forms.Label lblRoomCount;
        private System.Windows.Forms.TextBox txtRoomCount;
        private System.Windows.Forms.Label lblPatientCount;
        private System.Windows.Forms.TextBox txtPatientCount;
    }
}