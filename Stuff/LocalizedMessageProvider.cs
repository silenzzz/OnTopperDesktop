using OnTopper.Properties;
using System.Globalization;

namespace OnTopper.Stuff
{
    class LocalizedMessageProvider
    {
        private static readonly string currentLocale = CultureInfo.CurrentCulture.ToString().Substring(3);

        public static string GetMessage(string name)
        {
            string language = Settings.Default.Language;
            if (language.Equals("System") == false)
            {
                return GetLocalizedMessage(language, name);
            } else
            {
                SetSystemLanguage();
            }

            string message = Resources.ResourceManager.GetString(currentLocale + "_" + name);
            if (message == null)
            {
                return Resources.ResourceManager.GetString("EN_" + name);
            }
            return message;
        }

        private static string GetLocalizedMessage(string language, string name)
        {
            if (language.Equals("English"))
            {
                SaveAbbreviation("EN");
                return Resources.ResourceManager.GetString("EN_" + name);
            } else if (language.Equals("Русский"))
            {
                SaveAbbreviation("RU");
                return Resources.ResourceManager.GetString("RU_" + name);
            } else
            {
                SetSystemLanguage();
                return Resources.ResourceManager.GetString("EN_" + name);
            }
        }

        private static void SaveAbbreviation(string abbreviation)
        {
            Settings.Default.LanguageAbbreviation = abbreviation;
            SaveSettings();
        }

        private static void SetSystemLanguage()
        {
            Settings.Default.LanguageAbbreviation = currentLocale;
            SaveSettings();
        }

        private static void SaveSettings()
        {
            Settings.Default.Save();
        }
    }
}
