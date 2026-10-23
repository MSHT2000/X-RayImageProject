//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Drive.v3.Data;
//using Googl   e.Apis.Drive.v3;
//using Google.Apis.Services;
using System;
using System.Net.Http;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;

namespace X_Ray
{
    internal class OnlineService
    {
        //private static string credentialsFile = "C:\Users\wwwgu\Downloads\x-ray-425308-97b0093d53c3.json";


        private static readonly HttpClient httpClient = new HttpClient();
        private static string BotToken = "7380998514:AAGNO47QxiPpJ_hjkFv7axyqtkkL29-Pjuo";
        private static string ChatId = "6197481753";

        //public static void ShareUsingWhatsApp(string filePath)
        //{
        //    string shareUrl = $"https://wa.me/?text={Uri.EscapeDataString("Check out this file sent by C# code : " + filePath)}";

        //    Process.Start(new ProcessStartInfo(shareUrl) { UseShellExecute = true });
        //}

        //public static void ShareUsingWhatsApp(string filePath)
        //{
        //    try
        //    {
        //        string fileUrl = UploadFileToDrive(filePath).Result;
        //        ShareUsingWhatsApp(fileUrl);

        //        MessageBox.Show("File sent successfully via WhatsApp.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error sending file via WhatsApp: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private static async Task<string> UploadFileToDrive(string filePath)
        //{
        //    var fileMetadata = new Google.Apis.Drive.v3.Data.File()
        //    {
        //        Name = Path.GetFileName(filePath),
        //        MimeType = GetMimeType(filePath)
        //    };

        //    byte[] byteArray = System.IO.File.ReadAllBytes(filePath);
        //    MemoryStream stream = new MemoryStream(byteArray);

        //    var credential = await GoogleCredential.FromFileAsync(credentialsFile, System.Threading.CancellationToken.None)
        //        .ConfigureAwait(false);
        //    credential = credential.CreateScoped(new[] { DriveService.ScopeConstants.Drive });

        //    var driveService = new DriveService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = "Your Application Name",
        //    });

        //    var request = driveService.Files.Create(fileMetadata, stream, fileMetadata.MimeType);
        //    request.Fields = "id,webViewLink";

        //    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        //    var uploadRequest = await request.UploadAsync(cancellationTokenSource.Token).ConfigureAwait(false);

        //    if (uploadRequest.Status == Google.Apis.Upload.UploadStatus.Completed)
        //    {
        //        var file = request.ResponseBody;

        //        var permission = new Permission()
        //        {
        //            Role = "reader",
        //            Type = "anyone"
        //        };

        //        var permissionRequest = driveService.Permissions.Create(permission, file.Id);
        //        await permissionRequest.ExecuteAsync().ConfigureAwait(false);

        //        return file.WebViewLink;
        //    }
        //    else
        //    {
        //        throw new Exception("File upload failed.");
        //    }
        //}

        public static async Task ShareUsingTelegram(string filePath)
        {
             Console.WriteLine(1);
            try
            {
                Console.WriteLine(2);

                string url = $"https://api.telegram.org/bot{BotToken}/sendDocument";
                Console.WriteLine(3);

                using (var form = new MultipartFormDataContent())
                {
                    Console.WriteLine(5);

                    using (var fileStream = File.OpenRead(filePath))
                    {
                        Console.WriteLine(6);

                        form.Add(new StreamContent(fileStream), "document", Path.GetFileName(filePath));
                        Console.WriteLine(7);

                        form.Add(new StringContent(ChatId), "chat_id");
                        Console.WriteLine(8);

                        var response = await httpClient.PostAsync(url, form);
                        Console.WriteLine(9);

                        //var value = response.EnsureSuccessStatusCode();
                        Console.WriteLine(10);

                        Console.WriteLine("File sent successfully!");
                        Console.WriteLine(11);

                    }
                Console.WriteLine(12);
                }
                Console.WriteLine(13);

            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        

        //public  static string GetMimeType(string filePath)
        //{
        //    string mimeType = "application/unknown";
        //    string ext = Path.GetExtension(filePath).ToLower();

        //    switch (ext)
        //    {
        //        case ".txt":
        //            mimeType = "text/plain";
        //            break;
        //        case ".pdf":
        //            mimeType = "application/pdf";
        //            break;
        //        case ".zip":
        //            mimeType = "application/zip";
        //            break;
        //        case ".png":
        //            mimeType = "image/png";
        //            break;
        //    }
        //    return mimeType;
        //}

    }
}
