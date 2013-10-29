using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    partial class Project
    {
        private void Initialize()
        {
            Categories.Add(new Category
            {
                Id = "tarnung",
                Name = "Camouflage",
                Resources = new ObservableCollection<CategoryResource>
                {
                    new CategoryResource { Type = CategoryResourceType.Wikipedia, Url="http://de.wikipedia.org/wiki/Tarnung" },
                    new CategoryResource { Type = CategoryResourceType.Html, Url="http://www.duden.de/rechtschreibung/Tarnung" },
                },
            });
            Categories.Add(new Category
            {
                Id = "bird",
                Name = "Vogel",
                Resources = new ObservableCollection<CategoryResource>
                {
                    new CategoryResource {Type = CategoryResourceType.Html, Url="http://www.ausgabe.natur-lexikon.com/Voegel.php"},
                    new CategoryResource { Type = CategoryResourceType.Wikipedia, Url="http://de.wikipedia.org/wiki/V%C3%B6gel" },
                },
            });
        }
    }
}
