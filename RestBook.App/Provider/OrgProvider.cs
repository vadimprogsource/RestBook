using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Api.Filter;
using RestBook.Api.Provider;
using RestBook.App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.App.Provider
{
    public class OrgProvider : IOrgProvider
    {

        private readonly ILocationRepository m_location_repository;
        private readonly IOrgRepository org_data_repository;


        public OrgProvider(IOrgRepository orgRepository , ILocationRepository locationRepository)
        {
            org_data_repository = orgRepository;
            m_location_repository = locationRepository;
        }

        public async Task<IEnumerable<IOrg>> FindOrgs(IFilter filter)
        {
            return (await org_data_repository.Select(filter)).Select(x=>new Org(x));
        }

        public async Task<ILocation> GetLocation(Guid locationGuid) => new Location( (await m_location_repository.Select(locationGuid)));
    
        public async Task<IOrg> GetOrg(Guid guid)
        {
            return new Org(await org_data_repository.Select(guid));
        }

        public  async Task<IEnumerable<IOrg>> GetTopOrgs()
        {
            return (await org_data_repository.GetTopOrgs(10)).Select(x=>new Org(x));
        }
    }
}
