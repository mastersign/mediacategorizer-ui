using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using de.fhb.oll.mediacategorizer.model;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace de.fhb.oll.mediacategorizer
{
    /// <summary>
    /// Interaktionslogik für PageCategories.xaml
    /// </summary>
    public partial class PageCategories : Page
    {
        public PageCategories()
        {
            InitializeComponent();

            openFileDlg = new CommonOpenFileDialog
            {
                Title = "Lokale Datei als Ressource hinzufügen...",
                Multiselect = true,
                AllowNonFileSystemItems = false,
                EnsureFileExists = true
            };
            openFileDlg.Filters.Add(new CommonFileDialogFilter("Ressource", ".txt;.htm;.html"));
            openFileDlg.Filters.Add(new CommonFileDialogFilter("Textdatei", ".txt"));
            openFileDlg.Filters.Add(new CommonFileDialogFilter("HTML-Datei", ".htm;.html"));
            openFileDlg.Filters.Add(new CommonFileDialogFilter("Alle Dateien", ".*"));
        }

        private readonly CommonOpenFileDialog openFileDlg;

        private Project ProjectModel { get { return DataContext as Project; } }

        private Category SelectedCategory { get { return categoryDataGrid.SelectedItem as Category; } }

        private void CreateCategoryHandler(object sender, RoutedEventArgs e)
        {
            if (ProjectModel == null) return;
            ProjectModel.Categories.Add(new Category());
        }

        private void DeleteCategoryHandler(object sender, RoutedEventArgs e)
        {
            if (ProjectModel == null) return;
            if (SelectedCategory == null) return;
            ProjectModel.Categories.Remove(SelectedCategory);
        }

        private void CategorySelectionChangedHandler(object sender, RoutedEventArgs e)
        {
            btnDeleteCategory.IsEnabled = SelectedCategory != null;
        }

        private void NewRessourceClickHandler(object sender, RoutedEventArgs e)
        {
            var dlg = new TaskDialog();
            dlg.Cancelable = true;
            dlg.Caption = "Neue Ressource hinzufügen...";
            dlg.InstructionText = "Wählen Sie einen Ressourcen-Typ aus.";
            dlg.StandardButtons = TaskDialogStandardButtons.None;
            var tdbClose = new TaskDialogCommandLink("file", "Lokale Datei",
                "Eine lokale Text- oder HTML-Datei mit Textinhalt.");
            tdbClose.Click += (s, args) => dlg.Close(TaskDialogResult.No);
            dlg.Controls.Add(tdbClose);
            var tdbSave = new TaskDialogCommandLink("web", "Webserver",
                "Eine Text- oder HTML-Quelle auf einem Web-Server. Das kann eine Wikipedia-Seite sein oder eine andere Web-Seite mit Textinhalten.");
            tdbSave.Click += (s, args) => dlg.Close(TaskDialogResult.Yes);
            dlg.Controls.Add(tdbSave);
            var tdbCancel = new TaskDialogCommandLink("cancel", "Abbrechen");
            tdbCancel.Click += (s, args) => dlg.Close(TaskDialogResult.Cancel);
            dlg.Controls.Add(tdbCancel);
            var result = dlg.Show();

            switch (result)
            {
                case TaskDialogResult.No:
                    NewLocalRessource();
                    break;
                case TaskDialogResult.Yes:
                    NewWebRessource();
                    break;
            }
        }

        private void NewLocalRessource()
        {
            var result = openFileDlg.ShowDialog(Window.GetWindow(this));
            if (result != CommonFileDialogResult.Ok) return;
            foreach (var fileName in openFileDlg.FileNames)
            {
                NewLocalRessource(fileName);
            }
        }

        private void NewLocalRessource(string path)
        {
            var ext = System.IO.Path.GetExtension(path);
            var type = CategoryResourceType.Plain;
            if (ext != null)
            {
                switch (ext.ToLowerInvariant())
                {
                    case ".txt":
                        type = CategoryResourceType.Plain;
                        break;
                    case ".htm":
                    case ".html":
                        type = IsWikipediaPage(path)
                            ? CategoryResourceType.Wikipedia
                            : CategoryResourceType.Html;
                        break;
                }
            }

            NewRessource(type, new Uri("file:///" + path));
        }

        private static bool IsWikipediaPage(string path)
        {
            var html = System.IO.File.ReadAllText(path);
            return html.Contains("href=\"//de.wikipedia.org/");
        }

        private void NewWebRessource()
        {

        }

        private void NewRessource(CategoryResourceType type, Uri uri)
        {
            if (SelectedCategory == null)
            {
                return;
            }
            SelectedCategory.Resources.Add(new CategoryResource() { Type = type, Url = uri.ToString() });
        }

        private static bool IsDropCompatible(DragEventArgs ea)
        {
            return ea.Data.GetDataPresent(DataFormats.FileDrop);
        }

        private void DragOverHandler(object sender, DragEventArgs e)
        {
            e.Effects = IsDropCompatible(e) ? DragDropEffects.Link : DragDropEffects.None;
        }

        private void DropHandler(object sender, DragEventArgs e)
        {
            var items = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (items != null)
            {
                foreach (var item in items.OrderBy(s => s))
                {
                    TryAddRessource(item);
                }
            }
        }

        private static bool IsCompatibleFile(string file)
        {
            var extList = new[] { ".txt", ".htm", ".html" };
            var ext = (System.IO.Path.GetExtension(file) ?? ".").Substring(1);
            return extList.Contains(ext);
        }

        private bool IsExisting(string file)
        {
            if (SelectedCategory == null) return false;
            var uri = new Uri("file:///" + file).ToString();
            return SelectedCategory.Resources
                .Select(r => r.Url)
                .Contains(uri);
        }

        private void TryAddRessource(string item)
        {
            if (File.Exists(item))
            {
                if (!IsCompatibleFile(item)) return;
                if (IsExisting(item)) return;
                NewLocalRessource(item);
            }
            else if (Directory.Exists(item))
            {
                var items = Directory.GetFiles(item, "*.*", SearchOption.AllDirectories);
                foreach (var item2 in items)
                {
                    TryAddRessource(item2);
                }
            }
        }


        private void DeleteRessourceClickHandler(object sender, RoutedEventArgs e)
        {
            if (SelectedCategory == null) return;
            foreach (var item in resourceDataGrid.SelectedItems.Cast<CategoryResource>().ToArray())
            {
                SelectedCategory.Resources.Remove(item);
            }
        }

        private void ResourceSelectionChangedHandler(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteRessource.IsEnabled = (resourceDataGrid.SelectedItem as CategoryResource) != null;
        }
    }
}
