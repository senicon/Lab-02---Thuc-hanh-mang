using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Code_NT106.Q13._1_Lab02_24520592
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public string ID { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public float Course1 { get; set; }
        public float Course2 { get; set; }
        public float Course3 { get; set; }
        public float Average { get; set; }
    }

    public partial class Bai04 : Form
    {
        private List<Student> studentList = new List<Student>();
        private int page = 0;
        private const string JsonFile = "students.json";

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

            if (!Regex.IsMatch(idStr, @"^\d{8}$")) { error = $"MSSV không hợp lệ: {idStr}"; return false; }

            if (!Regex.IsMatch(phone, @"^\d{10}$") || !phone.StartsWith("0")) { error = $"SĐT không hợp lệ: {phone}"; return false; }

            c1s = c1s.Replace(',', '.');
            c2s = c2s.Replace(',', '.');
            c3s = c3s.Replace(',', '.');

            if (!float.TryParse(c1s, NumberStyles.Float, CultureInfo.InvariantCulture, out float c1) || c1 < 0 || c1 > 10) { error = $"Điểm 1 không hợp lệ: {c1s}"; return false; }
            if (!float.TryParse(c2s, NumberStyles.Float, CultureInfo.InvariantCulture, out float c2) || c2 < 0 || c2 > 10) { error = $"Điểm 2 không hợp lệ: {c2s}"; return false; }
            if (!float.TryParse(c3s, NumberStyles.Float, CultureInfo.InvariantCulture, out float c3) || c3 < 0 || c3 > 10) { error = $"Điểm 3 không hợp lệ: {c3s}"; return false; }

            student.Name = name;
            student.ID = idStr;
            student.Phone = phone;
            student.Course1 = c1;
            student.Course2 = c2;
            student.Course3 = c3;
            student.Average = (c1 + c2 + c3) / 3f;
            return true;
        }

        private List<Student> LoadStudentsFromJson()
        {
            try
            {
                if (!File.Exists(JsonFile)) return new List<Student>();
                var json = File.ReadAllText(JsonFile);
                if (string.IsNullOrWhiteSpace(json)) return new List<Student>();
                var list = JsonSerializer.Deserialize<List<Student>>(json);
                return list ?? new List<Student>();
            }
            catch
            {
                return new List<Student>();
            }
        }

        private void SaveStudentsToJson(List<Student> list)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(list, options);
            File.WriteAllText(JsonFile, json, System.Text.Encoding.UTF8);
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
                var list = LoadStudentsFromJson();
                list.Add(student);
                SaveStudentsToJson(list);
                MessageBox.Show("Đã thêm sinh viên vào students.json!", "No Bugs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                var list = LoadStudentsFromJson();
                if (list.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                studentList = list;
                page = 0;
                DisplayStudent(page);
                MessageBox.Show("Đã đọc " + studentList.Count + " sinh viên!", "No Bugs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc dữ liệu: " + ex.Message, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                var list = studentList;
                if (list == null || list.Count == 0)
                {
                    list = LoadStudentsFromJson();
                    if (list.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để xuất!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (var sw = new StreamWriter("output4.txt", false, System.Text.Encoding.UTF8))
                {
                    foreach (var st in list)
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

                MessageBox.Show("Đã xuất output4.txt. Tổng: " + list.Count + " sinh viên", "No Bugs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayStudent(int idx)
        {
            if (studentList == null || studentList.Count == 0) return;
            if (idx < 0 || idx >= studentList.Count) return;

            var st = studentList[idx];
            txtName.Text = st.Name;
            txtID.Text = st.ID;
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
