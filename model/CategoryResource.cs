using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    class CategoryResource : ModelBase
    {
        private const CategoryResourceType DEF_TYPE = CategoryResourceType.Plain;
        private const string DEF_URL = null;

        private CategoryResourceType type;
        private string url;

        public CategoryResource()
        {
            type = DEF_TYPE;
            url = DEF_URL;
        }

        [DefaultValue(DEF_TYPE)]
        public CategoryResourceType Type
        {
            get { return type; }
            set
            {
                if (value == type) return;
                type = value; 
                OnPropertyChanged("Type");
            }
        }

        [DefaultValue(DEF_URL)]
        public string Url
        {
            get { return url; }
            set
            {
                if (value == url) return;
                url = value; 
                OnPropertyChanged("Url");
            }
        }
    }
}
