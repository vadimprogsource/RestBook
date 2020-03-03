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
    [Route("api/catalog")]
    public class CatalogController : ControllerBase
    {
        private ICatalogProvider m_catalog_provider;


        public CatalogController(ICatalogProvider catalogProvider)
        {
            m_catalog_provider = catalogProvider;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCatalogs()
        {

            IEnumerable<ICatalog> cats = await m_catalog_provider.GetCatalogs();

            if (cats != null && cats.Any())
            {
                return Ok(cats.Select(x => new CatalogModel(x)));
            }

            return NotFound();
        }

        [HttpGet("location/{guid}")]
        public async Task<IActionResult> GetCalalogsByLocations(Guid guid)
        {
            IEnumerable<ICatalog> cats = await m_catalog_provider.GetCatalogsByLocation(guid);

            if (cats != null && cats.Any())
            {
                return Ok(cats.Select(x => new CatalogModel(x)));
            }

            return NotFound();

        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetCatalog(Guid guid)
        {
            ICatalog cat = await m_catalog_provider.GetCatalog(guid);

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(new CatalogModel(cat));
        }

        [HttpPost("product/find")]
        public async Task<IActionResult> FindProducts([FromBody]FilterModel model)
        {

            if (model == null || string.IsNullOrWhiteSpace(model.SearchText))
            {
                return NotFound();
            }

            if (model.PageSize < 1) model.PageSize = 10;
            if (model.PageIndex< 0) model.PageIndex = 0;


            return Ok((await m_catalog_provider.FindProducts(model)).Select(x => new ProductModel(x)));
        }
    }
}
