using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carousel
{
    public partial class MainForm : Form
    {
        private static string WALLPAPER_PATH = System.IO.Path.Combine(System.IO.Path.GetTempPath() + "wallpaper.jpg");
        private Timer _timer;

        public MainForm()
        {
            InitializeComponent();

            Bitmap icon = new Bitmap(@"..\..\..\carousel.png");
            _notifyIcon.Icon = Icon.FromHandle(icon.GetHicon());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeWallpaper();
            _timer = new Timer();
            _timer.Interval = 600000;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                _notifyIcon.Visible = true;
            }
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            ChangeWallpaper();
        }

        private void ChangeWallpaper()
        {
            int numScreens = Screen.AllScreens.Length;
            Rectangle primScreenBounds = Screen.PrimaryScreen.Bounds;
            System.Drawing.Size totSize = new Size(primScreenBounds.Width * numScreens, primScreenBounds.Height);

            Bitmap[] images = GetRandomImages(numScreens);

            System.Drawing.Bitmap bitmap = new Bitmap(totSize.Width, totSize.Height);

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            for (int i = 0; i < numScreens; i++)
            {
                graphics.DrawImage(images[i], new Rectangle(new Point(i * primScreenBounds.Width, 0), primScreenBounds.Size));
            }

            graphics.Dispose();

            SaveJpeg(WALLPAPER_PATH, bitmap, 100);
            
            bitmap.Dispose();

            foreach (var image in images)
                image.Dispose();

            Wallpaper.Set(new Uri(WALLPAPER_PATH), Wallpaper.Style.Tiled);
        }

        private Bitmap[] GetRandomImages(int count)
        {
            List<string> files = new List<string>(System.IO.Directory.GetFiles(this._txtPhotoDirectory.Text)); //TODO: Only image files
            Bitmap[] images = new Bitmap[count];

            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                int index = rnd.Next(0, files.Count);
                images[i] = new Bitmap(files[index]);
                files.RemoveAt(index);
            }

            return images;
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="path">Path to which the image would be saved.</param> 
        /// <param name="quality">An integer from 0 to 100, with 100 being the 
        /// highest quality</param> 
        /// <exception cref="ArgumentOutOfRangeException">
        /// An invalid value was entered for image quality.
        /// </exception>
        public static void SaveJpeg(string path, Image image, int quality)
        {
            //ensure the quality is within the correct range
            if ((quality < 0) || (quality > 100))
            {
                //create the error message
                string error = string.Format("Jpeg image quality must be between 0 and 100, with 100 being the highest quality.  A value of {0} was specified.", quality);
                //throw a helpful exception
                throw new ArgumentOutOfRangeException(error);
            }

            //create an encoder parameter for the image quality
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            //get the jpeg codec
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            //create a collection of all parameters that we will pass to the encoder
            EncoderParameters encoderParams = new EncoderParameters(1);
            //set the quality parameter for the codec
            encoderParams.Param[0] = qualityParam;
            //save the image using the codec and the parameters
            image.Save(path, jpegCodec, encoderParams);
        }

        /// <summary>
        /// A quick lookup for getting image encoders
        /// </summary>
        private static Dictionary<string, ImageCodecInfo> encoders = null;

        /// <summary>
        /// A quick lookup for getting image encoders
        /// </summary>
        public static Dictionary<string, ImageCodecInfo> Encoders
        {
            //get accessor that creates the dictionary on demand
            get
            {
                //if the quick lookup isn't initialised, initialise it
                if (encoders == null)
                {
                    encoders = new Dictionary<string, ImageCodecInfo>();
                }

                //if there are no codecs, try loading them
                if (encoders.Count == 0)
                {
                    //get all the codecs
                    foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
                    {
                        //add each codec to the quick lookup
                        encoders.Add(codec.MimeType.ToLower(), codec);
                    }
                }

                //return the lookup
                return encoders;
            }
        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            //do a case insensitive search for the mime type
            string lookupKey = mimeType.ToLower();

            //the codec to return, default to null
            ImageCodecInfo foundCodec = null;

            //if we have the encoder, get it to return
            if (Encoders.ContainsKey(lookupKey))
            {
                //pull the codec from the lookup
                foundCodec = Encoders[lookupKey];
            }

            return foundCodec;
        }

        private void _btnForceRefresh_Click(object sender, EventArgs e)
        {
            ChangeWallpaper();
        }

        private void _notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            _notifyIcon.Visible = false;
        } 
    }
}
