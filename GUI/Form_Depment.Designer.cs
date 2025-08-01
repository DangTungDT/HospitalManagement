namespace GUI
{
    partial class Form_Depment
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
            this.dgv_phongban = new System.Windows.Forms.DataGridView();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_lammoi = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.txtIdDepartment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_phongban)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_phongban
            // 
            this.dgv_phongban.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_phongban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_phongban.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_phongban.Location = new System.Drawing.Point(0, 422);
            this.dgv_phongban.Name = "dgv_phongban";
            this.dgv_phongban.Size = new System.Drawing.Size(1159, 256);
            this.dgv_phongban.TabIndex = 58;
            this.dgv_phongban.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_phongban_CellClick);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(784, 336);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(75, 23);
            this.btn_thoat.TabIndex = 53;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.Location = new System.Drawing.Point(632, 336);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(75, 23);
            this.btn_lammoi.TabIndex = 54;
            this.btn_lammoi.Text = "Làm mới";
            this.btn_lammoi.UseVisualStyleBackColor = true;
            this.btn_lammoi.Click += new System.EventHandler(this.btn_lammoi_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(467, 336);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(75, 23);
            this.btn_sua.TabIndex = 55;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(331, 336);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa.TabIndex = 56;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(170, 336);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 23);
            this.btn_them.TabIndex = 57;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(632, 126);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(211, 20);
            this.txtDescription.TabIndex = 50;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(209, 173);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(211, 20);
            this.txtDepartmentName.TabIndex = 51;
            // 
            // txtIdDepartment
            // 
            this.txtIdDepartment.Location = new System.Drawing.Point(209, 121);
            this.txtIdDepartment.Name = "txtIdDepartment";
            this.txtIdDepartment.Size = new System.Drawing.Size(211, 20);
            this.txtIdDepartment.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(559, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Ghi chú:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "ID phòng ban:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Tên phòng ban:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(292, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(594, 54);
            this.label16.TabIndex = 46;
            this.label16.Text = "THÔNG TIN PHÒNG BAN";
            // 
            // Form_Depment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 678);
            this.Controls.Add(this.dgv_phongban);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_lammoi);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtDepartmentName);
            this.Controls.Add(this.txtIdDepartment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Name = "Form_Depment";
            this.Text = "Form_Depment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Depment_FormClosing);
            this.Load += new System.EventHandler(this.Form_Depment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_phongban)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_phongban;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_lammoi;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.TextBox txtIdDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
    }
}