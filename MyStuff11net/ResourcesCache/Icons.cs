using System.Collections;

namespace MyStuff11net
{
    public class Icons : IDisposable
    {
        private ArrayList _icons = new ArrayList();

        internal Icons(string[] resources)
        {
            foreach (string resource in resources)
            {
                if (Path.GetExtension(resource).ToLower() == ".ico")
                    _icons.Add(new IconEx(resource, new Icon(resource)));
            }
        }

        public void Dispose()
        {
            foreach (IconEx ie in _icons)
                ie.Dispose();

            GC.SuppressFinalize(this);
        }

        private class IconEx : IDisposable
        {
            private string _name = string.Empty;
            private Icon _icon;

            public IconEx(string name, Icon icon)
            {
                string[] tokens = name.Split('.');

                // Pluck the simple name of the resource out of
                // the fully qualified string.  tokens[tokens.Length - 1]
                // is the file extension, also not needed.
                _name = tokens[tokens.Length - 2].ToLower();
                _icon = icon;
            }

            public string Name
            {
                get { return _name; }
            }

            public Icon Icon
            {
                get { return _icon; }
            }

            public void Dispose()
            {
                _icon.Dispose();
            }
        }
    }
}
