using System;
using System.Collections.Generic;
using System.Text;
using Y.Utils.IOUtils.TxtUtils;

namespace Phantoscope.Commons
{
    public static class P
    {
        public static void Init()
        {
            R.Strings.FormName =  IniTool.GetStringValue(R.Files.SettingsFile, "Strings", "FormName", R.Strings.FormName);
            R.Strings.Title = IniTool.GetStringValue(R.Files.SettingsFile, "Strings", "Title", R.Strings.Title);

            R.Color.TitleText = IniTool.GetStringValue(R.Files.SettingsFile, "Color", "TitleText", R.Color.TitleText);
            R.Color.MottoText = IniTool.GetStringValue(R.Files.SettingsFile, "Color", "MottoText", R.Color.MottoText);

            R.FontStyle.Title = IniTool.GetStringValue(R.Files.SettingsFile, "FontStyle", "Title", R.FontStyle.Title);
            R.FontStyle.Motto = IniTool.GetStringValue(R.Files.SettingsFile, "FontStyle", "Motto", R.FontStyle.Motto);

            R.FontSize.Title = IniTool.GetIntValue(R.Files.SettingsFile, "FontSize", "Title", R.FontSize.Title);
            R.FontSize.Motto = IniTool.GetIntValue(R.Files.SettingsFile, "FontSize", "Motto", R.FontSize.Motto);

            R.FormSize.MainFormWidth = IniTool.GetIntValue(R.Files.SettingsFile, "FormSize", "MainFormWidth", R.FormSize.MainFormWidth);
            R.FormSize.MainFormHeight = IniTool.GetIntValue(R.Files.SettingsFile, "FormSize", "MainFormHeight", R.FormSize.MainFormHeight);

            R.Interval.Rolling = IniTool.GetIntValue(R.Files.SettingsFile, "Interval", "Rolling", R.Interval.Rolling);

            P.Create();
        }
        public static void Create()
        {
            IniTool.WriteValue(R.Files.SettingsFile, "Strings", "FormName", R.Strings.FormName);
            IniTool.WriteValue(R.Files.SettingsFile, "Strings", "Title", R.Strings.Title);

            IniTool.WriteValue(R.Files.SettingsFile, "Color", "MottoText", R.Color.MottoText);
            IniTool.WriteValue(R.Files.SettingsFile, "Color", "TitleText", R.Color.TitleText);

            IniTool.WriteValue(R.Files.SettingsFile, "FontStyle", "Motto", R.FontStyle.Motto);
            IniTool.WriteValue(R.Files.SettingsFile, "FontStyle", "Title", R.FontStyle.Title);

            IniTool.WriteValue(R.Files.SettingsFile, "FontSize", "Title", R.FontSize.Title.ToString());
            IniTool.WriteValue(R.Files.SettingsFile, "FontSize", "Motto", R.FontSize.Motto.ToString());

            IniTool.WriteValue(R.Files.SettingsFile, "FormSize", "MainFormWidth", R.FormSize.MainFormWidth.ToString());
            IniTool.WriteValue(R.Files.SettingsFile, "FormSize", "MainFormHeight", R.FormSize.MainFormHeight.ToString());

            IniTool.WriteValue(R.Files.SettingsFile, "Interval", "Rolling", R.Interval.Rolling.ToString());
        }
    }
}
