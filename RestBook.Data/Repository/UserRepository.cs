using Microsoft.EntityFrameworkCore;
using RestBook.Api.Comparer;
using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Data.Repository
{
    public class UserRepository : DataEntityRepository<IUserAccount, DataUserAccount> , IUserRepository
    {
        public UserRepository(IDataRepositoryProvider provider) : base(provider)
        {
        }


        public async Task<IUserAccount> GetUserByPassword(Guid passwordGuid, byte[] passwordHash, IBytesComparer comparer)
        {

            DataUserAccount[] acc =  await AsQueryable<DataUserAccount>().Where(x => x.PasswordGuid == passwordGuid).ToArrayAsync();

            if (acc == null)
            {
                return default;
            }

            return acc.FirstOrDefault(x => comparer.Compare(x.PasswordHash, passwordHash));
        }


        public async Task<IUserAccount> GetUserByCellular(string cellular) => await AsQueryable<DataUserAccount>().FirstOrDefaultAsync(x => x.Cellular == cellular);
        public async Task<IUserAccount> GetUserByEmail(string email) => await AsQueryable<DataUserAccount>().FirstOrDefaultAsync(x => x.Email == email);

        public async Task<IUserAccount> GetUserByLogin(string loginName) => await AsQueryable<DataUserAccount>().FirstOrDefaultAsync(x => x.LoginName == loginName);



        public Task<bool> IsLoginExists(string loginName) => AsQueryable<DataUserAccount>().AnyAsync(x => x.LoginName == loginName);
       

        public async Task ResetPassword(Guid userGuid, Guid passwordGuid, byte[] passwordHash)
        {
            DataUserAccount ua = await Set<DataUserAccount>().FindAsync(userGuid);

            if (ua != null)
            {
                ua.PasswordGuid = passwordGuid;
                ua.PasswordHash = passwordHash;
                await SaveChangesAsync();
            }
        }

        public async Task<bool> ResetLoginName(Guid userGuid, string loginName)
        {
            DataUserAccount ua = await Set<DataUserAccount>().FindAsync(userGuid);

            if (ua == null)
            {
                return false;
            }

            if (await AsQueryable<DataUserAccount>().AnyAsync(x => x.Guid != ua.Guid && x.LoginName == loginName))
            {
                return false;
            }

            ua.LoginName = loginName;
            return await SaveChangesAsync() > 0;
        }
    }
}
