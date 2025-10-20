namespace Code_NT106.Q13._1_Lab02_24520592
{
    partial class Bai07
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TreeView treeViewFolders;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.RichTextBox richTextBoxContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            treeViewFolders = new TreeView();
            panelContent = new Panel();
            pictureBoxImage = new PictureBox();
            richTextBoxContent = new RichTextBox();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            SuspendLayout();
            // 
            // treeViewFolders
            // 
            treeViewFolders.Dock = DockStyle.Left;
            treeViewFolders.Location = new Point(0, 0);
            treeViewFolders.Margin = new Padding(3, 4, 3, 4);
            treeViewFolders.Name = "treeViewFolders";
            treeViewFolders.Size = new Size(210, 562);
            treeViewFolders.TabIndex = 0;
            treeViewFolders.BeforeExpand += treeViewFolders_BeforeExpand;
            treeViewFolders.NodeMouseDoubleClick += treeViewFolders_NodeMouseDoubleClick;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(pictureBoxImage);
            panelContent.Controls.Add(richTextBoxContent);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(210, 0);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(590, 562);
            panelContent.TabIndex = 1;
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Dock = DockStyle.Fill;
            pictureBoxImage.Location = new Point(0, 0);
            pictureBoxImage.Margin = new Padding(3, 4, 3, 4);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(590, 562);
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImage.TabIndex = 0;
            pictureBoxImage.TabStop = false;
            pictureBoxImage.Visible = false;
            // 
            // richTextBoxContent
            // 
            richTextBoxContent.Dock = DockStyle.Fill;
            richTextBoxContent.Location = new Point(0, 0);
            richTextBoxContent.Margin = new Padding(3, 4, 3, 4);
            richTextBoxContent.Name = "richTextBoxContent";
            richTextBoxContent.Size = new Size(590, 562);
            richTextBoxContent.TabIndex = 1;
            richTextBoxContent.Text = "";
            richTextBoxContent.Visible = false;
            // 
            // Bai07
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 562);
            Controls.Add(panelContent);
            Controls.Add(treeViewFolders);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Bai07";
            Text = "Bài 07 – Duyệt thư mục";
            Load += Bai07_Load;
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ResumeLayout(false);
        }
    }
}
