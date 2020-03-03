using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{

    public interface IOrderItem
    {
        IProduct Product { get; }
        decimal Quantity { get; }
        decimal UnitPrice { get; }
        decimal Discount { get; }
        decimal TotalPrice { get; }
        decimal TaxValue { get; }
    }

    public interface IOrderDetail : ILocationPlace
    {
        IEnumerable<IOrderItem> Items { get; }
        decimal TotalPrice { get; }
    }


    public interface IRetailOrder : IBussnessEntity
    {
        IOrg Org { get; }
        IUserAccount Customer { get; }
        IAddress DeliveryAddress { get; }
        string OrderNumber { get; }
        DateTime OrderedAt { get; }
        decimal Discount { get; }
        decimal SubTotal { get; }
        decimal TotalTax { get; }
        decimal TotalDue { get; }

        IEnumerable<IOrderDetail> Details { get; }
    }
}
