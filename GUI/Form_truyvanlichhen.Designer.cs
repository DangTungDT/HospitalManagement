namespace GUI
{
    partial class Form_truyvanlichhen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.dgv_lichhen = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_ngayhen = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lichhen)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv_lichhen
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_lichhen.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_lichhen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_lichhen.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgv_lichhen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lichhen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_lichhen.Location = new System.Drawing.Point(0, 407);
            this.dgv_lichhen.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_lichhen.Name = "dgv_lichhen";
            this.dgv_lichhen.RowHeadersWidth = 51;
            this.dgv_lichhen.RowTemplate.Height = 24;
            this.dgv_lichhen.Size = new System.Drawing.Size(1121, 243);
            this.dgv_lichhen.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Nhập ngày";
            // 
            // dtp_ngayhen
            // 
            this.dtp_ngayhen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngayhen.Location = new System.Drawing.Point(471, 220);
            this.dtp_ngayhen.Name = "dtp_ngayhen";
            this.dtp_ngayhen.Size = new System.Drawing.Size(162, 20);
            this.dtp_ngayhen.TabIndex = 40;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(713, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(217, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(758, 54);
            this.label16.TabIndex = 52;
            this.label16.Text = "TÌM KIẾM THÔNG TIN LỊCH HẸN";
            // 
            // Form_truyvanlichhen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 650);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_lichhen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_ngayhen);
            this.Name = "Form_truyvanlichhen";
            this.Text = "Form_truyvanlichhen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_truyvanlichhen_FormClosing);
            this.Load += new System.EventHandler(this.Form_truyvanlichhen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lichhen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv_lichhen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_ngayhen;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label16;
    }
}