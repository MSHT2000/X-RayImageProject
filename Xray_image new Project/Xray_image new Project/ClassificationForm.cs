using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xray_image_new_Project
{
    public partial class ClassificationForm : Form
    {

        public bool IsMousDown =false;
        public Point StartPoint;
        public Point EndPoint;
        public Rectangle rect;

        public ClassificationForm()
        {
            InitializeComponent();
            this.pictureBox1.Image = MainForm.instance.Original_Image;
            this.pictureBox1.Size = new Size(256, 256);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                IsMousDown = true;
                StartPoint = e.Location;
            }

        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {

                if (IsMousDown == true)
                {
                    EndPoint = e.Location;

                    Refresh();
                }
            }

        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (IsMousDown == true)
                {
                    EndPoint = e.Location;
                    IsMousDown = false;

                }
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                e.Graphics.DrawRectangle(Pens.Yellow, GetRect());
            }
        }
        public Rectangle GetRect()
        {
            rect = new Rectangle();
            //This ensures that the rectangle starts at the leftmost point between the two coordinates
            rect.X = Math.Min(EndPoint.X, StartPoint.X);
            rect.Y = Math.Min(EndPoint.Y, StartPoint.Y);

            rect.Width = Math.Abs(EndPoint.X - StartPoint.X);
            rect.Height = Math.Abs(EndPoint.Y - StartPoint.Y);

            return rect;


        }

        private void Classification_Images_Button_Click(object sender, EventArgs e)
        {
            {
                    Bitmap grayScale = ConvertToGrayscale((Bitmap)pictureBox1.Image);

                    ClassifyRegion(grayScale);
            }
        }
      
        public void ClassifyRegion(Bitmap region)
        {
            if (rect.X != 0)
            {

                int width = region.Width;
                int height = region.Height;
                int totalPixels = rect.Width * rect.Height;

                // Calculate mean gray value and contrast
                double sumGrayValues = 0;
                double sumGrayValuesSquared = 0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if ((y >= rect.Y && y <= rect.Height + rect.Y) && (x >= rect.X && x <= rect.Width + rect.X))
                        {

                            Color pixelColor = region.GetPixel(x, y);
                            double grayValue = pixelColor.R; // Since it's grayscale, R=G=B
                            sumGrayValues += grayValue;
                            sumGrayValuesSquared += grayValue * grayValue;
                        }
                    }
                }

                double meanGrayValue = sumGrayValues / totalPixels;


                if (meanGrayValue >= 150 && meanGrayValue < 240)
                {
                    MessageBox.Show("meanGrayValue:" + meanGrayValue + "\nSevere Condition..");
                }
                else if (meanGrayValue >= 80 && meanGrayValue < 150)
                {
                    MessageBox.Show("meanGrayValue:" + meanGrayValue + "\nModerate Condition..");
                }
                else if (meanGrayValue >= 20 && meanGrayValue < 80) 
                {
                    MessageBox.Show("meanGrayValue:" + meanGrayValue + "\nMild Condition..");

                }
            }
            else
            {
                MessageBox.Show("You do not specify the area to be classified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap ConvertToGrayscale(Bitmap original)
        {
            // Create a new Bitmap with the same dimensions
            Bitmap grayscale = new Bitmap(original.Width, original.Height);

            // Iterate over each pixel in the original image
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    // Get the color of the pixel
                    Color originalColor = original.GetPixel(x, y);

                    // Calculate luminance (average of R, G, and B components)
                    int luminance = (int)(0.2126 * originalColor.R + 0.7152 * originalColor.G + 0.0722 * originalColor.B);

                    // Set the grayscale value for each channel
                    Color grayscaleColor = Color.FromArgb(luminance, luminance, luminance);

                    // Set the pixel in the grayscale image
                    grayscale.SetPixel(x, y, grayscaleColor);
                }
            }

            return grayscale;
        }

    }
}
