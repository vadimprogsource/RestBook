using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Entity
{
    public class DataGroup : DataEntity,IGroup
    {
        public Guid CatalogGuid    { get; set; }
        public DataCatalog Catalog { get; set; }

        public IEnumerable<DataProduct> Products { get; set; }

   
        ICatalog IGroup.Catalog => Catalog;

        IEnumerable<IProduct> IGroup.Products => Products;


        public override void Fill(IBussnessEntity obj)
        {
            base.Fill(obj);

            IGroup group = obj as IGroup;

            if (group != null)
            {
                if (group.Catalog != null) CatalogGuid = group.Catalog.Guid;
            }
        }
    }
}
