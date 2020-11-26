using System.Globalization;

namespace OnTopper.Stuff
{
    class LocalizedMessageProvider
    {
        private static readonly string local = CultureInfo.CurrentCulture.ToString().Substring(3);

        public static string GetMessage(string name)
        {
            return Properties.Resources.ResourceManager.GetString(local + "_" + name);
        }
    }
}
