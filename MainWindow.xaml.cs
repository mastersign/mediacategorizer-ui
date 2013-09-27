using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace de.fhb.oll.mediacategorizer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyNavigate("Start");
        }

        private void MyNavigate(string page)
        {
            frame.Navigate(new Uri("Page" + page + ".xaml", UriKind.Relative));
        }

        private void ExpanderExpandedHandler(object sender, RoutedEventArgs e)
        {
            var expander = (Expander)e.Source;
            foreach (var exp in navigationPanel.Children.OfType<Expander>().Where(exp => exp != expander))
            {
                exp.IsExpanded = false;
            }
            var nextPage = ((string)expander.Tag);
            MyNavigate(nextPage);
        }

        private void MenuNewProjectHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, "NewProject", "Menu", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MenuOpenProjectHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, "OpenProject", "Menu", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
