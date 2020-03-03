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
    public class LocationRepository : DataEntityRepository<ILocation, DataLocation>, ILocationRepository
    {
        public LocationRepository(IDataRepositoryProvider provider) : base(provider)
        {
        }

        public async Task<IEnumerable<ICatalogAccess>> GetCatalogs(Guid locationGuid)
        {
            return await AsQueryable<DataCatalogAccess>().Include(x => x.Catalog).Where(x => x.LocationGuid == locationGuid).ToArrayAsync();
        }
    }
}
