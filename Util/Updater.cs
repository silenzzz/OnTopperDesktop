using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace OnTopper.Util
{
    public class Updater
    {
        private readonly string currentVersion = typeof(Program).Assembly.GetName().Version.ToString();

        public bool UpdateAvailable()
        {
            var request = WebRequest.Create("https://pastebin.com/raw/PyGgwApk");
            try
            {
                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException());
                var webVersion = reader.ReadToEnd();

                int parsedWebVersion = Convert.ToInt16(webVersion.Replace(".", ""));
                int parsedCurrentVersion = Convert.ToInt16(currentVersion.Replace(".", ""));

                return parsedWebVersion > parsedCurrentVersion;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void InstallUpdate()
        {
            Process.Start("OnTopperUpdater.exe");
            Application.Exit();
        }
    }
}
