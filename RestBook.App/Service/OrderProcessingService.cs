using RestBook.Api.Calculator;
using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Api.Provider;
using RestBook.Api.Service;
using RestBook.App.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.App.Service
{
    public class OrderProcessingService : IOrderProcessingService
    {

        private readonly IOrgProvider         m_org_provider;
        private readonly ICatalogProvider     m_catalog_provider;
        private readonly IOrderRepository     m_order_repository;
        private readonly IOrderCalculator     m_order_calculator;


        public OrderProcessingService(IOrgProvider orgProvider ,  ICatalogProvider catalogProvider , ILocationRepository locationRepository,IOrderRepository orderRepository , IOrderCalculator caluclator ) 
        {
            m_catalog_provider = catalogProvider;
            m_order_repository = orderRepository;
            m_order_calculator = caluclator;
            m_org_provider = orgProvider;
        }


        private  async Task<RetailOrder> GenOrderNumber(RetailOrder order)
        {
            order.OrderedAt = DateTime.Now;
            order.ReorderLevel = await m_order_repository.GetMaxReorderLevel(order.Org.Guid, order.OrderedAt.Year);
            order.OrderNumber = $"{++order.ReorderLevel}/{order.Code}-{order.OrderedAt.Year}";
            return order;
        }


        public async Task<IRetailOrder> CreateNewOrder(IUserAccount customer,Guid orgGuid)
        {
            RetailOrder order =  new RetailOrder { Guid = Guid.NewGuid(), OrderedAt = DateTime.Now, Code = "C" , Customer = new UserAccount(customer) , Org = new Org(await m_org_provider.GetOrg(orgGuid))  };
            return await GenOrderNumber( order);
        }


        public async Task<IRetailOrder> AddToOrder(IRetailOrder order, Guid locationGuid, string placeCode, Guid productGuid, decimal quantity)
        {

            ILocation location = await m_org_provider.GetLocation(locationGuid);
            IProduct  product  = await m_catalog_provider.GetProduct(productGuid);

            if (product == null || location == null)
            {
                return default;
            }

            return await m_order_calculator.Calculate( new RetailOrder(order).AddToOrder(location, placeCode, product , quantity));
        }

        public async Task<IRetailOrder> RemoveFromOrder(IRetailOrder order, Guid locationGuid, string placeCode, Guid productGuid, decimal quantity)
        {

            ILocation location = await m_org_provider.GetLocation(locationGuid);
            IProduct product = await m_catalog_provider.GetProduct(productGuid);


            return await m_order_calculator.Calculate( new RetailOrder(order).RemoveFromOrder(location, placeCode, product, quantity));

        }

        
        public async Task<IRetailOrder> PushOrder(IRetailOrder order)
        {
            RetailOrder retailOrder = await GenOrderNumber(new RetailOrder(order));
            await m_order_repository.Insert(order = await m_order_calculator.Calculate(retailOrder));
            return order;
        }

        public async Task<IRetailOrder> CancelOrder(IRetailOrder order)
        {
            await m_order_repository.Delete(order.Guid);
            return order;
        }



    }
}
