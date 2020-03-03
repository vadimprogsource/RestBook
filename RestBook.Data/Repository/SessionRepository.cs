using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestBook.Api.Comparer;
using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Api.Filter;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Data.Repository
{
    public class SessionRepository : DataRepository<IAccessToken, DataUserSession> ,ISessionRepository
    {
        public SessionRepository(IDataRepositoryProvider provider) : base(provider) { }
        public Task<bool> RemoveAll       (IUserAccount userAccount) => Delete(x => x.UserGuid == userAccount.Guid);
  
        public override IQueryable<DataUserSession> Where(IQueryable<DataUserSession> query, IFilter filter) => query;

        public override async  Task<IAccessToken> Select(Guid guid) => await Set<DataUserSession>().Include(x => x.User).AsNoTracking().FirstOrDefaultAsync(x => x.Guid == guid);



        public async Task<IAccessToken> GetTokenByPinCode(Guid pinCodeGuid, byte[] pinCodeHash, IBytesComparer comparer)
        {
            DataUserSession[] us = await Set<DataUserSession>()
                                         .Include(x=>x.User)
                                         .AsNoTracking()
                                         .Where(x => x.PinCodeGuid == pinCodeGuid)
                                         .ToArrayAsync();

            if (us == null)
            {
                return default;
            }

            return us.SingleOrDefault(x => comparer.Compare(x.PinCodeHash, pinCodeHash));
        }


        public async Task ResetPinCode(Guid sid, Guid pinCodeGuid, byte[] pinCodeHash)
        {
            DataUserSession us = await Set<DataUserSession>().SingleOrDefaultAsync(x => x.Guid == sid);

            if (us != null)
            {
                us.PinCodeGuid = pinCodeGuid;
                us.PinCodeHash = pinCodeHash;
                await SaveChangesAsync();
            }
        }



        public Task<bool> RemoveAllExpired(DateTime expiredDateTime,int perTokens) => Delete(x => x.ExpiredDateTime <= expiredDateTime,perTokens);
    }
}
