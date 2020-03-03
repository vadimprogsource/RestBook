using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestBook.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Data.EF
{
    public class EFRepository 
    {

        private readonly DbContext m_db_context;


        public EFRepository(IDataRepositoryProvider provider)
        {
            m_db_context = provider.GetContext<DbContext>();
        }


        protected DbSet<TEntity> Set<TEntity>() where TEntity : class => m_db_context.Set<TEntity>();


        protected IQueryable<TEntity> AsQueryable<TEntity>() where TEntity : class => Set<TEntity>().AsNoTracking();

        protected Task<int> SaveChangesAsync() => m_db_context.SaveChangesAsync();
    }
}
