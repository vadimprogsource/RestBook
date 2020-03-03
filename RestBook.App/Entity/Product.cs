using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.App.Entity
{
    public class Product : BussinessEntity , IProduct
    {

        Catalog Catalog { get; set; }
        Group Group { get; set; }

        public decimal ListPrice { get; set; }

        public decimal NetCost { get; set; }

        public decimal UnitWeight { get; set; }

        public decimal UnitEnergy { get; set; }

        ICatalog IProduct.Catalog => Catalog;
        IGroup IProduct.Group => Group;

        public string UnitCode { get; set; }

        public decimal UnitVolume { get; set; }

        public string Weights { get; set; }

        public Product() { }

        public Product(Catalog catalog  , Group group , IProduct product) : base(product)  
        {
            Catalog = catalog;
            Group = group;

            ListPrice  = product.ListPrice;
            NetCost    = product.NetCost;
            UnitWeight = product.UnitWeight;
            UnitEnergy = product.UnitEnergy;
            UnitVolume = product.UnitVolume;
            UnitCode   = product.UnitCode;

            Weights = product.Weights;

        }


    }
}
