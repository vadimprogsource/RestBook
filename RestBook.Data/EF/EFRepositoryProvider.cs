using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RestBook.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Data.EF
{

    public class EFRepositoryProvider : DbContext , IDataRepositoryProvider
    {

        private static IDataModel[] mappers;



        static EFRepositoryProvider()
        {

            mappers = typeof(EFRepository)
                        .Assembly
                        .GetTypes()
                        .Where(x => x.IsClass && typeof(IDataModel).IsAssignableFrom(x) && x.IsSealed)
                        .Select(x => Activator.CreateInstance(x))
                        .OfType<IDataModel>()
                        .ToArray();
        }

        private readonly IDataConfig       m_data_config;
        private readonly IServiceProvider  m_service_provider;


        //[Obsolete("DataBase create method  is off!")]
        public EFRepositoryProvider(IServiceProvider provider)
        {
            m_service_provider = provider;
            m_data_config      = provider.GetService(typeof(IDataConfig)) as IDataConfig;
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IDataModel x in mappers)
            {
                x.Map(modelBuilder);
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                if (m_data_config.IsLogToConsole)
                {
                    //optionsBuilder.UseLoggerFactory(new LoggerFactory().AddConsole());
                }

                optionsBuilder.UseSqlServer(m_data_config.Connection);
            }
        }




        public TRepository CreateRepository<TRepository>() where TRepository : class => m_service_provider.GetService(typeof(TRepository)) as TRepository; 
        

      
        public TDataContext GetContext<TDataContext>() where TDataContext : class => this as TDataContext;

    

        private class EFTransaction : ITransactionScope
        {
           private IDbContextTransaction  m_transaction;

            public EFTransaction(IDbContextTransaction transaction)
            {
                m_transaction = transaction;
            }

            public Task Commit()=>m_transaction.CommitAsync();
   
            public void Dispose()
            {
                if (m_transaction != null)
                {
                    m_transaction.Commit();
                    m_transaction = null;
                }
            }

            public Task Rollback() => m_transaction.RollbackAsync();
           
        }


        public async Task<ITransactionScope> TransactionScope()
        {
            return new EFTransaction(await Database.BeginTransactionAsync());
        }



    }
}
