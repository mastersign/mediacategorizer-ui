using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    class Project : ModelBase
    {
        private const string DEF_NAME = "No Name";
        private const string DEF_DESCRIPTION = "No Description";
        private const string DEF_OUTPUT_DIR = "output";

        private string name;
        private string description;
        private string outputDir;
        private Configuration configuration;
        private ObservableCollection<Category> categories;
        private ObservableCollection<Media> media;

        public Project()
        {
            Configuration = new Configuration();
            Categories = new ObservableCollection<Category>();
            Media = new ObservableCollection<Media>();
        }

        [DefaultValue(DEF_NAME)]
        public string Name
        {
            get { return name; }
            set
            {
                if (value == name) return;
                name = value;
                OnPropertyChanged("Name");
            }
        }

        [DefaultValue(DEF_DESCRIPTION)]
        public string Description
        {
            get { return description; }
            set
            {
                if (value == description) return;
                description = value;
                OnPropertyChanged("Description");
            }
        }

        [DefaultValue(DEF_OUTPUT_DIR)]
        public string OutputDir
        {
            get { return outputDir; }
            set
            {
                if (value == outputDir) return;
                outputDir = value;
                OnPropertyChanged("OutputDir");
            }
        }

        public Configuration Configuration
        {
            get { return configuration; }
            set
            {
                if (value == configuration) return;
                if (configuration != null)
                {
                    configuration.PropertyChanged -= ChildPropertyChangedHandler;
                }
                configuration = value;
                if (configuration != null)
                {
                    configuration.PropertyChanged += ChildPropertyChangedHandler;
                }
                OnPropertyChanged("Configuration");
            }
        }

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                if (value == categories) return;
                if (categories != null)
                {
                    categories.CollectionChanged -= CollectionChangedHandler;
                }
                categories = value;
                if (categories != null)
                {
                    categories.CollectionChanged += CollectionChangedHandler;
                }
                OnPropertyChanged("Categories");
            }
        }

        public ObservableCollection<Media> Media
        {
            get { return media; }
            set
            {
                if (value == media) return;
                if (media != null)
                {
                    media.CollectionChanged -= CollectionChangedHandler;
                }
                media = value;
                if (media != null)
                {
                    media.CollectionChanged += CollectionChangedHandler;
                }
                OnPropertyChanged("Media");
            }
        }
    }
}
