using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace de.fhb.oll.mediacategorizer.model
{
    partial class Project
    {
        private const string WORKING_DIR_NAME = "_tmp_";

        private void Initialize()
        {
            LoadDemoData();
        }

        [Conditional("DEBUG")]
        private void LoadDemoData()
        {
            var appDir = Path.GetDirectoryName(
                new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
                .LocalPath);
            var basePath = Path.Combine(appDir, @"..\..\..\..");

            Name = "Testprojekt";
            Description = "Ein Testprojekt zum Testen.";
            OutputDir = @"C:\Temp\MediaCategorizerOutput";

            Categories.Add(new Category
            {
                Id = "tarnung",
                Name = "Camouflage",
                Resources = new ObservableCollection<CategoryResource>
                {
                    new CategoryResource {Type = CategoryResourceType.Wikipedia, Url = "http://de.wikipedia.org/wiki/Tarnung"},
                    new CategoryResource {Type = CategoryResourceType.Html, Url = "http://www.duden.de/rechtschreibung/Tarnung"},
                },
            });
            Categories.Add(new Category
            {
                Id = "bird",
                Name = "Vogel",
                Resources = new ObservableCollection<CategoryResource>
                {
                    new CategoryResource
                    {
                        Type = CategoryResourceType.Html,
                        Url = "http://www.ausgabe.natur-lexikon.com/Voegel.php"
                    },
                    new CategoryResource
                    {
                        Type = CategoryResourceType.Wikipedia,
                        Url = "http://de.wikipedia.org/wiki/V%C3%B6gel"
                    },
                },
            });

            Media.Add(new Media
            {
                Id = "11-01-Informatik",
                Name = "11.01 Theoretische, technische, praktische, angewandte Informatik",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\11.01 Theoretische, technische, praktische, angewandte Informatik.mp4"),
            });
            Media.Add(new Media
            {
                Id = "12-01-2-Baum",
                Name = "12.01.2 Baum als Datenstruktur",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\12.01.2 Baum als Datenstruktur.mp4"),
            });

            Configuration.MainCloud.FontFamily = new FontFamily("Arial");
            Configuration.CategoryCloud.FontFamily = new FontFamily("Arial");
            Configuration.MediaCloud.FontFamily = new FontFamily("Arial");
        }

        public string GetWorkingDirectory()
        {
            return Path.Combine(OutputDir, WORKING_DIR_NAME);
        }
    }
}
