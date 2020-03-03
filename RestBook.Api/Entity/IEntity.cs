using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{
    public interface IEntity
    {
        Guid Guid        { get; }
        int ReorderLevel { get; }
    }
}
