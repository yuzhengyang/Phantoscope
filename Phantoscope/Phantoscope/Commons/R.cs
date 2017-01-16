using System;
using System.Drawing;
using System.Windows.Forms;

namespace Phantoscope.Commons
{
    public static class R
    {
        public static string AppName = "yuzhyn.Phantoscope";
        public static bool Release = false;
        public static string Name = Environment.MachineName;
        public static string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        public static class Interval
        {
            public static int Rolling = 1;
        }
        public static class Strings
        {
            public static string FormName = "";
            public static string Title = "";
        }

        public static class Files
        {
            public static string AppFile = Application.ExecutablePath;
            public static string Layout = AppPath + @"\Layout.xml";
            public static string SettingsFile = AppPath + @"\Settings.ini";
        }
        public static class Paths
        {
            public static string Box = AppPath + @"\Box";
            public static string Cache = AppPath + @"\Cache";
            public static string BoxThumbnail = Cache + @"\BoxThumbnail\";
            public static string DataPath;//应用数据目录
            public static string SettingsPath;//应用配置信息目录
        }
        public static class FontStyle
        {
            public static string Title = "微软雅黑";
            public static string Motto = "微软雅黑";
        }
        public static class FontSize
        {
            public static int Title = 20;
            public static int Motto = 12;
        }
        public static class Color
        {
            public static string MottoText = "#000000";
            public static string TitleText = "#000000";
        }
        public static class FormSize
        {
            public static int MainFormWidth = 1300;
            public static int MainFormHeight = 700;
        }
    }
}
