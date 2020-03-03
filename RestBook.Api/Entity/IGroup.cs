using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{
    public interface IGroup : IBussnessEntity
    {
        ICatalog Catalog { get; }
       IEnumerable<IProduct> Products { get; }
    }
}
