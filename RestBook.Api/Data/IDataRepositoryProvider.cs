using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Data
{

    public interface ITransactionScope : IDisposable
    {
        Task Commit();
        Task Rollback();
        
    }

    public interface IDataRepositoryProvider
    {
        Task<ITransactionScope> TransactionScope();
        TRepository CreateRepository<TRepository>() where TRepository : class;
        TDataContext GetContext<TDataContext>() where TDataContext :class;
    }
}
