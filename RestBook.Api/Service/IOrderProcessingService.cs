using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Service
{
    public interface IOrderProcessingService
    {
        Task<IRetailOrder> CreateNewOrder(IUserAccount customer,Guid orgGuid);
        Task<IRetailOrder> AddToOrder(IRetailOrder order, Guid locationGuid, string placeCode, Guid productGuid, decimal quantity);
        Task<IRetailOrder> RemoveFromOrder(IRetailOrder order, Guid locationGuid, string placeCode, Guid productGuid, decimal quantity);
        Task<IRetailOrder> PushOrder(IRetailOrder order);
        Task<IRetailOrder> CancelOrder(IRetailOrder order);
    }
}
