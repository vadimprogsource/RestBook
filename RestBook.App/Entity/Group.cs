using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestBook.App.Entity
{
    public class Group : BussinessEntity, IGroup
    {

        public Catalog Catalog { get; set; }

        public IEnumerable<Product> Products { get; set; }

        ICatalog IGroup.Catalog => Catalog;

        IEnumerable<IProduct> IGroup.Products => Products;

        public Group() { }
        public Group(Catalog catalog, IGroup group) : base(group)
        {
            Catalog = catalog;

            if (group.Products != null && group.Products.Any())
            {
                Products = group.Products.Select(x => new Product(Catalog, this, x)).OrderBy(x=>x.ReorderLevel).ToArray();
            }
        }
    }
}
