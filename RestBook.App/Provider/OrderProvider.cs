using RestBook.Api.Calculator;
using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Api.Provider;
using RestBook.App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.App.Provider
{
    public class OrderProvider : IOrderProvider
    {

        private readonly IOrderRepository m_order_repository;
        private readonly IOrderCalculator m_order_caluclator;

        public OrderProvider(IOrderRepository orderRepository,IOrderCalculator orderCalculator)
        {
            m_order_repository = orderRepository;
            m_order_caluclator = orderCalculator;
        }


        private IEnumerable<RetailOrder> SelectOrders(IEnumerable<IRetailOrder> orders) => orders.Select(x => new RetailOrder(x).GroupBy(x => m_order_caluclator.CalculateTotalPrice(x))).ToArray();


        public async Task<IEnumerable<IRetailOrder>> GetActiveOrders(IUserAccount user) => SelectOrders(await m_order_repository.GetActiveOrders(user));
       

        
        public async Task<IRetailOrder> GetOrder(IUserAccount user, Guid guid)
        {

            IRetailOrder order = await m_order_repository.Select(guid);

            if (order.Customer.Guid == user.Guid)
            {
                return new RetailOrder(order).GroupBy(x => m_order_caluclator.CalculateTotalPrice(x));
            }

            return default;
        }

        public async Task<IEnumerable<IRetailOrder>> GetOrders(Guid orgGuid, DateTime today, Guid? locationGuid)
        {
            DateTime start = today.Date, end = start.AddDays(1).AddMilliseconds(-1);
            return SelectOrders(await m_order_repository.GetOrders(orgGuid, locationGuid, start, end));
        }


    }
}
