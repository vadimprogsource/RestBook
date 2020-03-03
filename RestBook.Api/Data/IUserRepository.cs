using RestBook.Api.Comparer;
using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Data
{
    public interface IUserRepository : IDataRepository<IUserAccount>
    {


        Task<IUserAccount> GetUserByCellular(string cellular);
        Task<IUserAccount> GetUserByEmail(string email);
        Task<IUserAccount> GetUserByLogin(string loginName);

        Task<bool> IsLoginExists(string loginName);

        Task<IUserAccount> GetUserByPassword(Guid passwordGuid , byte[] passwordHash , IBytesComparer comparer);
        Task ResetPassword(Guid userGuid, Guid passwordGuid, byte[] passwordHash);
        Task<bool> ResetLoginName(Guid userGuid, string loginName);
    }
}
