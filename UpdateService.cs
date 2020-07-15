using System;
using System.IO;
using System.Net;
using System.Text;
using System.IO.Compression.FileSystem;
using System.Windows.Forms;

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
            ZipFile.ExtractToDirectory(zipPath, extractPath);
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

        public bool UpdateAvaliable() => !webVersion.Equals(currentVersion);

        public string GetWebVersion() => webVersion;
    }
}
