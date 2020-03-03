using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{
    public interface ICatalog :IBussnessEntity
    {
       IEnumerable<IGroup> Groups { get; }
    }
}
