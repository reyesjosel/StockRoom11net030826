using System.Collections;

namespace MyStuff11net
{
    public class Bitmaps : IDisposable
    {
        private ArrayList _bitmaps = new ArrayList();

        internal Bitmaps()
        { }

        internal Bitmaps(string resource)
        {
            if (!File.Exists(resource))
                return;

            if (!MyCode.IsImageExtension(Path.GetExtension(resource)))
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

            if (!MyCode.IsImageExtension(Path.GetExtension(filepaht)))
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