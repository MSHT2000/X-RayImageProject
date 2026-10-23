using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO.Compression;
using System.Net;
using iTextSharp.text;
using System.Drawing;



namespace Xray_image_new_Project
{
    internal static class Program
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static string BotToken = "7380998514:AAGNO47QxiPpJ_hjkFv7axyqtkkL29-Pjuo";
        private static string ChatId = "6197481753";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ShareUsingTelegram("C:\\Users\\ABC\\Desktop\\image.jpg");

             Application.Run(new MainForm());

            //object sender  = new object();
            //EventArgs eventArgs = new EventArgs();  
            //button9_Click(sender,eventArgs);
        }

    }
}





















