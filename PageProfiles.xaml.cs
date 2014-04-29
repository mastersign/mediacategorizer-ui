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

namespace de.fhb.oll.mediacategorizer
{
    /// <summary>
    /// Interaktionslogik für PageProfiles.xaml
    /// </summary>
    public partial class PageProfiles : Page
    {
        public PageProfiles()
        {
            InitializeComponent();
        }

        private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var cell = sender as DataGridCell;
            if (!cell.IsEditing)
            {
                
                if (!cell.IsFocused) cell.Focus();
                var parent = VisualTreeHelper.GetParent(cell);
                while (parent != null && parent.GetType() != typeof(DataGridRow))
                {
                    parent = VisualTreeHelper.GetParent(parent);
                }
                var row = (DataGridRow)parent;
                if (row != null && !row.IsSelected) row.IsSelected = true;
                //if (!cell.IsSelected) cell.IsSelected = true;
            }
        }
    }
}
