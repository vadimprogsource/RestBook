using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class CatalogModel : EntityModel
    {

        public GroupModel[] Groups { get; set; } 

        public CatalogModel(ICatalog catalog) : base(catalog)
        {
            if (catalog.Groups != null && catalog.Groups.Any())
            {
                Groups = catalog.Groups.Select(x => new GroupModel(x)).ToArray();
            }
        }
    }
}
