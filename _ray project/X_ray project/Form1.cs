using Emgu.CV.Reg;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_ray_project
{
    public partial class Form1 : Form
    {

        Point locationXY;
        Point locationX1Y1;
        private string image_path;
        private Rectangle rect;
        private bool is_mouseDown = false;



        public Form1()
        {

            InitializeComponent();
        }
        //convert upload image to GrayScale
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


        private void open_image_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            //decliration image's forms

            ofd.Filter =
                "JPEG Image|*.jpeg" +
                "|JPG Image|*.jpg" +
                "|PNG Image|*.png" +
                "|Bitmap Image|*.bmp" +
                "|RAW Image|*.raw" +
                "|PSD Image|*.psd" +
                "|EPS Image|*.eps" +
                "|GIF Image|*.gif" +
                "|ICO Image|*.ico" +
                "|AI Image|*.ai" +
                "|SVG Image|*.svg" +
                "|TIF Image|*.tif" +
                "|CDR Image|*.cdr" +
                "|All Files|*.*";

            // open upload windows
            if (DialogResult.OK == ofd.ShowDialog())
            {


                pictureBox3.Image = new Bitmap(ofd.FileName);


            }

            image_path = ofd.FileName;
            //display crosshair on image box
            pictureBox3.Cursor = Cursors.Hand;
        }

        private void Save_image_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter =
               "JPEG Image|*.jpeg" +
               "|JPG Image|*.jpg" +
               "|PNG Image|*.png" +
               "|Bitmap Image|*.bmp" +
               "|RAW Image|*.raw" +
               "|PSD Image|*.psd" +
               "|EPS Image|*.eps" +
               "|GIF Image|*.gif" +
               "|ICO Image|*.ico" +
               "|AI Image|*.ai" +
               "|SVG Image|*.svg" +
               "|TIF Image|*.tif" +
               "|CDR Image|*.cdr" +
               "|All Files|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image.Save(sfd.FileName);
            }

        }


        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            //if (is_mouseDown == true)
            //{
            //    locationX1Y1 = e.Location;
            //    is_mouseDown = false;

            //}
            is_mouseDown = true;
            locationX1Y1 = e.Location;

        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {

            //is_mouseDown = true;
            //locationX1Y1 = e.Location;

            if (is_mouseDown == true)
            {
                locationXY = e.Location;
                is_mouseDown = false;

            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_mouseDown == true)
            {
                locationXY = e.Location;

                Refresh();
            }

        }

        private void pictureBox_DrawRectangel(object sender, PaintEventArgs e)
        {


            e.Graphics.DrawRectangle(Pens.Yellow, GetRect());



        }

        private Rectangle GetRect()
        {
            rect = new Rectangle();
            //This ensures that the rectangle starts at the leftmost point between the two coordinates
            rect.X = Math.Min(locationXY.X, locationX1Y1.X);
            rect.Y = Math.Min(locationXY.Y, locationX1Y1.Y);

            rect.Width = Math.Abs(locationXY.X - locationX1Y1.X);
            rect.Height = Math.Abs(locationXY.Y - locationX1Y1.Y);

            return rect;


        }



        public Bitmap ApplyHeatmap(Bitmap grayscaleImage)
        {
            // Create a new bitmap with the same dimensions as the original grayscale image

            for (int x = 0; x < grayscaleImage.Width; x++)
            {
                for (int y = 0; y < grayscaleImage.Height; y++)
                {

                    if ((y >= rect.Y && y <= rect.Height + rect.Y) && (x >= rect.X && x <= rect.Width + rect.X))
                    {

                        // Get the grayscale value from the original image
                        Color grayColor = grayscaleImage.GetPixel(x, y);
                        int grayValue = grayColor.R; // Assuming it's a grayscale image, R=G=B

                        // Normalize the grayscale value to [0, 1]
                        double normalizedValue = grayValue / 255.0;

                        // Get the heatmap color based on the normalized grayscale value
                        Color heatmapColor = GetHeatmapColor(normalizedValue);

                        // Set the pixel color in the heatmap image
                        grayscaleImage.SetPixel(x, y, heatmapColor);
                    }


                }
            }

            return grayscaleImage;
        }

        public Bitmap ApplyHotmap(Bitmap grayscaleImage)
        {

            for (int x = 0; x < grayscaleImage.Width; x++)
            {
                for (int y = 0; y < grayscaleImage.Height; y++)
                {
                    if ((y >= rect.Y && y <= rect.Height + rect.Y) && (x >= rect.X && x <= rect.Width + rect.X))
                    {

                        // Get the grayscale value from the original image
                        Color grayColor = grayscaleImage.GetPixel(x, y);
                        int grayValue = grayColor.R; // Assuming it's a grayscale image, R=G=B

                        // Normalize the grayscale value to [0, 1]
                        double normalizedValue = grayValue / 255.0;

                        // Get the heatmap color based on the normalized grayscale value
                        Color hotmapColor = GetHotmapColor(normalizedValue);

                        // Set the pixel color in the heatmap image
                        grayscaleImage.SetPixel(x, y, hotmapColor);
                    }

                }
            }

            return grayscaleImage;
        }

        public Bitmap ApplyCoolMap(Bitmap grayscaleImage)
        {


            for (int x = 0; x < grayscaleImage.Width; x++)
            {
                for (int y = 0; y < grayscaleImage.Height; y++)
                {
                    if ((y >= rect.Y && y <= rect.Height + rect.Y) && (x >= rect.X && x <= rect.Width + rect.X))
                    {
                        // Get the grayscale pixel value
                        Color grayColor = grayscaleImage.GetPixel(x, y);

                        int grayValue = grayColor.R; // Assuming grayscale image where R=G=B

                        // Normalize the gray value to a range of 0 to 1
                        double normalizedValue = grayValue / 255.0;

                        // Get the hotmap color for the normalized value
                        Color coolmapColor = GetCoolmapColor(normalizedValue);

                        // Set the hotmap color in the new image
                        grayscaleImage.SetPixel(x, y, coolmapColor);
                    }

                }
            }

            return grayscaleImage;
        }

        public Bitmap ApplySpringMap(Bitmap grayscaleImage)
        {

            for (int x = 0; x < grayscaleImage.Width; x++)
            {
                for (int y = 0; y < grayscaleImage.Height; y++)
                {
                    if ((y >= rect.Y && y <= rect.Height + rect.Y) && (x >= rect.X && x <= rect.Width + rect.X))
                    {
                        // Get the grayscale pixel value
                        Color grayColor = grayscaleImage.GetPixel(x, y);
                        int grayValue = grayColor.R; // Assuming grayscale image where R=G=B

                        // Normalize the gray value to a range of 0 to 1
                        double normalizedValue = grayValue / 255.0;

                        // Get the hotmap color for the normalized value
                        Color springmapColor = GetSpringmapColor(normalizedValue);

                        // Set the hotmap color in the new image
                        grayscaleImage.SetPixel(x, y, springmapColor);
                    }

                }
            }

            return grayscaleImage;
        }

        public Bitmap ApplyJetMap(Bitmap grayscaleImage)
        {

            for (int x = 0; x < grayscaleImage.Width; x++)
            {
                for (int y = 0; y < grayscaleImage.Height; y++)
                {
                    if ((y >= rect.Y && y <= rect.Height + rect.Y) && (x >= rect.X && x <= rect.Width + rect.X))
                    {
                        // Get the grayscale pixel value
                        Color grayColor = grayscaleImage.GetPixel(x, y);
                        int grayValue = grayColor.R; // Assuming grayscale image where R=G=B

                        // Normalize the gray value to a range of 0 to 1
                        double normalizedValue = grayValue / 255.0;

                        // Get the hotmap color for the normalized value
                        Color jetmapColor = GetJetmapColor(normalizedValue);

                        // Set the hotmap color in the new image
                        grayscaleImage.SetPixel(x, y, jetmapColor);
                    }

                }
            }

            return grayscaleImage;
        }


        private static Color GetCoolmapColor(double value)
        {
            // Ensure value is clamped between 0 and 1
            value = Math.Max(0, Math.Min(1, value));

            // Define color points (gradient from black to blue to cyan to green to white)
            Color[] colors = {
                Color.Black,  // 0.0
                Color.Blue,   // 0.25
                Color.Cyan,   // 0.5
                Color.Green,  // 0.75
                Color.White   // 1.0
            };

            // Determine which segment of the gradient value falls into
            double scaledValue = value * (colors.Length - 1);
            int index1 = (int)Math.Floor(scaledValue); // Lower index
            int index2 = (int)Math.Ceiling(scaledValue); // Upper index
            double fraction = scaledValue - index1; // Fraction between indices

            // Interpolate between the two colors
            Color color1 = colors[index1];
            Color color2 = colors[index2];

            byte r = (byte)((color2.R - color1.R) * fraction + color1.R);
            byte g = (byte)((color2.G - color1.G) * fraction + color1.G);
            byte b = (byte)((color2.B - color1.B) * fraction + color1.B);

            return Color.FromArgb(r, g, b);
        }

        private static Color GetHeatmapColor(double value)
        {
            // Ensure value is clamped between 0 and 1
            value = Math.Max(0, Math.Min(1, value));

            // Define color points (gradient from blue to red)
            Color[] colors = {
            Color.Blue,   // 0.0
            Color.Cyan,   // 0.25
            Color.Green,  // 0.5
            Color.Yellow, // 0.75
            Color.Red     // 1.0
        };


            // Determine which segment of the gradient value falls into
            //الغرض من هذا السطر هو تعيين قيمة الإدخال، التي تم تسويتها بين 0 و1، إلى الموضع المقابل ضمن نطاق مؤشرات مصفوفة الألوان.
            double scaledValue = value * (colors.Length - 1);
            int index1 = (int)Math.Floor(scaledValue); // Lower index
            int index2 = (int)Math.Ceiling(scaledValue); // Upper index
            double fraction = scaledValue - index1; // Fraction between indices
                                                    // الغرض من هذا السطر هو تحديد مدى المسافة المقاسة بين المؤشرين
                                                    // (index1 وindex2)

            // Interpolate between the two colors
            Color color1 = colors[index1];
            Color color2 = colors[index2];

            byte r = (byte)((color2.R - color1.R) * fraction + color1.R);
            byte g = (byte)((color2.G - color1.G) * fraction + color1.G);
            byte b = (byte)((color2.B - color1.B) * fraction + color1.B);

            return Color.FromArgb(r, g, b);
        }

        private static Color GetHotmapColor(double value)
        {
            // Ensure value is clamped between 0 and 1
            value = Math.Max(0, Math.Min(1, value));

            // Define color points (gradient from black to red to yellow to white)
            Color[] colors = {
            Color.Black,  // 0.0
            Color.Red,    // 0.33
            Color.Orange, // 0.66
            Color.Yellow, // 1.0
        };

            // Determine which segment of the gradient value falls into
            double scaledValue = value * (colors.Length - 1);
            int index1 = (int)Math.Floor(scaledValue); // Lower index
            int index2 = (int)Math.Ceiling(scaledValue); // Upper index
            double fraction = scaledValue - index1; // Fraction between indices

            // Interpolate between the two colors
            Color color1 = colors[index1];
            Color color2 = colors[index2];

            byte r = (byte)((color2.R - color1.R) * fraction + color1.R);
            byte g = (byte)((color2.G - color1.G) * fraction + color1.G);
            byte b = (byte)((color2.B - color1.B) * fraction + color1.B);

            return Color.FromArgb(r, g, b);
        }

        private static Color GetSpringmapColor(double value)
        {
            // Ensure value is clamped between 0 and 1
            value = Math.Max(0, Math.Min(1, value));

            // Define a custom color gradient for springmap
            // Green, Yellow, Light Pink
            Color[] colors = {
            Color.Green,    // 0.0
            Color.Yellow,   // 0.5
            Color.FromArgb(255, 255, 182, 193) // Light Pink
        };

            // Calculate index and fraction for interpolation
            double scaledValue = value * (colors.Length - 1);
            int index1 = (int)Math.Floor(scaledValue); // Lower index
            int index2 = (int)Math.Ceiling(scaledValue); // Upper index
            double fraction = scaledValue - index1; // Fraction between indices

            // Interpolate between the two colors
            Color color1 = colors[index1];
            Color color2 = colors[index2];

            byte r = (byte)((color2.R - color1.R) * fraction + color1.R);
            byte g = (byte)((color2.G - color1.G) * fraction + color1.G);
            byte b = (byte)((color2.B - color1.B) * fraction + color1.B);

            return Color.FromArgb(r, g, b);
        }

        private static Color GetJetmapColor(double value)
        {
            // Ensure value is clamped between 0 and 1
            value = Math.Max(0, Math.Min(1, value));

            // Define a custom color gradient for jetmap
            Color[] colors = {
            Color.FromArgb(0, 0, 127),   // Blue
            Color.FromArgb(0, 0, 255),    // Cyan
            Color.FromArgb(0, 255, 255),  // Green
            Color.FromArgb(255, 255, 0),  // Yellow
            Color.FromArgb(255, 0, 0)     // Red
        };

            // Calculate index and fraction for interpolation
            double scaledValue = value * (colors.Length - 1);
            int index1 = (int)Math.Floor(scaledValue); // Lower index
            int index2 = (int)Math.Ceiling(scaledValue); // Upper index
            double fraction = scaledValue - index1; // Fraction between indices

            // Interpolate between the two colors
            Color color1 = colors[index1];
            Color color2 = colors[index2];

            byte r = (byte)((color2.R - color1.R) * fraction + color1.R);
            byte g = (byte)((color2.G - color1.G) * fraction + color1.G);
            byte b = (byte)((color2.B - color1.B) * fraction + color1.B);

            return Color.FromArgb(r, g, b);
        }


        private void HeatMap_Button(object sender, EventArgs e)
        {
            Bitmap RGB_Image = new Bitmap(image_path);

            Bitmap Gray_image = ConvertToGrayscale(RGB_Image);

            pictureBox4.Image = ApplyHeatmap(Gray_image);

        }

        private void HotMap_Button(object sender, EventArgs e)
        {
            Bitmap RGB_Image = new Bitmap(image_path);

            Bitmap Gray_image = ConvertToGrayscale(RGB_Image);


            // Extract components pixel by pixel
            //for (int y = 0; y < b.Height; y++)
            //{
            //    for (int x = 0; x < b.Width; x++)
            //    {

            //        if ((y >= rect.Y && y <= rect.Height + rect.Y) && (x >= rect.X && x <= rect.Width + rect.X))
            //        {


            //            // Get RGB color of current pixel
            //            Color pixelColor = b.GetPixel(x, y);
            //            // Extract components
            //            int color = (pixelColor.G + pixelColor.B + pixelColor.R)/3;
            //            if (color >= 0 && color <= 100)
            //            {
            //                Color redColor = Color.FromArgb(color, 0, color);
            //                b.SetPixel(x, y, redColor);

            //            }
            //            else if (color >= 101 && color <= 200)
            //            {
            //                Color redColor = Color.FromArgb(0, color, color);
            //                b.SetPixel(x, y, redColor);

            //            }
            //            else if (color >= 201 && color <= 255)
            //            {
            //                Color redColor = Color.FromArgb(color, color, 0);
            //                b.SetPixel(x, y, redColor);
            //            }

            //            // Create colors for each component

            //            // Set the corresponding pixel in each component imag 
            //        }
            //        else
            //        {
            //            continue;
            //        }
            //    }
            //}
            Bitmap Hotmap_Image = ApplyHotmap(Gray_image);

            pictureBox4.Image = Hotmap_Image;
        }

        private void SpringMap_Button(object sender, EventArgs e)
        {

            Bitmap RGB_Image = new Bitmap(image_path);

            Bitmap Gray_Image = ConvertToGrayscale(RGB_Image);

            pictureBox4.Image = ApplySpringMap(Gray_Image);
        }

        private void JetMap_Button(object sender, EventArgs e)
        {
            Bitmap RGB_Image = new Bitmap(image_path);

            Bitmap Gray_Image = ConvertToGrayscale(RGB_Image);

            pictureBox4.Image = ApplyJetMap(Gray_Image);

        }

        private void CoolMap_Button(object sender, EventArgs e)
        {
            Bitmap RGB_Image = new Bitmap(image_path);

            Bitmap Gray_Image = ConvertToGrayscale(RGB_Image);

            pictureBox4.Image = ApplyCoolMap(Gray_Image);
        }


       private Bitmap RGB(Bitmap image)
        {

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    if ((y >= rect.Y && y <= rect.Height + rect.Y) && (x >= rect.X && x <= rect.Width + rect.X))
                    {

                        // Get the grayscale value from the original image
                        Color grayColor = image.GetPixel(x, y);
                        if (grayColor.R >= 0 && grayColor.R <= 100)
                        {
                            Color c = Color.FromArgb(grayColor.R, grayColor.R, 0);
                            image.SetPixel(x, y, c);
                        }// Assuming it's a grayscale image, R=G=B
                        if (grayColor.R >= 101 && grayColor.R <= 200)
                        {
                            Color c = Color.FromArgb(0, grayColor.R,grayColor.R);
                            image.SetPixel(x, y, c);
                        }// Assuming it's a grayscale image, R=G=B

                        if (grayColor.R >= 201 && grayColor.R <= 255)
                        {
                            Color c = Color.FromArgb(grayColor.R, 0, grayColor.R);
                            image.SetPixel(x, y, c);
                        }// Assuming it's a grayscale image, R=G=B

                        // Normalize the grayscale value to [0, 1]

                    }

                }


            }

            return image;
        }

       private void button1_Click(object sender, EventArgs e)
            {
                Bitmap n = new Bitmap(image_path);

            pictureBox4.Image = RGB(n);
            }

        } }