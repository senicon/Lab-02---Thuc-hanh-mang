using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Code_NT106.Q13._1_Lab02_24520592
{
    public partial class Bai05 : Form
    {
        private class MovieInfo
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public List<int> Rooms { get; set; }
            public int TotalSeats { get; set; }
            public int SoldSeats { get; set; }
            public decimal Revenue { get; set; }
            public int RemainingSeats => TotalSeats - SoldSeats;
            public decimal SalesPercentage => TotalSeats > 0 ? (decimal)SoldSeats / TotalSeats * 100 : 0;
        }

        private readonly Dictionary<string, MovieInfo> movies = new();
        private readonly Dictionary<string, decimal> seatMultipliers = new();
        private readonly Dictionary<string, bool> bookedSeats = new();
        private readonly Dictionary<string, Button> seatButtons = new();
        private readonly List<string> selectedSeats = new();
        private int currentRoom = 0;
        private const int SEATS_PER_ROOM = 188;

        public Bai05()
        {
            InitializeComponent();
            InitMultipliers();
        }

        private void InitMultipliers()
        {
            string[] discount = { "A1", "A5", "C1", "C5" };
            foreach (var s in discount) seatMultipliers[s] = 0.25m;

            string[] normal = { "A2", "A3", "A4", "C2", "C3", "C4" };
            foreach (var s in normal) seatMultipliers[s] = 1m;

            string[] vip = { "B2", "B3", "B4" };
            foreach (var s in vip) seatMultipliers[s] = 2m;

            string[] couple = { "M1+2", "M3+4", "M5+6", "M7+8", "M9+10", "M11+12" };
            foreach (var s in couple) seatMultipliers[s] = 2m;
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            string path = "input5.txt";
            if (!File.Exists(path))
            {
                MessageBox.Show("File input5.txt không tồn tại!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                movies.Clear();
                bookedSeats.Clear();

                var lines = File.ReadAllLines(path, Encoding.UTF8);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split('|');
                    if (parts.Length < 3) throw new Exception("Dữ liệu bị thiếu.");

                    var name = parts[0].Trim();
                    if (!decimal.TryParse(parts[1].Trim(), out decimal price) || price <= 0) throw new Exception("Giá sai.");
                    var rooms = parts[2].Split(',').Select(x => int.Parse(x.Trim())).ToList();

                    var info = new MovieInfo
                    {
                        Name = name,
                        Price = price,
                        Rooms = rooms,
                        TotalSeats = rooms.Count * SEATS_PER_ROOM,
                        SoldSeats = 0,
                        Revenue = 0
                    };
                    movies[name] = info;

                    if (parts.Length > 3 && !string.IsNullOrWhiteSpace(parts[3]))
                    {
                        var bookings = parts[3].Split(';');
                        foreach (var b in bookings)
                        {
                            if (string.IsNullOrWhiteSpace(b)) continue;
                            var bp = b.Split(':');
                            if (bp.Length != 2) continue;
                            var room = int.Parse(bp[0].Trim());
                            var seats = bp[1].Split(',').Select(s => s.Trim());
                            foreach (var s in seats) bookedSeats[$"{room}_{s}"] = true;
                        }
                    }

                    foreach (var r in rooms) InitSeatsForRoom(r);
                }

                UpdateMovieCombo();
                MessageBox.Show("Đọc file thành công!", "No Bugs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file: " + ex.Message, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitSeatsForRoom(int room)
        {
            char[] rows = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M' };
            foreach (var r in rows)
            {
                if (r == 'M')
                {
                    string[] couple = { "M1+2", "M3+4", "M5+6", "M7+8", "M9+10", "M11+12" };
                    foreach (var s in couple) bookedSeats.TryAdd($"{room}_{s}", false);
                }
                else
                {
                    for (int c = 1; c <= 14; c++) bookedSeats.TryAdd($"{room}_{r}{c}", false);
                }
            }
        }

        private void UpdateMovieCombo()
        {
            cmbMovie.Items.Clear();
            foreach (var k in movies.Keys) cmbMovie.Items.Add(k);
        }

        private void cmbMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbRoom.Items.Clear();
            if (cmbMovie.SelectedItem == null) return;
            var name = cmbMovie.SelectedItem.ToString();
            if (!movies.ContainsKey(name)) return;
            foreach (var r in movies[name].Rooms) cmbRoom.Items.Add(r);
            cmbRoom.Enabled = true;
            panelSeats.Visible = false;
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoom.SelectedItem == null) return;
            currentRoom = Convert.ToInt32(cmbRoom.SelectedItem);
            selectedSeats.Clear();
            CreateSeatLayout();
            panelSeats.Visible = true;
        }

        private void CreateSeatLayout()
        {
            panelSeats.Controls.Clear();
            seatButtons.Clear();

            int startX = 50, startY = 80, w = 35, h = 30, sx = 40, sy = 35;
            char[] rows = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M' };

            var screen = new Label { Text = "Screen", Location = new Point(startX + 200, 10), Size = new Size(200, 30), Font = new Font("Arial", 14, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.LightGray };
            panelSeats.Controls.Add(screen);

            for (int i = 0; i < rows.Length; i++)
            {
                var row = rows[i];
                var rowLabel = new Label { Text = row.ToString(), Location = new Point(20, startY + i * sy + 5), Size = new Size(20, 20), Font = new Font("Arial", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
                panelSeats.Controls.Add(rowLabel);

                if (row == 'M')
                {
                    string[] couples = { "1+2", "3+4", "5+6", "7+8", "9+10", "11+12" };
                    for (int j = 0; j < couples.Length; j++)
                    {
                        string seatName = $"M{couples[j]}";
                        string key = $"{currentRoom}_{seatName}";
                        var btn = new Button { Text = couples[j], Location = new Point(startX + j * sx * 2 + (j * 10), startY + i * sy), Size = new Size(w * 2 + 10, h), Font = new Font("Arial", 8, FontStyle.Bold), Tag = key, FlatStyle = FlatStyle.Flat };
                        ApplySeatStyle(btn, seatName, key);
                        btn.Click += Seat_Click;
                        seatButtons[key] = btn;
                        panelSeats.Controls.Add(btn);
                    }
                }
                else
                {
                    for (int col = 1; col <= 14; col++)
                    {
                        string seatName = $"{row}{col}";
                        string key = $"{currentRoom}_{seatName}";
                        var btn = new Button { Text = col.ToString(), Location = new Point(startX + (col - 1) * sx, startY + i * sy), Size = new Size(w, h), Font = new Font("Arial", 8), Tag = key, FlatStyle = FlatStyle.Flat };
                        ApplySeatStyle(btn, seatName, key);
                        btn.Click += Seat_Click;
                        seatButtons[key] = btn;
                        panelSeats.Controls.Add(btn);
                    }
                }
            }
        }

        private void ApplySeatStyle(Button btn, string seatName, string key)
        {
            if (bookedSeats.TryGetValue(key, out bool booked) && booked)
            {
                btn.BackColor = Color.DarkGray;
                btn.ForeColor = Color.White;
                btn.Enabled = false;
                return;
            }

            if (selectedSeats.Contains(seatName))
            {
                btn.BackColor = Color.Orange;
                btn.ForeColor = Color.Black;
                return;
            }

            char r = seatName[0];
            if (r == 'A' || r == 'B' || r == 'C')
            {
                btn.BackColor = Color.Gray;
                btn.ForeColor = Color.White;
                btn.Enabled = false;
                return;
            }

            if (r == 'M')
            {
                btn.BackColor = Color.DodgerBlue;
                btn.ForeColor = Color.White;
                btn.Enabled = true;
                return;
            }

            if (r == 'F' || r == 'G' || r == 'I')
            {
                int col = int.Parse(seatName.Substring(1));
                if ((r == 'F' || r == 'G') && (col == 7 || col == 8) || (r == 'I' && col >= 5 && col <= 10))
                {
                    btn.BackColor = Color.Orange;
                    btn.ForeColor = Color.Black;
                    return;
                }
            }

            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.Enabled = true;
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var key = (string)btn.Tag;
            var parts = key.Split('_');
            string seatName = parts[1];

            if (bookedSeats.TryGetValue(key, out bool booked) && booked)
            {
                MessageBox.Show("Ghế này đã được đặt!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedSeats.Contains(seatName)) selectedSeats.Remove(seatName);
            else selectedSeats.Add(seatName);

            ApplySeatStyle(btn, seatName, key);
            txtSelectedSeats.Text = string.Join(", ", selectedSeats);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMovie.SelectedItem == null || cmbRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phim và phòng!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string customer = txtCustomerName.Text.Trim();
            string movieName = cmbMovie.SelectedItem.ToString();
            decimal basePrice = movies[movieName].Price;
            decimal total = 0m;

            foreach (var seat in selectedSeats)
            {
                decimal mult = seatMultipliers.ContainsKey(seat) ? seatMultipliers[seat] : 1m;
                total += basePrice * mult;
                bookedSeats[$"{currentRoom}_{seat}"] = true;
            }

            var receipt = new StringBuilder();
            receipt.AppendLine($"Họ và tên: {customer}");
            receipt.AppendLine($"Phim: {movieName}");
            receipt.AppendLine($"Phòng: {currentRoom}");
            receipt.AppendLine($"Ghế: {string.Join(", ", selectedSeats)}");
            receipt.AppendLine($"Tổng: {total:N0}đ");

            txtResult.Text = receipt.ToString();
            MessageBox.Show("Đặt vé thành công!", "No Bugs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            selectedSeats.Clear();
            CreateSeatLayout();
            txtSelectedSeats.Clear();
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            if (movies.Count == 0)
            {
                MessageBox.Show("Vui lòng đọc dữ liệu trước!", "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ExportReport("output5.txt");
                MessageBox.Show("Xuất báo cáo thành công!", "No Bugs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất báo cáo: " + ex.Message, "Error 404 NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportReport(string filePath)
        {
            var snapshot = movies.Values.Select(m => new MovieInfo
            {
                Name = m.Name,
                Price = m.Price,
                Rooms = new List<int>(m.Rooms),
                TotalSeats = m.TotalSeats,
                SoldSeats = 0,
                Revenue = 0
            }).ToList();

            for (int idx = 0; idx < snapshot.Count; idx++)
            {
                var m = snapshot[idx];
                foreach (var room in m.Rooms)
                {
                    char[] rows = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M' };
                    foreach (var r in rows)
                    {
                        if (r == 'M')
                        {
                            string[] couples = { "M1+2", "M3+4", "M5+6", "M7+8", "M9+10", "M11+12" };
                            foreach (var s in couples)
                            {
                                if (bookedSeats.TryGetValue($"{room}_{s}", out bool b) && b)
                                {
                                    m.SoldSeats++;
                                    m.Revenue += m.Price * (seatMultipliers.ContainsKey(s) ? seatMultipliers[s] : 1m);
                                }
                            }
                        }
                        else
                        {
                            for (int c = 1; c <= 14; c++)
                            {
                                string sName = $"{r}{c}";
                                if (bookedSeats.TryGetValue($"{room}_{sName}", out bool b) && b)
                                {
                                    m.SoldSeats++;
                                    m.Revenue += m.Price * (seatMultipliers.ContainsKey(sName) ? seatMultipliers[sName] : 1m);
                                }
                            }
                        }
                    }
                }

                int progress = (idx + 1) * 100 / Math.Max(1, snapshot.Count);
                progressBar.Value = progress;
                lblProgress.Text = $"Đang xuất: {progress}%";
                Application.DoEvents();
            }

            var sorted = snapshot.OrderByDescending(x => x.Revenue).ToList();

            using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.WriteLine(new string('=', 100));
                sw.WriteLine("THỐNG KÊ PHÒNG VÉ".PadLeft(60));
                sw.WriteLine(new string('=', 100));
                sw.WriteLine();
                sw.WriteLine($"{"Xếp hạng",-12}{"Tên phim",-30}{"Vé bán",-12}{"Vé tồn",-12}{"Tỉ lệ (%)",-12}{"Doanh thu (VNĐ)",-20}");
                sw.WriteLine(new string('-', 100));
                for (int i = 0; i < sorted.Count; i++)
                {
                    var mv = sorted[i];
                    sw.WriteLine($"{(i + 1),-12}{mv.Name,-30}{mv.SoldSeats,-12}{mv.RemainingSeats,-12}{mv.SalesPercentage,-12:F2}{mv.Revenue,-20:N0}");
                }
                sw.WriteLine(new string('-', 100));
                sw.WriteLine();
                sw.WriteLine($"Tổng doanh thu: {sorted.Sum(x => x.Revenue):N0} VNĐ");
                sw.WriteLine($"Tổng vé bán ra: {sorted.Sum(x => x.SoldSeats)}");
                sw.WriteLine(new string('=', 100));
            }

            progressBar.Value = 100;
            lblProgress.Text = "Hoàn tất";
            Application.DoEvents();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCustomerName.Clear();
            cmbMovie.SelectedIndex = -1;
            cmbRoom.Items.Clear();
            cmbRoom.Enabled = false;
            txtResult.Clear();
            txtSelectedSeats.Clear();
            selectedSeats.Clear();
            panelSeats.Visible = false;
            panelSeats.Controls.Clear();
            progressBar.Value = 0;
            lblProgress.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Bai05_Load(object sender, EventArgs e) { }
    }
}
