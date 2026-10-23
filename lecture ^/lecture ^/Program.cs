using Emgu.CV.CvEnum;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace lecture__
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string input_path = "D:\\Various Files\\multimedia";


            Bitmap rgbImage = new Bitmap(input_path + "\\image.jpg");

            Bitmap binaryIameg =ConvertToBinary(rgbImage);

            Bitmap f = CreateBitmapFromRLE(RunLengthEncode1(binaryIameg),rgbImage.Width,rgbImage.Height);
            
            Form form = new Form();
            form.Size = new Size(f.Width, f.Height);
            // Handle the Paint event of the form
            form.Paint += (sender, e) =>
            {
                // Get the graphics object
                Graphics g = e.Graphics;
                // Draw the image at position (0, 0)
                g.DrawImage(f, new Point(0, 0));
            };
            // Show the form
            Application.Run(form);
            















        }


        public static string RunLengthEncode(Bitmap binaryImage)
        {
            StringBuilder encodedData = new StringBuilder();

            int width = binaryImage.Width;
            int height = binaryImage.Height;

            Color currentColor = binaryImage.GetPixel(0, 0);
            int count = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = binaryImage.GetPixel(x, y);

                    if (pixelColor == currentColor)
                    {
                        count++;
                    }
                    else
                    {
                        encodedData.Append(count).Append(" ").Append(currentColor == Color.Black ? "0" : "1").Append(" ");
                        currentColor = pixelColor;
                        count = 1;
                    }
                }
            }

            // Append the last run
            encodedData.Append(count).Append(" ").Append(currentColor == Color.Black ? "0" : "1");

            return encodedData.ToString();
        }
        static Bitmap ConvertToBinary(Bitmap originalImage)
        {
            Bitmap binaryImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);
                    // Convert RGB to grayscale
                    int grayscale = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    // Convert grayscale to binary (thresholding)
                    Color binaryColor = grayscale < 128 ? Color.Black : Color.White;
                    binaryImage.SetPixel(x, y, binaryColor);
                }
            }

            return binaryImage;
        }
        public static Bitmap CreateBitmapFromRLE(byte[] encodedBytes, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            bool currentPixel = false;
            int index = 0;
            int x = 0;
            int y = 0;

            while (index < encodedBytes.Length)
            {
                int count = encodedBytes[index++];
                byte pixelValue = encodedBytes[index++];

                for (int i = 0; i < count; i++)
                {
                    bitmap.SetPixel(x, y, pixelValue == 0 ? Color.White : Color.Black);
                    x++;

                    if (x >= width)
                    {
                        x = 0;
                        y++;
                    }
                }
            }

            return bitmap;
        }

        public static byte[] RunLengthEncode1(Bitmap binaryImage)
        {
            byte[] encodedBytes = new byte[0];
            bool currentPixel = false;
            int count = 0;

            for (int y = 0; y < binaryImage.Height; y++)
            {
                for (int x = 0; x < binaryImage.Width; x++)
                {
                    Color pixelColor = binaryImage.GetPixel(x, y);
                    bool isWhite = pixelColor == Color.White;

                    if (isWhite != currentPixel || count == 255)
                    {
                        Array.Resize(ref encodedBytes, encodedBytes.Length + 2);
                        encodedBytes[encodedBytes.Length - 2] = (byte)count;
                        encodedBytes[encodedBytes.Length - 1] = (byte)(currentPixel ? 0 : 1);
                        count = 0;
                        currentPixel = !currentPixel;
                    }

                    count++;
                }
            }

            // Add the last count
            Array.Resize(ref encodedBytes, encodedBytes.Length + 2);
            encodedBytes[encodedBytes.Length - 2] = (byte)count;
            encodedBytes[encodedBytes.Length - 1] = (byte)(currentPixel ? 0 : 1);

            return encodedBytes;
        }
    }
}
