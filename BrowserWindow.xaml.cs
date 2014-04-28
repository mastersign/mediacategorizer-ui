using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace de.fhb.oll.mediacategorizer
{
    /// <summary>
    /// Interaktionslogik für BrowserWindow.xaml
    /// </summary>
    public partial class BrowserWindow : Window
    {
        public BrowserWindow()
        {
            InitializeComponent();
        }

        public string Address { get; private set; }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            Go();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            browser.Navigate("https://www.google.de/");
        }

        private void btnEncyclopedia_Click(object sender, RoutedEventArgs e)
        {
            browser.Navigate("http://de.wikipedia.org/");
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            Address = txtUrl.Text;
            Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Address = null;
            Hide();
        }

        private void browser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            txtUrl.Text = e.Uri.ToString();
        }

        private void browser_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            txtUrl.Text = e.Uri.ToString();
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Go();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Go();
        }

        private void Go()
        {
            var input = txtUrl.Text;
            Uri uri;
            if (!Uri.TryCreate(input, UriKind.RelativeOrAbsolute, out uri))
            {
                browser.Navigate("about:blank");
                txtUrl.Text = input;
                txtUrl.SelectAll();
                return;
            }
            if (!uri.IsAbsoluteUri)
            {
                txtUrl.Text = "http://" + input;
                Go();
                return;
            }
            try
            {
                browser.Navigate(uri.ToString());
            }
            catch (Exception) { }
        }
    }
}
