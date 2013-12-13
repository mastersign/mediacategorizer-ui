using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.settings;

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
        }

        private Project Project { get { return DataContext as Project; } }

        private bool IsDropCompatible(DragEventArgs ea)
        {
            return ea.Data.GetDataPresent(DataFormats.FileDrop);
        }

        private bool IsCompatibleFile(string file)
        {
            var sm = (SetupManager)Application.Current.Resources["SetupManager"];
            var extList = sm.Setup.CompatibleMediaFileExtensions.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var ext = (Path.GetExtension(file) ?? ".").Substring(1);
            return extList.Contains(ext);
        }

        private bool IsExisting(string file)
        {
            return Project.GetMedia()
                .Select(m => m.MediaFile)
                .Contains(file);
        }

        private void DragEnterHandler(object sender, DragEventArgs e)
        {
            dropBorder.Tag = dropBorder.BorderBrush;
            dropBorder.BorderBrush = SystemColors.HighlightBrush;
        }

        private void DragLeaveHandler(object sender, DragEventArgs e)
        {
            dropBorder.BorderBrush = dropBorder.Tag as Brush;
        }

        private void DragOverHandler(object sender, DragEventArgs e)
        {
            e.Effects = IsDropCompatible(e) ? DragDropEffects.Link : DragDropEffects.None;
        }

        private void DropHandler(object sender, DragEventArgs e)
        {
            dropBorder.BorderBrush = dropBorder.Tag as Brush;
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
    }
}
