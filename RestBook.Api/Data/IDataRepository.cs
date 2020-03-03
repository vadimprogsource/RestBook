using RestBook.Api.Filter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Data
{
    public interface IDataRepository<TEntity>
    {

        Task<IEnumerable<TEntity>> Select(IFilter filter);
        Task<TEntity> Select(Guid guid);
        Task<IEnumerable<TEntity>> SelectMany(Guid[] guids);

        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool>    Delete(Guid guid);
    }
}
