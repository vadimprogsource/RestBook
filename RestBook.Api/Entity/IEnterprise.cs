using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{
    public interface IEnterprise : IContactEntity
    {
        IAddress          MainOffice { get; }
        IEnumerable<IOrg> Orgs { get; }
    }
}
