using System.Windows.Forms;

namespace GUI
{
    partial class frmPrescriptionDetailInfoDoctorGUI
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
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.rtbNote = new System.Windows.Forms.RichTextBox();
            this.lblDosage = new System.Windows.Forms.Label();
            this.cbItemID = new System.Windows.Forms.ComboBox();
            this.txtDosage = new System.Windows.Forms.TextBox();
            this.lblPrescriptionID = new System.Windows.Forms.Label();
            this.cbPrescriptionID = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvPrescriptionDetails = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelMain.SuspendLayout();
            this.gbDetail.SuspendLayout();
            this.tableLayoutPanelDetail.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.gbDetail, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanelButtons, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.dgvPrescriptionDetails, 0, 3);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 4;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(900, 600);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(894, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông Tin Chi Tiết Đơn Thuốc";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.tableLayoutPanelDetail);
            this.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.gbDetail.Location = new System.Drawing.Point(3, 53);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(894, 194);
            this.gbDetail.TabIndex = 1;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Thông tin chi tiết đơn thuốc";
            // 
            // tableLayoutPanelDetail
            // 
            this.tableLayoutPanelDetail.ColumnCount = 6;
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelDetail.Controls.Add(this.lblItemID, 2, 0);
            this.tableLayoutPanelDetail.Controls.Add(this.lblQuantity, 4, 0);
            this.tableLayoutPanelDetail.Controls.Add(this.txtQuantity, 5, 0);
            this.tableLayoutPanelDetail.Controls.Add(this.lblUnit, 0, 1);
            this.tableLayoutPanelDetail.Controls.Add(this.cbUnit, 1, 1);
            this.tableLayoutPanelDetail.Controls.Add(this.lblFrequency, 4, 1);
            this.tableLayoutPanelDetail.Controls.Add(this.txtFrequency, 5, 1);
            this.tableLayoutPanelDetail.Controls.Add(this.lblNote, 0, 2);
            this.tableLayoutPanelDetail.Controls.Add(this.rtbNote, 1, 2);
            this.tableLayoutPanelDetail.Controls.Add(this.lblDosage, 2, 1);
            this.tableLayoutPanelDetail.Controls.Add(this.cbItemID, 3, 0);
            this.tableLayoutPanelDetail.Controls.Add(this.txtDosage, 3, 1);
            this.tableLayoutPanelDetail.Controls.Add(this.lblPrescriptionID, 0, 0);
            this.tableLayoutPanelDetail.Controls.Add(this.cbPrescriptionID, 1, 0);
            this.tableLayoutPanelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDetail.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanelDetail.Name = "tableLayoutPanelDetail";
            this.tableLayoutPanelDetail.RowCount = 3;
            this.tableLayoutPanelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelDetail.Size = new System.Drawing.Size(888, 166);
            this.tableLayoutPanelDetail.TabIndex = 0;
            // 
            // lblItemID
            // 
            this.lblItemID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemID.AutoSize = true;
            this.lblItemID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblItemID.Location = new System.Drawing.Point(336, 18);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(78, 19);
            this.lblItemID.TabIndex = 2;
            this.lblItemID.Text = "Mã Thuốc:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQuantity.Location = new System.Drawing.Point(619, 18);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(76, 19);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Số Lượng:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtQuantity.Location = new System.Drawing.Point(701, 15);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(150, 25);
            this.txtQuantity.TabIndex = 5;
            // 
            // lblUnit
            // 
            this.lblUnit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUnit.Location = new System.Drawing.Point(60, 73);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(57, 19);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "Đơn Vị:";
            // 
            // cbUnit
            // 
            this.cbUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Items.AddRange(new object[] {
            "Viên",
            "Hộp",
            "Chai",
            "Gói",
            "Chiếc"});
            this.cbUnit.Location = new System.Drawing.Point(123, 69);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(183, 25);
            this.cbUnit.TabIndex = 7;
            // 
            // lblFrequency
            // 
            this.lblFrequency.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFrequency.Location = new System.Drawing.Point(625, 73);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(70, 19);
            this.lblFrequency.TabIndex = 10;
            this.lblFrequency.Text = "Tần Suất:";
            // 
            // txtFrequency
            // 
            this.txtFrequency.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFrequency.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFrequency.Location = new System.Drawing.Point(701, 70);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(150, 25);
            this.txtFrequency.TabIndex = 11;
            // 
            // lblNote
            // 
            this.lblNote.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNote.Location = new System.Drawing.Point(53, 128);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(64, 19);
            this.lblNote.TabIndex = 12;
            this.lblNote.Text = "Ghi Chú:";
            // 
            // rtbNote
            // 
            this.rtbNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanelDetail.SetColumnSpan(this.rtbNote, 5);
            this.rtbNote.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbNote.Location = new System.Drawing.Point(123, 120);
            this.rtbNote.Name = "rtbNote";
            this.rtbNote.Size = new System.Drawing.Size(758, 35);
            this.rtbNote.TabIndex = 13;
            this.rtbNote.Text = "";
            // 
            // lblDosage
            // 
            this.lblDosage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDosage.AutoSize = true;
            this.lblDosage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDosage.Location = new System.Drawing.Point(328, 73);
            this.lblDosage.Name = "lblDosage";
            this.lblDosage.Size = new System.Drawing.Size(86, 19);
            this.lblDosage.TabIndex = 8;
            this.lblDosage.Text = "Liều Lượng:";
            // 
            // cbItemID
            // 
            this.cbItemID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbItemID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbItemID.FormattingEnabled = true;
            this.cbItemID.Location = new System.Drawing.Point(420, 14);
            this.cbItemID.Name = "cbItemID";
            this.cbItemID.Size = new System.Drawing.Size(183, 25);
            this.cbItemID.TabIndex = 3;
            // 
            // txtDosage
            // 
            this.txtDosage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDosage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDosage.Location = new System.Drawing.Point(420, 70);
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.Size = new System.Drawing.Size(183, 25);
            this.txtDosage.TabIndex = 9;
            // 
            // lblPrescriptionID
            // 
            this.lblPrescriptionID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPrescriptionID.AutoSize = true;
            this.lblPrescriptionID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrescriptionID.Location = new System.Drawing.Point(8, 18);
            this.lblPrescriptionID.Name = "lblPrescriptionID";
            this.lblPrescriptionID.Size = new System.Drawing.Size(109, 19);
            this.lblPrescriptionID.TabIndex = 0;
            this.lblPrescriptionID.Text = "Mã Đơn Thuốc:";
            // 
            // cbPrescriptionID
            // 
            this.cbPrescriptionID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPrescriptionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrescriptionID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbPrescriptionID.FormattingEnabled = true;
            this.cbPrescriptionID.Location = new System.Drawing.Point(120, 14);
            this.cbPrescriptionID.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.cbPrescriptionID.Name = "cbPrescriptionID";
            this.cbPrescriptionID.Size = new System.Drawing.Size(189, 25);
            this.cbPrescriptionID.TabIndex = 1;
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Controls.Add(this.btnCreate);
            this.flowLayoutPanelButtons.Controls.Add(this.btnUpdate);
            this.flowLayoutPanelButtons.Controls.Add(this.btnDelete);
            this.flowLayoutPanelButtons.Controls.Add(this.btnRefresh);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(3, 253);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(894, 44);
            this.flowLayoutPanelButtons.TabIndex = 2;
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCreate.Location = new System.Drawing.Point(20, 8);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(20, 8, 20, 8);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(150, 30);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Tạo Chi Tiết";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(210, 8);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(20, 8, 20, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 30);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Cập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(400, 8);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(20, 8, 20, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(590, 8);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(20, 8, 20, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvPrescriptionDetails
            // 
            this.dgvPrescriptionDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrescriptionDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrescriptionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrescriptionDetails.Location = new System.Drawing.Point(3, 303);
            this.dgvPrescriptionDetails.Name = "dgvPrescriptionDetails";
            this.dgvPrescriptionDetails.ReadOnly = true;
            this.dgvPrescriptionDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrescriptionDetails.Size = new System.Drawing.Size(894, 294);
            this.dgvPrescriptionDetails.TabIndex = 3;
            // 
            // frmPrescriptionDetailInfoDoctorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "frmPrescriptionDetailInfoDoctorGUI";
            this.Text = "Thông Tin Chi Tiết Đơn Thuốc";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.gbDetail.ResumeLayout(false);
            this.tableLayoutPanelDetail.ResumeLayout(false);
            this.tableLayoutPanelDetail.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptionDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDetail;
        private System.Windows.Forms.Label lblPrescriptionID;
        private System.Windows.Forms.ComboBox cbPrescriptionID;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.ComboBox cbItemID;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.Label lblDosage;
        private System.Windows.Forms.TextBox txtDosage;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.RichTextBox rtbNote;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvPrescriptionDetails;
    }
}