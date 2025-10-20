namespace Code_NT106.Q13._1_Lab02_24520592
{
    partial class Bai03
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
            btnRead = new Button();
            txtShow = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnRead
            // 
            btnRead.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRead.Location = new Point(27, 119);
            btnRead.Margin = new Padding(3, 2, 3, 2);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(154, 58);
            btnRead.TabIndex = 0;
            btnRead.Text = "Đọc file";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // txtShow
            // 
            txtShow.Location = new Point(255, 39);
            txtShow.Margin = new Padding(3, 2, 3, 2);
            txtShow.Multiline = true;
            txtShow.Name = "txtShow";
            txtShow.ReadOnly = true;
            txtShow.Size = new Size(433, 274);
            txtShow.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(186, 140);
            label1.Name = "label1";
            label1.Size = new Size(58, 17);
            label1.TabIndex = 2;
            label1.Text = "Kết quả:";
            // 
            // Bai03
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(700, 338);
            Controls.Add(label1);
            Controls.Add(txtShow);
            Controls.Add(btnRead);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Bai03";
            Text = "Bài 03 - Đọc và Ghi file và tính toán";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRead;
        private TextBox txtShow;
        private Label label1;
    }
}