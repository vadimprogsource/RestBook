using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Service
{

    public interface IAccessTokenService
    {
        Task<IAccessToken> GenerateToken(IUserAccount user);
        Task<string> GeneratePinCode(IUserAccount user, string cellular, string email);
        Task<IAccessToken> GetToken(string accessToken);
        Task<IAccessToken> GetTokenByPinCode(string pinCode,string cellular , string email);
        Task ReleaseToken(string accessToken);
        Task ReleaseTokens(IUserAccount user);
        Task ReleaseExpiredTokens(int perTokens);
    }
}
