namespace Carousel
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
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this._btnForceRefresh = new System.Windows.Forms.Button();
            this._lblPhotoDirectory = new System.Windows.Forms.Label();
            this._txtPhotoDirectory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _notifyIcon
            // 
            this._notifyIcon.Text = "Carousel";
            this._notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._notifyIcon_MouseDoubleClick);
            // 
            // _btnForceRefresh
            // 
            this._btnForceRefresh.Location = new System.Drawing.Point(301, 32);
            this._btnForceRefresh.Name = "_btnForceRefresh";
            this._btnForceRefresh.Size = new System.Drawing.Size(104, 23);
            this._btnForceRefresh.TabIndex = 0;
            this._btnForceRefresh.Text = "Force Refresh";
            this._btnForceRefresh.UseVisualStyleBackColor = true;
            this._btnForceRefresh.Click += new System.EventHandler(this._btnForceRefresh_Click);
            // 
            // _lblPhotoDirectory
            // 
            this._lblPhotoDirectory.AutoSize = true;
            this._lblPhotoDirectory.Location = new System.Drawing.Point(12, 9);
            this._lblPhotoDirectory.Name = "_lblPhotoDirectory";
            this._lblPhotoDirectory.Size = new System.Drawing.Size(83, 13);
            this._lblPhotoDirectory.TabIndex = 1;
            this._lblPhotoDirectory.Text = "Photo Directory:";
            // 
            // _txtPhotoDirectory
            // 
            this._txtPhotoDirectory.Location = new System.Drawing.Point(101, 6);
            this._txtPhotoDirectory.Name = "_txtPhotoDirectory";
            this._txtPhotoDirectory.Size = new System.Drawing.Size(304, 20);
            this._txtPhotoDirectory.TabIndex = 2;
            this._txtPhotoDirectory.Text = "D:\\Google Drive\\Pictures\\Desktop Wallpapers";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 79);
            this.Controls.Add(this._txtPhotoDirectory);
            this.Controls.Add(this._lblPhotoDirectory);
            this.Controls.Add(this._btnForceRefresh);
            this.Name = "MainForm";
            this.Text = "Carousel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private System.Windows.Forms.Button _btnForceRefresh;
        private System.Windows.Forms.Label _lblPhotoDirectory;
        private System.Windows.Forms.TextBox _txtPhotoDirectory;

    }
}

