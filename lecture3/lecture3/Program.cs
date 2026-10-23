using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.IO;
using OxyPlot;
using OxyPlot.Series;
using Emgu.CV.Structure;
using OxyPlot.WindowsForms;

namespace lecture3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Convert RGB To Binary Image:

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string path = "D:\\Various Files\\New folder\\1.jpg";
            Mat rgb = CvInvoke.Imread(path);
            //CvInvoke.Imshow("a",rgb);
            Mat binary_image = new Mat();
            CvInvoke.CvtColor(rgb, binary_image,ColorConversion.Bgr2Gray);
            CvInvoke.Imshow("image", binary_image);
            CvInvoke.WaitKey(0);

            //Converting RGB image to gray-scale image:
            Mat grayscaleImage = new Mat();
            CvInvoke.CvtColor(rgb, grayscaleImage,
            ColorConversion.Bgr2Gray);
            // Convert the grayscale image to a binary
            Mat binaryImage = new Mat();
            CvInvoke.Threshold(grayscaleImage, binaryImage,10, 255,
            ThresholdType.Binary);
            CvInvoke.Imshow("Binary Image", binaryImage);
            CvInvoke.WaitKey(0);

            //indexed image:    
            Bitmap indexedImage = new Bitmap(path);
            // Extract the color palette
            ColorPalette colorPalette = indexedImage.Palette;
            // Extract one color from the colormap and its 
            int index = 10;
         //   Color sampleColor = colorPalette.Entries[index];
            //Console.WriteLine(sampleColor);

            //Excercises lecutre 3 :
            //I:
            //read image:
            string newPath = "D:\\Various Files\\New folder\\2.jpg";
            string output_Path = "C:\\Users\\ABC\\Desktop";
            Mat Image = CvInvoke.Imread(newPath);
            //show Image:
            CvInvoke.Imshow("image", Image);
            CvInvoke.WaitKey(0);
            CvInvoke.DestroyAllWindows();
            //Write image on my device :
           CvInvoke.Imwrite (output_Path+"\\iamge1.jpg", Image);

            //image info:
            //Width:
            Console.WriteLine("Image Width= " + Image.Width);
            //height
            Console.WriteLine("Image Height= " + Image.Height);
            //Depth:
            Console.WriteLine("Image Depth= " + Image.Depth);
            //Type:
            Console.WriteLine("Image Type= "+Image.GetType());
            //file Format:
            Console.WriteLine("Image file Format= " +Path.GetExtension(newPath));
            //size width x height:
            Console.WriteLine("Image size= "+Image.Width);
            //size by Kilobytes and Bytes:
            FileInfo fileInfo = new FileInfo(newPath);
            long fileSizeBytes = fileInfo.Length;

            double fileSizeKB = fileSizeBytes / 1024.0; // Convert bytes to kilobytes

            // Format the size as a string with the desired format
            string sizeString = string.Format("{0:N0} KB ({1:N0} bytes)", fileSizeKB, fileSizeBytes);

            Console.WriteLine("image size= "+sizeString);

            //II
            Bitmap image1 = new Bitmap(newPath);
            string path1 = "C:\\Users\\ABC\\Desktop";


            //SaveImageWithQuality(image1, output_Path + "\\image2.jpg", 0);
            //SaveImageWithQuality(image1, output_Path + "\\image3.jpg", 5);
            //SaveImageWithQuality(image1, output_Path + "\\image4.jpg", 15);
            //SaveImageWithQuality(image1, output_Path + "\\image5.jpg", 25);
            //SaveImageWithQuality(image1, output_Path + "\\image6.jpg", 50);
            double compression_val = 0;

            //compression_val = get_size(newPath) / get_size(path1 + "\\image2.jpg");
            //Console.WriteLine("imag2= " + compression_val);
            //compression_val = get_size(newPath) / get_size(path1 + "\\image3.jpg");
            //Console.WriteLine("imag3= " + compression_val);
            //compression_val = get_size(newPath) / get_size(path1 + "\\image4.jpg");
            //Console.WriteLine("imag4= " + compression_val);
            //compression_val = get_size(newPath) / get_size(path1 + "\\image5.jpg");
            //Console.WriteLine("imag5= " + compression_val);
            //compression_val = get_size(newPath) / get_size(path1 + "\\image6.jpg");
            //Console.WriteLine("imag6= " + compression_val);


            string imagePath = "D:\\Various Files\\New folder\\2.jpg";

            // Check if the file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file does not exist: " + imagePath);
                return; // Exit if no file found
            }

            long originalSize = new FileInfo(imagePath).Length;
            int[] qualities = new int[] { 50, 25, 15, 5, 0 };
            double[] compressionRatios = new double[qualities.Length];

            Image<Bgr, Byte> image = new Image<Bgr, byte>(imagePath);

            for (int i = 0; i < qualities.Length; i++)
            {
                string outputPath = "C:\\Users\\ABC\\Desktop\\fff.jpg";
                CvInvoke.Imwrite(outputPath, image, new KeyValuePair<Emgu.CV.CvEnum.ImwriteFlags, int>(Emgu.CV.CvEnum.ImwriteFlags.JpegQuality, qualities[i]));

                if (!File.Exists(outputPath))
                {
                    Console.WriteLine("Failed to write image: " + outputPath);
                    continue; // Skip this iteration if output file isn't written
                }

                long newSize = new FileInfo(outputPath).Length;
                compressionRatios[i] = (double)originalSize / newSize;
            }

            // Plotting the data
            var plotModel = new PlotModel { Title = "Quality vs Compression Ratio" };
            var series = new LineSeries();
            for (int i = 0; i < qualities.Length; i++)
            {
                series.Points.Add(new DataPoint(qualities[i], compressionRatios[i]));
            }
            plotModel.Series.Add(series);

            // Correctly create and show the plot using OxyPlot.WindowsForms
            var plotView = new PlotView
            {
                Model = plotModel,
                Dock = System.Windows.Forms.DockStyle.Fill
            };
            Form plotForm = new Form { Width = 600, Height = 400 };
            plotForm.Controls.Add(plotView);
            plotForm.ShowDialog();










        }
        //static void SaveImageWithQuality(Bitmap image, string outputPath, int quality)
        //{
        //    // Convert Mat to Bitmap


        //    // Create encoder parameters for JPEG
        //    EncoderParameters encoderParams = new EncoderParameters(1);
        //    encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);

        //    // Get the JPEG codec info
        //    ImageCodecInfo jpegCodecInfo = GetEncoderInfo(ImageFormat.Jpeg);

        //    // Save the bitmap with specified quality
        //    image.Save(outputPath, jpegCodecInfo, encoderParams);
        //}

        //static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        //{
        //    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        //    foreach (ImageCodecInfo codec in codecs)
        //    {
        //        if (codec.FormatID == format.Guid)
        //        {
        //            return codec;
        //        }
        //    }
        //    return null;
        //}

        //static Double get_size(string path)
        //{
        //    FileInfo fileInfo = new FileInfo(path);
        //    long fileSizeBytes = fileInfo.Length;

        //    double fileSizeKB = fileSizeBytes / 1024.0;


        //    return fileSizeKB;

        //}
        
    }


}

