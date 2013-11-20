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
using System.Xml.Serialization;
using de.fhb.oll.mediacategorizer.processing;

namespace de.fhb.oll.mediacategorizer.model
{
    partial class Project
    {
        private const string WORKING_DIR_NAME = "_tmp_";

        private static readonly XmlSerializer serializer;

        static Project()
        {
            try
            {
                serializer = new XmlSerializer(typeof(Project));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void Initialize()
        {
        }

        public void SaveToFile(string file)
        {
            using (var s = File.Open(file, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(s, this);
            }
            AcceptChanges();
        }

        public static Project LoadFromFile(string file)
        {
            Project result;
            using (var s = File.Open(file, FileMode.Open, FileAccess.Read))
            {

                result = (Project)serializer.Deserialize(s);
            }
            result.AcceptChanges();
            return result;
        }

        public string GetWorkingDirectory()
        {
            return Path.Combine(OutputDir, WORKING_DIR_NAME);
        }

        [XmlIgnore]
        public ProcessChain ProcessChain { get; set; }

        [Conditional("DEBUG")]
        public void LoadDemoData()
        {
            var appDir = Path.GetDirectoryName(
                new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
                .LocalPath);
            var basePath = Path.Combine(appDir, @"..\..\..\..");

            Name = "Testprojekt";
            Description = "Ein Testprojekt zum Testen.";
            OutputDir = @"C:\Temp\MediaCategorizerOutput";

            #region Categories

            Categories.Add(new Category
            {
                Id = "info",
                Name = "Informatik",
                Resources = new ObservableCollection<CategoryResource>
                {
                    new CategoryResource {Type = CategoryResourceType.Wikipedia, Url = "http://de.wikipedia.org/wiki/Informatik"},
                    new CategoryResource {Type = CategoryResourceType.Wikipedia, Url = "http://de.wikipedia.org/wiki/Theoretische_Informatik"},
                    new CategoryResource {Type = CategoryResourceType.Wikipedia, Url = "http://de.wikipedia.org/wiki/Praktische_Informatik"},
                    new CategoryResource {Type = CategoryResourceType.Wikipedia, Url = "http://de.wikipedia.org/wiki/Technische_Informatik"},
                },
            });
            Categories.Add(new Category
            {
                Id = "queue",
                Name = "Datenstrukturen - Warteschlange",
                Resources = new ObservableCollection<CategoryResource>
                {
                    new CategoryResource{Type = CategoryResourceType.Wikipedia,Url = "http://de.wikipedia.org/wiki/Warteschlange_%28Datenstruktur%29"},
                },
            });
            Categories.Add(new Category
            {
                Id = "stack",
                Name = "Datenstrukturen - Stapel",
                Resources = new ObservableCollection<CategoryResource>
                {
                    new CategoryResource{Type = CategoryResourceType.Wikipedia,Url = "http://de.wikipedia.org/wiki/Stapelspeicher"},
                },
            });
            Categories.Add(new Category
            {
                Id = "tree",
                Name = "Datenstrukturen - Baum",
                Resources = new ObservableCollection<CategoryResource>
                {
                    new CategoryResource{Type = CategoryResourceType.Wikipedia,Url = "http://de.wikipedia.org/wiki/Baum_%28Graphentheorie%29"},
                },
            });
            Categories.Add(new Category
            {
                Id = "math",
                Name = "Mathematik",
                Resources = new ObservableCollection<CategoryResource>
                {
                    new CategoryResource{Type = CategoryResourceType.Wikipedia,Url = "http://de.wikipedia.org/wiki/Mathematik"},
                    new CategoryResource{Type = CategoryResourceType.Wikipedia,Url = "http://de.wikipedia.org/wiki/Rechnen"},
                    new CategoryResource{Type = CategoryResourceType.Wikipedia,Url = "http://de.wikipedia.org/wiki/Zahl"},
                    new CategoryResource{Type = CategoryResourceType.Wikipedia,Url = "http://de.wikipedia.org/wiki/Arithmetik"},
                },
            });
            Categories.Add(new Category
            {
                Id = "oeko",
                Name = "Wirtschaft",
                Resources = new ObservableCollection<CategoryResource>
                {
                    new CategoryResource{Type = CategoryResourceType.Wikipedia,Url = "http://de.wikipedia.org/wiki/Wirtschaft"},
                    new CategoryResource{Type = CategoryResourceType.Wikipedia,Url = "http://de.wikipedia.org/wiki/Wirtschaftswissenschaft"},
                    new CategoryResource{Type = CategoryResourceType.Wikipedia,Url = "http://de.wikipedia.org/wiki/Bank"},
                    new CategoryResource{Type = CategoryResourceType.Wikipedia,Url = "http://de.wikipedia.org/wiki/Geld"},
                },
            });

            #endregion

            #region Media

            Media.Add(new Media
            {
                Id = "11-01-Informatik",
                Name = "11.01 Theoretische, technische, praktische, angewandte Informatik",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\11.01 Theoretische, technische, praktische, angewandte Informatik.mp4"),
            });
            Media.Add(new Media
            {
                Id = "12-01-1-Datenstrukturen",
                Name = "12.01.1 Datenstrukturen, Array, Queue, Stack",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\12.01.1 Datenstrukturen, Array, Queue, Stack.mp4"),
            });
            Media.Add(new Media
            {
                Id = "12-01-2-Baum",
                Name = "12.01.2 Baum als Datenstruktur",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\12.01.2 Baum als Datenstruktur.mp4"),
            });
            Media.Add(new Media
            {
                Id = "Algo1",
                Name = "Algorithmen und Datenstrukturen 001",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\Algorithmen und Datenstrukturen 001.mp4"),
            });
            Media.Add(new Media
            {
                Id = "Algo2",
                Name = "Algorithmen und Datenstrukturen 002",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\Algorithmen und Datenstrukturen 002.mp4"),
            });
            Media.Add(new Media
            {
                Id = "Algo3",
                Name = "Algorithmen und Datenstrukturen 003",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\Algorithmen und Datenstrukturen 003.mp4"),
            });
            Media.Add(new Media
            {
                Id = "Algo4",
                Name = "Algorithmen und Datenstrukturen 004",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\Algorithmen und Datenstrukturen 004.mp4"),
            });
            Media.Add(new Media
            {
                Id = "Bernoulli",
                Name = "Binomialverteilung_Formel von Bernoulli, Stochastik, Nachhilfe online, Hilfe in Mathe",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\Binomialverteilung_Formel von Bernoulli, Stochastik, Nachhilfe online, Hilfe in Mathe (720).mp4"),
            });
            Media.Add(new Media
            {
                Id = "Hypothesentest",
                Name = "Einseitiger(rechtsseitiger) Hypothesentest_mit Ablesen aus der Tabelle, Stochastik, Nachhilfe online",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\Einseitiger(rechtsseitiger) Hypothesentest_mit Ablesen aus der Tabelle, Stochastik, Nachhilfe online (720).mp4"),
            });
            Media.Add(new Media
            {
                Id = "Parabeln",
                Name = "Parabeln_Quadratische Funktion_en Übersicht (Scheitelpunkt,Stauchung,Streckung,etc.)",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\Parabeln_Quadratische Funktion_en Übersicht (Scheitelpunkt,Stauchung,Streckung,etc.) (720).mp4"),
            });
            Media.Add(new Media
            {
                Id = "Gauss",
                Name = "Gauß-Algorithmus_Lineares Gleichungssystem lösen (einfach_schnell erklärt), Nachhilfe online",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\Gauß-Algorithmus_Lineares Gleichungssystem lösen (einfach_schnell erklärt), Nachhilfe online (720).mp4"),
            });
            Media.Add(new Media
            {
                Id = "Lambda",
                Name = "Der Lambda-Kalkül",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\Der Lambda-Kalkül (720).mp4"),
            });
            Media.Add(new Media
            {
                Id = "IS-Kurve",
                Name = "IS-Kurve im Vier-Quadrantenschema Die Herleitung",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\IS-Kurve im Vier-Quadrantenschema Die Herleitung (720).mp4"),
            });
            Media.Add(new Media
            {
                Id = "Makrooekonomie",
                Name = "Makroökonomie online lernen - VWL Tutorium",
                MediaFile = Path.Combine(basePath, @"Media\Video\de-DE\Makroökonomie online lernen - VWL Tutorium (360).mp4"),
            });

            #endregion

            Configuration.MainCloud.FontFamily = new FontFamily("Segoe UI");
            Configuration.CategoryCloud.FontFamily = new FontFamily("Segoe UI");
            Configuration.MediaCloud.FontFamily = new FontFamily("Segoe UI");
        }

    }
}
