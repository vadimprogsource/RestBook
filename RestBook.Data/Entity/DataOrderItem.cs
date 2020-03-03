using RestBook.Api.Entity;
using System;
using System.Collections.Generic;

namespace RestBook.Data.Entity
{
    public class DataOrderItem : DataObject, IOrderItem , IOrderDetail
    {

        public Guid? LocationGuid { get; set; }
        public Guid ProductGuid { get; set; }
        public Guid OrderGuid { get; set; } 
            

        public DataProduct Product { get; set; }

        public DataLocation Location { get; set; }

        public DataOrder Order { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal TaxValue { get; set; }


        public string PlaceCode { get; set; }

        IEnumerable<IOrderItem> IOrderDetail.Items => new[] {this };

        IProduct IOrderItem.Product => Product;

        ILocation ILocationPlace.Location => Location;

        public override void Fill(IEntity entity)
        {
           
        }
        public DataOrderItem() { }

        public DataOrderItem(IRetailOrder order ,  IOrderDetail detail , IOrderItem  item) 
        {
            OrderGuid = order.Guid;
            LocationGuid = detail.Location.Guid;
            PlaceCode = detail.PlaceCode;
            ProductGuid = item.Product.Guid;

            Quantity = item.Quantity;
            UnitPrice = item.UnitPrice;
            Discount = item.Discount;
            TotalPrice = item.TotalPrice;
            TaxValue = item.TaxValue;
        }

    }
}
