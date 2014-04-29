using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private readonly Timer timer;

        public PageProcessing()
        {
            InitializeComponent();
            timer = new Timer(OnTimer);
        }

        private void OnTimer(object state)
        {
            if (!CheckAccess())
            {
                Dispatcher.InvokeAsync(() => OnTimer(null));
                return;
            }
            var processChain = GetProcessChain();
            lblDurationTime.Content = processChain.StartTime != null 
                ? processChain.EndTime != null
                    ? (processChain.EndTime - processChain.StartTime).Value.ToString(@"%d\:hh\:mm\:ss")
                    : (DateTime.Now - processChain.StartTime).Value.ToString(@"%d\:hh\:mm\:ss")
                : "";
        }

        private ProcessChain GetProcessChain()
        {
            return ((Project)DataContext).ProcessChain;
        }

        private void StartProcessHandler(object sender, RoutedEventArgs e)
        {
            var pc = GetProcessChain();
            if (pc.IsEnded)
            {
                pc.Reset();
            }
            pc.Start();
        }

        private void CancelProcessHandler(object sender, RoutedEventArgs e)
        {
            var pc = GetProcessChain();
            if (pc.IsRunning)
            {
                pc.Cancel();
            }
        }

        private void DataContextChangedHandler(object sender, DependencyPropertyChangedEventArgs e)
        {
            var pc = GetProcessChain();
            if (pc == null) return;
            pc.ChainStarted += ChainStartedHandler;
            pc.ChainEnded += ChainEndedHandler;
        }

        private void ChainStartedHandler(object sender, EventArgs e)
        {
            lblStatus.Content = "Verarbeiten";
            btnStartProcessing.IsEnabled = false;
            btnCancelProcessing.IsEnabled = true;
            timer.Change(0, 1000);
        }

        private void ChainEndedHandler(object sender, EventArgs e)
        {
            var pc = (ProcessChain)sender;
            lblStatus.Content = pc.IsCanceled 
                ? "Abgebrochen" 
                : (pc.IsFailed ? "Fehlgeschlagen" : "Beendet");
            btnStartProcessing.IsEnabled = true;
            btnCancelProcessing.IsEnabled = false;
            timer.Change(0, Timeout.Infinite);
            OnTimer(null);
        }
    }
}
