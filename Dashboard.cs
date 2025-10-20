namespace Code_NT106.Q13._1_Lab02_24520592
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void btnBai01_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai01().ShowDialog();
            this.Show();
        }

        private void btnBai2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai02().ShowDialog();
            this.Show();
        }

        private void btnBai3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai03().ShowDialog();
            this.Show();
        }

        private void btnBai4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai04().ShowDialog();
            this.Show();
        }

        private void btnBai5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai05().ShowDialog();
            this.Show();
        }

        private void btnBai6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai06().ShowDialog();
            this.Show();
        }

        private void btnBai7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bai07().ShowDialog();
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
