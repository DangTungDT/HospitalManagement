namespace GUI
{
    partial class frmMedicalRecordInfo_Doctor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMedicalRecord = new System.Windows.Forms.DataGridView();
            this.cboPatient = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvPatient = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.txtPrescription = new System.Windows.Forms.TextBox();
            this.txtVitalSigns = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtTreatmentPlan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalRecord)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMedicalRecord
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMedicalRecord.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMedicalRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicalRecord.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvMedicalRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicalRecord.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMedicalRecord.Location = new System.Drawing.Point(0, 445);
            this.dgvMedicalRecord.Name = "dgvMedicalRecord";
            this.dgvMedicalRecord.RowHeadersWidth = 51;
            this.dgvMedicalRecord.RowTemplate.Height = 24;
            this.dgvMedicalRecord.Size = new System.Drawing.Size(1782, 367);
            this.dgvMedicalRecord.TabIndex = 37;
            this.dgvMedicalRecord.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicalRecord_CellClick);
            // 
            // cboPatient
            // 
            this.cboPatient.FormattingEnabled = true;
            this.cboPatient.Location = new System.Drawing.Point(204, 25);
            this.cboPatient.Name = "cboPatient";
            this.cboPatient.Size = new System.Drawing.Size(290, 30);
            this.cboPatient.TabIndex = 42;
            this.cboPatient.TextChanged += new System.EventHandler(this.cboPatient_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvPatient);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(999, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(747, 238);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin bệnh nhân";
            this.groupBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // dgvPatient
            // 
            this.dgvPatient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatient.Location = new System.Drawing.Point(3, 26);
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.RowHeadersWidth = 51;
            this.dgvPatient.RowTemplate.Height = 24;
            this.dgvPatient.Size = new System.Drawing.Size(741, 209);
            this.dgvPatient.TabIndex = 0;
            this.dgvPatient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatient_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(336, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 55);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(690, 260);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(290, 30);
            this.txtNote.TabIndex = 47;
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(204, 136);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(290, 30);
            this.txtDiagnosis.TabIndex = 45;
            // 
            // txtPrescription
            // 
            this.txtPrescription.Location = new System.Drawing.Point(691, 30);
            this.txtPrescription.Name = "txtPrescription";
            this.txtPrescription.Size = new System.Drawing.Size(290, 30);
            this.txtPrescription.TabIndex = 27;
            // 
            // txtVitalSigns
            // 
            this.txtVitalSigns.Location = new System.Drawing.Point(690, 136);
            this.txtVitalSigns.Name = "txtVitalSigns";
            this.txtVitalSigns.Size = new System.Drawing.Size(290, 30);
            this.txtVitalSigns.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(551, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 22);
            this.label9.TabIndex = 25;
            this.label9.Text = "Dấu Hiệu :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(21, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 22);
            this.label10.TabIndex = 23;
            this.label10.Text = "Chuẩn Đoán :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1002, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(744, 105);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(59, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 55);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm ";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(599, 32);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 53);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtTreatmentPlan
            // 
            this.txtTreatmentPlan.Location = new System.Drawing.Point(204, 260);
            this.txtTreatmentPlan.Name = "txtTreatmentPlan";
            this.txtTreatmentPlan.Size = new System.Drawing.Size(290, 30);
            this.txtTreatmentPlan.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(551, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Đơn Thuốc :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(550, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ghi Chú :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bệnh Nhân :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.txtDiagnosis);
            this.groupBox1.Controls.Add(this.cboPatient);
            this.groupBox1.Controls.Add(this.txtPrescription);
            this.groupBox1.Controls.Add(this.txtVitalSigns);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtTreatmentPlan);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(993, 349);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(20, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "Kế Hoạch Điều Trị :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(839, 387);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(243, 33);
            this.label11.TabIndex = 38;
            this.label11.Text = "Danh Sách Bệnh Án";
            // 
            // frmMedicalRecordInfo_Doctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 812);
            this.Controls.Add(this.dgvMedicalRecord);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Name = "frmMedicalRecordInfo_Doctor";
            this.Text = "Bệnh Án";
            this.Load += new System.EventHandler(this.frmMedicalRecordInfo_Doctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalRecord)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMedicalRecord;
        private System.Windows.Forms.ComboBox cboPatient;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvPatient;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.TextBox txtPrescription;
        private System.Windows.Forms.TextBox txtVitalSigns;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtTreatmentPlan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
    }
}