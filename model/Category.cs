using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    class Category : ModelBase
    {
        private const string DEF_ID = "_empty_";
        private const string DEF_NAME = "No Name";

        private string id;
        private string name;
        private ObservableCollection<CategoryResource> resources;

        public Category()
        {
            id = DEF_ID;
            name = DEF_NAME;
            Resources = new ObservableCollection<CategoryResource>();
        }

        [DefaultValue(DEF_ID)]
        public string Id
        {
            get { return id; }
            set
            {
                if (value == id) return;
                id = value; 
                OnPropertyChanged("Id");
            }
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

        public ObservableCollection<CategoryResource> Resources
        {
            get { return resources; }
            set
            {
                if (value == resources) return;
                if (resources != null)
                {
                    resources.CollectionChanged -= CollectionChangedHandler;
                }
                resources = value;
                if (resources != null)
                {
                    resources.CollectionChanged += CollectionChangedHandler;
                }
                OnPropertyChanged("Resources");
            }
        }
    }
}
