using Microsoft.EntityFrameworkCore;
using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Data.Repository
{
    public class OrgRepository : DataEntityRepository<IOrg, DataOrg> , IOrgRepository
    {
        public OrgRepository(IDataRepositoryProvider provider) : base(provider)
        {
        }

        
        public async Task<IEnumerable<IOrg>> GetTopOrgs(int maxCount)
        {
            return await Set<DataOrg>()
                .Include(x=>x.Address)
                .Include(x=>x.Locations)
                .ThenInclude(x=>x.Catalogs)
                .ThenInclude(x=>x.Catalog)
                .AsNoTracking()
                .Take(maxCount)
                .OrderByDescending(x=>x.Rating)
                .ThenBy(x=>x.ReorderLevel)
                .ToArrayAsync();
        }

        public override async Task<IOrg> Select(Guid guid)
        {
            DataOrg org   = await Set<DataOrg>()
                           .Include(x=>x.Address)
                           .Include(x=>x.Locations)
                           .ThenInclude(x => x.Catalogs)
                           .ThenInclude(x => x.Catalog)
                           .AsNoTracking()
                           .SingleAsync(x => x.Guid    == guid);
            return org;
        }

    }
}
