using Microsoft.EntityFrameworkCore.Diagnostics;
using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Entity
{
    public class DataOrder : DataEntity, IRetailOrder
    {

        public Guid OrgGuid { get; set; }
        public Guid CustomerGuid { get; set; }
        public Guid? AddressGuid { get; set; }


        public DataOrg Org { get; set; }
        public DataUserAccount Customer { get; set; }
        public DataAddress DeliveryAddress { get; set; }


  
        public string OrderNumber { get; set; }

        public DateTime OrderedAt { get; set; }

        public decimal Discount { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TotalTax { get; set; }

        public decimal TotalDue { get; set; }

        public IEnumerable<DataOrderItem> Rows { get; set; }

        public IEnumerable<IOrderDetail> Details => Rows;

        IUserAccount IRetailOrder.Customer => Customer;

        IAddress IRetailOrder.DeliveryAddress => DeliveryAddress;

        IOrg IRetailOrder.Org => Org;

        public override void Fill(IBussnessEntity obj)
        {
            base.Fill(obj);

            IRetailOrder order = obj as IRetailOrder;

            OrgGuid       = order.Org.Guid;
            CustomerGuid = order.Customer.Guid;
            
            if (order.DeliveryAddress != null)
            {
                AddressGuid = null; 
            }

            OrderNumber = order.OrderNumber;
            OrderedAt = order.OrderedAt;
            Discount = order.Discount;
            SubTotal = order.SubTotal;
            TotalTax = order.TotalTax;
            TotalDue = order.TotalDue;
        }


        public DataOrder() { }
        public DataOrder(IRetailOrder order) 
        {
            Fill(order);
        }

    }
}
