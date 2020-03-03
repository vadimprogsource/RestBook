using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{
    public interface IUserAccount : IContactEntity
    {
        DateTime CreatedDateTime { get; }
        bool IsAdmin { get; }
        bool IsStaff { get; }
        bool IsCustomer { get; }
        string LoginName { get; }

        IAddress Address { get; }
    }
}
