using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Code_NT106.Q13._1_Lab02_24520592
{
    public struct Student
    {
        public string Name;
        public int ID;
        public string Phone;
        public float Course1;
        public float Course2;
        public float Course3;
        public float Average;
    }

    public partial class Bai04 : Form
    {
        private List<Student> studentList = new List<Student>();
        private int page = 0;

        public Bai04()
        {
            InitializeComponent();
        }

        private bool ParseStudentFromLines(string[] lines, int startIndex, out Student student, out string error)
        {
            student = new Student();
            error = null;

            if (startIndex + 5 >= lines.Length)
            {
                error = "Dữ liệu không đủ cho một sinh viên.";
                return false;
            }

            string name = lines[startIndex].Trim();
            string idStr = lines[startIndex + 1].Trim();
            string phone = lines[startIndex + 2].Trim();
            string c1s = lines[startIndex + 3].Trim();
            string c2s = lines[startIndex + 4].Trim();
            string c3s = lines[startIndex + 5].Trim();

            if (string.IsNullOrWhiteSpace(name)) { error = "Tên rỗng."; return false; }

            if (!int.TryParse(idStr, out int id) || idStr.Length != 8) { error = $"MSSV không hợp lệ: {idStr}"; return false; }

            if (phone.Length != 10 || !phone.StartsWith("0")) { error = $"SĐT không hợp lệ: {phone}"; return false; }

            if (!float.TryParse(c1s, NumberStyles.Float, CultureInfo.InvariantCulture, out float c1) || c1 < 0 || c1 > 10) { error = $"Điểm 1 không hợp lệ: {c1s}"; return false; }
            if (!float.TryParse(c2s, NumberStyles.Float, CultureInfo.InvariantCulture, out float c2) || c2 < 0 || c2 > 10) { error = $"Điểm 2 không hợp lệ: {c2s}"; return false; }
            if (!float.TryParse(c3s, NumberStyles.Float, CultureInfo.InvariantCulture, out float c3) || c3 < 0 || c3 > 10) { error = $"Điểm 3 không hợp lệ: {c3s}"; return false; }

            student.Name = name;
            student.ID = id;
            student.Phone = phone;
            student.Course1 = c1;
            student.Course2 = c2;
            student.Course3 = c3;
            student.Average = (c1 + c2 + c3) / 3f;
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text?.Trim();
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Vui lòng nhập thông tin sinh viên!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            if (lines.Length < 6)
            {
                MessageBox.Show("Cần 6 dòng: Tên, MSSV, SĐT, Điểm1, Điểm2, Điểm3", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ParseStudentFromLines(lines, 0, out Student student, out string error))
            {
                MessageBox.Show(error, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var sw = new StreamWriter("input4.txt", true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(student.Name);
                    sw.WriteLine(student.ID);
                    sw.WriteLine(student.Phone);
                    sw.WriteLine(student.Course1.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine(student.Course2.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine(student.Course3.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine();
                }

                MessageBox.Show("Đã thêm sinh viên vào input4.txt!", "No Bugs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (!File.Exists("input4.txt"))
            {
                MessageBox.Show("Không tìm thấy file input4.txt!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] lines = File.ReadAllLines("input4.txt");
            var temp = new List<Student>();
            int i = 0;

            while (i < lines.Length)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) { i++; continue; }

                if (!ParseStudentFromLines(lines, i, out Student s, out string err))
                {
                    MessageBox.Show($"Lỗi tại dòng {i + 1}: {err}", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                temp.Add(s);
                i += 7; // 6 data lines + 1 blank separator (or move to next non-empty)
            }

            try
            {
                using (var sw = new StreamWriter("output4.txt", false, System.Text.Encoding.UTF8))
                {
                    foreach (var st in temp)
                    {
                        sw.WriteLine(st.Name);
                        sw.WriteLine(st.ID);
                        sw.WriteLine(st.Phone);
                        sw.WriteLine(st.Course1.ToString("F2", CultureInfo.InvariantCulture));
                        sw.WriteLine(st.Course2.ToString("F2", CultureInfo.InvariantCulture));
                        sw.WriteLine(st.Course3.ToString("F2", CultureInfo.InvariantCulture));
                        sw.WriteLine(st.Average.ToString("F2", CultureInfo.InvariantCulture));
                        sw.WriteLine();
                    }
                }

                MessageBox.Show("Đã tính điểm TB và ghi vào output4.txt. Tổng: " + temp.Count + " sinh viên", "No Bugs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (!File.Exists("input4.txt"))
            {
                MessageBox.Show("Không tìm thấy file input4.txt!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] lines = File.ReadAllLines("input4.txt");
            if (lines.Length == 0)
            {
                MessageBox.Show("File input4.txt rỗng!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            studentList.Clear();
            int i = 0;
            while (i < lines.Length)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) { i++; continue; }

                if (!ParseStudentFromLines(lines, i, out Student s, out string err))
                {
                    MessageBox.Show($"Lỗi tại dòng {i + 1}: {err}", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                studentList.Add(s);
                i += 7;
            }

            if (studentList.Count > 0)
            {
                page = 0;
                DisplayStudent(page);
            }

            MessageBox.Show("Đã đọc " + studentList.Count + " sinh viên!", "No Bugs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DisplayStudent(int idx)
        {
            if (studentList == null || studentList.Count == 0) return;
            if (idx < 0 || idx >= studentList.Count) return;

            var st = studentList[idx];
            txtName.Text = st.Name;
            txtID.Text = st.ID.ToString();
            txtPhone.Text = st.Phone;
            txtCourse1.Text = st.Course1.ToString("F2", CultureInfo.InvariantCulture);
            txtCourse2.Text = st.Course2.ToString("F2", CultureInfo.InvariantCulture);
            txtCourse3.Text = st.Course3.ToString("F2", CultureInfo.InvariantCulture);
            txtAverage.Text = st.Average.ToString("F2", CultureInfo.InvariantCulture);
            lblPage.Text = (idx + 1).ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (studentList == null || studentList.Count == 0) { MessageBox.Show("Chưa có dữ liệu!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (page > 0) { page--; DisplayStudent(page); }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (studentList == null || studentList.Count == 0) { MessageBox.Show("Chưa có dữ liệu!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (page < studentList.Count - 1) { page++; DisplayStudent(page); }
        }

        private void Bai04_Load(object sender, EventArgs e) { }
    }
}
