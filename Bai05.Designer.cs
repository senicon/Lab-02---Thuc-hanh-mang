namespace Code_NT106.Q13._1_Lab02_24520592
{
    partial class Bai05
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnLoadFile = new Button();
            btnExportReport = new Button();
            panelSeats = new Panel();
            cmbMovie = new ComboBox();
            cmbRoom = new ComboBox();
            txtCustomerName = new TextBox();
            lblCustomerName = new Label();
            lblMovie = new Label();
            lblRoom = new Label();
            btnCalculate = new Button();
            btnReset = new Button();
            txtResult = new TextBox();
            lblSelectedSeats = new Label();
            txtSelectedSeats = new TextBox();
            lblResult = new Label();
            btnExit = new Button();
            progressBar = new ProgressBar();
            lblProgress = new Label();
            SuspendLayout();
            // 
            // btnLoadFile
            // 
            btnLoadFile.BackColor = Color.White;
            btnLoadFile.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoadFile.Location = new Point(113, 36);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(131, 38);
            btnLoadFile.TabIndex = 0;
            btnLoadFile.Text = "Đọc File";
            btnLoadFile.UseVisualStyleBackColor = false;
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // btnExportReport
            // 
            btnExportReport.BackColor = Color.White;
            btnExportReport.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportReport.Location = new Point(113, 96);
            btnExportReport.Name = "btnExportReport";
            btnExportReport.Size = new Size(131, 38);
            btnExportReport.TabIndex = 2;
            btnExportReport.Text = "Xuất Báo Cáo";
            btnExportReport.UseVisualStyleBackColor = false;
            btnExportReport.Click += btnExportReport_Click;
            // 
            // panelSeats
            // 
            panelSeats.AutoScroll = true;
            panelSeats.BackColor = Color.White;
            panelSeats.BorderStyle = BorderStyle.FixedSingle;
            panelSeats.Location = new Point(30, 206);
            panelSeats.Name = "panelSeats";
            panelSeats.Size = new Size(549, 446);
            panelSeats.TabIndex = 3;
            panelSeats.Visible = false;
            // 
            // cmbMovie
            // 
            cmbMovie.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMovie.Font = new Font("Arial", 10F);
            cmbMovie.FormattingEnabled = true;
            cmbMovie.Location = new Point(407, 62);
            cmbMovie.Name = "cmbMovie";
            cmbMovie.Size = new Size(237, 24);
            cmbMovie.TabIndex = 4;
            cmbMovie.SelectedIndexChanged += cmbMovie_SelectedIndexChanged;
            // 
            // cmbRoom
            // 
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.Enabled = false;
            cmbRoom.Font = new Font("Arial", 10F);
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(407, 110);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(237, 24);
            cmbRoom.TabIndex = 5;
            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Font = new Font("Arial", 10F);
            txtCustomerName.Location = new Point(407, 15);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(237, 23);
            txtCustomerName.TabIndex = 6;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerName.Location = new Point(311, 18);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(71, 19);
            lblCustomerName.TabIndex = 7;
            lblCustomerName.Text = "Họ và tên:";
            // 
            // lblMovie
            // 
            lblMovie.AutoSize = true;
            lblMovie.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMovie.Location = new Point(311, 65);
            lblMovie.Name = "lblMovie";
            lblMovie.Size = new Size(78, 19);
            lblMovie.TabIndex = 8;
            lblMovie.Text = "Chọn phim:";
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.Location = new Point(304, 111);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(85, 19);
            lblRoom.TabIndex = 9;
            lblRoom.Text = "Phòng chiếu:";
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.White;
            btnCalculate.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnCalculate.Location = new Point(585, 240);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(105, 38);
            btnCalculate.TabIndex = 10;
            btnCalculate.Text = "Đặt vé";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.White;
            btnReset.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnReset.Location = new Point(713, 240);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(105, 38);
            btnReset.TabIndex = 11;
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // txtResult
            // 
            txtResult.Font = new Font("Courier New", 10F);
            txtResult.Location = new Point(616, 308);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(180, 270);
            txtResult.TabIndex = 12;
            // 
            // lblSelectedSeats
            // 
            lblSelectedSeats.AutoSize = true;
            lblSelectedSeats.Font = new Font("Arial", 10F);
            lblSelectedSeats.Location = new Point(486, 181);
            lblSelectedSeats.Name = "lblSelectedSeats";
            lblSelectedSeats.Size = new Size(93, 16);
            lblSelectedSeats.TabIndex = 13;
            lblSelectedSeats.Text = "Ghế đã chọn:";
            // 
            // txtSelectedSeats
            // 
            txtSelectedSeats.Font = new Font("Arial", 10F);
            txtSelectedSeats.Location = new Point(585, 167);
            txtSelectedSeats.Multiline = true;
            txtSelectedSeats.Name = "txtSelectedSeats";
            txtSelectedSeats.ReadOnly = true;
            txtSelectedSeats.ScrollBars = ScrollBars.Vertical;
            txtSelectedSeats.Size = new Size(219, 48);
            txtSelectedSeats.TabIndex = 14;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResult.Location = new Point(604, 281);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(208, 24);
            lblResult.TabIndex = 15;
            lblResult.Text = "THÔNG TIN ĐẶT VÉ";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.White;
            btnExit.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(802, 358);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(152, 123);
            btnExit.TabIndex = 16;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(725, 65);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(219, 22);
            progressBar.TabIndex = 17;
            progressBar.Visible = false;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Arial", 9F);
            lblProgress.Location = new Point(760, 66);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(0, 15);
            lblProgress.TabIndex = 18;
            // 
            // Bai05
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 704);
            Controls.Add(lblProgress);
            Controls.Add(progressBar);
            Controls.Add(btnExit);
            Controls.Add(lblResult);
            Controls.Add(txtSelectedSeats);
            Controls.Add(lblSelectedSeats);
            Controls.Add(txtResult);
            Controls.Add(btnReset);
            Controls.Add(btnCalculate);
            Controls.Add(lblRoom);
            Controls.Add(lblMovie);
            Controls.Add(lblCustomerName);
            Controls.Add(txtCustomerName);
            Controls.Add(cmbRoom);
            Controls.Add(cmbMovie);
            Controls.Add(panelSeats);
            Controls.Add(btnExportReport);
            Controls.Add(btnLoadFile);
            Name = "Bai05";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 05 – Quản lý phòng vé (phiên bản số 2)";
            Load += Bai05_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Panel panelSeats;
        private System.Windows.Forms.ComboBox cmbMovie;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblSelectedSeats;
        private System.Windows.Forms.TextBox txtSelectedSeats;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
    }
}
