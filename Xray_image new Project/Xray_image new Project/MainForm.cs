using AForge.Imaging.Filters;
using AForge.Math;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.ServiceModel.Syndication;
using System.Text;
using System.Windows.Forms;


namespace Xray_image_new_Project
{
    public partial class MainForm : Form
    {
        //instance of MianForm Class
       public static MainForm instance;
       private static readonly HttpClient httpClient = new HttpClient();
       private static string BotToken = "7380998514:AAGNO47QxiPpJ_hjkFv7axyqtkkL29-Pjuo";
       private static string ChatId = "6197481753";
        //uploade Iamge 
        public Bitmap Original_Image;
        object sender = new object();


        public MainForm()
        {
            InitializeComponent();
            instance = this;
            //resize MainForm PictureBox to x=256 , y=256
            this.pictureBox1.Size =  new Size(256,256); 
        }
        //open image function
        public void Open_Button_Click_1(object sender, EventArgs e, PictureBox picturebox)
        {
           
                OpenFileDialog ofd = new OpenFileDialog();

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
            try
            {

                if (DialogResult.OK==ofd.ShowDialog())
                {
                    picturebox.Image = new Bitmap(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        //save image function
        public void Save(object sender, EventArgs e, PictureBox picturebox)
        {
            if (picturebox.Image != null)
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
                picturebox.Image.Save(sfd.FileName);
            }
            }
        }
        //ColorMap Button
        private void ColorMap_Button_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null)
            {

                ColorMapForm s= new ColorMapForm();
                s.Show();

            }
            else
            {
                MessageBox.Show("Image not Found !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Compare Between Tow Iamge Button 
        private void Comapre_Button_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {

           CompareForm compareform = new CompareForm();
            compareform.Show();
            }
            else
            {
                MessageBox.Show
                    (
                    " image you want compare not found!!! "
                    , "Error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error
                    );
            }
           
        }
        //change Quality iamge  Button
        private void Sharpen_Button_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image!= null)
            {

            Sharpen sharpen =new Sharpen();
            sharpen.Show();
            }
            else
            {
                MessageBox.Show("Image not found !!!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }

        }
        //Record Audio Button
        private void Record_Audio_Button_Click(object sender, EventArgs e)
        {
            RecordAudio Record = new RecordAudio();
            Record.Show();
        }
        //Compress Image Button
        private void Compress_Image_Button_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null)
            {
            CompressForm compressForm = new CompressForm(); ;
             
                compressForm.Show();
            }
            else
            {
                MessageBox.Show("Image not found !!!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error ); 
            }

        }
        //Add Comment on Image Button
        private void Comment_Button_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {

            CommentForm commentform = new CommentForm();
            commentform.Show();
            
            }
            else
            {
                MessageBox.Show
                    (
                    "image you wnat comment it not found!!!"
                    ,"Error"
                    ,MessageBoxButtons.OK
                    ,MessageBoxIcon.Error 
                    );
            }
        }
        //Classification Image Button 
        private void Classification_Image_Button(object sender, EventArgs e)
        {
            if(this.pictureBox1.Image!=null)
            {
            ClassificationForm classificationForm = new ClassificationForm();
            classificationForm.Show();
            }
            else
            {
                MessageBox.Show
                    (
                    "The image to be classified has not been selected !!!"
                    ,"Error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error
                    );
            }

        }
        //Rest PictureBox Image to Original Image Button
        private void Reset_Image_Button_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image!= null)
            {

            pictureBox1.Image = null;
            Original_Image = new Bitmap(Original_Image);
            pictureBox1.Image = Original_Image;
            }
            else
            {
                MessageBox.Show
                    (
                    "Image not Found !!!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }
        //Crop Image Button
        private void Crop_Button_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
            CropForm cropForm = new CropForm(); 
            cropForm.Show();
            }
            else
            {
                MessageBox.Show(
                    "image you want Crop it not found!!!"
                    ,"Error"
                    ,MessageBoxButtons.OK
                    ,MessageBoxIcon.Error 
                    );
            }

        }
        //Open Image From Device Button
        private void open_Button_Click(object sender, EventArgs e)
        {
            Open_Button_Click_1(sender, e, pictureBox1);
            Original_Image = (Bitmap)pictureBox1.Image;
        }
        //Save Image on Device Button
        private void Save_Button_Click(object sender, EventArgs e)
        {
             Save(sender, e, pictureBox1);
        }
        //Make Report Button
        private void Report_Button_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
            }
            else
            {
                MessageBox.Show
                    (
                    "Image is Requierd!!!"
                    , "Error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error
                    );
            }
        }
        //Filter Images Button
        private void Filter_Image_Button_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm();
            filterForm.Show();
        }

        private void Share_Button_Click(object sender, EventArgs e)
        {
            EventArgs eventArgs = new EventArgs();

            button9_Click(sender,e,path());

        }

        public string path()

        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Multiselect = true;
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
                    "|ZIP File |*.zip" +
                    "|WAVE File |*.wav" +
                    "|RAR File |*.rar" +
                    "|All Files|*.*";



            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return sfd.FileName;
            }
            return "";
        }

        private static void button9_Click(object sender, EventArgs e,string path)
        {
            
            string audioFilePath = "C:\\Users\\ABC\\Desktop\\New folder (2)\\audio.wav";
            string zipFilePath = Path.Combine(Path.GetTempPath(), "new.zip");

            Bitmap loadedImage2 = new Bitmap("C:\\Users\\ABC\\Desktop\\d.jpg");
            Console.WriteLine("MUNEB");

            // Compress the files first
            try
            {
                using (FileStream zipToOpen = new FileStream(zipFilePath, FileMode.Create))
                {
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        string pdfReportPath = Path.Combine(Path.GetTempPath(), "MedicalReport.pdf");
                        using (FileStream stream = new FileStream(pdfReportPath, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();
                            pdfDoc.Add(new Paragraph("Your medical report content here"));
                            if (pdfDoc.PageNumber == 0)
                            {
                                pdfDoc.NewPage();
                                pdfDoc.Add(new Paragraph("Mohammad"));
                            }
                            pdfDoc.Close();
                        }
                        archive.CreateEntryFromFile(pdfReportPath, "LoadedImage.jpg");

                        if (File.Exists(audioFilePath))
                        {
                            archive.CreateEntryFromFile(audioFilePath, Path.GetFileName(audioFilePath));
                        }
                        else
                        {
                            MessageBox.Show("Audio file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (loadedImage2 != null)
                        {
                            string imageFilePath = Path.Combine(Path.GetTempPath(), "LoadedImage.png");
                            loadedImage2.Save(imageFilePath);
                            archive.CreateEntryFromFile(imageFilePath, "LoadedImage.png");
                        }
                        else
                        {
                            MessageBox.Show("No image loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while compressing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Send the ZIP file via Telegram
            try
            {

                //const int ChatId = 1234567890; // the chat we want
                //const string Filepath = @"C:\...\photo.jpg";

                //using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
                //await client.LoginUserIfNeeded();
                //var chats = await client.Messages_GetAllChats(null);
                //InputPeer peer = chats.chats[ChatId];
                //var inputFile = await client.UploadFileAsync(Filepath);
                //await client.SendMediaAsync(peer, "Here is the photo", inputFile);

                string botToken = "6469101685:AAHwnBZAsG1YywO8BWN3C3GETUfF4E9baxc";
                string chatId = "5608667920"; // This should be your actual chat ID
                string url = $"https://api.telegram.org/bot{botToken}/sendDocument";

                

                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "multipart/form-data");
                    var fileBytes = System.IO.File.ReadAllBytes(path);

                    string boundary = "------------------------" + DateTime.Now.Ticks.ToString("x");
                    client.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);

                    var postData = new MemoryStream();
                    var writer = new StreamWriter(postData);
                    writer.Write("--" + boundary + "\r\n");
                    writer.Write("Content-Disposition: form-data; name=\"chat_id\"\r\n\r\n");
                    writer.Write(chatId + "\r\n");
                    writer.Write("--" + boundary + "\r\n");
                    writer.Write("Content-Disposition: form-data; name=\"document\"; filename=\"" + Path.GetFileName(path) + "\"\r\n");
                    writer.Write("Content-Type: application/octet-stream\r\n\r\n");
                    writer.Flush();
                    postData.Write(fileBytes, 0, fileBytes.Length);
                    writer.Write("\r\n--" + boundary + "--");
                    writer.Flush();
                    postData.Position = 0;

                    client.UploadData(url, "POST", postData.ToArray());
                }
                
                
                MessageBox.Show("File sent via Telegram");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while sending the file via Telegram: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
   
    

