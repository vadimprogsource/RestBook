using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{
    public interface IBussnessEntity : IEntity
    {
        string Name { get; }
        string Code { get; }
        string Uri { get; }
        string Description { get; }
    }
}
