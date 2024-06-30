using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace OnTopper
{
    public class UpdateService
    {
        private readonly string currentVersion;
        private readonly string webVersion;
        private static UpdateService _updateService;
        private readonly WebClient web = new WebClient();

        public event EventHandler UpdateDownloaded;

        private readonly string zipFilePath = Environment.ExpandEnvironmentVariables(@"C:\Users\hgt16\AppData\Roaming\DeMmAge Inc\OnTopper\update.zip");

        private UpdateService()
        {
            currentVersion = typeof(Program).Assembly.GetName().Version.ToString();
            web.DownloadFileCompleted += OnDownloadCompleted;
            try
            {
                webVersion = Encoding.UTF8.GetString(web.DownloadData("https://pastebin.com/raw/PyGgwApk"));
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void OnDownloadCompleted(object sender, EventArgs e)
        {
            //ZipFile.ExtractToDirectory(zipPath, extractPath);
            var handler = UpdateDownloaded;
            handler?.Invoke(this, e);
        }

        public void DownloadUpdate()
        {
            web.DownloadFileAsync(new Uri("https://sourceforge.net/projects/testprojtopper/files/OnTopper.zip/download"),
                zipFilePath);
        }

        public static UpdateService GetInstance()
        {
            return _updateService ?? (_updateService = new UpdateService());
        }

        public bool UpdateAvailable() 
        {
            var request = WebRequest.Create("https://pastebin.com/raw/PyGgwApk");
            try
            {
                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var _webVersion = reader.ReadToEnd();

                int parsedWebVersion = Convert.ToInt16(_webVersion.Replace(".", ""));
                int parsedCurrentVersion = Convert.ToInt16(currentVersion.Replace(".", ""));

                return parsedWebVersion > parsedCurrentVersion;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetWebVersion() => webVersion;
    }
}
