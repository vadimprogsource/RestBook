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
    public class UserAdminService : IUserAdminService
    {

        private readonly IUserRepository m_user_repository;


        public UserAdminService(IUserRepository userRepository)
        {
            m_user_repository = userRepository;
        }


        public async Task<IUserAccount> RegisterCustomer(IContactData customerData)
        {

            if (await m_user_repository.IsLoginExists(customerData.Email))
            {
                return null;
            }

            UserAccount ua = new UserAccount();
            ua.Data        = customerData;
            ua.IsCustomer  = true;
            ua.LoginName   = customerData.Email;
            
            return new UserAccount(await m_user_repository.Insert(ua));
        }

        public async Task<bool> ResetPasspord(IAccessToken accessToken, string newPassword, string confirmPassword)
        {
            if (string.CompareOrdinal(newPassword, confirmPassword) == 0)
            {
              
                if (accessToken != null && !accessToken.HasExpired)
                {
                    PasswordBuilder pb = new PasswordBuilder();
                    await m_user_repository.ResetPassword(accessToken.User.Guid, pb.MakeGuid(accessToken.User.LoginName, newPassword), pb.MakePasswordHash(accessToken.User.LoginName, newPassword));
                    return true;
                }
            }

            return false;
        }


        public async Task<bool> ResetLoginName(IAccessToken accessToken, string loginName)
        {
            if (accessToken != null && !accessToken.HasExpired)
            {
                return await m_user_repository.ResetLoginName(accessToken.User.Guid, loginName);
            }

            return false;
        }

        public async Task<bool> SaveUserData(IAccessToken accessToken, IContactData userData, IAddress userAddress)
        {
            if (accessToken != null && !accessToken.HasExpired)
            {
                UserAccount ua = new UserAccount(accessToken.User);
                ua.Data = userData;

                if (userAddress != null)
                {
                    ua.Address = new Address(userAddress);
                }

                return await m_user_repository.Update(ua) != null;

            }

            return false;
        }
    }
}
