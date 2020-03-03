﻿using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Data
{
    public interface IProductRepository : IDataRepository<IProduct>
    {
    }
}
