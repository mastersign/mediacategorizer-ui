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
        }

        private Project ProjectModel {get { return DataContext as Project; }}

        private Category SelectedCategory {get { return categoryDataGrid.SelectedItem as Category; }}

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
    }
}
