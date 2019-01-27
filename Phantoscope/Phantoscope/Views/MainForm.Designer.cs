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
            this.PbPhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // TmRolling
            // 
            this.TmRolling.Interval = 200;
            this.TmRolling.Tick += new System.EventHandler(this.TmRolling_Tick);
            // 
            // PbPhoto
            // 
            this.PbPhoto.BackColor = System.Drawing.Color.Transparent;
            this.PbPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PbPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbPhoto.Location = new System.Drawing.Point(20, 100);
            this.PbPhoto.Name = "PbPhoto";
            this.PbPhoto.Size = new System.Drawing.Size(573, 252);
            this.PbPhoto.TabIndex = 1;
            this.PbPhoto.TabStop = false;
            this.PbPhoto.DoubleClick += new System.EventHandler(this.PbPhoto_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(613, 372);
            this.Controls.Add(this.PbPhoto);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 100, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PbPhoto;
        private System.Windows.Forms.Timer TmRolling;
    }
}