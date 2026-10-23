using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Libs.TagLib;

namespace Xray_image_new_Project
{
    public partial class CommentForm : Form
    {
        bool is_MouseDown = false;
        Point StartPoint;
        Bitmap OriginalImage;

        public CommentForm()
        {
            InitializeComponent();
            pictureBox1.Size = new Size(256,256);
            pictureBox1.Image=MainForm.instance.pictureBox1.Image;

            StartPoint.X = pictureBox1.Width/2;
            StartPoint.Y= pictureBox1.Height/2;
            
        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            OriginalImage = new Bitmap(MainForm.instance.pictureBox1.Image);
            pictureBox1.Image = OriginalImage;
           pictureBox1.Image = InsertTextintoImage(OriginalImage, textBox1.Text, StartPoint);
          
        }

        public Bitmap InsertTextintoImage(Bitmap image, string text,Point CommentLocation)
        {
            Point firstLocation = CommentLocation;
           
            using (Graphics graphics = Graphics.FromImage(image))
            {
                using (Font arialFont = new Font("Verdana",7,FontStyle.Bold))
                {
                    graphics.DrawString(text.ToUpper(), arialFont, Brushes.Red, firstLocation);
                    
                    
                }
            }
            return  new Bitmap(image);

        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                is_MouseDown = true;
                StartPoint = e.Location;
                is_MouseDown = false;

            }
        }

        private void Done_Button_Click(object sender, EventArgs e)
        {
            MainForm.instance.pictureBox1.Image = pictureBox1.Image;
            this.Close();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            MainForm.instance.Save(sender, e, pictureBox1);
        }
    }
}
