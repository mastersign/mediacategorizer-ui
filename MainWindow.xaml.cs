﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.processing;
using de.fhb.oll.mediacategorizer.settings;
using de.fhb.oll.mediacategorizer.tools;
using Microsoft.Win32;

namespace de.fhb.oll.mediacategorizer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Project project;
        private volatile bool lastProjectChangedState = false;
        private string baseWindowTitle;
        private string projectFile;

        public MainWindow()
        {
            InitializeComponent();
            baseWindowTitle = Title;
            GoToPage("Start");
            NewProject();
        }

        public Project Project
        {
            get { return project; }
            set
            {
                if (ReferenceEquals(project, value)) return;
                if (project != null)
                {
                    project.PropertyChanged -= ProjectChangedHandler;
                }
                project = value;
                DataContext = value;
                if (value != null)
                {
                    value.PropertyChanged += ProjectChangedHandler;
                    if (value.ProcessChain == null)
                    {
                        var setup = ((SetupManager)Application.Current.Resources["SetupManager"]).Setup;
                        var toolProv = ((ToolProvider)Application.Current.Resources["ToolProvider"]);
                        value.ProcessChain = new ProcessChain(setup, toolProv, value);
                    }
                }
            }
        }

        private void ProjectChangedHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (lastProjectChangedState == Project.IsChanged) return;
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke((Action)UpdateTitle);
                return;
            }
            lastProjectChangedState = Project.IsChanged;
            Title = Project != null
                ? string.Format("{0} [{1}]{2}",
                    baseWindowTitle, Path.GetFileName(projectFile) ?? "neu",
                    Project.IsChanged ? "*" : "")
                : baseWindowTitle;
        }

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
            NewProject();
        }

        private void MenuOpenProjectHandler(object sender, RoutedEventArgs e)
        {
            if (!CheckProjectStateBeforeClosing("Projekt öffnen")) return;
            if (!QueryProjectFileForOpening()) return;
            OpenProject();
        }

        private void MenuSaveProjectHandler(object sender, RoutedEventArgs e)
        {
            if (Project == null) return;
            if (projectFile == null)
            {
                if (!QueryProjectFileForSaving(false)) return;
            }
            SaveProject();
        }

        private void MenuSaveProjectAsHandler(object sender, RoutedEventArgs e)
        {
            if (Project == null) return;
            if (QueryProjectFileForSaving(true))
            {
                SaveProject();
            }
        }

        private bool QueryProjectFileForOpening()
        {
            var dlg = new OpenFileDialog
            {
                Title = "Project öffnen...",
                Filter = "Media-Categorizer-Projekt (*.mc.xml)|*.mc.xml",
            };
            if (dlg.ShowDialog(this) == true)
            {
                projectFile = dlg.FileName;
                return true;
            }
            return false;
        }

        private bool QueryProjectFileForSaving(bool saveAs)
        {
            var dlg = new SaveFileDialog
            {
                OverwritePrompt = true,
                Title = saveAs ? "Project speicher unter..." : "Project speichern...",
                Filter = "Media-Categorizer-Projekt (*.mc.xml)|*.mc.xml",
                AddExtension = true
            };
            if (dlg.ShowDialog(this) == true)
            {
                projectFile = dlg.FileName;
                return true;
            }
            return false;
        }

        private void NewProject()
        {
            projectFile = null;
            Project = new Project();
            Project.LoadDemoData();
            Project.AcceptChanges();
            UpdateTitle();
        }

        private bool OpenProject()
        {
            try
            {
                Project = Project.LoadFromFile(projectFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    "Während dem Öffnen des Projektes ist ein Fehler aufgetreten."
                    + Environment.NewLine + Environment.NewLine + ex.Message);
                return false;
            }
            UpdateTitle();
            return true;
        }

        private bool SaveProject()
        {
            try
            {
                Project.SaveToFile(projectFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    "Während dem Speichern des Projektes ist ein Fehler aufgetreten."
                    + Environment.NewLine + Environment.NewLine + ex.Message);
                return false;
            }
            UpdateTitle();
            return true;
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
