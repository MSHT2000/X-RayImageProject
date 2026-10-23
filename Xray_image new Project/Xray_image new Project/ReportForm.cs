using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GES;
using VisioForge.Libs.MediaFoundation;
using PdfSharp.Pdf.IO;
using PdfReader = iTextSharp.text.pdf.PdfReader;
using System.Drawing.Imaging;
using Serilog.Parsing;
using Spire.Pdf.Conversion.Compression;

namespace Xray_image_new_Project
{
    public partial class ReportForm : Form
    {
        string pdf_path;

        public ReportForm()
        {
            InitializeComponent();
            pictureBox1.Size = new Size(256, 256);
            pictureBox1.Image = MainForm.instance.pictureBox1.Image;

        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if( 
                FirstNameBox.Text != ""        ||
                LastNameBox.Text != ""         ||
                AgeBox.Text != ""              ||
                PhoneBox.Text != ""            ||
                GenderBox.Text != ""           ||
                StateNameBox.Text != ""        ||
                StateDescriptionBox.Text != "" 
              )
            {

            /*
             //pdf_path = path();
             //StreamWriter Writer = new StreamWriter(pdf_path);

             //Writer.WriteLine(FirstName.Text+" "+FirstNameBox.Text);
             //Writer.WriteLine(LastName.Text+" "+LastNameBox.Text);
             //Writer.WriteLine(Gender.Text+" "+GenderBox.Text);
             //Writer.WriteLine(Age.Text+" "+ AgeBox.Text);
             //Writer.WriteLine(Phone.Text+" "+PhoneBox.Text);
             //Writer.WriteLine(StateName.Text+" "+StateNameBox.Text);
             //Writer.WriteLine(StateDescription.Text + " " + StateDescriptionBox.Text);
             //Writer.Close();

             //string fakepath1 = "C:\\Users\\ABC\\Desktop\\fake_pdf.pdf";
             //ConvertTextToPdf(pdf_path,fakepath1);
             //string fakepath2 = "C:\\Users\\ABC\\Desktop\\fake_iamge.pdf";
             //ConvertImageToPdf((Bitmap)pictureBox1.Image,fakepath2);
             //string[] pdfFiles = { fakepath2, fakepath1 };
             //MergePdfFiles(pdfFiles, pdf_path);

             //File.Delete(fakepath1);
             //File.Delete(fakepath2);         
            */
            pdf_path = path();

            Document pdf = new Document(PageSize.A5, 20f, 20f, 30f, 30f);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdf, new FileStream(pdf_path, FileMode.Create));

            pdf.Open();

            pdf.Add(CreateImagePDF(pictureBox1.Image));

            pdf.Add(CreatParagraphPDF(FirstName.Text + " " + FirstNameBox.Text));
            pdf.Add(CreatParagraphPDF(LastName.Text + " " + LastNameBox.Text));
            pdf.Add(CreatParagraphPDF(Gender.Text + " " + GenderBox.Text));
            pdf.Add(CreatParagraphPDF(Age.Text + " " + AgeBox.Text));
            pdf.Add(CreatParagraphPDF(Phone.Text + " " + PhoneBox.Text));
            pdf.Add(CreatParagraphPDF(StateName.Text + " " + StateNameBox.Text));
            pdf.Add(CreatParagraphPDF(StateDescription.Text + " " + StateDescriptionBox.Text));

            pdf.Close();
            }
            else
            {
                MessageBox.Show
                    (
                    "There are unfilled fields !!!"
                    ,"Error"
                    ,MessageBoxButtons.OK
                    ,MessageBoxIcon.Error
                    );
            }

        }

        public iTextSharp.text.Image CreateImagePDF(System.Drawing.Image image)
        {
            System.Drawing.Image pdfImage = pictureBox1.Image;
            iTextSharp.text.Image textImage = iTextSharp.text.Image.GetInstance(pdfImage, ImageFormat.Jpeg);
            textImage.Alignment = Element.ALIGN_LEFT;
            return textImage;

        }

        public Paragraph CreatParagraphPDF(string text)
        {
            Paragraph paragraph = new Paragraph(text);
            paragraph.Alignment = Element.ALIGN_LEFT;

            return paragraph;

        }

        public string path()
        {

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "PDF Files|*.pdf";


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return sfd.FileName;
            }
            return "";
        }

        private void Compress_Report_Button_Click(object sender, EventArgs e)
        {

            if (File.Exists(pdf_path))
            {
                CompressPdf(pdf_path, path());
            }

        }

        public void CompressPdf(string input, string output)
        {
            // Load a PDF document while initializing the PdfCompressor object
            PdfCompressor compressor = new PdfCompressor(input);

            // Get text compression options
            TextCompressionOptions textCompression = compressor.Options.TextCompressionOptions;
            // Compress fonts
            textCompression.CompressFonts = true;
            // Unembed fonts
            textCompression.UnembedFonts = true;

            // Get image compression options
            ImageCompressionOptions imageCompression = compressor.Options.ImageCompressionOptions;
            // Set the compressed image quality
            imageCompression.ImageQuality = ImageQuality.High;
            // Resize images
            imageCompression.ResizeImages = true;
            // Compress images
            imageCompression.CompressImage = true;

            // Save the compressed document to file
            compressor.CompressToFile(output);
        }


    }
}
