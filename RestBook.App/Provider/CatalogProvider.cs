using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Api.Filter;
using RestBook.Api.Provider;
using RestBook.App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.App.Provider
{
    public class CatalogProvider : ICatalogProvider
    {

        private readonly ICatalogRepository   m_catalog_repository;
        private readonly IProductRepository   m_product_repository;
        private readonly ILocationRepository  m_location_repostory;

        public CatalogProvider(ICatalogRepository catalogRepository, IProductRepository dataRepository,ILocationRepository locationRepository)
        {
            m_catalog_repository = catalogRepository;
            m_product_repository = dataRepository;
            m_location_repostory = locationRepository;
        }

        public  async Task<IEnumerable<ICatalog>> GetCatalogs()
        {
            return (await m_catalog_repository.GetActiveCatalogs(10)).Select(x=>new Catalog(x)).OrderBy(x=>x.Code);
        }

        public async Task<ICatalog> GetCatalog(Guid guid)
        {
            ICatalog catalog = await m_catalog_repository.GetCatalog(guid);
            
            if (catalog != null)
            {
                return new Catalog(catalog);
            }

            return default;

        }

        public async Task<IEnumerable<IProduct>> FindProducts(IFilter filter)
        {
            return (await m_product_repository.Select(filter)).Select(x => new Product(null, null, x)).ToArray();
        }

        public async Task<IEnumerable<ICatalog>> GetCatalogsByLocation(Guid locationGuid)
        {

           IEnumerable<CatalogAccess> ca =   (await m_location_repostory.GetCatalogs(locationGuid))
                                            .Select(x=>new CatalogAccess(x))
                                            .Where(x=>x.IsFilter(DateTime.Now));


            return ca.Select(x => x.Catalog).ToArray();
        }

        public Task<IProduct> GetProduct(Guid productGuid) => m_product_repository.Select(productGuid);
       
        public Task<IGroup> GetGroup(Guid groupGuid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IProduct>> GetProducts(Guid[] productGuids)
        {

            if (productGuids == null || productGuids.Length < 1)
            {
                return Enumerable.Empty<IProduct>();
            }

            return (await m_product_repository.SelectMany(productGuids.Distinct().ToArray())).Select(x => new Product(null, null, x)).ToArray();
        }
    }
}
