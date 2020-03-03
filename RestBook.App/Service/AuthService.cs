using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Api.Service;
using RestBook.App.Builder;
using RestBook.App.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.App.Service
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository     m_user_repository;
        private readonly IAccessTokenService m_token_service;


        public AuthService(IUserRepository userRepository , IAccessTokenService accessTokenService)
        {
            m_user_repository = userRepository;
            m_token_service   = accessTokenService;
        }



        public async Task<string> GeneratePinCode(string cellular, string email)
        {

            IUserAccount ua;

            if (string.IsNullOrWhiteSpace(cellular))
            {
                ua = await m_user_repository.GetUserByEmail(email);
            }
            else
            {
                ua = await m_user_repository.GetUserByCellular(cellular);
            }

            if (ua == null)
            {
                return default;
            }

            return await m_token_service.GeneratePinCode(ua,cellular ,email);
        }

        public async Task<IAccessToken> SignIn(string name, string password)
        {
            PasswordBuilder pb  = new PasswordBuilder();
            IUserAccount    user =  await m_user_repository.GetUserByPassword(pb.MakeGuid(name, password), pb.MakePasswordHash(name, password),pb);

            if (user == null)
            {
                return default;
            }

            await m_token_service.ReleaseTokens(user);
            return await m_token_service.GenerateToken(user);
        }

        
        public Task<IAccessToken> LoginByPinCode(string cellular, string email, string pinCode)
        {
            return m_token_service.GetTokenByPinCode(pinCode, cellular, email);
        }

        public async Task SignOut(string accessToken)
        {
            await m_token_service.ReleaseToken(accessToken);
        }
    }
}
