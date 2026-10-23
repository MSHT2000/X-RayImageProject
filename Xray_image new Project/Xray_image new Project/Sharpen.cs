using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xray_image_new_Project
{
    public partial class Sharpen : Form
    {
        Bitmap HPF_Image, Input_Image1;
        Bitmap Resulte_Image;


        public Sharpen()
        {
            InitializeComponent();
            this.pictureBox1.Image = MainForm.instance.pictureBox1.Image;
            Input_Image1 = (Bitmap)pictureBox1.Image;
            this.pictureBox1.Size = new Size(256, 256);
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

        public static Bitmap ApplyLowPassFilter(Bitmap image, int cutoffFrequency)
        {
            // Convert the image to a 2D array of complex values

            Grayscale f = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap h = f.Apply(image);



            AForge.Math.Complex[,] complexImage = ConvertToComplex(h);



            // Apply FFT to the image
            FourierTransform.FFT2(complexImage, FourierTransform.Direction.Forward);


            //Get the dimensions of the image
            int width = complexImage.GetLength(0);
            int height = complexImage.GetLength(1);

            // Calculate the center coordinates
            int centerX = width / 2;
            int centerY = height / 2;

            // Apply the low - pass filter
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double distance = Math.Sqrt(Math.Pow((x - centerX), 2) + Math.Pow((y - centerY), 2));

                    if (distance > cutoffFrequency)
                    {
                        complexImage[x, y] = AForge.Math.Complex.Zero;

                    }
                }
            }

            // Apply inverse FFT to the filtered image
            FourierTransform.FFT2(complexImage, FourierTransform.Direction.Backward);



            // Convert the filtered image back to a bitmap
            Bitmap filteredImage = ConvertToBitmap(complexImage);

            return filteredImage;
        }

        static AForge.Math.Complex[,] ConvertToComplex(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            AForge.Math.Complex[,] complexImage = new AForge.Math.Complex[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = image.GetPixel(x, y);

                    // Convert the pixel values to a complex value
                    double real = pixel.R / 255.0;  // Scale the pixel value to the range [0, 1]
                    double imaginary = 0.0;  // Since we are converting a grayscale image, the imaginary part is 0

                    complexImage[x, y] = new AForge.Math.Complex(real, imaginary);
                }
            }

            return complexImage;
        }

        static Bitmap ConvertToBitmap(AForge.Math.Complex[,] complexImage)
        {
            int width = complexImage.GetLength(0);
            int height = complexImage.GetLength(1);

            Bitmap image = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    AForge.Math.Complex complexValue = complexImage[x, y];

                    // Convert the complex value to a grayscale pixel value
                    int grayscale = (int)(complexValue.Re * 255);  // Scale the real part to the range [0, 255]

                    grayscale = Clamp(grayscale, 0, 255);
                    // Create a grayscale color from the pixel value
                    Color pixel = Color.FromArgb(grayscale, grayscale, grayscale);


                    image.SetPixel(x, y, pixel);
                }
            }

            return image;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;
            else
                return value;
        }

        private void Save_Image(object sender, EventArgs e)
        {
            MainForm.instance.Save(sender, e, pictureBox1);
        }

        private void Done_Button_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Resulte_Image.ToString());
            MainForm.instance.pictureBox1.Image = Resulte_Image;
            this.Close();
        }
        //Sahrpen ScrollBar
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value != 100)
            {
                ShValue.Text = trackBar2.Value.ToString();

                pictureBox1.Image = EnhanceImageQuality(HPF_Image, trackBar2.Value);
                Resulte_Image = (Bitmap)pictureBox1.Image;
                Console.WriteLine(Resulte_Image.ToString());
            }
        }
        //HPF ScrollBar
        private void HPF_Bar_Scroll(object sender, EventArgs e)
        {

            trackBar2.Value = 0;
            HPFValue.Text = trackBar1.Value.ToString();
            //pictureBox1.Image = ApplyLowPassFilter(Input_Image1, trackBar1.Value);
            pictureBox1.Image = ApplyHighPassFilter(Input_Image1, trackBar1.Value);
            HPF_Image = (Bitmap)pictureBox1.Image;
            Resulte_Image = (Bitmap)pictureBox1.Image;
            Console.WriteLine(Resulte_Image.ToString());
        }

        private Bitmap ApplyHighPassFilter(Bitmap image,int radius)
        {
            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = grayscaleFilter.Apply(image);

            int width = grayImage.Width;
            int height = grayImage.Height;
            ComplexImage complexImage = ComplexImage.FromBitmap(grayImage);

            complexImage.ForwardFourierTransform();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int dx = x - width / 2;
                    int dy = y - height / 2;
                    double distance = Math.Sqrt(dx * dx + dy * dy);

                    if (distance < radius)
                    {
                        complexImage.Data[x, y] = Complex.Zero;
                    }
                }
            }

            complexImage.BackwardFourierTransform();
            Bitmap resultImage = complexImage.ToBitmap();

            return resultImage;
        }
    }
}
