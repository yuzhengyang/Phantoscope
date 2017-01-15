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

            Photos = FileTool.GetFile(R.Paths.Box, "*.jpg");
            Text = R.Strings.FormName + "      developer：inc@live.cn";
            LbTitle.Text = R.Strings.Title;

            LbMotto.ForeColor = ColorTranslator.FromHtml(R.Color.MottoText);
            LbMotto.Font = new Font(R.FontStyle.Motto, R.FontSize.Motto);
            LbTitle.ForeColor = ColorTranslator.FromHtml(R.Color.TitleText);
            LbTitle.Font = new Font(R.FontStyle.Title, R.FontSize.Title);
            PbLogo.BackgroundImage = Image.FromFile(R.AppPath + @"\Images\Logo.jpg");
            PbPhoto.BackgroundImage = Image.FromFile(R.AppPath + @"\Images\Photo.jpg");
            BackgroundImage = Image.FromFile(R.AppPath + @"\Images\Background.jpg");

            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(PbPhoto.ClientRectangle);
                using (Region region = new Region(gp))
                {
                    PbPhoto.Region = region;
                }
            }
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
            }
            else
            {
                MessageBox.Show("没有找到照片，请将照片放到Box文件中。", "");
            }
        }
        private void TmRolling_Tick(object sender, EventArgs e)
        {
            if (Index < Photos.Count)
            {
                PbPhoto.BackgroundImage = GetPhoto(Photos[Index]);
                string mottoFile = Photos[Index].Replace(".jpg", ".txt");
                if (File.Exists(mottoFile))
                {
                    string mottoText = GetMotto(mottoFile);
                    LbMotto.Text = mottoText;
                }
                else
                {
                    LbMotto.Text = "";
                }
                Index++;
            }
            else
            {
                Index = 0;
            }
        }

        private Image GetPhoto(string key)
        {
            if (!PhotosCache.ContainsKey(key))
            {
                PhotosCache.Add(key, Image.FromFile(key));
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

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            IniTool.WriteValue(R.Files.SettingsFile, "FormSize", "MainFormWidth", Width.ToString());
            IniTool.WriteValue(R.Files.SettingsFile, "FormSize", "MainFormHeight", Height.ToString());
        }
    }
}
