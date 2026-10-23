using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Core.Types.X.VideoEncoders;

namespace Xray_image_new_Project
{
    public partial class CompressForm : Form
    {
        public CompressForm()
        {
            InitializeComponent();
            pictureBox2.Size = new Size(256, 256);
            pictureBox2.Image = MainForm.instance.pictureBox1.Image;
            Console.WriteLine();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
             Bitmap CompImage = CompressBitmapWithQuality((Bitmap)MainForm.instance.pictureBox1.Image, trackBar1.Value);
            pictureBox2.Image = CompImage;
            label3.Text = getSizeImage(CompImage).ToString() +" KB";
        }
       
        public static Bitmap CompressBitmapWithQuality(Bitmap bitmap, int quality)
        {
            // Create a new Bitmap with the same size as the input bitmap
            Bitmap compressedBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            // Create a JPEG encoder with the specified quality level
            ImageCodecInfo jpegCodec = GetEncoderInfo(ImageFormat.Jpeg);
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            // Save the compressed bitmap to a temporary file
            string tempFile = Path.GetTempFileName() + ".jpg";
            bitmap.Save(tempFile, jpegCodec, encoderParams);

            // Load the compressed bitmap from the temporary file
            compressedBitmap = new Bitmap(tempFile);

            // Delete the temporary file
            //File.Delete(tempFile);

            // Return the compressed bitmap
            return compressedBitmap;
        }

        private static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            // Get image codec info for the specified image format
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainForm.instance.Save(sender, e, pictureBox2);
        }

        public float getSizeImage(Bitmap bitmap)
        {
           using(var memoryStream = new MemoryStream())
        {
               
                // Save the bitmap to the memory stream
                bitmap.Save(memoryStream, bitmap.RawFormat);

                // Calculate the size in kilobytes (1 kB = 1024 bytes)
                float sizeInKB = memoryStream.Length / 1024.0f;

                return sizeInKB;
            }
        }

        private void Done_Button_Click(object sender, EventArgs e)
        {
            MainForm.instance.pictureBox1.Image = pictureBox2.Image;
            this.Close();
        }

        private void CompressForm_Load(object sender, EventArgs e)
        {

        }

      
        public string path()
        {

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "ZIP Files|*.zip";


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return sfd.FileName;
            }
            return "";
        }

        private void Create_Zip_Button_Click(object sender, EventArgs e)
        {
            //ConvertBitmapToZip((Bitmap)pictureBox2.Image,path());
        }
    }

}

