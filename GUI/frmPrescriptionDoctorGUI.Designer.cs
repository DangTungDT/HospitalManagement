namespace GUI
{
    partial class frmPrescriptionDoctorGUI
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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelDetail = new System.Windows.Forms.TableLayoutPanel();
            this.lblPrescriptionID = new System.Windows.Forms.Label();
            this.txtPrescriptionID = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblPatient = new System.Windows.Forms.Label();
            this.cbPatient = new System.Windows.Forms.ComboBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.rtbNote = new System.Windows.Forms.RichTextBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.cbDoctor = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.flowLayoutPanelSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearchPatient = new System.Windows.Forms.Label();
            this.cbSearchPatient = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvPrescriptions = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelMain.SuspendLayout();
            this.gbDetail.SuspendLayout();
            this.tableLayoutPanelDetail.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.flowLayoutPanelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.gbDetail, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanelButtons, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanelSearch, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.dgvPrescriptions, 0, 4);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 5;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(675, 390);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(2, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(671, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông Tin Đơn Thuốc";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.tableLayoutPanelDetail);
            this.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetail.Location = new System.Drawing.Point(2, 41);
            this.gbDetail.Margin = new System.Windows.Forms.Padding(2);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Padding = new System.Windows.Forms.Padding(2);
            this.gbDetail.Size = new System.Drawing.Size(671, 113);
            this.gbDetail.TabIndex = 1;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Thông tin Đơn Thuốc";
            // 
            // tableLayoutPanelDetail
            // 
            this.tableLayoutPanelDetail.ColumnCount = 4;
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelDetail.Controls.Add(this.lblPrescriptionID, 0, 0);
            this.tableLayoutPanelDetail.Controls.Add(this.txtPrescriptionID, 1, 0);
            this.tableLayoutPanelDetail.Controls.Add(this.lblOrderDate, 2, 0);
            this.tableLayoutPanelDetail.Controls.Add(this.dtpOrderDate, 3, 0);
            this.tableLayoutPanelDetail.Controls.Add(this.lblPatient, 0, 1);
            this.tableLayoutPanelDetail.Controls.Add(this.cbPatient, 1, 1);
            this.tableLayoutPanelDetail.Controls.Add(this.lblNote, 2, 1);
            this.tableLayoutPanelDetail.Controls.Add(this.rtbNote, 3, 1);
            this.tableLayoutPanelDetail.Controls.Add(this.lblDoctor, 0, 2);
            this.tableLayoutPanelDetail.Controls.Add(this.cbDoctor, 1, 2);
            this.tableLayoutPanelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDetail.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanelDetail.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelDetail.Name = "tableLayoutPanelDetail";
            this.tableLayoutPanelDetail.RowCount = 3;
            this.tableLayoutPanelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanelDetail.Size = new System.Drawing.Size(667, 96);
            this.tableLayoutPanelDetail.TabIndex = 0;
            // 
            // lblPrescriptionID
            // 
            this.lblPrescriptionID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPrescriptionID.Location = new System.Drawing.Point(13, 8);
            this.lblPrescriptionID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrescriptionID.Name = "lblPrescriptionID";
            this.lblPrescriptionID.Size = new System.Drawing.Size(75, 15);
            this.lblPrescriptionID.TabIndex = 0;
            this.lblPrescriptionID.Text = "Mã Đơn Thuốc:";
            // 
            // txtPrescriptionID
            // 
            this.txtPrescriptionID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPrescriptionID.Location = new System.Drawing.Point(120, 20);
            this.txtPrescriptionID.Name = "txtPrescriptionID";
            this.txtPrescriptionID.Size = new System.Drawing.Size(200, 20);
            this.txtPrescriptionID.TabIndex = 1;
            this.txtPrescriptionID.ReadOnly = true; // Chỉ đọc, không cho nhập
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOrderDate.Location = new System.Drawing.Point(297, 8);
            this.lblOrderDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(75, 15);
            this.lblOrderDate.TabIndex = 2;
            this.lblOrderDate.Text = "Ngày Kê:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(376, 5);
            this.dtpOrderDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(180, 20);
            this.dtpOrderDate.TabIndex = 3;
            // 
            // lblPatient
            // 
            this.lblPatient.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPatient.Location = new System.Drawing.Point(13, 39);
            this.lblPatient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(75, 15);
            this.lblPatient.TabIndex = 4;
            this.lblPatient.Text = "Bệnh Nhân:";
            // 
            // cbPatient
            // 
            this.cbPatient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatient.Location = new System.Drawing.Point(92, 36);
            this.cbPatient.Margin = new System.Windows.Forms.Padding(2);
            this.cbPatient.Name = "cbPatient";
            this.cbPatient.Size = new System.Drawing.Size(180, 21);
            this.cbPatient.TabIndex = 5;
            // 
            // lblNote
            // 
            this.lblNote.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNote.Location = new System.Drawing.Point(297, 39);
            this.lblNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(75, 15);
            this.lblNote.TabIndex = 6;
            this.lblNote.Text = "Ghi Chú:";
            // 
            // rtbNote
            // 
            this.rtbNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rtbNote.Location = new System.Drawing.Point(376, 33);
            this.rtbNote.Margin = new System.Windows.Forms.Padding(2);
            this.rtbNote.Name = "rtbNote";
            this.rtbNote.Size = new System.Drawing.Size(200, 27);
            this.rtbNote.TabIndex = 7;
            this.rtbNote.Text = "";
            // 
            // lblDoctor
            // 
            this.lblDoctor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDoctor.Location = new System.Drawing.Point(13, 71);
            this.lblDoctor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(75, 15);
            this.lblDoctor.TabIndex = 8;
            this.lblDoctor.Text = "Bác Sĩ:";
            // 
            // cbDoctor
            // 
            this.cbDoctor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoctor.Location = new System.Drawing.Point(92, 68);
            this.cbDoctor.Margin = new System.Windows.Forms.Padding(2);
            this.cbDoctor.Name = "cbDoctor";
            this.cbDoctor.Size = new System.Drawing.Size(180, 21);
            this.cbDoctor.TabIndex = 9;
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Controls.Add(this.btnCreate);
            this.flowLayoutPanelButtons.Controls.Add(this.btnUpdate);
            this.flowLayoutPanelButtons.Controls.Add(this.btnViewDetail);
            this.flowLayoutPanelButtons.Controls.Add(this.btnRefresh);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(2, 158);
            this.flowLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(671, 35);
            this.flowLayoutPanelButtons.TabIndex = 2;
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCreate.Location = new System.Drawing.Point(15, 6);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(15, 6, 15, 6);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(105, 26);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Tạo Đơn";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(150, 6);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(15, 6, 15, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 26);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Cập Nhật Đơn";
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnViewDetail.Location = new System.Drawing.Point(285, 6);
            this.btnViewDetail.Margin = new System.Windows.Forms.Padding(15, 6, 15, 6);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(132, 26);
            this.btnViewDetail.TabIndex = 2;
            this.btnViewDetail.Text = "Xem Chi Tiết";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(447, 6);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(15, 6, 15, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(105, 26);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm Mới";
            // 
            // flowLayoutPanelSearch
            // 
            this.flowLayoutPanelSearch.Controls.Add(this.lblSearchPatient);
            this.flowLayoutPanelSearch.Controls.Add(this.cbSearchPatient);
            this.flowLayoutPanelSearch.Controls.Add(this.btnSearch);
            this.flowLayoutPanelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelSearch.Location = new System.Drawing.Point(2, 197);
            this.flowLayoutPanelSearch.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelSearch.Name = "flowLayoutPanelSearch";
            this.flowLayoutPanelSearch.Size = new System.Drawing.Size(671, 35);
            this.flowLayoutPanelSearch.TabIndex = 4;
            // 
            // lblSearchPatient
            // 
            this.lblSearchPatient.AutoSize = true;
            this.lblSearchPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearchPatient.Location = new System.Drawing.Point(15, 8);
            this.lblSearchPatient.Margin = new System.Windows.Forms.Padding(15, 8, 5, 8);
            this.lblSearchPatient.Name = "lblSearchPatient";
            this.lblSearchPatient.Size = new System.Drawing.Size(85, 19);
            this.lblSearchPatient.TabIndex = 0;
            this.lblSearchPatient.Text = "Tìm Bệnh Nhân:";
            // 
            // cbSearchPatient
            // 
            this.cbSearchPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchPatient.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbSearchPatient.Location = new System.Drawing.Point(110, 6);
            this.cbSearchPatient.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbSearchPatient.Name = "cbSearchPatient";
            this.cbSearchPatient.Size = new System.Drawing.Size(200, 25);
            this.cbSearchPatient.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(320, 6);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5, 6, 15, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm Kiếm";
            // 
            // dgvPrescriptions
            // 
            this.dgvPrescriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrescriptions.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrescriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrescriptions.Location = new System.Drawing.Point(2, 236);
            this.dgvPrescriptions.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPrescriptions.Name = "dgvPrescriptions";
            this.dgvPrescriptions.ReadOnly = true;
            this.dgvPrescriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrescriptions.Size = new System.Drawing.Size(671, 152);
            this.dgvPrescriptions.TabIndex = 3;
            // 
            // frmPrescriptionDoctorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 390);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPrescriptionDoctorGUI";
            this.Text = "Thông Tin Đơn Thuốc";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.gbDetail.ResumeLayout(false);
            this.tableLayoutPanelDetail.ResumeLayout(false);
            this.tableLayoutPanelDetail.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelSearch.ResumeLayout(false);
            this.flowLayoutPanelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDetail;
        private System.Windows.Forms.Label lblPrescriptionID;
        private System.Windows.Forms.TextBox txtPrescriptionID;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.ComboBox cbPatient;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cbDoctor;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.RichTextBox rtbNote;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSearch;
        private System.Windows.Forms.Label lblSearchPatient;
        private System.Windows.Forms.ComboBox cbSearchPatient;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvPrescriptions;
    }
}