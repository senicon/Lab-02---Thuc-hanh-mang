using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_NT106.Q13._1_Lab02_24520592
{
    public partial class Bai01 : Form
    {
        public Bai01()
        {
            InitializeComponent();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            if (!File.Exists("input1.txt"))
            {
                MessageBox.Show("Chưa tạo file input1.txt", "Error 404 NOT FOUND");
                return;
            }

            var file = new FileInfo("input1.txt");
            if (file.Length == 0)
            {
                MessageBox.Show("File input1.txt rỗng", "Error 404 NOT FOUND");
                return;
            }

            try
            {
                using (var read = new StreamReader("input1.txt", Encoding.UTF8))
                {
                    txtContentOfFile.Text = read.ReadToEnd();
                }
                MessageBox.Show("Đọc file thành công", "No Bugs Found");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message, "Error 404 NOT FOUND");
            }
        }

        private void btnWriteFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContentOfFile.Text))
            {
                MessageBox.Show("Chưa có nội dung để lưu", "Error 404 NOT FOUND");
                return;
            }

            try
            {
                using (var write = new StreamWriter("output1.txt", false, Encoding.UTF8))
                {
                    write.Write(txtContentOfFile.Text.ToUpper());
                }

                MessageBox.Show("Đã lưu nội dung dưới dạng in hoa vào file output1.txt", "No Bugs Found");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message, "Error 404 NOT FOUND");
            }
        }

        private void txtContentOfFile_TextChanged(object sender, EventArgs e)
        {
        }

        private void Bai01_Load(object sender, EventArgs e)
        {
        }
    }
}
