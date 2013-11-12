using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.settings;

namespace de.fhb.oll.mediacategorizer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Project = new Project();
            InitializeComponent();
            GoToPage("Start");
        }

        public Project Project { get { return DataContext as Project; } set { DataContext = value; } }

        private void GoToPage(string page)
        {
            frame.Navigate(new Uri("Page" + page + ".xaml", UriKind.Relative));
        }

        private void FrameDataContextChangedHandler(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdatePageDataContext();
        }

        private void FrameLoadCompleteHandler(object sender, NavigationEventArgs e)
        {
            UpdatePageDataContext();
        }

        private void UpdatePageDataContext()
        {
            var page = frame.Content as Page;
            if (page != null)
            {
                page.DataContext = DataContext;
            }
        }

        private void ExpanderExpandedHandler(object sender, RoutedEventArgs e)
        {
            var expander = (Expander)e.Source;
            foreach (var exp in navigationPanel.Children.OfType<Expander>().Where(exp => exp != expander))
            {
                exp.IsExpanded = false;
            }
            var nextPage = expander.Tag as string;
            if (nextPage != null)
            {
                GoToPage(nextPage);
            }
        }

        private bool CheckProjectStateBeforeClosing(string dialogCaption)
        {
            return Project == null || !Project.IsChanged ||
                   MessageBox.Show(this,
                       "Das aktuelle Projekt wurde nicht gespeichert.\nWollen Sie es dennoch schließen?",
                       dialogCaption, 
                       MessageBoxButton.YesNo, MessageBoxImage.Question)
                   == MessageBoxResult.Yes;
        }

        private void MenuNewProjectHandler(object sender, RoutedEventArgs e)
        {
            if (!CheckProjectStateBeforeClosing("Neues Projekt")) return;
            DataContext = new Project();
        }

        private void MenuOpenProjectHandler(object sender, RoutedEventArgs e)
        {
            if (!CheckProjectStateBeforeClosing("Projekt öffnen")) return;
            // TODO Save Project
            MessageBox.Show(this, "OpenProject", "Menu", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MenuSaveProjectHandler(object sender, RoutedEventArgs e)
        {
            // TODO Save Project As
            MessageBox.Show(this, "SaveProject", "Menu", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MenuSetupHandler(object sender, RoutedEventArgs e)
        {
            GoToPage("Setup");
            foreach (var exp in navigationPanel.Children.OfType<Expander>())
            {
                exp.IsExpanded = false;
            }
        }

        private void MenuInfoHandler(object sender, RoutedEventArgs e)
        {
            // TODO Infobox
            MessageBox.Show(this, "Info", "Menu", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ClosedHandler(object sender, EventArgs e)
        {
            var sm = (SetupManager)Application.Current.Resources["SetupManager"];
            sm.Save();
        }

    }
}
