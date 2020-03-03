using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Entity
{
    public class DataProduct  : DataEntity , IProduct
    {
        public Guid CatalogGuid { get; set; }
        public Guid GroupGuid { get; set; }

        public DataCatalog Catalog { get; set; }
        public DataGroup   Group { get; set; }

        public decimal ListPrice { get; set; }
        public decimal NetCost { get; set; }

        public decimal UnitWeight { get; set; }

        public decimal UnitEnergy { get; set; }

        public string UnitCode { get; set; }

        public decimal UnitVolume { get; set; }

        public string Weights { get; set; }

        ICatalog IProduct.Catalog => Catalog;

        IGroup IProduct.Group => Group;

        public override void Fill(IBussnessEntity obj)
        {
            base.Fill(obj);

            IProduct product = obj as IProduct;

            if (product != null)
            {
                ListPrice = product.ListPrice;
                NetCost = product.NetCost;
                UnitWeight = product.UnitWeight;
                UnitEnergy = product.UnitEnergy;

                if (product.Catalog != null)
                {
                    CatalogGuid = product.Catalog.Guid;
                }

                if (product.Group != null)
                {
                    GroupGuid = product.Group.Guid;
                }
            }
        }
    }
}
