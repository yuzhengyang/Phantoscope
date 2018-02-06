namespace Phantoscope.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TmRolling = new System.Windows.Forms.Timer(this.components);
            this.FpMain = new Y.Skin.YoPanel.FlexiblePanel();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.PbPhoto = new System.Windows.Forms.PictureBox();
            this.LbMotto = new System.Windows.Forms.Label();
            this.LbTitle = new System.Windows.Forms.Label();
            this.FpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // TmRolling
            // 
            this.TmRolling.Interval = 1;
            this.TmRolling.Tick += new System.EventHandler(this.TmRolling_Tick);
            // 
            // FpMain
            // 
            //this.FpMain.AutoScaleMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.FpMain.BackColor = System.Drawing.Color.Transparent;
            this.FpMain.Controls.Add(this.PbLogo);
            this.FpMain.Controls.Add(this.PbPhoto);
            this.FpMain.Controls.Add(this.LbMotto);
            this.FpMain.Controls.Add(this.LbTitle);
            this.FpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FpMain.Location = new System.Drawing.Point(0, 0);
            this.FpMain.Name = "FpMain";
            this.FpMain.Size = new System.Drawing.Size(984, 561);
            this.FpMain.TabIndex = 3;
            // 
            // PbLogo
            // 
            this.PbLogo.BackColor = System.Drawing.Color.Transparent;
            this.PbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PbLogo.Location = new System.Drawing.Point(35, 12);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(221, 94);
            this.PbLogo.TabIndex = 0;
            this.PbLogo.TabStop = false;
            // 
            // PbPhoto
            // 
            this.PbPhoto.BackColor = System.Drawing.Color.Transparent;
            this.PbPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PbPhoto.Location = new System.Drawing.Point(52, 172);
            this.PbPhoto.Name = "PbPhoto";
            this.PbPhoto.Size = new System.Drawing.Size(350, 350);
            this.PbPhoto.TabIndex = 1;
            this.PbPhoto.TabStop = false;
            this.PbPhoto.DoubleClick += new System.EventHandler(this.PbPhoto_DoubleClick);
            // 
            // LbMotto
            // 
            this.LbMotto.BackColor = System.Drawing.Color.Transparent;
            this.LbMotto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LbMotto.Location = new System.Drawing.Point(562, 163);
            this.LbMotto.Name = "LbMotto";
            this.LbMotto.Size = new System.Drawing.Size(265, 368);
            this.LbMotto.TabIndex = 2;
            this.LbMotto.Text = "~~~~~~";
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.BackColor = System.Drawing.Color.Transparent;
            this.LbTitle.Location = new System.Drawing.Point(305, 59);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(41, 12);
            this.LbTitle.TabIndex = 1;
            this.LbTitle.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.FpMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.FpMain.ResumeLayout(false);
            this.FpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.PictureBox PbPhoto;
        private System.Windows.Forms.Label LbMotto;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Timer TmRolling;
        private Y.Skin.YoPanel.FlexiblePanel FpMain;
    }
}