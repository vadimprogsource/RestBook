using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class OrderItemModel :EntityModel, IOrderItem ,IProduct
    {
        IProduct IOrderItem.Product => this;

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public string UnitCode { get; set; }
        public decimal UnitWeight { get; set; }
        public string Weights { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TaxValue { get; set; }

        string IBussnessEntity.Code => string.Empty;
        public string Uri { get; set; } 

       string IBussnessEntity.Description => string.Empty;

        int IEntity.ReorderLevel => 0;

        ICatalog IProduct.Catalog => null;

        IGroup IProduct.Group => null;


        decimal IProduct.ListPrice => UnitPrice;

        decimal IProduct.NetCost => UnitPrice;

        decimal IProduct.UnitVolume => decimal.Zero;

        decimal IProduct.UnitEnergy => decimal.Zero;


        public OrderItemModel() { }
        public OrderItemModel(IOrderItem row) 
        {
            Quantity = row.Quantity;
            UnitPrice = row.UnitPrice;
            UnitCode = row.Product.UnitCode;
            UnitWeight = row.Product.UnitWeight;
            Weights = row.Product.Weights;

            Discount = row.Discount;
            TotalPrice = row.TotalPrice;
            TaxValue = row.TaxValue;

            Guid = row.Product.Guid;
            Name = row.Product.Name;
        }


    }
}
