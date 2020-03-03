using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Entity
{

    public enum DataUserRole : byte {Guest = 0, Customer =1 , Staff=2 , Admin=3};

    public class DataUserAccount : DataContact, IUserAccount
    {
        public DateTime CreatedDateTime { get; set; }
        public DataUserRole Role { get; set; } 

        public bool IsAdmin { get => Role == DataUserRole.Admin; set => Role = value ? DataUserRole.Admin : Role; }
        public bool IsStaff { get => Role == DataUserRole.Staff; set => Role = value ? DataUserRole.Staff : Role; }
        public bool IsCustomer { get => Role == DataUserRole.Customer; set => Role = value ? DataUserRole.Customer : Role; }
        public string LoginName { get; set; }


        public Guid? AddressGuid { get; set; }

        public DataAddress Address { get; set; }

        IAddress IUserAccount.Address => Address;


        public Guid PasswordGuid   { get; set; }
        public byte[] PasswordHash { get; set; }


        public override void Fill(IBussnessEntity obj)
        {
            base.Fill(obj);

            IUserAccount ua = obj as IUserAccount;

            CreatedDateTime = ua.CreatedDateTime;
            IsAdmin = ua.IsAdmin;
            IsStaff = ua.IsStaff;
            IsCustomer = ua.IsCustomer;

            LoginName = ua.LoginName;

            AddressGuid = null;
        }
    }
}
