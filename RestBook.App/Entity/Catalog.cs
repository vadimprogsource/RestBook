using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestBook.App.Entity
{
    public class Catalog : BussinessEntity, ICatalog
    {
        public IEnumerable<Group> Groups { get; set; }

        IEnumerable<IGroup> ICatalog.Groups => Groups;


        public Catalog() { }
        public Catalog(ICatalog catalog) : base(catalog) 
        {
            if (catalog.Groups != null && catalog.Groups.Any())
            {
                Groups = catalog.Groups.Select(x => new Group(this,x)).ToArray();
            }
        }

    }
}
