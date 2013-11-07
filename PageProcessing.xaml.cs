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
using de.fhb.oll.mediacategorizer.settings;
using de.fhb.oll.mediacategorizer.tools;

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

        public ProcessChain ProcessChain
        {
            get { return (ProcessChain) gridProcessChain.DataContext; }
            set { gridProcessChain.DataContext = value; }
        }

        private static SetupManager GetSetupManager()
        {
            return Application.Current.Resources["SetupManager"] as SetupManager;
        }

        private void StartProcessHandler(object sender, RoutedEventArgs e)
        {
            var sm = GetSetupManager();
            var toolProvider = new ToolProvider(sm.Setup);
            ProcessChain = new ProcessChain(sm.Setup, toolProvider, DataContext as Project);
            ProcessChain.Start();
        }
    }
}
