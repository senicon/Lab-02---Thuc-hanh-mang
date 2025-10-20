using System;
namespace Code_NT106.Q13._1_Lab02_24520592
{ 
    partial class Bai02
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
            label1 = new Label();
            txtFileName = new TextBox();
            txtSize = new TextBox();
            label2 = new Label();
            txtURL = new TextBox();
            label3 = new Label();
            txtLineCount = new TextBox();
            label4 = new Label();
            txtWordsCount = new TextBox();
            label5 = new Label();
            txtCharacterCount = new TextBox();
            label6 = new Label();
            btnReadFromFile = new Button();
            btnExit = new Button();
            txtShow = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 71);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 1;
            label1.Text = "File name";
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(92, 66);
            txtFileName.Margin = new Padding(3, 2, 3, 2);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(273, 23);
            txtFileName.TabIndex = 2;
            txtFileName.TextChanged += txtFileName_TextChanged;
            // 
            // txtSize
            // 
            txtSize.Location = new Point(92, 110);
            txtSize.Margin = new Padding(3, 2, 3, 2);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(273, 23);
            txtSize.TabIndex = 5;
            txtSize.TextChanged += txtSize_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F);
            label2.Location = new Point(21, 112);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 4;
            label2.Text = "Size";
            // 
            // txtURL
            // 
            txtURL.Location = new Point(92, 153);
            txtURL.Margin = new Padding(3, 2, 3, 2);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(273, 23);
            txtURL.TabIndex = 7;
            txtURL.TextChanged += txtURL_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 155);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 6;
            label3.Text = "URL";
            // 
            // txtLineCount
            // 
            txtLineCount.Location = new Point(92, 201);
            txtLineCount.Margin = new Padding(3, 2, 3, 2);
            txtLineCount.Name = "txtLineCount";
            txtLineCount.Size = new Size(273, 23);
            txtLineCount.TabIndex = 9;
            txtLineCount.TextChanged += txtLineCount_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(5, 206);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 8;
            label4.Text = "Line Count";
            // 
            // txtWordsCount
            // 
            txtWordsCount.Location = new Point(92, 246);
            txtWordsCount.Margin = new Padding(3, 2, 3, 2);
            txtWordsCount.Name = "txtWordsCount";
            txtWordsCount.Size = new Size(273, 23);
            txtWordsCount.TabIndex = 11;
            txtWordsCount.TextChanged += txtWordsCount_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 251);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 10;
            label5.Text = "Words Count";
            // 
            // txtCharacterCount
            // 
            txtCharacterCount.Location = new Point(108, 295);
            txtCharacterCount.Margin = new Padding(3, 2, 3, 2);
            txtCharacterCount.Name = "txtCharacterCount";
            txtCharacterCount.Size = new Size(273, 23);
            txtCharacterCount.TabIndex = 13;
            txtCharacterCount.TextChanged += txtCharacterCount_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(3, 297);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 12;
            label6.Text = "Character Count";
            // 
            // btnReadFromFile
            // 
            btnReadFromFile.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReadFromFile.Location = new Point(10, 16);
            btnReadFromFile.Margin = new Padding(3, 2, 3, 2);
            btnReadFromFile.Name = "btnReadFromFile";
            btnReadFromFile.Size = new Size(354, 30);
            btnReadFromFile.TabIndex = 15;
            btnReadFromFile.Text = "Read From File";
            btnReadFromFile.UseVisualStyleBackColor = true;
            btnReadFromFile.Click += btnReadFromFile_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Times New Roman", 17.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(2, 328);
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(382, 52);
            btnExit.TabIndex = 16;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // txtShow
            // 
            txtShow.BackColor = SystemColors.ActiveBorder;
            txtShow.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtShow.Location = new Point(388, 2);
            txtShow.Margin = new Padding(3, 2, 3, 2);
            txtShow.Multiline = true;
            txtShow.Name = "txtShow";
            txtShow.ReadOnly = true;
            txtShow.Size = new Size(552, 379);
            txtShow.TabIndex = 17;
            txtShow.TextChanged += txtShow_TextChanged;
            // 
            // Bai02
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(948, 381);
            Controls.Add(txtShow);
            Controls.Add(btnExit);
            Controls.Add(btnReadFromFile);
            Controls.Add(txtCharacterCount);
            Controls.Add(label6);
            Controls.Add(txtWordsCount);
            Controls.Add(label5);
            Controls.Add(txtLineCount);
            Controls.Add(label4);
            Controls.Add(txtURL);
            Controls.Add(label3);
            Controls.Add(txtSize);
            Controls.Add(label2);
            Controls.Add(txtFileName);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Bai02";
            Text = "Bài 02 – Đọc thông tin một file .txt";
            Load += Bai02_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox txtFileName;
        private TextBox txtSize;
        private Label label2;
        private TextBox txtURL;
        private Label label3;
        private TextBox txtLineCount;
        private Label label4;
        private TextBox txtWordsCount;
        private Label label5;
        private TextBox txtCharacterCount;
        private Label label6;
        private Button btnReadFromFile;
        private Button btnExit;
        private TextBox txtShow;
    }
}