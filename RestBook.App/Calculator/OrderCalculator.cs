using RestBook.Api.Calculator;
using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Api.Provider;
using RestBook.App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.App.Calculator
{
    public class OrderCalculator : IOrderCalculator
    {

        private ICatalogProvider m_catalog_provider;


        public OrderCalculator(ICatalogProvider catalogProvider)
        {
            m_catalog_provider = catalogProvider;
        }

        public async Task<IRetailOrder> Calculate(IRetailOrder order)
        {
            RetailOrder retailOrder = new RetailOrder(order);


            Dictionary<Guid, Product> productCache = (await m_catalog_provider.GetProducts(retailOrder.Details.SelectMany(x => x.Items).Select(x=>x.Product.Guid).ToArray()))
                                                              .Select(x=>new Product(null,null,x))
                                                              .ToDictionary(x=>x.Guid);

            retailOrder.SubTotal = decimal.Zero;

            foreach (RetailOrderDetail detail in retailOrder.Details)
            {

                detail.TotalPrice = decimal.Zero;

                foreach (RetailOrderItem item in detail.Items)
                {

                    Product product;

                    if (productCache.TryGetValue(item.Product.Guid, out product))
                    {
                        item.Product = product; 
                    }

                    item.UnitPrice  = item.Product.ListPrice;
                    item.TotalPrice = Math.Round(item.UnitPrice * item.Quantity, 2, MidpointRounding.AwayFromZero);
                    detail.TotalPrice    += item.TotalPrice;
                    retailOrder.SubTotal += item.TotalPrice;
                }

                detail.TotalPrice = Math.Round(detail.TotalPrice, 2, MidpointRounding.AwayFromZero);
                
            }

            retailOrder.TotalDue = retailOrder.SubTotal = Math.Round(retailOrder.SubTotal, 2, MidpointRounding.AwayFromZero);
            return retailOrder;

        }

        public decimal CalculateTotalPrice(IEnumerable<IOrderItem> items)
        {

            if (items != null && items.Any())
            {
                return Math.Round(items.Sum(x => x.TotalPrice), 2, MidpointRounding.AwayFromZero); 
            }

            return decimal.Zero;
        }
    }
}
