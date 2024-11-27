using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcess2;

namespace coins_counting_act
{
    public partial class Form1 : Form
    {
        Bitmap orig, processed;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            orig = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = orig;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (orig == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            processed = (Bitmap)orig.Clone();
            bool success;

            success = BitmapFilter.GaussianBlur(processed, 4);
            processed = BitmapFilter.ApplyThreshold(processed, 170);
            success = BitmapFilter.EdgeDetectHomogenity(processed, 60);
            pictureBox2.Image = processed;
            int coinCount = BitmapFilter.CountCoins(processed);
            label1.Text = $"Total Coins: {coinCount}";
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
