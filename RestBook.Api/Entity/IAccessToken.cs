using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{
    public interface IAccessToken : IEntity
    {
        DateTime CreatedDateTime { get; }
        DateTime ExpiredDateTime { get; }
        bool HasExpired { get; }
        IUserAccount User { get; }

    }
}
