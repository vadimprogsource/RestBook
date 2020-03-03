using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Api.Service;
using RestBook.App.Builder;
using RestBook.App.Entity;
using RestBook.App.Generator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.App.Service
{
    public class AccessTokenService : IAccessTokenService
    {
        private readonly TimeSpan           m_session_timeout = TimeSpan.FromHours(1); 
        private readonly ISessionRepository m_session_repository;

        public AccessTokenService(ISessionRepository sessionRepository) 
        {
            m_session_repository = sessionRepository;
        }

        public  async Task<string> GeneratePinCode(IUserAccount user, string cellular, string email)
        {
            IAccessToken accessToken = await GenerateToken(user);

            PasswordBuilder   pb = new PasswordBuilder();
            PinCodeGenerator  gen = new PinCodeGenerator();

            string pinCode = gen.GenerateNextPinCode();

            await m_session_repository.ResetPinCode(accessToken.Guid, pb.MakeGuid(cellular, email, pinCode), pb.MakePasswordHash(cellular, email, pinCode));
            return pinCode;
        }

        public async Task<IAccessToken> GenerateToken(IUserAccount user)
        {
            UserSession us = new UserSession { CreatedDateTime = DateTime.Now, ExpiredDateTime = DateTime.Now.Add(m_session_timeout), User = new UserAccount(user),Guid = Guid.NewGuid() };
            await m_session_repository.Insert(us);
            return us;
        }


        private async Task<IAccessToken> Renew(IAccessToken accessToken)
        {
            UserSession us = new UserSession(accessToken);
            us.ExpiredDateTime = DateTime.Now.Add(m_session_timeout);
            await m_session_repository.Update(us);
            return us;

        }


        public async Task<IAccessToken> GetToken(string accessToken)
        {
            Guid sid;


            if (Guid.TryParse(accessToken, out sid))
            {
                IAccessToken session = await m_session_repository.Select(sid);

                if (session != null && !session.HasExpired)
                {
                    return await Renew(session);
                }
            }

            return UserSession.Empty;
        }

        public async Task<IAccessToken> GetTokenByPinCode(string pinCode, string cellular , string email)
        {
            PasswordBuilder pwd = new PasswordBuilder();

            IAccessToken accessToken = await m_session_repository.GetTokenByPinCode(pwd.MakeGuid(cellular , email , pinCode) , pwd.MakePasswordHash(cellular , email ,pinCode) , pwd);

            if (accessToken == null)
            {
                return default;
            }

            await m_session_repository.ResetPinCode(accessToken.Guid, Guid.Empty, new byte[0]);
            return await Renew(accessToken);
        }

        public async Task ReleaseExpiredTokens(int perTokens)
        {
            await m_session_repository.RemoveAllExpired(DateTime.Now,perTokens);
        }
        

        public Task ReleaseToken(string accessToken) => m_session_repository.Delete(Guid.Parse(accessToken));

        public Task ReleaseTokens(IUserAccount user) => m_session_repository.RemoveAll(user);

        
    }
}
