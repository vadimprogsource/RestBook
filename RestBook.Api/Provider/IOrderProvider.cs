using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Provider
{
    public interface IOrderProvider
    {
        Task<IEnumerable<IRetailOrder>> GetActiveOrders(IUserAccount user);
        Task<IRetailOrder> GetOrder(IUserAccount user,Guid guid);
        Task<IEnumerable<IRetailOrder>> GetOrders(Guid orgGuid,  DateTime today, Guid? locationGuid);
    
    }
}
