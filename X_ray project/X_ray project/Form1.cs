using Emgu.CV.CvEnum;
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
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace X_ray_project
{
    public partial class Form1 : Form
    {

        Point locationXY;
        Point locationX1Y1;
        Bitmap ColorMapImage;
        Bitmap image1;
        Bitmap image2;
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
            //reset pictureBox image
            pictureBox4.Image = null;

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
                image1 = new Bitmap(ofd.FileName);
                pictureBox3.Image = image1;
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
                ColorMapImage.Save(sfd.FileName);
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

           ColorMapImage = ApplyHeatmap(Gray_image);

            pictureBox3.Image = ColorMapImage;

        }

        private void HotMap_Button(object sender, EventArgs e)
        {
            Bitmap RGB_Image = new Bitmap(image_path);

            Bitmap Gray_image = ConvertToGrayscale(RGB_Image);

            ColorMapImage = ApplyHotmap(Gray_image);

            pictureBox3.Image = ColorMapImage;
        }

        private void SpringMap_Button(object sender, EventArgs e)
        {

            Bitmap RGB_Image = new Bitmap(image_path);

            Bitmap Gray_Image = ConvertToGrayscale(RGB_Image);

            ColorMapImage = ApplySpringMap(Gray_Image);

            pictureBox3.Image = ColorMapImage;
        }

        private void JetMap_Button(object sender, EventArgs e)
        {
            Bitmap RGB_Image = new Bitmap(image_path);

            Bitmap Gray_Image = ConvertToGrayscale(RGB_Image);

            pictureBox3.Image = ApplyJetMap(Gray_Image);

        }

        private void CoolMap_Button(object sender, EventArgs e)
        {
            Bitmap RGB_Image = new Bitmap(image_path);

            Bitmap Gray_Image = ConvertToGrayscale(RGB_Image);

            ColorMapImage = ApplyCoolMap(Gray_Image);

            pictureBox3.Image = ColorMapImage;
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

       private void RGB_Button(object sender, EventArgs e)
        {
            Bitmap n = new Bitmap(image_path);

            ColorMapImage = RGB(n);

            pictureBox3.Image = ColorMapImage;
        }
         

       private void Comapre_Button(object sender, EventArgs e)
        {
            UploadImagetToComapare(pictureBox4);

            //if (calculation_sum(image1) < calculation_sum(image2))
            //{
            //    MessageBox.Show("worsening condition", "Comparing Resulte", MessageBoxButtons.OK);

               
            //}
            //else if(calculation_sum(image1)>calculation_sum(image2))
            //{
            //    MessageBox.Show("Improved condition", "Comparing Result", MessageBoxButtons.OK);
            //}



            label1.Text = "DifferenceRatio = "+CalculateDifferenceRatio(image1,image2)+" %";
            
        }

        
        private void UploadImagetToComapare(PictureBox pictureBox)
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
                pictureBox.Image = new Bitmap(ofd.FileName);

            }

            image2= new Bitmap(ofd.FileName);
 
        }

        private int calculation_sum(Bitmap grayImage)
        {
            int sum = 0;
            int num_pixel= grayImage.Width * grayImage.Height;
            for (int i = 0; i < grayImage.Height; i++)
            {
                for (int j = 0; j <grayImage.Width; j++)
                {
                    Color grayColor = grayImage.GetPixel(j,i);

                    int grayValue = grayColor.R;
                    
                    sum = sum + grayValue; 
                }

            }

            Console.WriteLine(sum/num_pixel);
            return sum / num_pixel;
        }

        static double CalculateDifferenceRatio(Bitmap image_1 ,Bitmap image_2)
        {
            Bitmap binary1 = ConvertToBinary(image_1);
            Bitmap binary2 = ConvertToBinary(image_2);
            int width = binary1.Width;
            int height = binary1.Height; ;
            int differingPixels = 0;

            // Compare images
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                //    int Pixel_image1 = binary1.GetPixel(x, y).R;
                //    int Pixel_image2 = binary2.GetPixel(x, y).R;

                    Color grayColor1 = binary1.GetPixel(x, y);
                    Color grayColor2 = binary2.GetPixel(x, y);

                    int grayValue1= grayColor1.R;
                    int grayValue2 = grayColor2.R;
               
                    if (grayValue1!=grayValue2)
                    {
                        differingPixels++;
                    }
                }
            }

            // Calculate difference ratio
            double totalPixels = width * height;
            double differenceRatio = (differingPixels / totalPixels)*100;
            return differenceRatio;
        }

        public static Bitmap ConvertToBinary(Bitmap sourceBitmap, byte threshold = 127)
        {
            // Create a new Bitmap with the same size as the source, but with Format1bppIndexed
            Bitmap binaryBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height, PixelFormat.Format1bppIndexed);

            // Lock the bits of the source bitmap
            BitmapData sourceData = sourceBitmap.LockBits(
                new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            // Lock the bits of the binary bitmap
            BitmapData binaryData = binaryBitmap.LockBits(
                new Rectangle(0, 0, binaryBitmap.Width, binaryBitmap.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);

            int sourceStride = sourceData.Stride;
            int binaryStride = binaryData.Stride;

            IntPtr sourceScan0 = sourceData.Scan0;
            IntPtr binaryScan0 = binaryData.Scan0;

            unsafe
            {
                byte* pSource = (byte*)sourceScan0;
                byte* pBinary = (byte*)binaryScan0;

                for (int y = 0; y < sourceBitmap.Height; y++)
                {
                    byte* pSourceRow = pSource + (y * sourceStride);
                    byte* pBinaryRow = pBinary + (y * binaryStride);
                    byte mask = 0x80;
                    byte binaryByte = 0;

                    for (int x = 0; x < sourceBitmap.Width; x++)
                    {
                        // Calculate the grayscale value (simple average method)
                        byte pixelValue = (byte)((pSourceRow[x * 3] + pSourceRow[x * 3 + 1] + pSourceRow[x * 3 + 2]) / 3);

                        if (pixelValue >= threshold)
                        {
                            binaryByte |= mask;
                        }

                        if (mask == 0x01)
                        {
                            pBinaryRow[x / 8] = binaryByte;
                            mask = 0x80;
                            binaryByte = 0;
                        }
                        else
                        {
                            mask >>= 1;
                        }
                    }

                    if (mask != 0x80)
                    {
                        pBinaryRow[sourceBitmap.Width / 8] = binaryByte;
                    }
                }
            }

            // Unlock the bits of both bitmaps
            sourceBitmap.UnlockBits(sourceData);
            binaryBitmap.UnlockBits(binaryData);

            return binaryBitmap;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void classification1_image()

        {
            double Value = calc_AvgIntensity(image1);

            Console.WriteLine(Value);

            if (Value>=10 && Value <= 80) {
                MessageBox.Show("Mild medical condition","Classification Result",MessageBoxButtons.OK);
            }

            else if(Value >= 81 && Value <= 150)
            {
                MessageBox.Show("Moderate medical condition", "Classification Result", MessageBoxButtons.OK);
            }
            else if (Value >= 151 && Value <= 240)
            {
                MessageBox.Show("Severe medical condition", "Classification Result", MessageBoxButtons.OK);
            }

        }

        private double calc_AvgIntensity (Bitmap image)
        {
            Bitmap grayImage = ConvertToGrayscale(image);
            double sum = 0.0;
            int totalPixel = rect.Height * rect.Width;

            for (int i = 0; i < grayImage.Width; i++)
            {
                for (int j = 0; j < grayImage.Height; j++)
                {

                    if ((j >= rect.Y && j <= rect.Height + rect.Y) && (i >= rect.X && i <= rect.Width + rect.X))
                    {
                        Color grayColor = grayImage.GetPixel(i, j);
                        double PixelValue = grayColor.R;
                        sum += PixelValue;

                    }

                }
            }

            return sum /totalPixel ;

        }

        private void  classification2_image()
        {
            double TotlaImageArea = image1.Width * image1.Height;
            double HarmArea = rect.Height * rect.Width;
            double percentValue = (HarmArea/TotlaImageArea) * 100;


            if(percentValue>0 && percentValue <= 20)
            {
                MessageBox.Show("Mild medical condition", "Classification Result", MessageBoxButtons.OK);
            }
            else if (percentValue > 20 && percentValue <= 40)
            {
                MessageBox.Show("Moderate medical condition", "Classification Result", MessageBoxButtons.OK);
            }
            else if (percentValue > 40 && percentValue <= 100)
            {
                MessageBox.Show("Severe medical condition", "Classification Result", MessageBoxButtons.OK);
            }
            Console.WriteLine(percentValue);


        }

        private void classification_Click(object sender, EventArgs e)
        {
            classification2_image();
        }
        public static Bitmap EnhanceImageQuality(Bitmap image, int sharpenValue)
        {
            // Load the image


            // Create a custom sharpening filter
            Convolution sharpenFilter = new Convolution(new int[,]
            {
            { 0, -sharpenValue, 0 },
            { -sharpenValue, 1 + 4 * sharpenValue, -sharpenValue },
            { 0, -sharpenValue, 0 }
            });

            // Apply the sharpening filter
            return sharpenFilter.Apply(image);
        }
    }
}