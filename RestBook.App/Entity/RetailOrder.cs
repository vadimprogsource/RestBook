using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestBook.App.Entity
{


    public class RetailOrderItem : IOrderItem
    {
        public Product Product { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal TaxValue { get; set; }

        IProduct IOrderItem.Product => Product;


        public RetailOrderItem() { }

        public RetailOrderItem(IProduct product) 
        {
            Product = new Product(null, null, product);
            UnitPrice = Product.ListPrice;
        }


        public RetailOrderItem(IOrderItem row)
        {
            Product = new Product(null,null,row.Product);
            Quantity = row.Quantity;
            Discount = row.Discount;
            UnitPrice = row.UnitPrice;
            TotalPrice = row.TotalPrice;
            TaxValue = row.TaxValue;
        }
    }


    public class RetailOrderDetail : IOrderDetail ,ILocationPlace
    {
        public Location Location { get; set; }

        public string PlaceCode { get; set; }


        public decimal TotalPrice { get; set; }

        public RetailOrderItem[] Items { get; set; } = new RetailOrderItem[] { };


        IEnumerable<IOrderItem> IOrderDetail.Items => Items;

        ILocation ILocationPlace.Location => Location;

        public RetailOrderDetail() { }
        public RetailOrderDetail(IOrderDetail orderDetail) 
        {
            if (orderDetail.Location != null)
            {
                Location = new Location(orderDetail.Location);
            }

            PlaceCode = orderDetail.PlaceCode;
            TotalPrice = orderDetail.TotalPrice;
            
            if (orderDetail.Items != null && orderDetail.Items.Any())
            {
                Items = orderDetail.Items.Select(x => new RetailOrderItem(x)).ToArray();
            }
        }


        public RetailOrderDetail AddItem(IProduct product, decimal qty)
        {

            RetailOrderItem item = Items.FirstOrDefault(x => x.Product.Guid == product.Guid);

            if (item == null)
            {
                item = new RetailOrderItem(product);
                Items = Items.Union(new[] { item }).ToArray();
            }

            item.Quantity += qty;
            return this;
        }

        public RetailOrderDetail RemoveItem(IProduct product, decimal qty)
        {
            RetailOrderItem item = Items.FirstOrDefault(x => x.Product.Guid == product.Guid);

            if (item != null)
            {
                item.Quantity -= qty;

                if (item.Quantity < 1)
                {
                    Items = Items.Where(x => x.Quantity > 0).ToArray();
                }
            }

            return this;
        }

    }


    public class RetailOrder : BussinessEntity, IRetailOrder
    {

        public Org Org { get; set; }

        public UserAccount Customer { get; set; }

        public Address DeliveryAddress { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderedAt { get; set; }

        public decimal Discount { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TotalTax { get; set; }

        public decimal TotalDue { get; set; }


        public RetailOrderDetail[] Details { get; set; }

        IUserAccount IRetailOrder.Customer => Customer;

        IAddress IRetailOrder.DeliveryAddress => DeliveryAddress;

        IEnumerable<IOrderDetail> IRetailOrder.Details => Details;

        IOrg IRetailOrder.Org => Org;

        public RetailOrder() 
        {
            Details = new RetailOrderDetail[] { };
        }
        public RetailOrder(IRetailOrder order) : base(order)
        {

            if (order.Org != null)
            {
                Org = new Org(order.Org);
            }

            if (order.Customer != null)
            {
                Customer = new UserAccount(order.Customer); 
            }

            OrderNumber = order.OrderNumber;
            OrderedAt = order.OrderedAt;
            Discount = order.Discount;
            SubTotal = order.SubTotal;
            TotalTax = order.TotalTax;
            TotalDue = order.TotalDue;


            if (order.Details != null && order.Details.Any())
            {
                Details = order.Details.Select(x => new RetailOrderDetail(x)).ToArray();
            }
            else
            {
                Details = new RetailOrderDetail[] { };
            }
        }


        public RetailOrder AddToOrder(ILocation location, string placeCode, IProduct product, decimal qty)
        {
            RetailOrderDetail orderDetail = Details.FirstOrDefault(x => x.Location.Guid == location.Guid && x.PlaceCode == placeCode);

            if (orderDetail == null)
            {
                orderDetail = new RetailOrderDetail { Location = new Location(location), PlaceCode = placeCode };
                Details = Details.Union(new[] { orderDetail }).ToArray();
            }

            orderDetail.AddItem(product, qty);
            return this;
        }

        public RetailOrder RemoveFromOrder(ILocation location, string placeCode, IProduct product, decimal qty)
        {
            RetailOrderDetail orderDetail = Details.FirstOrDefault(x => x.Location.Guid == location.Guid && x.PlaceCode == placeCode);

            if (orderDetail != null)
            {
                orderDetail.RemoveItem(product, qty);
                if (orderDetail.Items == null || orderDetail.Items.Length < 1)
                {
                    Details = Details.Where(x => orderDetail.Items.Any()).ToArray();
                }
            }

            return this;
        }


        public RetailOrder GroupBy(Func<IEnumerable<IOrderItem>,decimal> calc_total_price)
        {
            if (Details != null && Details.Any())
            {
                Details = Details
                     .GroupBy(x => new { x.Location.Guid, x.PlaceCode })
                     .Select(x => new RetailOrderDetail { PlaceCode = x.Key.PlaceCode, Location = x.First().Location, Items = x.SelectMany(y => y.Items).ToArray(), TotalPrice = calc_total_price(x.SelectMany(y => y.Items)) })
                     .ToArray();
            }

            return this;
        }


    }
}
