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
using System.Windows.Navigation;
using System.Windows.Shapes;
using de.fhb.oll.mediacategorizer.model;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace de.fhb.oll.mediacategorizer
{
    /// <summary>
    /// Interaktionslogik für PageStart.xaml
    /// </summary>
    public partial class PageStart : Page
    {
        public PageStart()
        {
            InitializeComponent();
        }

        private Project GetProject()
        {
            return (Project)DataContext;
        }

        private void ChooseOutputDirectoryHandler(object sender, RoutedEventArgs e)
        {
            var dlg = new CommonOpenFileDialog("Ausgabeverzeichnis wählen...")
            {
                IsFolderPicker = true,
                InitialDirectory = txtOutputDirectory.Text,
            };
            var res = dlg.ShowDialog(Window.GetWindow(this));
            if (res == CommonFileDialogResult.Ok)
            {
                GetProject().OutputDir = dlg.FileName;
            }
        }
    }
}
