using System.Globalization;

namespace OnTopper.Stuff
{
    class LocalizedMessageProvider
    {
        private static readonly string local = CultureInfo.CurrentCulture.ToString().Substring(3);

        public static string GetMessage(string name)
        {
            string message = Properties.Resources.ResourceManager.GetString(local + "_" + name);
            if (message == null)
            {
                return Properties.Resources.ResourceManager.GetString("EN_" + name);
            }
            return message;
        }
    }
}
