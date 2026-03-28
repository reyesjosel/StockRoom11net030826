namespace MyStuff11net
{
    public class ResourcesCache : IDisposable
    {
        private Bitmaps _bitmaps;
        private Icons _icons;
        private Sounds _sounds;

        public ResourcesCache()
        {
            if (Bitmaps == null)
                _bitmaps = new Bitmaps();
        }

        /// <summary>
        /// Will load in memory all resources front target directory.
        /// _bitmaps = new Bitmaps(string[] resources = Directory.GetFiles(targetDirectory));
        /// _icons   = new Icons  (string[] resources = Directory.GetFiles(targetDirectory));
        /// _sounds  = new Sounds (string[] resources = Directory.GetFiles(targetDirectory));
        /// </summary>
        /// <param name="targetDirectory"></param>
        public ResourcesCache(string targetDirectory)
        {
            string[] resources = Directory.GetFiles(targetDirectory);

            _bitmaps = new Bitmaps(resources);
            _icons = new Icons(resources);
            _sounds = new Sounds(resources);
        }

        public Bitmap GetBitmap(string filepaht)
        {
            var filename = Path.GetFileNameWithoutExtension(filepaht);

            if (Bitmaps.Contains(filename))
                return _bitmaps[filename];

            _bitmaps.Add(filepaht);

            if (Bitmaps.Contains(filename))
                return _bitmaps[filename];

            return null;
        }

        public Bitmaps Bitmaps
        {
            get { return _bitmaps; }
        }

        public Icons Icons
        {
            get { return _icons; }
        }

        public Sounds Sounds
        {
            get { return _sounds; }
        }

        public void Dispose()
        {
            if (Bitmaps != null)
                _bitmaps.Dispose();

            if (_icons != null)
                _icons.Dispose();

            if (Sounds != null)
                _sounds.Dispose();

            GC.SuppressFinalize(this);
        }

    }
}
