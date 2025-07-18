namespace GUI
{
    partial class frmTestInfo_Doctor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMedicalOrderID = new System.Windows.Forms.DataGridView();
            this.cboMedicalOrderID = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtResultUnit = new System.Windows.Forms.TextBox();
            this.txtResultValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvTestInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalOrderID)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMedicalOrderID
            // 
            this.dgvMedicalOrderID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicalOrderID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicalOrderID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicalOrderID.Location = new System.Drawing.Point(3, 26);
            this.dgvMedicalOrderID.Name = "dgvMedicalOrderID";
            this.dgvMedicalOrderID.RowHeadersWidth = 51;
            this.dgvMedicalOrderID.RowTemplate.Height = 24;
            this.dgvMedicalOrderID.Size = new System.Drawing.Size(741, 209);
            this.dgvMedicalOrderID.TabIndex = 0;
            this.dgvMedicalOrderID.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicalOrderID_CellClick);
            // 
            // cboMedicalOrderID
            // 
            this.cboMedicalOrderID.FormattingEnabled = true;
            this.cboMedicalOrderID.Location = new System.Drawing.Point(182, 25);
            this.cboMedicalOrderID.Name = "cboMedicalOrderID";
            this.cboMedicalOrderID.Size = new System.Drawing.Size(290, 30);
            this.cboMedicalOrderID.TabIndex = 42;
            this.cboMedicalOrderID.TextChanged += new System.EventHandler(this.cboMedicalOrderID_TextChanged);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.cboMedicalOrderID);
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Controls.Add(this.txtResultUnit);
            this.groupBox1.Controls.Add(this.txtResultValue);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(993, 351);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(692, 252);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(290, 30);
            this.txtNote.TabIndex = 47;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(181, 146);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(290, 30);
            this.dtpStartDate.TabIndex = 44;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(691, 30);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(290, 30);
            this.txtResult.TabIndex = 27;
            // 
            // txtResultUnit
            // 
            this.txtResultUnit.Location = new System.Drawing.Point(691, 146);
            this.txtResultUnit.Name = "txtResultUnit";
            this.txtResultUnit.Size = new System.Drawing.Size(290, 30);
            this.txtResultUnit.TabIndex = 12;
            // 
            // txtResultValue
            // 
            this.txtResultValue.Location = new System.Drawing.Point(182, 252);
            this.txtResultValue.Name = "txtResultValue";
            this.txtResultValue.Size = new System.Drawing.Size(290, 30);
            this.txtResultValue.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(20, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "Giá Trị Kết Quả :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(509, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Kết Quả Xét Nhiệm :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(509, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Đơn Vị Kết Quả :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(509, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ghi Chú :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(20, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày Thực Hiện :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Y lệnh :";
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
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(999, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(744, 105);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvMedicalOrderID);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(999, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(747, 238);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin bệnh nhân";
            this.groupBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(839, 388);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(277, 33);
            this.label11.TabIndex = 33;
            this.label11.Text = "Danh Sách Xét Nghiệm";
            // 
            // dgvTestInfo
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTestInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTestInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTestInfo.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvTestInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTestInfo.Location = new System.Drawing.Point(0, 445);
            this.dgvTestInfo.Name = "dgvTestInfo";
            this.dgvTestInfo.RowHeadersWidth = 51;
            this.dgvTestInfo.RowTemplate.Height = 24;
            this.dgvTestInfo.Size = new System.Drawing.Size(1782, 367);
            this.dgvTestInfo.TabIndex = 32;
            this.dgvTestInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestInfo_CellClick);
            // 
            // frmTestInfo_Doctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 812);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvTestInfo);
            this.Name = "frmTestInfo_Doctor";
            this.Text = "frmTestInfo_Doctor";
            this.Load += new System.EventHandler(this.frmTestInfo_Doctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalOrderID)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMedicalOrderID;
        private System.Windows.Forms.ComboBox cboMedicalOrderID;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvTestInfo;
        private System.Windows.Forms.TextBox txtResultUnit;
        private System.Windows.Forms.TextBox txtResultValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txtNote;
    }
}