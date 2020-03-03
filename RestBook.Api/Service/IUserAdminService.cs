using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Service
{
    public interface IUserAdminService
    {
        Task<IUserAccount> RegisterCustomer(IContactData customerData);
        Task<bool> ResetPasspord(IAccessToken accessToken, string newPassword, string confirmPassword);
        Task<bool> ResetLoginName(IAccessToken accessToken, string loginName);
        Task<bool> SaveUserData(IAccessToken accessToken, IContactData userData , IAddress userAddress);
    }
}
