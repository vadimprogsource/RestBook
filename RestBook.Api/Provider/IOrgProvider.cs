using RestBook.Api.Entity;
using RestBook.Api.Filter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Provider
{
    public interface IOrgProvider
    {
        Task<IEnumerable<IOrg>> GetTopOrgs();
        Task<IOrg> GetOrg(Guid guid);
        Task<IEnumerable<IOrg>> FindOrgs(IFilter filter);
        Task<ILocation> GetLocation(Guid locationGuid);
    }
}
