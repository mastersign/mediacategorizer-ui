using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Controls;

namespace de.fhb.oll.mediacategorizer
{
    /// <summary>
    /// Interaktionslogik für PageAbout.xaml
    /// </summary>
    public partial class PageAbout : Page
    {
        public PageAbout()
        {
            InitializeComponent();

            tbTitle.Text = AssemblyTitle;
            tbProduct.Text = AssemblyProduct;
            tbVersion.Text = AssemblyVersion;
            tbDescription.Text = AssemblyDescription;
            tbCompany.Text = AssemblyCompany;
            tbCopyright.Text = AssemblyCopyright;
        }

        #region Assembly Metainfos

        private static Assembly MainAssembly
        {
            get { return Assembly.GetEntryAssembly(); }
        }

        private static string AssemblyTitle
        {
            get
            {
                var attributes = MainAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(new Uri(MainAssembly.CodeBase).LocalPath);
            }
        }

        private static string AssemblyProduct
        {
            get
            {
                var attributes = MainAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return attributes.Length == 0 ? ""
                    : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        private static string AssemblyVersion
        {
            get { return MainAssembly.GetName().Version.ToString(3); }
        }

        private static string AssemblyDescription
        {
            get
            {
                var attributes = MainAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return attributes.Length == 0 ? ""
                    : ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        private static string AssemblyCompany
        {
            get
            {
                var attributes = MainAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return attributes.Length == 0 ? ""
                    : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        private static string AssemblyCopyright
        {
            get
            {
                var attributes = MainAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return attributes.Length == 0 ? ""
                    : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        #endregion

        private void LicenseClickHandler(object sender, EventArgs e)
        {
            Process.Start("http://opensource.org/licenses/MIT");
        }
    }
}
