using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Code_NT106.Q13._1_Lab02_24520592
{
    public partial class Bai07 : Form
    {
        public Bai07()
        {
            InitializeComponent();
        }

        private void Bai07_Load(object sender, EventArgs e)
        {
            LoadDrives();
        }

        private void LoadDrives()
        {
            try
            {
                string[] drives = Directory.GetLogicalDrives();
                foreach (string drive in drives)
                {
                    TreeNode driveNode = new TreeNode(drive);
                    driveNode.Tag = drive;
                    driveNode.Nodes.Add("");
                    treeViewFolders.Nodes.Add(driveNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ổ đĩa: " + ex.Message);
            }
        }

        private void treeViewFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            if (selectedNode.Nodes.Count == 1 && selectedNode.Nodes[0].Tag == null)
            {
                selectedNode.Nodes.Clear();
                string path = selectedNode.Tag.ToString();
                LoadDirectories(selectedNode, path);
            }
        }

        private void LoadDirectories(TreeNode node, string path)
        {
            try
            {
                string[] directories = Directory.GetDirectories(path);
                foreach (string dir in directories)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    TreeNode dirNode = new TreeNode(dirInfo.Name);
                    dirNode.Tag = dir;
                    dirNode.Nodes.Add("");
                    node.Nodes.Add(dirNode);
                }

                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    TreeNode fileNode = new TreeNode(fileInfo.Name);
                    fileNode.Tag = file;
                    fileNode.ForeColor = Color.Blue;
                    node.Nodes.Add(fileNode);
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void treeViewFolders_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            string path = selectedNode.Tag.ToString();

            if (File.Exists(path))
            {
                DisplayFileContent(path);
            }
            else if (Directory.Exists(path))
            {
                if (!selectedNode.IsExpanded)
                {
                    selectedNode.Expand();
                }
            }
        }

        private void DisplayFileContent(string filePath)
        {
            try
            {
                string extension = Path.GetExtension(filePath).ToLower();

                pictureBoxImage.Visible = false;
                richTextBoxContent.Visible = false;

                if (extension == ".jpg" || extension == ".jpeg" ||
                    extension == ".png" || extension == ".bmp" ||
                    extension == ".gif")
                {
                    pictureBoxImage.Image = Image.FromFile(filePath);
                    pictureBoxImage.Visible = true;
                }
                else if (extension == ".txt" || extension == ".cs" ||
                         extension == ".xml" || extension == ".json")
                {
                    richTextBoxContent.Text = File.ReadAllText(filePath);
                    richTextBoxContent.Visible = true;
                }
                else
                {
                    MessageBox.Show("Không hỗ trợ định dạng file này để xem trước.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file: " + ex.Message);
            }
        }
    }
}
