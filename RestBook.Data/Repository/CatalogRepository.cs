using Microsoft.EntityFrameworkCore;
using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Data.Repository
{
    public class CatalogRepository : DataEntityRepository<ICatalog, DataCatalog>, ICatalogRepository
    {
        public CatalogRepository(IDataRepositoryProvider provider) : base(provider)
        {
        }

        public async Task<IEnumerable<ICatalog>> GetActiveCatalogs(int maxCount) => await AsQueryable<DataCatalog>().OrderBy(x => x.ReorderLevel).Take(maxCount).ToArrayAsync();

        public async Task<ICatalog> GetCatalog(Guid catalogGuid)
        {
            DataCatalog catalog = await AsQueryable<DataCatalog>().SingleOrDefaultAsync(x=>x.Guid == catalogGuid);

            if (catalog != null)
            {
               catalog.Groups = await Set<DataGroup>()
                                                .Include(x => x.Products)
                                                .AsNoTracking()
                                                .OrderBy(x => x.ReorderLevel)
                                                .Where(x => x.CatalogGuid == catalogGuid)
                                                .ToArrayAsync();
            }

            return catalog;
        }

        public async Task<IGroup> GetGroup(Guid groupGuid)
        {
            return await Set<DataGroup>().Include(x => x.Products).AsNoTracking().SingleOrDefaultAsync(x => x.Guid == groupGuid);
        }

        public async Task<IEnumerable<IGroup>> GetGroups(Guid catalogGuid) => await Set<DataGroup>().Include(x=>x.Products).AsNoTracking().OrderBy(x => x.ReorderLevel).Where(x => x.CatalogGuid == catalogGuid).ToArrayAsync();
        public async Task<IEnumerable<IProduct>> GetProducts(Guid catalogGuid) => await AsQueryable<DataProduct>().OrderBy(x => x.ReorderLevel).Where(x => x.CatalogGuid == catalogGuid).ToArrayAsync();
        
    }
}
