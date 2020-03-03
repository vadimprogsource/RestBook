using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class ProductModel : EntityModel 
    {
        public string UnitCode { get; set; }
        public decimal ListPrice { get; set; }
        public decimal UnitWeight { get; set; }
        public decimal UnitEnergy { get; set; }
        public string Description { get; set; }
        public string Weights { get; set; }

        public ProductModel(IProduct product) : base(product)
        {
            UnitCode   = product.UnitCode;
            ListPrice  = product.ListPrice;
            UnitWeight = product.UnitWeight;
            UnitEnergy = product.UnitEnergy;

            Description = product.Description;
            Weights = product.Weights;
        }

    }
}
