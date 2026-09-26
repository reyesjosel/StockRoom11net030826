using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace StockRoom11net
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCompanyName.Text = AssemblyCompany;
            LoadReleaseNotes();
        }

        private void LoadReleaseNotes()
        {
            string notesPath = Path.Combine(AppContext.BaseDirectory, "Properties", "ReleaseNotes.txt");
            textBoxDescription.Text = File.Exists(notesPath)
                ? File.ReadAllText(notesPath)
                : "No release notes available.";

            string releaseDatePath = Path.Combine(AppContext.BaseDirectory, "Properties", "ReleaseDate.txt");
            label_DateTimeRelease.Text = File.Exists(releaseDatePath)
                ? $"Released: {File.ReadAllText(releaseDatePath).Trim()}"
                : "Release date unavailable.";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return Assembly.GetExecutingAssembly().GetName().Name ?? "StockRoom11net";
            }
        }

        public string AssemblyVersion
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                if (version == null)
                {
                    return "0.0.0";
                }

                // Compensate: the version bump runs BeforeTargets="Publish" (after Build),
                // so the compiled assembly always reflects the version from the previous publish.
                // Displaying patch+1 shows the actual version of THIS running build.
                var displayVersion = new Version(version.Major, version.Minor, version.Build + 1);
                return displayVersion.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
