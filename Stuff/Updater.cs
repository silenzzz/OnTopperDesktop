using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace OnTopper.Stuff
{
    public class Updater
    {
        private readonly string currentVersion = typeof(Program).Assembly.GetName().Version.ToString();

        public bool UpdateAvaliable()
        {
            // TODO: ¯\_(ツ)_ /¯ 
            WebRequest request = WebRequest.Create("https://pastebin.com/raw/PyGgwApk");
            try
            {
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string webVersion = reader.ReadToEnd();
                if (webVersion.Equals(currentVersion) == false)
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

        public void InstallUpdate()
        {
            Process.Start("OnTopperUpdater.exe");
            Application.Exit();
        }
    }
}
