using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace de.fhb.oll.mediacategorizer.settings
{
    class SetupManager : INotifyPropertyChanged
    {
        private Setup setup;

        public SetupManager()
        {
            Load();
        }

        public string SetupFilePath
        {
            get
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                var appPath = new Uri(assembly.CodeBase).LocalPath;
                return Path.Combine(
                    Path.GetDirectoryName(appPath) ?? string.Empty,
                    assembly.GetName().Name + ".setup.xml");
            }
        }

        public Setup Setup
        {
            get { return setup; }
            private set
            {
                if (ReferenceEquals(setup, value)) return;
                setup = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Setup"));
                }
            }
        }

        public void Load()
        {
            var path = SetupFilePath;
            if (File.Exists(path))
            {
                var r = new XmlSerializer(typeof(Setup));
                using (var s = File.OpenRead(path))
                {
                    Setup = (Setup)r.Deserialize(s);
                }
            }
            else
            {
                Setup = new Setup();
            }
        }

        public void Save()
        {
            if (Setup == null || !Setup.IsChanged) return;
            var w = new XmlSerializer(typeof(Setup));
            var path = SetupFilePath;
            using (var s = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                w.Serialize(s, Setup);
            }
            Setup.AcceptChanges();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
