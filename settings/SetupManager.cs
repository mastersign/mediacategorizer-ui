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

        public void Load()
        {
            var path = SetupFilePath;
            if (File.Exists(path))
            {
                var r = new XmlSerializer(typeof(Setup));
                using (var s = File.OpenRead(path))
                {
                    setup = (Setup)r.Deserialize(s);
                }
            }
            else
            {
                setup = new Setup();
            }
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Setup"));
            }
        }

        public void Save()
        {
            if (setup == null || setup.IsChanged) return;
            var w = new XmlSerializer(typeof(Setup));
            var path = SetupFilePath;
            using (var s = File.OpenWrite(path))
            {
                w.Serialize(s, setup);
            }
            setup.AcceptChanges();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
