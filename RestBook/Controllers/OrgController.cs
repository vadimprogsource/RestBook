using Microsoft.AspNetCore.Mvc;
using RestBook.Api.Entity;
using RestBook.Api.Provider;
using RestBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Controllers
{

    [ApiController]
    [Route("api/org")]
    public class OrgController : ControllerBase
    {
        private readonly IOrgProvider m_org_provider;


        public OrgController(IOrgProvider provider)
        {
            m_org_provider = provider;
        }


        [HttpGet("top")]
        public async Task<IActionResult> GetTopOrgs()
        {
            IEnumerable<IOrg> orgs = await m_org_provider.GetTopOrgs();

            if (orgs != null && orgs.Any())
            {
                return Ok(orgs.Select(x=>new OrgModel(x)).ToArray());
            }

            return NotFound();
        }


        [HttpGet("{guid}")]
        public async Task<IActionResult> GetOrg(Guid guid)
        {
            IOrg org = await m_org_provider.GetOrg(guid);

            if (org == null)
            {
                return NotFound();
            }

            return Ok(new OrgModel(org));
        }

        [HttpPost("find")]
        public async Task<IActionResult> FindOrgs([FromBody]FilterModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.SearchText))
            {
                return NotFound();
            }

            if (model.PageSize < 1) model.PageSize = 10;
            if (model.PageIndex < 0) model.PageIndex = 0;


            return Ok((await m_org_provider.FindOrgs(model)).Select(x => new OrgModel(x)));
        }
    }
}
