namespace GUI
{
    partial class FormPatient
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
            this.dgvPatient = new System.Windows.Forms.DataGridView();
            this.panelFillForm = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.labelTypePatient = new System.Windows.Forms.Label();
            this.labelUpdatedDate = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelEmergencyPhone = new System.Windows.Forms.Label();
            this.labelEmergencyName = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.dtpUpdatedDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.cbbTypePatient = new System.Windows.Forms.ComboBox();
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmergencyPhone = new System.Windows.Forms.TextBox();
            this.txtEmergencyName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWeight = new System.Windows.Forms.Label();
            this.labelInsuranceID = new System.Windows.Forms.Label();
            this.labelCitizenID = new System.Windows.Forms.Label();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.labelDob = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.cbInsuranceID = new System.Windows.Forms.CheckBox();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.radGenderOther = new System.Windows.Forms.RadioButton();
            this.radGenderFemale = new System.Windows.Forms.RadioButton();
            this.radGenderMale = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.txtInsuranceID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCitizenID = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            this.panelFillForm.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPatient
            // 
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPatient.Location = new System.Drawing.Point(0, 451);
            this.dgvPatient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.RowHeadersWidth = 51;
            this.dgvPatient.RowTemplate.Height = 24;
            this.dgvPatient.Size = new System.Drawing.Size(888, 143);
            this.dgvPatient.TabIndex = 0;
            this.dgvPatient.TabStop = false;
            this.dgvPatient.Click += new System.EventHandler(this.dgvPatient_Click);
            // 
            // panelFillForm
            // 
            this.panelFillForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFillForm.Controls.Add(this.panelRight);
            this.panelFillForm.Controls.Add(this.panelLeft);
            this.panelFillForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelFillForm.Location = new System.Drawing.Point(0, 0);
            this.panelFillForm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelFillForm.Name = "panelFillForm";
            this.panelFillForm.Size = new System.Drawing.Size(673, 451);
            this.panelFillForm.TabIndex = 1;
            this.panelFillForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFillForm_Paint);
            this.panelFillForm.Resize += new System.EventHandler(this.panelFillForm_Resize);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.labelTypePatient);
            this.panelRight.Controls.Add(this.labelUpdatedDate);
            this.panelRight.Controls.Add(this.labelCreatedDate);
            this.panelRight.Controls.Add(this.labelStatus);
            this.panelRight.Controls.Add(this.labelEmergencyPhone);
            this.panelRight.Controls.Add(this.labelEmergencyName);
            this.panelRight.Controls.Add(this.labelAddress);
            this.panelRight.Controls.Add(this.dtpUpdatedDate);
            this.panelRight.Controls.Add(this.dtpCreatedDate);
            this.panelRight.Controls.Add(this.cbbTypePatient);
            this.panelRight.Controls.Add(this.cbbStatus);
            this.panelRight.Controls.Add(this.label16);
            this.panelRight.Controls.Add(this.label13);
            this.panelRight.Controls.Add(this.label12);
            this.panelRight.Controls.Add(this.label11);
            this.panelRight.Controls.Add(this.label10);
            this.panelRight.Controls.Add(this.label9);
            this.panelRight.Controls.Add(this.label8);
            this.panelRight.Controls.Add(this.txtEmergencyPhone);
            this.panelRight.Controls.Add(this.txtEmergencyName);
            this.panelRight.Controls.Add(this.txtAddress);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(330, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(341, 449);
            this.panelRight.TabIndex = 1;
            this.panelRight.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // labelTypePatient
            // 
            this.labelTypePatient.AutoSize = true;
            this.labelTypePatient.Location = new System.Drawing.Point(136, 261);
            this.labelTypePatient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTypePatient.Name = "labelTypePatient";
            this.labelTypePatient.Size = new System.Drawing.Size(0, 13);
            this.labelTypePatient.TabIndex = 10;
            // 
            // labelUpdatedDate
            // 
            this.labelUpdatedDate.AutoSize = true;
            this.labelUpdatedDate.Location = new System.Drawing.Point(136, 220);
            this.labelUpdatedDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUpdatedDate.Name = "labelUpdatedDate";
            this.labelUpdatedDate.Size = new System.Drawing.Size(0, 13);
            this.labelUpdatedDate.TabIndex = 10;
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(136, 180);
            this.labelCreatedDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(0, 13);
            this.labelCreatedDate.TabIndex = 10;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(136, 139);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 10;
            // 
            // labelEmergencyPhone
            // 
            this.labelEmergencyPhone.AutoSize = true;
            this.labelEmergencyPhone.Location = new System.Drawing.Point(136, 98);
            this.labelEmergencyPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmergencyPhone.Name = "labelEmergencyPhone";
            this.labelEmergencyPhone.Size = new System.Drawing.Size(0, 13);
            this.labelEmergencyPhone.TabIndex = 10;
            // 
            // labelEmergencyName
            // 
            this.labelEmergencyName.AutoSize = true;
            this.labelEmergencyName.Location = new System.Drawing.Point(136, 58);
            this.labelEmergencyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmergencyName.Name = "labelEmergencyName";
            this.labelEmergencyName.Size = new System.Drawing.Size(0, 13);
            this.labelEmergencyName.TabIndex = 10;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(136, 15);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(0, 13);
            this.labelAddress.TabIndex = 10;
            // 
            // dtpUpdatedDate
            // 
            this.dtpUpdatedDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpUpdatedDate.Enabled = false;
            this.dtpUpdatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUpdatedDate.Location = new System.Drawing.Point(139, 236);
            this.dtpUpdatedDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpUpdatedDate.Name = "dtpUpdatedDate";
            this.dtpUpdatedDate.Size = new System.Drawing.Size(157, 20);
            this.dtpUpdatedDate.TabIndex = 15;
            this.dtpUpdatedDate.ValueChanged += new System.EventHandler(this.dtpUpdatedDate_ValueChanged);
            // 
            // dtpCreatedDate
            // 
            this.dtpCreatedDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpCreatedDate.Enabled = false;
            this.dtpCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedDate.Location = new System.Drawing.Point(139, 195);
            this.dtpCreatedDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(157, 20);
            this.dtpCreatedDate.TabIndex = 14;
            // 
            // cbbTypePatient
            // 
            this.cbbTypePatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbTypePatient.FormattingEnabled = true;
            this.cbbTypePatient.Location = new System.Drawing.Point(139, 276);
            this.cbbTypePatient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbTypePatient.Name = "cbbTypePatient";
            this.cbbTypePatient.Size = new System.Drawing.Size(157, 21);
            this.cbbTypePatient.TabIndex = 16;
            this.cbbTypePatient.SelectedIndexChanged += new System.EventHandler(this.cbbStatus_SelectedIndexChanged);
            // 
            // cbbStatus
            // 
            this.cbbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Location = new System.Drawing.Point(139, 154);
            this.cbbStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(157, 21);
            this.cbbStatus.TabIndex = 13;
            this.cbbStatus.SelectedIndexChanged += new System.EventHandler(this.cbbStatus_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 276);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Loại bệnh nhân";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 236);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Ngày cập nhật TT";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 195);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Ngày tạo thông tin";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 154);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Trạng thái điều trị";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 114);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Số điện thoại người thân";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 73);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tên người thân ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Địa chỉ liên hệ";
            // 
            // txtEmergencyPhone
            // 
            this.txtEmergencyPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmergencyPhone.Location = new System.Drawing.Point(139, 114);
            this.txtEmergencyPhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmergencyPhone.MaxLength = 15;
            this.txtEmergencyPhone.Name = "txtEmergencyPhone";
            this.txtEmergencyPhone.Size = new System.Drawing.Size(157, 20);
            this.txtEmergencyPhone.TabIndex = 12;
            // 
            // txtEmergencyName
            // 
            this.txtEmergencyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmergencyName.Location = new System.Drawing.Point(139, 73);
            this.txtEmergencyName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmergencyName.MaxLength = 255;
            this.txtEmergencyName.Name = "txtEmergencyName";
            this.txtEmergencyName.Size = new System.Drawing.Size(157, 20);
            this.txtEmergencyName.TabIndex = 11;
            this.txtEmergencyName.TextChanged += new System.EventHandler(this.txtEmergencyName_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(139, 32);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAddress.MaxLength = 255;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(157, 20);
            this.txtAddress.TabIndex = 10;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.labelHeight);
            this.panelLeft.Controls.Add(this.labelWeight);
            this.panelLeft.Controls.Add(this.labelInsuranceID);
            this.panelLeft.Controls.Add(this.labelCitizenID);
            this.panelLeft.Controls.Add(this.labelPhoneNumber);
            this.panelLeft.Controls.Add(this.labelDob);
            this.panelLeft.Controls.Add(this.labelGender);
            this.panelLeft.Controls.Add(this.labelFullName);
            this.panelLeft.Controls.Add(this.labelID);
            this.panelLeft.Controls.Add(this.cbInsuranceID);
            this.panelLeft.Controls.Add(this.dtpDob);
            this.panelLeft.Controls.Add(this.radGenderOther);
            this.panelLeft.Controls.Add(this.radGenderFemale);
            this.panelLeft.Controls.Add(this.radGenderMale);
            this.panelLeft.Controls.Add(this.label15);
            this.panelLeft.Controls.Add(this.txtInsuranceID);
            this.panelLeft.Controls.Add(this.label14);
            this.panelLeft.Controls.Add(this.txtCitizenID);
            this.panelLeft.Controls.Add(this.txtPhoneNumber);
            this.panelLeft.Controls.Add(this.txtFullName);
            this.panelLeft.Controls.Add(this.txtID);
            this.panelLeft.Controls.Add(this.label7);
            this.panelLeft.Controls.Add(this.label6);
            this.panelLeft.Controls.Add(this.label5);
            this.panelLeft.Controls.Add(this.txtHeight);
            this.panelLeft.Controls.Add(this.txtWeight);
            this.panelLeft.Controls.Add(this.label4);
            this.panelLeft.Controls.Add(this.label3);
            this.panelLeft.Controls.Add(this.label2);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(330, 449);
            this.panelLeft.TabIndex = 0;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(95, 375);
            this.labelHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(0, 13);
            this.labelHeight.TabIndex = 10;
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Location = new System.Drawing.Point(95, 334);
            this.labelWeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(0, 13);
            this.labelWeight.TabIndex = 10;
            // 
            // labelInsuranceID
            // 
            this.labelInsuranceID.AutoSize = true;
            this.labelInsuranceID.Location = new System.Drawing.Point(95, 293);
            this.labelInsuranceID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInsuranceID.Name = "labelInsuranceID";
            this.labelInsuranceID.Size = new System.Drawing.Size(0, 13);
            this.labelInsuranceID.TabIndex = 10;
            // 
            // labelCitizenID
            // 
            this.labelCitizenID.AutoSize = true;
            this.labelCitizenID.Location = new System.Drawing.Point(95, 212);
            this.labelCitizenID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCitizenID.Name = "labelCitizenID";
            this.labelCitizenID.Size = new System.Drawing.Size(0, 13);
            this.labelCitizenID.TabIndex = 10;
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Location = new System.Drawing.Point(95, 171);
            this.labelPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(0, 13);
            this.labelPhoneNumber.TabIndex = 10;
            // 
            // labelDob
            // 
            this.labelDob.AutoSize = true;
            this.labelDob.Location = new System.Drawing.Point(95, 130);
            this.labelDob.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDob.Name = "labelDob";
            this.labelDob.Size = new System.Drawing.Size(0, 13);
            this.labelDob.TabIndex = 10;
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(95, 91);
            this.labelGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(0, 13);
            this.labelGender.TabIndex = 10;
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(95, 50);
            this.labelFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(0, 13);
            this.labelFullName.TabIndex = 10;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(95, 9);
            this.labelID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(0, 13);
            this.labelID.TabIndex = 10;
            // 
            // cbInsuranceID
            // 
            this.cbInsuranceID.AutoSize = true;
            this.cbInsuranceID.Location = new System.Drawing.Point(98, 268);
            this.cbInsuranceID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbInsuranceID.Name = "cbInsuranceID";
            this.cbInsuranceID.Size = new System.Drawing.Size(85, 17);
            this.cbInsuranceID.TabIndex = 8;
            this.cbInsuranceID.Text = "Có bảo hiểm";
            this.cbInsuranceID.UseVisualStyleBackColor = true;
            this.cbInsuranceID.CheckedChanged += new System.EventHandler(this.cbInsuranceID_CheckedChanged);
            // 
            // dtpDob
            // 
            this.dtpDob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(98, 146);
            this.dtpDob.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(195, 20);
            this.dtpDob.TabIndex = 5;
            // 
            // radGenderOther
            // 
            this.radGenderOther.AutoSize = true;
            this.radGenderOther.Location = new System.Drawing.Point(204, 106);
            this.radGenderOther.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radGenderOther.Name = "radGenderOther";
            this.radGenderOther.Size = new System.Drawing.Size(50, 17);
            this.radGenderOther.TabIndex = 4;
            this.radGenderOther.TabStop = true;
            this.radGenderOther.Text = "Khác";
            this.radGenderOther.UseVisualStyleBackColor = true;
            // 
            // radGenderFemale
            // 
            this.radGenderFemale.AutoSize = true;
            this.radGenderFemale.Location = new System.Drawing.Point(156, 106);
            this.radGenderFemale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radGenderFemale.Name = "radGenderFemale";
            this.radGenderFemale.Size = new System.Drawing.Size(39, 17);
            this.radGenderFemale.TabIndex = 3;
            this.radGenderFemale.TabStop = true;
            this.radGenderFemale.Text = "Nữ";
            this.radGenderFemale.UseVisualStyleBackColor = true;
            // 
            // radGenderMale
            // 
            this.radGenderMale.AutoSize = true;
            this.radGenderMale.Location = new System.Drawing.Point(98, 106);
            this.radGenderMale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radGenderMale.Name = "radGenderMale";
            this.radGenderMale.Size = new System.Drawing.Size(47, 17);
            this.radGenderMale.TabIndex = 2;
            this.radGenderMale.TabStop = true;
            this.radGenderMale.Text = "Nam";
            this.radGenderMale.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 390);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Chiều cao (cm)";
            // 
            // txtInsuranceID
            // 
            this.txtInsuranceID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInsuranceID.Location = new System.Drawing.Point(98, 309);
            this.txtInsuranceID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInsuranceID.MaxLength = 20;
            this.txtInsuranceID.Name = "txtInsuranceID";
            this.txtInsuranceID.Size = new System.Drawing.Size(195, 20);
            this.txtInsuranceID.TabIndex = 1;
            this.txtInsuranceID.TabStop = false;
            this.txtInsuranceID.Visible = false;
            this.txtInsuranceID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInsuranceID_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 349);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Cân nặng (kg)";
            // 
            // txtCitizenID
            // 
            this.txtCitizenID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCitizenID.Location = new System.Drawing.Point(98, 228);
            this.txtCitizenID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCitizenID.MaxLength = 20;
            this.txtCitizenID.Name = "txtCitizenID";
            this.txtCitizenID.Size = new System.Drawing.Size(195, 20);
            this.txtCitizenID.TabIndex = 7;
            this.txtCitizenID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCitizenID_KeyPress);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(98, 187);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPhoneNumber.MaxLength = 15;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(195, 20);
            this.txtPhoneNumber.TabIndex = 6;
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(98, 65);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFullName.MaxLength = 255;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(195, 20);
            this.txtFullName.TabIndex = 1;
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtID.Location = new System.Drawing.Point(98, 24);
            this.txtID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtID.MaxLength = 10;
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(195, 20);
            this.txtID.TabIndex = 0;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 268);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Bảo hiểm y tế";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 228);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã CCCD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 146);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngày sinh";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight.Location = new System.Drawing.Point(98, 390);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(195, 20);
            this.txtHeight.TabIndex = 9;
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeight_KeyPress);
            // 
            // txtWeight
            // 
            this.txtWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeight.Location = new System.Drawing.Point(98, 349);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(195, 20);
            this.txtWeight.TabIndex = 8;
            this.txtWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Giới tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 187);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ và tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID bệnh nhân ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnClean);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(673, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 451);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(43, 143);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 32);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClean
            // 
            this.btnClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClean.Location = new System.Drawing.Point(43, 99);
            this.btnClean.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(150, 32);
            this.btnClean.TabIndex = 0;
            this.btnClean.TabStop = false;
            this.btnClean.Text = "Làm mới";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(43, 56);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 32);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(43, 16);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FormPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 594);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelFillForm);
            this.Controls.Add(this.dgvPatient);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(904, 576);
            this.Name = "FormPatient";
            this.Text = "Bệnh nhân";
            this.Load += new System.EventHandler(this.FormPatient_Load);
            this.Resize += new System.EventHandler(this.FormPatient_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            this.panelFillForm.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPatient;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelFillForm;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton radGenderMale;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DateTimePicker dtpUpdatedDate;
        private System.Windows.Forms.DateTimePicker dtpCreatedDate;
        private System.Windows.Forms.ComboBox cbbStatus;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtEmergencyPhone;
        private System.Windows.Forms.TextBox txtEmergencyName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.CheckBox cbInsuranceID;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.RadioButton radGenderOther;
        private System.Windows.Forms.RadioButton radGenderFemale;
        private System.Windows.Forms.TextBox txtInsuranceID;
        private System.Windows.Forms.TextBox txtCitizenID;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbbTypePatient;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelEmergencyPhone;
        private System.Windows.Forms.Label labelEmergencyName;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.Label labelInsuranceID;
        private System.Windows.Forms.Label labelCitizenID;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.Label labelDob;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelTypePatient;
        private System.Windows.Forms.Label labelUpdatedDate;
        private System.Windows.Forms.Label labelCreatedDate;
    }
}