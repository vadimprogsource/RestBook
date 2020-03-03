using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Data
{
    public interface IOrderRepository : IDataRepository<IRetailOrder>
    {
        Task<int> GetMaxReorderLevel(Guid orgGuid, int year);
        Task<IEnumerable<IRetailOrder>> GetActiveOrders(IUserAccount user);
        Task<IEnumerable<IRetailOrder>> GetOrders(Guid orgGuid ,  Guid? locationGuid , DateTime startDate , DateTime endDate);
    }
}
