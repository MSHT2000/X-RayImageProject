using Emgu.CV.CvEnum;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lecture2
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

            string imagePath = "D:\\Various Files\\New folder\\2.jpg";
            string outPutImagePAth = "C:\\Users\\ABC\\source\\repos\\lecture2\\lecture2\\images";

            //To Extract RGB Components follow these commands:
            Bitmap rgbImage = new Bitmap(imagePath);
            // save original image:
            rgbImage.Save(outPutImagePAth+"\\originalImage.jpg");

            Bitmap redComponentImage = new Bitmap(rgbImage.Width, rgbImage.Height);
            Bitmap greenComponentImage = new Bitmap(rgbImage.Width, rgbImage.Height);
            Bitmap blueComponentImage = new Bitmap(rgbImage.Width, rgbImage.Height);
            Bitmap cmyImage = new Bitmap(rgbImage.Width, rgbImage.Height);
            // Extract components pixel by pixel
            for (int y = 0; y < rgbImage.Height; y++)
            {
                for (int x = 0; x < rgbImage.Width; x++)
                {
                    // Get RGB color of current pixel
                    Color pixelColor = rgbImage.GetPixel(x, y);
                    // Extract components
                    int redComponent = pixelColor.R;
                    int greenComponent = pixelColor.G;
                    int blueComponent = pixelColor.B;

                    int cyan = 255 - redComponent;
                    int magenta = 255 - greenComponent;
                    int yellow = 255 - blueComponent;
                    // Create colors for each component
                    Color redColor = Color.FromArgb(redComponent, 0, 0);
                    Color greenColor = Color.FromArgb(0, greenComponent, 0);
                    Color blueColor = Color.FromArgb(0, 0, blueComponent);

                    Color cmyColor = Color.FromArgb(cyan, magenta, yellow);




                    redComponentImage.SetPixel(x, y, redColor);
                    greenComponentImage.SetPixel(x, y, greenColor);
                    blueComponentImage.SetPixel(x, y, blueColor);
                    cmyImage.SetPixel(x,y, cmyColor);
                    
                }

            }

            Form form = new Form(); 
            form.Size= new Size(redComponentImage.Width, greenComponentImage.Height);
            form.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;
                g.DrawImage(greenComponentImage, new Point(0, 0));
            };
            Application.Run(form);

            redComponentImage.Save(outPutImagePAth+"\\image1.jpg");
            greenComponentImage.Save(outPutImagePAth + "\\image2.jpg");
            blueComponentImage.Save(outPutImagePAth + "\\image3.jpg");
            cmyImage.Save(outPutImagePAth+"\\image4.jpg");

            //To Convert RGB Image to HSV:
          
            Mat rgb = CvInvoke.Imread(imagePath);

            Mat hsvImage = new Mat();
            Mat YCbCrImage = new Mat();
            Mat YuvImage = new Mat();
            Mat labImage = new Mat();
            //HSV Color:
            CvInvoke.CvtColor(rgb, hsvImage, ColorConversion.Bgr2Hsv);
            //YCrCb Color:
            CvInvoke.CvtColor(rgb, YCbCrImage, ColorConversion.Bgr2YCrCb);
            //Yuv Color:
            CvInvoke.CvtColor(rgb, YuvImage, ColorConversion.Bgr2Yuv);
            //l*a*b Color:
            CvInvoke.CvtColor(rgb, labImage, ColorConversion.Bgr2Lab);

           // CvInvoke.Imshow("HSF image", hsvImage);
            hsvImage.Save(outPutImagePAth+"\\image5.jpg");
            YCbCrImage.Save(outPutImagePAth+"\\image6.jpg");
            YuvImage.Save(outPutImagePAth+"\\image7.jpg");
            labImage.Save(outPutImagePAth+"\\image8.jpg");
            CvInvoke.WaitKey(0);

            //Solve Excersice lecutre 2:
            Bitmap image =new Bitmap(imagePath);
            Bitmap image_Without_green =new Bitmap(image.Width,image.Height);
            Bitmap image_Without_red =new Bitmap(image.Width,image.Height);
            Bitmap image_Without_blue =new Bitmap(image.Width,image.Height);

            for (int i = 0; i < image.Height; i++)
            {
               for (int j = 0; j < image.Width; j++)
                {
                    Color colorPixel = image.GetPixel(j, i);
                    Color Without_greenColor = Color.FromArgb(colorPixel.R, 0, colorPixel.B);
                    Color Without_RedColor = Color.FromArgb(0, colorPixel.G, colorPixel.B);
                    Color Without_BlueColor = Color.FromArgb(colorPixel.R, colorPixel.G, 0);

                    image_Without_green.SetPixel(j, i, Without_greenColor);
                    image_Without_red.SetPixel(j, i, Without_RedColor);
                    image_Without_blue.SetPixel(j, i, Without_BlueColor);

                }
            }
          
            image_Without_green.Save(outPutImagePAth+"\\image8.jpg");
            image_Without_red.Save(outPutImagePAth+"\\image9.jpg");
            image_Without_blue.Save(outPutImagePAth+"\\image10.jpg");
            Application.Run(form);
            



            //













        }
    }
}
