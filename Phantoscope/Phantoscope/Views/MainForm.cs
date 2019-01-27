using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.IOUtils.FileUtils;
using Phantoscope.Commons;
using Phantoscope.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Phantoscope.Views
{
    public partial class MainForm : Form
    {
        string Cmd = "";
        int CurrentUserIndex = -1;
        List<UserModel> UserList = new List<UserModel>();

        #region 初始化
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
            //FpMain.InitMouseAndContolStyle(R.Files.Layout);

            WindowState = FormWindowState.Maximized;

            Text = R.Strings.FormName + "      :yuzhengyang";
            //LbTitle.Text = R.Strings.Title;

            //LbTitle.ForeColor = ColorTranslator.FromHtml(R.Color.TitleText);
            //LbTitle.Font = new Font(R.FontStyle.Title, R.FontSize.Title);

            //if (File.Exists(R.AppPath + @"\Images\Logo" + R.Files.ImgExt))
            //PbLogo.BackgroundImage = Image.FromFile(R.Files.Logo);

            if (File.Exists(R.AppPath + @"\Images\Background" + R.Files.ImgExt))
                BackgroundImage = Image.FromFile(R.Files.Background);

            UserList = GetUsers();
        }
        #endregion

        #region 滚动照片
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Ls.Ok(UserList))
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
            if (Ls.Ok(UserList))
            {
                int index = R.Random.Next(UserList.Count);
                if (index == CurrentUserIndex) index = R.Random.Next(UserList.Count);

                CurrentUserIndex = index;
                PbPhoto.BackgroundImage = UserList[CurrentUserIndex].Photo;
            }
        }
        #endregion

        private void PbPhoto_DoubleClick(object sender, EventArgs e)
        {
            RemovePhoto();
        }

        private void DoCmd()
        {
            if (Cmd.Contains("JINGPING"))
            {
                //Photos = FileTool.GetFile(R.Paths.Box, "*" + R.Files.ImgExt);
                Cmd = "";
            }
            else if (Cmd.Contains("DEL"))
            {
                RemovePhoto();
                Cmd = "";
            }
        }
        private void RemovePhoto()
        {
            if (CurrentUserIndex >= 0 && UserList.Count > 1)
            {
                UserList.RemoveAt(CurrentUserIndex);
                PbPhoto.Image = null;
            }
        }
        #region 获取资源信息（图片和个性签名）
        private List<UserModel> GetUsers()
        {
            List<UserModel> users = new List<UserModel>();
            List<string> imgs = FileTool.GetFile(R.Paths.Box, "*" + R.Files.ImgExt);
            if (Ls.Ok(imgs))
            {
                foreach (var img in imgs)
                {
                    UserModel user = new UserModel();
                    user.Name = Path.GetFileNameWithoutExtension(img);
                    user.ImgFile = img;
                    user.Photo = Image.FromFile(img);
                    users.Add(user);
                }
            }
            return users;
        }
        #endregion

        #region 获取
        //创建位图
        Bitmap bmp = new Bitmap(600, 600);//位图大小600*600
        //创建位图的Graphics对象
        Graphics gr1 = Graphics.FromImage(bmp);
        //将位图清黑
        gr1.Clear(Color.Black);

        //在位图上画出要画的东西
        if (myBall != null)
        {
            myBall.Show(gr1);
        }
        for (int i = 0; i<bullnum; i++)
        {
            if (bull[i] != null) bull[i].Show(gr1);
}
        if (a != null)
        {
            a.Show(gr1);
        }
        //创建Picshow的Graphics对象
        Graphics gr2 = PicShow.CreateGraphics();
//将bmp画到picshow上
gr2.DrawImage(bmp, 0, 0);
        //释放内存！！这一步必须要，不然内存会爆炸的
        bmp.Dispose();
        bmp = null;
        gr1.Dispose();
        gr1 = null;
        gr2.Dispose();
        gr2 = null;
--------------------- 
作者：Fanstorm丶
来源：CSDN
原文：https://blog.csdn.net/wf824284257/article/details/53888611 
版权声明：本文为博主原创文章，转载请附上博文链接！
        #endregion
    }
}