using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        MedianFilter mf = new MedianFilter();
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void setImage(PictureBox pictureBox, Bitmap image) 
        {
            pictureBox.Width = image.Width;
            pictureBox.Height = image.Height;
            pictureBox.Image = image;
        }

        private void addMedianFilter()
        {
            Bitmap newImage = mf.medianFiltering(image, Convert.ToInt32(numericUpDown1.Value));

            label2.Location = new Point(pictureBoxBefore.Location.X + image.Width + 10, label2.Location.Y);
            pictureBoxAfter.Location = new Point(pictureBoxBefore.Location.X + image.Width + 10, pictureBoxAfter.Location.Y);
            setImage(pictureBoxAfter, newImage);
        }

        private void chooseImage_Click(object sender, EventArgs e)
        {
            string filePath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                image = new Bitmap(filePath);

                setImage(pictureBoxBefore,image);

                addMedianFilter();
            } 
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            buttonOK.Visible = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                addMedianFilter();
            }
            buttonOK.Visible = false;   
        }
    }
}
