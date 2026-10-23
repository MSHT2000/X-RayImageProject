using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xray_image_new_Project
{
    public partial class CompareForm : Form
    {
        public bool is_Active = false;
        public static CompareForm instance;

       
        public CompareForm()
        {
            InitializeComponent();
            this.pictureBox1.Size = this.pictureBox2.Size = new Size(256, 256);
            pictureBox1.Image = MainForm.instance.Original_Image;
            this.is_Active = true;
            instance = this;

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.pictureBox2.Image == null)
            {
                MainForm.instance.Open_Button_Click_1(sender, e, this.pictureBox2);
            }
        }

        private void Compare_Button_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null && pictureBox2.Image != null)
            {


                MessageBox.Show("Difference ratio:" + CalculateDifferenceRatio
                    (
                     (Bitmap)pictureBox1.Image
                    , (Bitmap)pictureBox2.Image
                    ) + " %"
                    , "Compare Result",
                     MessageBoxButtons.OK
                    );
            }
            else
            {
                MessageBox.Show("image not Found!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public double CalculateDifferenceRatio(Bitmap image_1, Bitmap image_2)
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

                    int grayValue1 = grayColor1.R;
                    int grayValue2 = grayColor2.R;

                    if (grayValue1 != grayValue2)
                    {
                        differingPixels++;
                    }
                }
            }

            // Calculate difference ratio
            double totalPixels = width * height;
            double differenceRatio = (differingPixels / totalPixels) * 100;
            return differenceRatio;
        }

        private  Bitmap ConvertToBinary(Bitmap sourceBitmap, byte threshold = 127)
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

        private void Rest_Images_Button_Click(object sender, EventArgs e)
        {
            if(this.pictureBox2 != null)
            {
                 this.pictureBox2.Image = null;
            }
        }

       
    }
}
