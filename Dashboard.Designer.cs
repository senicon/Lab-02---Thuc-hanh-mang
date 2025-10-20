using System;
namespace Code_NT106.Q13._1_Lab02_24520592
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBai01 = new Button();
            label1 = new Label();
            btnBai2 = new Button();
            btnBai3 = new Button();
            btnBai4 = new Button();
            btnBai5 = new Button();
            btnBai6 = new Button();
            btnBai7 = new Button();
            SuspendLayout();
            // 
            // btnBai01
            // 
            btnBai01.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBai01.Location = new Point(105, 89);
            btnBai01.Margin = new Padding(3, 2, 3, 2);
            btnBai01.Name = "btnBai01";
            btnBai01.Size = new Size(150, 85);
            btnBai01.TabIndex = 0;
            btnBai01.Text = "Bài 1";
            btnBai01.UseVisualStyleBackColor = true;
            btnBai01.Click += btnBai01_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(298, 9);
            label1.Name = "label1";
            label1.Size = new Size(67, 25);
            label1.TabIndex = 1;
            label1.Text = "Lab 02";
            label1.Click += label1_Click;
            // 
            // btnBai2
            // 
            btnBai2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBai2.Location = new Point(261, 40);
            btnBai2.Margin = new Padding(3, 2, 3, 2);
            btnBai2.Name = "btnBai2";
            btnBai2.Size = new Size(150, 85);
            btnBai2.TabIndex = 2;
            btnBai2.Text = "Bài 2";
            btnBai2.UseVisualStyleBackColor = true;
            btnBai2.Click += btnBai2_Click;
            // 
            // btnBai3
            // 
            btnBai3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBai3.Location = new Point(417, 89);
            btnBai3.Margin = new Padding(3, 2, 3, 2);
            btnBai3.Name = "btnBai3";
            btnBai3.Size = new Size(150, 85);
            btnBai3.TabIndex = 3;
            btnBai3.Text = "Bài 3";
            btnBai3.UseVisualStyleBackColor = true;
            btnBai3.Click += btnBai3_Click;
            // 
            // btnBai4
            // 
            btnBai4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBai4.Location = new Point(105, 190);
            btnBai4.Margin = new Padding(3, 2, 3, 2);
            btnBai4.Name = "btnBai4";
            btnBai4.Size = new Size(150, 85);
            btnBai4.TabIndex = 4;
            btnBai4.Text = "Bài 4";
            btnBai4.UseVisualStyleBackColor = true;
            btnBai4.Click += btnBai4_Click;
            // 
            // btnBai5
            // 
            btnBai5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBai5.Location = new Point(261, 145);
            btnBai5.Margin = new Padding(3, 2, 3, 2);
            btnBai5.Name = "btnBai5";
            btnBai5.Size = new Size(150, 85);
            btnBai5.TabIndex = 5;
            btnBai5.Text = "Bài 5";
            btnBai5.UseVisualStyleBackColor = true;
            btnBai5.Click += btnBai5_Click;
            // 
            // btnBai6
            // 
            btnBai6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBai6.Location = new Point(417, 190);
            btnBai6.Margin = new Padding(3, 2, 3, 2);
            btnBai6.Name = "btnBai6";
            btnBai6.Size = new Size(150, 85);
            btnBai6.TabIndex = 6;
            btnBai6.Text = "Bài 6";
            btnBai6.UseVisualStyleBackColor = true;
            btnBai6.Click += btnBai6_Click;
            // 
            // btnBai7
            // 
            btnBai7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBai7.Location = new Point(261, 252);
            btnBai7.Margin = new Padding(3, 2, 3, 2);
            btnBai7.Name = "btnBai7";
            btnBai7.Size = new Size(150, 85);
            btnBai7.TabIndex = 7;
            btnBai7.Text = "Bài 7";
            btnBai7.UseVisualStyleBackColor = true;
            btnBai7.Click += btnBai7_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnBai7);
            Controls.Add(btnBai6);
            Controls.Add(btnBai5);
            Controls.Add(btnBai4);
            Controls.Add(btnBai3);
            Controls.Add(btnBai2);
            Controls.Add(label1);
            Controls.Add(btnBai01);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Dashboard";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBai01;
        private Label label1;
        private Button btnBai2;
        private Button btnBai3;
        private Button btnBai4;
        private Button btnBai5;
        private Button btnBai6;
        private Button btnBai7;
    }
}
