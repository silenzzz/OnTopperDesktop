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
        private static UpdateService updateService = null;
        private readonly WebClient web = new WebClient();

        public event EventHandler UpdateDownloaded;

        private readonly string zipFilePath = Environment.ExpandEnvironmentVariables(@"C:\Users\hgt16\AppData\Roaming\DeMmAge Inc\OnTopper\update.zip");

        private UpdateService()
        {
            currentVersion = typeof(Program).Assembly.GetName().Version.ToString();
            web.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(OnDownloadCompleted);
            try
            {
                webVersion = Encoding.UTF8.GetString(web.DownloadData("https://pastebin.com/raw/PyGgwApk"));
            }
            catch (Exception)
            {

            }
        }

        private void OnDownloadCompleted(object sender, EventArgs e)
        {
            //ZipFile.ExtractToDirectory(zipPath, extractPath);
            EventHandler handler = UpdateDownloaded;
            handler?.Invoke(this, e);
        }

        public void DownloadUpdate()
        {
            //C:\Users\hgt16\AppData\Roaming\DeMmAge Inc\OnTopper
            web.DownloadFileAsync(new Uri("https://sourceforge.net/projects/testprojtopper/files/OnTopper.zip/download"),
                zipFilePath);
        }

        public static UpdateService GetInstance()
        {
            if (updateService == null)
            {
                updateService = new UpdateService();
            }
            return updateService;
        }

        public bool UpdateAvaliable() 
        {
            WebRequest request = WebRequest.Create("https://pastebin.com/raw/PyGgwApk");
            try
            {
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string webVersion = reader.ReadToEnd();

                int parsedWebVersion = Convert.ToInt16(webVersion.Replace(".", ""));
                int parsedCurrentVersion = Convert.ToInt16(currentVersion.Replace(".", ""));

                if (parsedWebVersion > parsedCurrentVersion)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetWebVersion() => webVersion;
    }
}
