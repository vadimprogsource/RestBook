using RestBook.Api.Comparer;
using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Data
{
   public interface ISessionRepository : IDataRepository<IAccessToken>
   {

        Task<IAccessToken> GetTokenByPinCode(Guid pinCodeGuid , byte[] pinCodeHash , IBytesComparer comparer);
        Task ResetPinCode(Guid sid, Guid pinCodeGuid, byte[] pinCodeHash);
        Task<bool> RemoveAll(IUserAccount userAccount);
        Task<bool> RemoveAllExpired(DateTime expitedDateTime, int perTokens);
   }
}
