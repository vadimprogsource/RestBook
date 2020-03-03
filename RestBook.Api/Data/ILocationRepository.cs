using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Data
{
    public interface ILocationRepository : IDataRepository<ILocation>
    {
        Task<IEnumerable<ICatalogAccess>> GetCatalogs(Guid locationGuid);
    }
}
