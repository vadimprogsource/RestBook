using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Data
{
    public interface ICatalogRepository : IDataRepository<ICatalog>
    {
        Task<IEnumerable<ICatalog>> GetActiveCatalogs(int maxCount);

        Task<ICatalog> GetCatalog(Guid catalogGuid);
        Task<IEnumerable<IGroup>> GetGroups(Guid catalogGuid);
        Task<IEnumerable<IProduct>> GetProducts(Guid catalogGuid);
        Task<IGroup> GetGroup(Guid groupGuid);
    }
}
