namespace GUI
{
    partial class FormSalaryDetail
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
            this.dgvSalaryDetail = new System.Windows.Forms.DataGridView();
            this.panelFill = new System.Windows.Forms.Panel();
            this.btnClean = new System.Windows.Forms.Button();
            this.txtAllowance = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtNetSalary = new System.Windows.Forms.TextBox();
            this.txtSocialInsurance = new System.Windows.Forms.TextBox();
            this.txtCreateStaff = new System.Windows.Forms.TextBox();
            this.txtIncomeTax = new System.Windows.Forms.TextBox();
            this.txtDeduction = new System.Windows.Forms.TextBox();
            this.txtBonus = new System.Windows.Forms.TextBox();
            this.txtOvertimeHours = new System.Windows.Forms.TextBox();
            this.txtWorkingDays = new System.Windows.Forms.TextBox();
            this.dtpCreateDate = new System.Windows.Forms.DateTimePicker();
            this.dtpSalaryDate = new System.Windows.Forms.DateTimePicker();
            this.cbbYear = new System.Windows.Forms.ComboBox();
            this.cbbMonth = new System.Windows.Forms.ComboBox();
            this.cbbBasicSalary = new System.Windows.Forms.ComboBox();
            this.cbbDepartmentID = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaryDetail)).BeginInit();
            this.panelFill.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSalaryDetail
            // 
            this.dgvSalaryDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalaryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalaryDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSalaryDetail.Location = new System.Drawing.Point(0, 703);
            this.dgvSalaryDetail.MultiSelect = false;
            this.dgvSalaryDetail.Name = "dgvSalaryDetail";
            this.dgvSalaryDetail.ReadOnly = true;
            this.dgvSalaryDetail.RowHeadersWidth = 51;
            this.dgvSalaryDetail.RowTemplate.Height = 24;
            this.dgvSalaryDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalaryDetail.Size = new System.Drawing.Size(1217, 150);
            this.dgvSalaryDetail.TabIndex = 0;
            this.dgvSalaryDetail.TabStop = false;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.btnClean);
            this.panelFill.Controls.Add(this.txtAllowance);
            this.panelFill.Controls.Add(this.txtNote);
            this.panelFill.Controls.Add(this.txtNetSalary);
            this.panelFill.Controls.Add(this.txtSocialInsurance);
            this.panelFill.Controls.Add(this.txtCreateStaff);
            this.panelFill.Controls.Add(this.txtIncomeTax);
            this.panelFill.Controls.Add(this.txtDeduction);
            this.panelFill.Controls.Add(this.txtBonus);
            this.panelFill.Controls.Add(this.txtOvertimeHours);
            this.panelFill.Controls.Add(this.txtWorkingDays);
            this.panelFill.Controls.Add(this.dtpCreateDate);
            this.panelFill.Controls.Add(this.dtpSalaryDate);
            this.panelFill.Controls.Add(this.cbbYear);
            this.panelFill.Controls.Add(this.cbbMonth);
            this.panelFill.Controls.Add(this.cbbBasicSalary);
            this.panelFill.Controls.Add(this.cbbDepartmentID);
            this.panelFill.Controls.Add(this.label14);
            this.panelFill.Controls.Add(this.label15);
            this.panelFill.Controls.Add(this.label13);
            this.panelFill.Controls.Add(this.label12);
            this.panelFill.Controls.Add(this.label11);
            this.panelFill.Controls.Add(this.label10);
            this.panelFill.Controls.Add(this.label2);
            this.panelFill.Controls.Add(this.label9);
            this.panelFill.Controls.Add(this.label8);
            this.panelFill.Controls.Add(this.label7);
            this.panelFill.Controls.Add(this.label6);
            this.panelFill.Controls.Add(this.label5);
            this.panelFill.Controls.Add(this.label4);
            this.panelFill.Controls.Add(this.label17);
            this.panelFill.Controls.Add(this.label16);
            this.panelFill.Controls.Add(this.label3);
            this.panelFill.Controls.Add(this.label1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(719, 703);
            this.panelFill.TabIndex = 2;
            this.panelFill.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFill_Paint);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(601, 645);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(100, 40);
            this.btnClean.TabIndex = 14;
            this.btnClean.TabStop = false;
            this.btnClean.Text = "Làm mới";
            this.btnClean.UseVisualStyleBackColor = true;
            // 
            // txtAllowance
            // 
            this.txtAllowance.Location = new System.Drawing.Point(173, 270);
            this.txtAllowance.Name = "txtAllowance";
            this.txtAllowance.Size = new System.Drawing.Size(400, 22);
            this.txtAllowance.TabIndex = 7;
            this.txtAllowance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAllowance_KeyDown);
            this.txtAllowance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAllowance_KeyPress);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(173, 590);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(400, 95);
            this.txtNote.TabIndex = 15;
            // 
            // txtNetSalary
            // 
            this.txtNetSalary.Location = new System.Drawing.Point(173, 550);
            this.txtNetSalary.Name = "txtNetSalary";
            this.txtNetSalary.ReadOnly = true;
            this.txtNetSalary.Size = new System.Drawing.Size(400, 22);
            this.txtNetSalary.TabIndex = 14;
            // 
            // txtSocialInsurance
            // 
            this.txtSocialInsurance.Location = new System.Drawing.Point(173, 510);
            this.txtSocialInsurance.Name = "txtSocialInsurance";
            this.txtSocialInsurance.Size = new System.Drawing.Size(400, 22);
            this.txtSocialInsurance.TabIndex = 13;
            this.txtSocialInsurance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSocialInsurance_KeyDown);
            this.txtSocialInsurance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSocialInsurance_KeyPress);
            // 
            // txtCreateStaff
            // 
            this.txtCreateStaff.Location = new System.Drawing.Point(173, 470);
            this.txtCreateStaff.Name = "txtCreateStaff";
            this.txtCreateStaff.ReadOnly = true;
            this.txtCreateStaff.Size = new System.Drawing.Size(400, 22);
            this.txtCreateStaff.TabIndex = 12;
            // 
            // txtIncomeTax
            // 
            this.txtIncomeTax.Location = new System.Drawing.Point(173, 390);
            this.txtIncomeTax.Name = "txtIncomeTax";
            this.txtIncomeTax.Size = new System.Drawing.Size(400, 22);
            this.txtIncomeTax.TabIndex = 10;
            this.txtIncomeTax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIncomeTax_KeyDown);
            this.txtIncomeTax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIncomeTax_KeyPress);
            // 
            // txtDeduction
            // 
            this.txtDeduction.Location = new System.Drawing.Point(173, 350);
            this.txtDeduction.Name = "txtDeduction";
            this.txtDeduction.Size = new System.Drawing.Size(400, 22);
            this.txtDeduction.TabIndex = 9;
            this.txtDeduction.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeduction_KeyDown);
            this.txtDeduction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeduction_KeyPress);
            // 
            // txtBonus
            // 
            this.txtBonus.Location = new System.Drawing.Point(173, 310);
            this.txtBonus.Name = "txtBonus";
            this.txtBonus.Size = new System.Drawing.Size(400, 22);
            this.txtBonus.TabIndex = 8;
            this.txtBonus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBonus_KeyDown);
            this.txtBonus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBonus_KeyPress);
            // 
            // txtOvertimeHours
            // 
            this.txtOvertimeHours.Location = new System.Drawing.Point(173, 227);
            this.txtOvertimeHours.Name = "txtOvertimeHours";
            this.txtOvertimeHours.Size = new System.Drawing.Size(400, 22);
            this.txtOvertimeHours.TabIndex = 6;
            this.txtOvertimeHours.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOvertimeHours_KeyDown);
            this.txtOvertimeHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOvertimeHours_KeyPress);
            // 
            // txtWorkingDays
            // 
            this.txtWorkingDays.Location = new System.Drawing.Point(173, 190);
            this.txtWorkingDays.Name = "txtWorkingDays";
            this.txtWorkingDays.Size = new System.Drawing.Size(400, 22);
            this.txtWorkingDays.TabIndex = 5;
            this.txtWorkingDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWorkingDays_KeyDown);
            this.txtWorkingDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWorkingDays_KeyPress);
            // 
            // dtpCreateDate
            // 
            this.dtpCreateDate.Enabled = false;
            this.dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreateDate.Location = new System.Drawing.Point(173, 430);
            this.dtpCreateDate.Name = "dtpCreateDate";
            this.dtpCreateDate.Size = new System.Drawing.Size(400, 22);
            this.dtpCreateDate.TabIndex = 11;
            // 
            // dtpSalaryDate
            // 
            this.dtpSalaryDate.Enabled = false;
            this.dtpSalaryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSalaryDate.Location = new System.Drawing.Point(173, 150);
            this.dtpSalaryDate.Name = "dtpSalaryDate";
            this.dtpSalaryDate.Size = new System.Drawing.Size(400, 22);
            this.dtpSalaryDate.TabIndex = 4;
            // 
            // cbbYear
            // 
            this.cbbYear.FormattingEnabled = true;
            this.cbbYear.Location = new System.Drawing.Point(436, 107);
            this.cbbYear.Name = "cbbYear";
            this.cbbYear.Size = new System.Drawing.Size(100, 24);
            this.cbbYear.TabIndex = 3;
            // 
            // cbbMonth
            // 
            this.cbbMonth.FormattingEnabled = true;
            this.cbbMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "Other"});
            this.cbbMonth.Location = new System.Drawing.Point(242, 107);
            this.cbbMonth.Name = "cbbMonth";
            this.cbbMonth.Size = new System.Drawing.Size(100, 24);
            this.cbbMonth.TabIndex = 2;
            // 
            // cbbBasicSalary
            // 
            this.cbbBasicSalary.FormattingEnabled = true;
            this.cbbBasicSalary.Location = new System.Drawing.Point(173, 72);
            this.cbbBasicSalary.Name = "cbbBasicSalary";
            this.cbbBasicSalary.Size = new System.Drawing.Size(400, 24);
            this.cbbBasicSalary.TabIndex = 1;
            this.cbbBasicSalary.SelectedIndexChanged += new System.EventHandler(this.cbbBasicSalary_SelectedIndexChanged);
            // 
            // cbbDepartmentID
            // 
            this.cbbDepartmentID.FormattingEnabled = true;
            this.cbbDepartmentID.Location = new System.Drawing.Point(173, 30);
            this.cbbDepartmentID.Name = "cbbDepartmentID";
            this.cbbDepartmentID.Size = new System.Drawing.Size(400, 24);
            this.cbbDepartmentID.TabIndex = 0;
            this.cbbDepartmentID.SelectedIndexChanged += new System.EventHandler(this.cbbDepartmentID_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 590);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 16);
            this.label14.TabIndex = 2;
            this.label14.Text = "Ghi chú";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 550);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 16);
            this.label15.TabIndex = 2;
            this.label15.Text = "Tổng thực lãnh";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 510);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 16);
            this.label13.TabIndex = 2;
            this.label13.Text = "Bảo hiểm xã hội";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 470);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Người tạo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 430);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Ngày tạo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Thuế";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tiền bị trừ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 310);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Thưởng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Phụ cấp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Số giờ tăng ca";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số ngày công thực";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Lương cơ bản ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ngày nhận lương";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(384, 110);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 16);
            this.label17.TabIndex = 8;
            this.label17.Text = "Năm";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(190, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 16);
            this.label16.TabIndex = 8;
            this.label16.Text = "Tháng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kỳ nhận lương";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Khoa nhân viên ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(719, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 703);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(498, 603);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.dgvStaff);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 72);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(498, 473);
            this.panel6.TabIndex = 2;
            // 
            // dgvStaff
            // 
            this.dgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaff.Location = new System.Drawing.Point(0, 0);
            this.dgvStaff.MultiSelect = false;
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.ReadOnly = true;
            this.dgvStaff.RowHeadersWidth = 51;
            this.dgvStaff.RowTemplate.Height = 24;
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.Size = new System.Drawing.Size(496, 471);
            this.dgvStaff.TabIndex = 0;
            this.dgvStaff.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 545);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(498, 58);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label18);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(498, 72);
            this.panel4.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(498, 72);
            this.label18.TabIndex = 0;
            this.label18.Text = "Danh sách nhân viên trong khoa/phòng ban";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 100);
            this.panel2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(341, 30);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(235, 30);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(129, 30);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(23, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FormSalaryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 853);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.dgvSalaryDetail);
            this.Name = "FormSalaryDetail";
            this.Text = "Chi tiết lương";
            this.Load += new System.EventHandler(this.FormSalaryDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaryDetail)).EndInit();
            this.panelFill.ResumeLayout(false);
            this.panelFill.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalaryDetail;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.ComboBox cbbDepartmentID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbBasicSalary;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbYear;
        private System.Windows.Forms.ComboBox cbbMonth;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtAllowance;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtNetSalary;
        private System.Windows.Forms.TextBox txtSocialInsurance;
        private System.Windows.Forms.TextBox txtCreateStaff;
        private System.Windows.Forms.TextBox txtIncomeTax;
        private System.Windows.Forms.TextBox txtDeduction;
        private System.Windows.Forms.TextBox txtBonus;
        private System.Windows.Forms.TextBox txtOvertimeHours;
        private System.Windows.Forms.TextBox txtWorkingDays;
        private System.Windows.Forms.DateTimePicker dtpCreateDate;
        private System.Windows.Forms.DateTimePicker dtpSalaryDate;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvStaff;
    }
}