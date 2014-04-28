using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.settings;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace de.fhb.oll.mediacategorizer
{
    /// <summary>
    /// Interaktionslogik für PageMedia.xaml
    /// </summary>
    public partial class PageMedia : Page
    {
        public PageMedia()
        {
            InitializeComponent();

            openFileDlg = new CommonOpenFileDialog()
            {
                Title = "Medien hinzufügen...",
                Multiselect = true,
                AllowNonFileSystemItems = false,
                EnsureFileExists = true
            };
        }

        private static string[] GetAudioFileExtensions()
        {
            var sm = (SetupManager) Application.Current.Resources["SetupManager"];
            return sm.Setup.GetAudioFileExtensions();
        }

        private static string[] GetVideoFileExtensions()
        {
            var sm = (SetupManager)Application.Current.Resources["SetupManager"];
            return sm.Setup.GetVideoFileExtensions();
        }

        private void UpdateMediaFileExtensions()
        {
            var audioExts = GetAudioFileExtensions();
            var videoExts = GetVideoFileExtensions();
            var extList = audioExts.Concat(videoExts);
            openFileDlg.Filters.Clear();
            openFileDlg.Filters.Add(new CommonFileDialogFilter("Mediendateien", string.Join(";", extList)));
            openFileDlg.Filters.Add(new CommonFileDialogFilter("Audiodateien", string.Join(";", audioExts)));
            openFileDlg.Filters.Add(new CommonFileDialogFilter("Videodateien", string.Join(";", videoExts)));
        }

        private readonly CommonOpenFileDialog openFileDlg;

        private Project Project { get { return DataContext as Project; } }

        private static bool IsDropCompatible(DragEventArgs ea)
        {
            return ea.Data.GetDataPresent(DataFormats.FileDrop);
        }

        private static bool IsCompatibleFile(string file)
        {
            var extList = GetAudioFileExtensions().Concat(GetVideoFileExtensions());
            var ext = (Path.GetExtension(file) ?? ".").Substring(1);
            return extList.Contains(ext);
        }

        private bool IsExisting(string file)
        {
            return Project.GetMedia()
                .Select(m => m.MediaFile)
                .Contains(file);
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
                    TryAddMedia(item);
                }
            }
        }

        private void TryAddMedia(string item)
        {
            if (File.Exists(item))
            {
                if (!IsCompatibleFile(item)) return;
                if (IsExisting(item)) return;
                var name = Path.GetFileNameWithoutExtension(item);
                var id = GenerateId(name);
                Project.Media.Add(new Media { Id = id, Name = name, MediaFile = item });
            }
            else if (Directory.Exists(item))
            {
                var items = Directory.GetFiles(item, "*.*", SearchOption.AllDirectories);
                foreach (var item2 in items)
                {
                    TryAddMedia(item2);
                }
            }
        }

        private string GenerateId(string name)
        {
            var maxExistingId = ExistingMediaIds()
                .Concat(new[] { 0 })
                .Max();
            return (maxExistingId + 1).ToString("0000");
        }

        private IEnumerable<int> ExistingMediaIds()
        {
            foreach (var m in Project.GetMedia())
            {
                int idNo;
                if (int.TryParse(m.Id, out idNo)) yield return idNo;
            }
        }

        private void MediaSelectionChangedHandler(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteMedia.IsEnabled = (mediaDataGrid.SelectedItem as Media) != null;
        }

        private void CreateMediaHandler(object sender, RoutedEventArgs e)
        {
            UpdateMediaFileExtensions();
            var result = openFileDlg.ShowDialog(Window.GetWindow(this));
            if (result != CommonFileDialogResult.Ok) return;
            foreach (var fileName in openFileDlg.FileNames)
            {
                TryAddMedia(fileName);
            }
        }

        private void DeleteMediaHandler(object sender, RoutedEventArgs e)
        {
            if (Project == null) return;
            var items = mediaDataGrid.SelectedItems.Cast<Media>().ToArray();
            foreach (var item in items)
            {
                Project.Media.Remove(item);
            }
        }
    }
}
