using System;
namespace Code_NT106.Q13._1_Lab02_24520592
{
    partial class Bai01
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
            btnWriteFile = new Button();
            btnReadFile = new Button();
            txtContentOfFile = new TextBox();
            SuspendLayout();
            // 
            // btnWriteFile
            // 
            btnWriteFile.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWriteFile.Location = new Point(10, 164);
            btnWriteFile.Margin = new Padding(3, 2, 3, 2);
            btnWriteFile.Name = "btnWriteFile";
            btnWriteFile.Size = new Size(224, 67);
            btnWriteFile.TabIndex = 4;
            btnWriteFile.Text = "Ghi File";
            btnWriteFile.UseVisualStyleBackColor = true;
            btnWriteFile.Click += btnWriteFile_Click;
            // 
            // btnReadFile
            // 
            btnReadFile.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReadFile.Location = new Point(10, 66);
            btnReadFile.Margin = new Padding(3, 2, 3, 2);
            btnReadFile.Name = "btnReadFile";
            btnReadFile.Size = new Size(224, 67);
            btnReadFile.TabIndex = 3;
            btnReadFile.Text = "Đọc File";
            btnReadFile.UseVisualStyleBackColor = true;
            btnReadFile.Click += btnReadFile_Click;
            // 
            // txtContentOfFile
            // 
            txtContentOfFile.BackColor = Color.White;
            txtContentOfFile.Location = new Point(258, 2);
            txtContentOfFile.Margin = new Padding(3, 2, 3, 2);
            txtContentOfFile.Multiline = true;
            txtContentOfFile.Name = "txtContentOfFile";
            txtContentOfFile.ReadOnly = true;
            txtContentOfFile.Size = new Size(432, 335);
            txtContentOfFile.TabIndex = 5;
            txtContentOfFile.TextChanged += txtContentOfFile_TextChanged;
            // 
            // Bai01
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(txtContentOfFile);
            Controls.Add(btnWriteFile);
            Controls.Add(btnReadFile);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Bai01";
            Text = "Bài 01 – Ghi và Đọc file";
            Load += Bai01_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnWriteFile;
        private Button btnReadFile;
        private TextBox txtContentOfFile;
    }
}