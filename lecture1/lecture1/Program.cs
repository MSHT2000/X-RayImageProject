using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lecture1
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

            // read image by Bitmap Class:
            string input_path = "D:\\Various Files\\New folder";
            string output_path="C:\\Users\\ABC\\source\\repos\\lecture1\\lecture1";
          

            Bitmap image1 = new Bitmap(input_path);


            // save image:
            image1.Save(output_path+"\\image2.jpg");

            // get pixel's rgb info:
            Color color_image1 = image1.GetPixel(0, 0);
            Console.WriteLine(color_image1);

            // edit pixel's rgb info:
            Color newColor = Color.Red;
            image1.SetPixel(100, 100, newColor);
            image1.Save(output_path+"\\image2.jpg");

            //dealing with image by BitMapData class:
            Console.WriteLine("image_width= "+image1.Width);
            Console.WriteLine("image_height= "+image1.Height);
            BitmapData bitmapData = image1.LockBits(new Rectangle(400, 200, 800, 400),
            ImageLockMode.ReadOnly, image1.PixelFormat);
            Bitmap image2 =new Bitmap(bitmapData.Width,bitmapData.Height,bitmapData.Stride,image1.PixelFormat,bitmapData.Scan0);
            image2.Save(output_path+"\\image3.jpg");
            image1.UnlockBits(bitmapData);

            //dispaly image in form:
            Form form = new Form();
            form.Size = new Size(image2.Width, image2.Height);
            // Handle the Paint event of the form
            form.Paint += (sender, e) =>
            {
                // Get the graphics object
                Graphics g = e.Graphics;
                // Draw the image at position (0, 0)
                g.DrawImage(image1, new Point(0, 0));
            };
            // Show the form
            Application.Run(form);












        }
    }
}
