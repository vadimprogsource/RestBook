using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.App.Entity
{
    public class UserAccount : ContactEntity, IUserAccount
    {
        public DateTime CreatedDateTime { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsStaff { get; set; }

        public bool IsCustomer { get; set; }

        public string LoginName { get; set; }

        public Address Address { get; set; }

        IAddress IUserAccount.Address => Address;

        public UserAccount() 
        {
            Guid = Guid.NewGuid();
            CreatedDateTime = DateTime.Now;
        }
        public UserAccount(IUserAccount user) : base(user) 
        {
            CreatedDateTime = user.CreatedDateTime;
            IsAdmin = user.IsAdmin;
            IsStaff = user.IsStaff;
            IsCustomer = user.IsCustomer;

            LoginName = user.LoginName;

            if (user.Address != null)
            {
                Address = new Address(user.Address);
            }
        }
    }
}
