using RestBook.Api.Entity;
using RestBook.Api.Filter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Provider
{
    public interface ICatalogProvider
    {
        Task<IEnumerable<ICatalog>> GetCatalogs();

        Task<IEnumerable<ICatalog>> GetCatalogsByLocation(Guid locatioGuid);

        Task<ICatalog> GetCatalog(Guid guid);
        Task<IProduct> GetProduct(Guid productGuid);
        Task<IEnumerable<IProduct>> GetProducts(Guid[] productGuids);
        Task<IGroup> GetGroup(Guid groupGuid);
        Task<IEnumerable<IProduct>> FindProducts(IFilter filter);
    }
}
