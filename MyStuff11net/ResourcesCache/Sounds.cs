using System.Collections;

namespace MyStuff11net
{
    public class Sounds : IDisposable
    {
        private ArrayList _sounds = new ArrayList();

        internal Sounds(string[] resources)
        {
            foreach (string resource in resources)
            {
                if (Path.GetExtension(resource).ToLower() == ".wav")
                    _sounds.Add(new Sound(resource, File.ReadAllBytes(resource)));
            }
        }

        public Sound this[string name]
        {
            get
            {
                foreach (Sound se in _sounds)
                    if (se.Name == name.ToLower())   // Search case-insensitive
                        return se;

                return null;
            }
        }

        public void Dispose()
        {
            foreach (Sound se in _sounds)
                se.Dispose();

            GC.SuppressFinalize(this);
        }
    }

    public class Sound : IDisposable
    {
        [System.Runtime.InteropServices.DllImport("Winmm.dll")]
        private static extern bool PlaySound(byte[] data, IntPtr hMod, UInt32 dwFlags);
        private const UInt32 SND_ASYNC = 1;
        private const UInt32 SND_MEMORY = 4;

        private string _name = string.Empty;
        private byte[] _data;

        internal Sound(string name, byte[] data)
        {
            _data = data;
            string[] tokens = name.Split('.');

            // Pluck the simple name of the resource out of
            // the fully qualified string.  tokens[tokens.Length - 1]
            // is the file extension, also not needed.
            _name = tokens[tokens.Length - 2];

        }

        public string Name
        {
            get { return _name; }
        }

        public void Play()
        {
            PlaySound(_data, IntPtr.Zero, SND_ASYNC | SND_MEMORY);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}