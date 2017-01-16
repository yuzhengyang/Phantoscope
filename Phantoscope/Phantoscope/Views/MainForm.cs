using Phantoscope.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Y.Utils.Net20.FileUtils;
using Y.Utils.Net20.ImageUtils;
using Y.Utils.Net20.ListUtils;
using Y.Utils.Net20.TxtUtils;

namespace Phantoscope.Views
{
    public partial class MainForm : Form
    {
        List<string> Photos;
        int Index = 0;
        Dictionary<string, Image> PhotosCache = new Dictionary<string, Image>();
        Dictionary<string, string> MottosCache = new Dictionary<string, string>();
        string Cmd = "";
        bool CanRemove = false;
        public MainForm()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲  
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            P.Init();
            FpMain.InitMouseAndContolStyle(R.Files.Layout);

            Height = R.FormSize.MainFormHeight;
            Width = R.FormSize.MainFormWidth;
            Left = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
            Top = (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2;
            TmRolling.Interval = R.Interval.Rolling;

            Text = R.Strings.FormName + "      developer：inc@live.cn";
            LbTitle.Text = R.Strings.Title;

            LbMotto.ForeColor = ColorTranslator.FromHtml(R.Color.MottoText);
            LbMotto.Font = new Font(R.FontStyle.Motto, R.FontSize.Motto);
            LbTitle.ForeColor = ColorTranslator.FromHtml(R.Color.TitleText);
            LbTitle.Font = new Font(R.FontStyle.Title, R.FontSize.Title);

            if (File.Exists(R.AppPath + @"\Images\Logo.jpg"))
                PbLogo.BackgroundImage = Image.FromFile(R.AppPath + @"\Images\Logo.jpg");

            if (File.Exists(R.AppPath + @"\Images\Photo.jpg"))
                PbPhoto.BackgroundImage = Image.FromFile(R.AppPath + @"\Images\Photo.jpg");

            if (File.Exists(R.AppPath + @"\Images\Background.jpg"))
                BackgroundImage = Image.FromFile(R.AppPath + @"\Images\Background.jpg");

            Photos = FileTool.GetFile(R.Paths.Box, "*.jpg");
            InitPhotos();
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (ListTool.HasElements(Photos))
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                {
                    if (TmRolling.Enabled)
                    {
                        TmRolling.Enabled = false;
                    }
                    else
                    {
                        TmRolling.Enabled = true;
                    }
                }
                else if (e.KeyCode == Keys.F1)
                {
                    MessageBox.Show(
                        "1、程序界面按“空格”或“回车”都可以控制滚动的开始和停止；" + Environment.NewLine +
                        "2、停止滚动后，双击照片或输入“DEL”可从滚动列表移除当前照片；" + Environment.NewLine +
                        "3、输入“JINGPING”可重置照片列表。" + Environment.NewLine +
                        "       — 于正洋 inc@live.cn"
                        , "使用帮助");
                }
                else
                {
                    Cmd += e.KeyCode;
                    DoCmd();
                }
            }
            else
            {
                MessageBox.Show("没有找到照片，请将照片放到Box文件中。", "");
            }
        }
        private void TmRolling_Tick(object sender, EventArgs e)
        {
            if (Index++ < Photos.Count - 1)
            {
                ChangePhoto();
            }
            else
            {
                Index = 0;
                ChangePhoto();
            }
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            IniTool.WriteValue(R.Files.SettingsFile, "FormSize", "MainFormWidth", Width.ToString());
            IniTool.WriteValue(R.Files.SettingsFile, "FormSize", "MainFormHeight", Height.ToString());
        }
        private void PbPhoto_DoubleClick(object sender, EventArgs e)
        {
            RemovePhoto();
        }

        private void DoCmd()
        {
            if (Cmd.Contains("JINGPING"))
            {
                Photos = FileTool.GetFile(R.Paths.Box, "*.jpg");
                Cmd = "";
            }
            else if (Cmd.Contains("DEL"))
            {
                RemovePhoto();
                Cmd = "";
            }
        }
        private void ChangePhoto() {
            CanRemove = true;
            PbPhoto.BackgroundImage = GetPhoto(Photos[Index]);
            string mottoFile = Photos[Index].ToLower().Replace(".jpg", ".txt");
            if (File.Exists(mottoFile))
            {
                string mottoText = GetMotto(mottoFile);
                LbMotto.Text = mottoText;
            }
            else
            {
                LbMotto.Text = "";
            }
        }
        private void RemovePhoto()
        {
            if (Index >= 0 && Index < Photos.Count && Photos.Count > 1 && CanRemove && !TmRolling.Enabled)
            {
                CanRemove = false;
                Photos.RemoveAt(Index);
                LbMotto.Text = "";
                if (File.Exists(R.AppPath + @"\Images\Photo.jpg"))
                    PbPhoto.BackgroundImage = Image.FromFile(R.AppPath + @"\Images\Photo.jpg");
            }
        }
        private Image GetPhoto(string key)
        {
            if (!PhotosCache.ContainsKey(key))
            {
                if (File.Exists(R.Paths.BoxThumbnail + Path.GetFileName(key)))
                {
                    PhotosCache.Add(key, Image.FromFile(R.Paths.BoxThumbnail + Path.GetFileName(key)));
                }
                else
                {
                    PhotosCache.Add(key, Image.FromFile(key));
                }
            }
            return PhotosCache[key];
        }
        private string GetMotto(string key)
        {
            if (!MottosCache.ContainsKey(key))
            {
                MottosCache.Add(key, TxtTool.Read(key, Encoding.Default));
            }
            return MottosCache[key];
        }
        private void InitPhotos()
        {
            DirTool.Create(R.Paths.BoxThumbnail);
            Photos?.ForEach(x =>
            {
                bool flag = ImageTool.MakeThumbnail(x, R.Paths.BoxThumbnail + Path.GetFileName(x), 1000, 1000, "W");
                if (flag)
                {
                    PhotosCache.Add(x, Image.FromFile(R.Paths.BoxThumbnail + Path.GetFileName(x)));
                }
            });
        }
    }
}