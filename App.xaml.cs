using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using de.fhb.oll.mediacategorizer.settings;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var setupManager = new SetupManager();
            var toolProvider = new ToolProvider(setupManager.Setup);
            Resources.Add("SetupManager", setupManager);
            Resources.Add("ToolProvider", toolProvider);
        }
    }
}
