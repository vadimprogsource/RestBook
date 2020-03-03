using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Service
{
    public interface IAuthService
    {
        Task<IAccessToken> SignIn(string name, string password);
        Task SignOut(string accessToken);
        Task<string> GeneratePinCode(string cellular , string email);
        Task<IAccessToken> LoginByPinCode(string cellular, string email,string pinCode);
    }
}
