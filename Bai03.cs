using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Code_NT106.Q13._1_Lab02_24520592
{
    public partial class Bai03 : Form
    {
        public Bai03()
        {
            InitializeComponent();
        }

        private bool IsValidExpression(string s)
        {
            return Regex.IsMatch(s ?? "", @"^[0-9\.\+\-\*\/\(\)\s]+$");
        }

        private bool TryCalculate(string expr, out string? result)
        {
            result = null;

            if (string.IsNullOrWhiteSpace(expr))
            {
                result = "Biểu thức rỗng";
                return false;
            }

            if (!IsValidExpression(expr))
            {
                result = "Chứa ký tự không hợp lệ";
                return false;
            }

            try
            {
                var table = new DataTable();
                var value = table.Compute(expr.Replace(',', '.'), null);
                result = value?.ToString()!;
                return true;
            }
            catch
            {
                result = "Cú pháp không hợp lệ";
                return false;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (!File.Exists("input3.txt"))
            {
                MessageBox.Show("Không tìm thấy file input3.txt", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lines = File.ReadAllLines("input3.txt", Encoding.UTF8);
            if (lines.Length == 0)
            {
                MessageBox.Show("File input3.txt rỗng", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtShow.Clear();
            var results = new List<string>();
            int errors = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                string output;

                if (string.IsNullOrEmpty(line))
                {
                    output = "Dòng " + (i + 1) + ": (rỗng)";
                }
                else if (TryCalculate(line, out string? res))
                {
                    output = "Dòng " + (i + 1) + ": " + line + " = " + res;
                }
                else
                {
                    output = "Dòng " + (i + 1) + ": " + line + " - Lỗi: " + res;
                    errors++;
                }

                txtShow.AppendText(output + Environment.NewLine);
                results.Add(output);
            }

            File.WriteAllLines("output3.txt", results, Encoding.UTF8);

            if (errors == 0)
            {
                MessageBox.Show("Đã xử lý xong. Kết quả đã ghi vào output3.txt", "No Bugs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đã xử lý xong với " + errors + " lỗi. Xem file output3.txt", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
