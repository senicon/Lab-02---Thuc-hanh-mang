using System;
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
    public partial class Bai02 : Form
    {
        public Bai02()
        {
            InitializeComponent();
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLineCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtWordsCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCharacterCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string url = ofd.FileName;
                if (!url.EndsWith(".txt"))
                {
                    MessageBox.Show("Vui lòng chọn file có đuôi .txt");
                    return;
                }
                txtURL.Text = url;
                string filename = ofd.SafeFileName;
                txtFileName.Text = filename;
                FileInfo size = new FileInfo(url);
                txtSize.Text = size.Length + " bytes";
                int LineCount = File.ReadAllLines(url).Length;
                txtLineCount.Text = LineCount.ToString();
                int WordsCount = File.ReadAllText(url).Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                txtWordsCount.Text = WordsCount.ToString();
                int CharacterCount = File.ReadAllText(url).Length;
                txtCharacterCount.Text = CharacterCount.ToString();
                StreamReader read = new StreamReader(url);
                txtShow.Text = read.ReadToEnd();
                read.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtShow_TextChanged(object sender, EventArgs e)
        {

        }

        private void Bai02_Load(object sender, EventArgs e)
        {

        }
    }
}
