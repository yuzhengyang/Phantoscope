using Azylee.Core.IOUtils.TxtUtils;

namespace Phantoscope.Commons
{
    public static class P
    {
        public static void Init()
        {
            R.Strings.FormName =  IniTool.GetString(R.Files.SettingsFile, "Strings", "FormName", R.Strings.FormName);
            R.Strings.Title = IniTool.GetString(R.Files.SettingsFile, "Strings", "Title", R.Strings.Title);

            R.Color.TitleText = IniTool.GetString(R.Files.SettingsFile, "Color", "TitleText", R.Color.TitleText);
            R.Color.MottoText = IniTool.GetString(R.Files.SettingsFile, "Color", "MottoText", R.Color.MottoText);

            R.FontStyle.Title = IniTool.GetString(R.Files.SettingsFile, "FontStyle", "Title", R.FontStyle.Title);
            R.FontStyle.Motto = IniTool.GetString(R.Files.SettingsFile, "FontStyle", "Motto", R.FontStyle.Motto);

            R.FontSize.Title = IniTool.GetInt(R.Files.SettingsFile, "FontSize", "Title", R.FontSize.Title);
            R.FontSize.Motto = IniTool.GetInt(R.Files.SettingsFile, "FontSize", "Motto", R.FontSize.Motto);
            
            P.Create();
        }
        public static void Create()
        {
            IniTool.Set(R.Files.SettingsFile, "Strings", "FormName", R.Strings.FormName);
            IniTool.Set(R.Files.SettingsFile, "Strings", "Title", R.Strings.Title);

            IniTool.Set(R.Files.SettingsFile, "Color", "MottoText", R.Color.MottoText);
            IniTool.Set(R.Files.SettingsFile, "Color", "TitleText", R.Color.TitleText);

            IniTool.Set(R.Files.SettingsFile, "FontStyle", "Motto", R.FontStyle.Motto);
            IniTool.Set(R.Files.SettingsFile, "FontStyle", "Title", R.FontStyle.Title);

            IniTool.Set(R.Files.SettingsFile, "FontSize", "Title", R.FontSize.Title.ToString());
            IniTool.Set(R.Files.SettingsFile, "FontSize", "Motto", R.FontSize.Motto.ToString());
        }
    }
}
