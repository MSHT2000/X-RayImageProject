using System;
using System.Windows.Forms;
using System.Numerics;
using MathNet.Numerics.IntegralTransforms;
using Emgu.CV.Features2D;
using System.IO;
using MathNet.Numerics;


using NAudio.Dsp;
using NAudio.Wave;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using AForge.Math;
using System.Drawing;
using MathNet.Numerics.Providers.FourierTransform;
using AForge.Imaging.Filters;

using AForge.Imaging.Filters;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;
using MathNet.Numerics.RootFinding;



namespace WindowsFormsApp2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string input = "C:\\Users\\ABC\\Downloads\\Xr.jpg";
            Bitmap image = new Bitmap(input);

            DisplayImage(ApplyLowPassFilter(EnhanceImageQuality(image, 4), 350));


         


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
            static Bitmap ConvertToGrayscale(Bitmap image)
        {
            Bitmap grayImage = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int average = (pixel.R + pixel.G + pixel.B) / 3;
                    Color grayPixel = Color.FromArgb(average, average, average);
                    grayImage.SetPixel(x, y, grayPixel);
                }
            }

            return grayImage;
        }

        public static void DisplayImage(Bitmap image)
        {

            Form form = new Form();
            form.Size = new Size(image.Width, image.Height);
            form.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;
                g.DrawImage(image, new Point(0, 0));
            };
            Application.Run(form);

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



        public static Bitmap Apply(Bitmap image, int kernelSize)
        {
            // Convert the image to grayscale
            Bitmap grayscaleImage = ConvertToGrayscale(image);

            // Apply low-pass filter
            double[,] lowPassFiltered = ApplyLowPassFilter1(grayscaleImage, kernelSize);

            // Apply high-pass filter
            double[,] highPassFiltered = ApplyHighPassFilter1(grayscaleImage, lowPassFiltered);

            // Normalize the result
            double[,] normalizedResult = NormalizeImage(highPassFiltered);

            // Convert array back to bitmap
            Bitmap filteredBitmap = ArrayToImage(normalizedResult);

            return filteredBitmap;
        }



        private static double[,] ApplyLowPassFilter1(Bitmap image, int kernelSize)
        {
            double[,] result = new double[image.Height, image.Width];

            // Apply averaging filter
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    double sum = 0.0;
                    int count = 0;

                    for (int i = -kernelSize / 2; i <= kernelSize / 2; i++)
                    {
                        for (int j = -kernelSize / 2; j <= kernelSize / 2; j++)
                        {
                            int px = Math.Max(0, Math.Min(image.Width - 1, x + j));
                            int py = Math.Max(0, Math.Min(image.Height - 1, y + i));
                            Color color = image.GetPixel(px, py);
                            sum += color.R; // Assuming grayscale
                            count++;
                        }
                    }

                    result[y, x] = sum / count;
                }
            }

            return result;
        }

        private static double[,] ApplyHighPassFilter1(Bitmap original, double[,] lowPassFiltered)
        {
            double[,] result = new double[original.Height, original.Width];

            // Apply high-pass filter by subtracting low-pass filtered version from original
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    result[y, x] = original.GetPixel(x, y).R - lowPassFiltered[y, x];
                }
            }

            return result;
        }

        private static double[,] NormalizeImage(double[,] imageData)
        {
            // Normalize the image data
            double max = double.MinValue;
            double min = double.MaxValue;

            // Find min and max values
            foreach (double value in imageData)
            {
                if (value > max)
                    max = value;
                if (value < min)
                    min = value;
            }

            double[,] result = new double[imageData.GetLength(0), imageData.GetLength(1)];

            // Rescale values to [0, 255]
            for (int y = 0; y < imageData.GetLength(0); y++)
            {
                for (int x = 0; x < imageData.GetLength(1); x++)
                {
                    result[y, x] = 255 * (imageData[y, x] - min) / (max - min);
                }
            }

            return result;
        }

        private static Bitmap ArrayToImage(double[,] imageData)
        {
            Bitmap result = new Bitmap(imageData.GetLength(1), imageData.GetLength(0));

            for (int y = 0; y < imageData.GetLength(0); y++)
            {
                for (int x = 0; x < imageData.GetLength(1); x++)
                {
                    int pixelValue = (int)Math.Round(imageData[y, x]);
                    result.SetPixel(x, y, Color.FromArgb(pixelValue, pixelValue, pixelValue));
                }
            }

            return result;
        }

    }
}




