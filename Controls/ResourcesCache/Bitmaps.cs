using System.Collections;
using System.Drawing.Imaging;
using System.Text;

namespace StockRoom11net.Controls.ResourcesCache
{
    public class Bitmaps : IDisposable
    {
        #region"Valid File.Ext in image or picture file"

        static readonly string[] _validExtensions = { ".jpg", ".bmp", ".gif", ".png", ".jpeg" };
        //private static string[] _validExtensions;

        static string[] ValidExtensions()
        {
            if (_validExtensions == null)
            {
                // load from app.config, text file, DB, wherever
            }
            return _validExtensions;
        }

        public static bool IsImageExtension(string ext)
        {
            return ValidExtensions().Contains(ext.ToLower());
        }

        //This method automatically creates a filter for the OpenFileDialog. It uses the informations
        //of the image decoders supported by Windows. It also adds information of "unknown" image
        //formats (see default case of the switch statement).
        static string SupportedImageDecodersFilter()
        {
            // ext = "*.BMP;*.DIB;*.RLE"           descr = BMP
            // ext = "*.JPG;*.JPEG;*.JPE;*.JFIF"   descr = JPEG
            // ext = "*.GIF"                       descr = GIF
            // ext = "*.TIF;*.TIFF"                descr = TIFF
            // ext = "*.PNG"                       descr = PNG

            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

            string allExtensions = "";//encoders.Select(enc => enc.FilenameExtension).Join(";").ToLowerInvariant();
            var sb = new StringBuilder(500)
                .AppendFormat("Image files  ({0})|{1}", allExtensions.Replace(";", ", "),
                              allExtensions);
            foreach (ImageCodecInfo encoder in encoders)
            {
                string ext = encoder.FilenameExtension.ToLowerInvariant();
                string caption;
                switch (encoder.FormatDescription)
                {
                    case "BMP":
                        caption = "Windows Bitmap";
                        break;
                    case "JPEG":
                        caption = "JPEG file";
                        break;
                    case "GIF":
                        caption = "Graphics Interchange Format";
                        break;
                    case "TIFF":
                        caption = "Tagged Image File Format";
                        break;
                    case "PNG":
                        caption = "Portable Network Graphics";
                        break;
                    default:
                        caption = encoder.FormatDescription;
                        break;
                }
                sb.AppendFormat("|{0}  ({1})|{2}", caption, ext.Replace(";", ", "), ext);
            }
            return sb.ToString();
        }
        //Use it like this:
        void UseItLike()
        {
            var dlg = new OpenFileDialog
            {
                Filter = SupportedImageDecodersFilter(),
                Multiselect = false,
                Title = "Choose Image"
            };
        }

        #endregion"Valid File.Ext in image or picture file"


        private ArrayList _bitmaps = new ArrayList();

        internal Bitmaps()
        { }

        internal Bitmaps(string resource)
        {
            if (!File.Exists(resource))
                return;

            if (!IsImageExtension(Path.GetExtension(resource)))
                return;

            try
            {
                var fs = new FileStream(resource, FileMode.Open, FileAccess.Read);

                _bitmaps.Add(new BitmapEx(Path.GetFileNameWithoutExtension(resource), (Bitmap)Image.FromStream(fs)));

                fs.Close();
            }
            catch (Exception error)
            {
                string Error = error.Message;
            }
        }

        internal Bitmaps(IEnumerable<string> resources)
        {
            foreach (var resource in from resource in resources
                                     where File.Exists(resource)
                                     let ext = Path.GetExtension(resource).ToLower()
                                     where ext == ".bmp" || ext == ".gif" || ext == ".jpg" || ext == ".jpeg"
                                     select resource)
            {
                _bitmaps.Add(new BitmapEx(Path.GetFileName(resource), (Bitmap)Image.FromFile(resource)));
            }
        }

        public Bitmap this[string name]
        {
            get
            {
                //foreach (BitmapEx b in _bitmaps)
                //    if (b.Name == name)
                //        return b.Bitmap;

                if (Contains(name))
                    return _bitmaps.Cast<BitmapEx>().First(b => b.Name == name).Bitmap;

                return null;
            }
        }

        /// <summary>
        /// filepaht, string paht were is file.
        /// to referenced to it used FileNameWithoutExtension.
        /// </summary>
        public void Add(string filepaht)
        {
            if (!File.Exists(filepaht))
                return;

            if (!IsImageExtension(Path.GetExtension(filepaht)))
                return;

            try
            {
                var fs = new FileStream(filepaht, FileMode.Open, FileAccess.Read);

                _bitmaps.Add(new BitmapEx(Path.GetFileNameWithoutExtension(filepaht), (Bitmap)Image.FromStream(fs)));

                fs.Close();
            }
            catch (Exception error)
            {
                string Error = error.Message;
            }
        }

        public bool Contains(string value)
        {
            return _bitmaps.Cast<BitmapEx>().Any(b => b.Name == value);
        }

        public void Dispose()
        {
            foreach (BitmapEx bmx in _bitmaps)
                bmx.Dispose();

            GC.SuppressFinalize(this);
        }

        private class BitmapEx : IDisposable
        {
            private string _name = string.Empty;
            private Bitmap _bitmap;

            /// <summary>
            /// name parameter, a name to referenced this bitmap,
            /// bitmap, bitmap itseft to be stored in memory.
            /// </summary>
            /// <param name="name"></param>
            /// <param name="bitmap"></param>
            public BitmapEx(string name, Bitmap bitmap)
            {
                _name = name;
                _bitmap = bitmap;
            }

            public string Name
            {
                get { return _name; }
            }

            public Bitmap Bitmap
            {
                get { return _bitmap; }
            }

            public void Dispose()
            {
                _bitmap.Dispose();
                _bitmap = null;
            }
        }
    }
}