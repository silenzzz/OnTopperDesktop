using System.Globalization;
using OnTopper.Properties;

namespace OnTopper.Util
{
    public static class LocalizedMessageProvider
    {
        private static readonly string CurrentLocale = CultureInfo.CurrentCulture.ToString().Substring(3);
        private static readonly Settings Settings = Settings.Default;

        public static string GetMessage(string name)
        {
            var language = Settings.Language;
            if (language != "System")
            {
                return GetLocalizedMessage(language, name);
            }

            SetSystemLanguage();

            var message = Resources.ResourceManager.GetString(CurrentLocale + "_" + name);
            return message ?? Resources.ResourceManager.GetString("EN_" + name);
        }

        private static string GetLocalizedMessage(string language, string name)
        {
            switch (language)
            {
                case "English":
                    SaveAbbreviation("EN");
                    return Resources.ResourceManager.GetString("EN_" + name);
                case "Русский":
                    SaveAbbreviation("RU");
                    return Resources.ResourceManager.GetString("RU_" + name);
                default:
                    SetSystemLanguage();
                    return Resources.ResourceManager.GetString("EN_" + name);
            }
        }

        private static void SaveAbbreviation(string abbreviation)
        {
            Settings.LanguageAbbreviation = abbreviation;
            SaveSettings();
        }

        private static void SetSystemLanguage()
        {
            Settings.LanguageAbbreviation = CurrentLocale;
            SaveSettings();
        }

        private static void SaveSettings()
        {
            Settings.Save();
        }
    }
}
