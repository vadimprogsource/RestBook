using RestBook.Api.Entity;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class OrderModel : EntityModel, IRetailOrder
    {
        internal IUserAccount Customer;

        public AddressModel DeliveryAddress { get; set; }
        public OrderDetailModel[] Details {get;set;}

        public OrgModel Org { get; set; }
        public string Token { get; set; }
        public string OrderNumber { get; set; }

        public DateTime OrderedAt { get; set; }

        public decimal Discount { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TotalTax { get; set; }

        public decimal TotalDue { get; set; }

        public string Code { get; set; }

        public string Uri { get; set; }

        public string Description { get; set; }

        public int ReorderLevel { get; set; }

        IAddress IRetailOrder.DeliveryAddress => DeliveryAddress;

        IEnumerable<IOrderDetail> IRetailOrder.Details => Details;

        IUserAccount IRetailOrder.Customer => Customer;

        IOrg IRetailOrder.Org => Org;

        public OrderModel() { }
        public OrderModel(IAccessToken accessToken , IRetailOrder order)  : base(order)
        {

            if (order.Org != null)
            {
                Org = new OrgModel(order.Org);
                Org.Locations = null;
                Org.Address = null;
            }

            Token = accessToken.ToString();
            OrderNumber = order.OrderNumber;
            OrderedAt = order.OrderedAt;
            Discount = order.Discount;
            SubTotal = order.SubTotal;
            TotalDue = order.TotalDue;
            TotalTax = order.TotalTax;
            Code = order.Code;
            Uri = order.Uri;
            ReorderLevel = order.ReorderLevel;
            Customer = order.Customer;

            if (order.Details != null)
            {
                Details = order.Details.Select(x => new OrderDetailModel(x)).ToArray();
            }


            if (order.DeliveryAddress != null)
            {
                DeliveryAddress = new AddressModel(order.DeliveryAddress);
            }
        }

    }
}
