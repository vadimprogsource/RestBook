using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Repository
{
    public class ProductRepository : DataEntityRepository<IProduct, DataProduct> ,IProductRepository
    {
        public ProductRepository(IDataRepositoryProvider provider) : base(provider)
        {
        }
    }
}
