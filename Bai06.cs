using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_NT106.Q13._1_Lab02_24520592
{
    public partial class Bai06 : Form
    {
        private const string DbFile = "Foods.db";
        private const string ConnStr = "Data Source=" + DbFile + ";Version=3;";
        private static readonly HttpClient httpClient = new HttpClient();

        public Bai06()
        {
            InitializeComponent();
        }

        private void Bai06_Load(object sender, EventArgs e)
        {
            try
            {
                EnsureDatabase();
                LoadDataToListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo: " + ex.Message, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnsureDatabase()
        {
            if (!File.Exists(DbFile)) SQLiteConnection.CreateFile(DbFile);
            using var conn = new SQLiteConnection(ConnStr);
            conn.Open();

            string createUser = @"
                CREATE TABLE IF NOT EXISTS NguoiDung (
                    IDNCC INTEGER PRIMARY KEY AUTOINCREMENT,
                    HoVaTen TEXT NOT NULL,
                    QuyenHan TEXT DEFAULT 'User'
                )";
            string createFood = @"
                CREATE TABLE IF NOT EXISTS MonAn (
                    IDMA INTEGER PRIMARY KEY AUTOINCREMENT,
                    TenMonAn TEXT NOT NULL,
                    HinhAnh TEXT,
                    IDNCC INTEGER,
                    FOREIGN KEY (IDNCC) REFERENCES NguoiDung(IDNCC)
                )";

            using var c1 = new SQLiteCommand(createUser, conn); c1.ExecuteNonQuery();
            using var c2 = new SQLiteCommand(createFood, conn); c2.ExecuteNonQuery();

            SeedDefaultData(conn);
        }

        private void SeedDefaultData(SQLiteConnection conn)
        {
            using var chk = new SQLiteCommand("SELECT COUNT(*) FROM MonAn", conn);
            long cnt = (long)chk.ExecuteScalar();
            if (cnt > 0) return;

            string[] users = { "Huỳnh Vũ Khánh Hưng", "test1", "test2" };
            foreach (var u in users)
            {
                using var iu = new SQLiteCommand("INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES (@n, 'User')", conn);
                iu.Parameters.AddWithValue("@n", u);
                iu.ExecuteNonQuery();
            }

            string[][] foods = new[]
            {
                new[] { "Phở", "https://img-cache.coccoc.com/image2?i=2&l=24/330530921", "1" },
                new[] { "Bún bò Huế", "https://img-cache.coccoc.com/image2?i=1&l=2/332224531", "2" },
                new[] { "Cơm tấm", "https://img-cache.coccoc.com/image2?i=1&l=79/132313775", "3" },
            };

            foreach (var f in foods)
            {
                using var ifood = new SQLiteCommand("INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES (@t, @h, @id)", conn);
                ifood.Parameters.AddWithValue("@t", f[0]);
                ifood.Parameters.AddWithValue("@h", f[1]);
                ifood.Parameters.AddWithValue("@id", f[2]);
                ifood.ExecuteNonQuery();
            }
        }

        private void LoadDataToListView()
        {
            try
            {
                listViewMonAn.Items.Clear();
                using var conn = new SQLiteConnection(ConnStr);
                conn.Open();

                string q = @"
                    SELECT m.IDMA, m.TenMonAn, m.HinhAnh, n.HoVaTen
                    FROM MonAn m
                    LEFT JOIN NguoiDung n ON m.IDNCC = n.IDNCC
                    ORDER BY m.IDMA";
                using var cmd = new SQLiteCommand(q, conn);
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var id = r["IDMA"]?.ToString() ?? "";
                    var ten = r["TenMonAn"]?.ToString() ?? "";
                    var img = r["HinhAnh"]?.ToString() ?? "";
                    var nguoi = r["HoVaTen"]?.ToString() ?? "";
                    var it = new ListViewItem(id);
                    it.SubItems.Add(ten);
                    it.SubItems.Add(img);
                    it.SubItems.Add(nguoi);
                    listViewMonAn.Items.Add(it);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool IsImageUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return false;
            try
            {
                var uri = new Uri(url);
                var ext = Path.GetExtension(uri.AbsolutePath).ToLowerInvariant();
                return ext switch { ".jpg" or ".jpeg" or ".png" or ".gif" or ".bmp" or ".webp" => true, _ => false };
            }
            catch { return false; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoVaTen = txtHoVaTen.Text.Trim();
            string tenMon = txtTenMonAn.Text.Trim();
            string hinh = txtHinhAnh.Text.Trim();

            if (string.IsNullOrEmpty(hoVaTen) || string.IsNullOrEmpty(tenMon))
            {
                MessageBox.Show("Vui lòng nhập họ tên và tên món!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(hinh) && !IsImageUrl(hinh))
            {
                MessageBox.Show("URL không hợp lệ (phải kết thúc .jpg/.png/...).", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = new SQLiteConnection(ConnStr);
                conn.Open();

                int idncc = 0;
                using (var chk = new SQLiteCommand("SELECT IDNCC FROM NguoiDung WHERE HoVaTen = @n", conn))
                {
                    chk.Parameters.AddWithValue("@n", hoVaTen);
                    var v = chk.ExecuteScalar();
                    if (v != null) idncc = Convert.ToInt32(v);
                }

                if (idncc == 0)
                {
                    using var iu = new SQLiteCommand("INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES (@n, 'User'); SELECT last_insert_rowid()", conn);
                    iu.Parameters.AddWithValue("@n", hoVaTen);
                    idncc = Convert.ToInt32(iu.ExecuteScalar());
                }

                using var ins = new SQLiteCommand("INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES (@t, @h, @id)", conn);
                ins.Parameters.AddWithValue("@t", tenMon);
                ins.Parameters.AddWithValue("@h", string.IsNullOrEmpty(hinh) ? "" : hinh);
                ins.Parameters.AddWithValue("@id", idncc);
                ins.ExecuteNonQuery();

                MessageBox.Show("Thêm món ăn thành công!", "No Bugs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoVaTen.Clear();
                txtTenMonAn.Clear();
                txtHinhAnh.Clear();
                LoadDataToListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm món: " + ex.Message, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnTimMonAn_Click(object sender, EventArgs e)
        {
            try
            {
                using var conn = new SQLiteConnection(ConnStr);
                conn.Open();
                using var c = new SQLiteCommand("SELECT COUNT(*) FROM MonAn", conn);
                int count = Convert.ToInt32(c.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("Chưa có món ăn trong database!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var cmd = new SQLiteCommand(@"
                    SELECT TenMonAn, HinhAnh, n.HoVaTen
                    FROM MonAn m
                    LEFT JOIN NguoiDung n ON m.IDNCC = n.IDNCC
                    ORDER BY RANDOM() LIMIT 1", conn);
                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    var ten = r["TenMonAn"]?.ToString() ?? "";
                    var hinh = r["HinhAnh"]?.ToString() ?? "";
                    var nguoi = r["HoVaTen"]?.ToString() ?? "";
                    lblKetQua.Text = $"{ten}\r\n\r\n(Đóng góp bởi: {nguoi})";
                    if (!string.IsNullOrEmpty(hinh) && IsImageUrl(hinh))
                    {
                        await LoadImageFromUrlAsync(hinh);
                    }
                    else
                    {
                        pictureBoxMonAn.Image?.Dispose();
                        pictureBoxMonAn.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm món: " + ex.Message, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadImageFromUrlAsync(string url)
        {
            try
            {
                var bytes = await httpClient.GetByteArrayAsync(url);
                using var ms = new MemoryStream(bytes);
                var img = Image.FromStream(ms);
                pictureBoxMonAn.Image?.Dispose();
                pictureBoxMonAn.Image = (Image)img.Clone();
            }
            catch
            {
                pictureBoxMonAn.Image?.Dispose();
                pictureBoxMonAn.Image = null;
                MessageBox.Show("Không thể tải hình ảnh từ URL!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc muốn xóa toàn bộ dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;

            try
            {
                using var conn = new SQLiteConnection(ConnStr);
                conn.Open();
                using var t1 = new SQLiteCommand("DELETE FROM MonAn", conn); t1.ExecuteNonQuery();
                using var t2 = new SQLiteCommand("DELETE FROM NguoiDung", conn); t2.ExecuteNonQuery();
                using var r1 = new SQLiteCommand("DELETE FROM sqlite_sequence WHERE name='MonAn'", conn); r1.ExecuteNonQuery();
                using var r2 = new SQLiteCommand("DELETE FROM sqlite_sequence WHERE name='NguoiDung'", conn); r2.ExecuteNonQuery();
                SeedDefaultData(conn);
                LoadDataToListView();
                lblKetQua.Text = "";
                pictureBoxMonAn.Image?.Dispose();
                pictureBoxMonAn.Image = null;
                MessageBox.Show("Đã xóa và khôi phục dữ liệu mẫu!", "No Bugs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e) => Close();
    }
}
