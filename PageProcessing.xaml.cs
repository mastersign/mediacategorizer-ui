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
using de.fhb.oll.mediacategorizer.processing;

namespace de.fhb.oll.mediacategorizer
{
    /// <summary>
    /// Interaktionslogik für PageProcessing.xaml
    /// </summary>
    public partial class PageProcessing : Page
    {
        public PageProcessing()
        {
            InitializeComponent();
        }

        private ProcessChain GetProcessChain()
        {
            return ((Project)DataContext).ProcessChain;
        }

        private void StartProcessHandler(object sender, RoutedEventArgs e)
        {
            GetProcessChain().Start();
        }
    }
}
