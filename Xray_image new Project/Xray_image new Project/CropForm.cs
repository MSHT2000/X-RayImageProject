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

namespace Xray_image_new_Project
{
    public partial class CropForm : Form
    {

        public bool IsMousDown = false;
        public Point StartPoint;
        public Point EndPoint;
        public Rectangle rect;

        public CropForm()
        {
            InitializeComponent();
            this.pictureBox1.Size = this.pictureBox2.Size= new Size(256,256);
            this.pictureBox1.Image = MainForm.instance.pictureBox1.Image;
        }

        private void Crop_Button_Click(object sender, EventArgs e)
        {
            Bitmap FullImage = (Bitmap)pictureBox1.Image;

            BitmapData bitmapData = FullImage.LockBits(rect,
            ImageLockMode.ReadWrite, FullImage.PixelFormat);
            // pixel manipulation (Do something)
            // Unlock the bitmap
            FullImage.UnlockBits(bitmapData);

            Bitmap Crop_Image = new Bitmap(
                                           bitmapData.Width
                                          , bitmapData.Height
                                          , bitmapData.Stride
                                          , FullImage.PixelFormat
                                          , bitmapData.Scan0
                                          );
            //pictureBox2.Size = new Size(Crop_Image.Width, Crop_Image.Height);

            Bitmap resizeCropImage = new Bitmap(Crop_Image, Int16.Parse("256"), Int16.Parse("256"));
            pictureBox2.Image =resizeCropImage;
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
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                e.Graphics.DrawRectangle(Pens.Yellow, GetRect());
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
            MainForm.instance.Save(sender, e, pictureBox2);
            }
            else
            {
                MessageBox.Show
                    (
                    "Message Cropped not Found !!!"
                    , "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error
                    );
            }
        }

        
    }
}