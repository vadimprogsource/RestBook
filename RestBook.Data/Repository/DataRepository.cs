using Microsoft.EntityFrameworkCore;
using RestBook.Api.Data;
using RestBook.Api.Entity;
using RestBook.Api.Filter;
using RestBook.Data.EF;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Data.Repository
{
    public abstract class DataRepository<TInterface, TObject> :EFRepository, IDataRepository<TInterface> where TObject : DataObject, TInterface, new() where TInterface : IEntity
    {
        public DataRepository(IDataRepositoryProvider provider) : base(provider)
        {
        }


        public abstract IQueryable<TObject> Where(IQueryable<TObject> query , IFilter filter);

        public async Task<IEnumerable<TInterface>> Select(IFilter filter)
        {
            IQueryable<TObject> query = Where ( Set<TObject>().AsNoTracking() , filter);

            query = query.OrderBy(x => x.ReorderLevel);

            int skipped = filter.PageIndex * filter.PageSize;

            if (skipped > 0)
            {
                query = query.Skip(skipped);
            }

            return await query.Take(filter.PageSize).ToArrayAsync();  

        }


        public virtual async Task<TInterface> Select(Guid guid)
        {
            return await AsQueryable<TObject>().SingleAsync (x => x.Guid == guid);
        }

        public virtual async Task<TInterface> Insert(TInterface entity)
        {

            DbSet<TObject> objectSet = Set<TObject>();

            TObject obj = new TObject();
            obj.Fill(entity);

            if (obj.Guid == Guid.Empty)
            {
                obj.Guid = Guid.NewGuid();
            }

            objectSet.Add(obj);

            await SaveChangesAsync();
            return obj;
        }

        public virtual async Task<TInterface> Update(TInterface entity)
        {

            DbSet<TObject> objectSet = Set<TObject>();
            TObject obj = objectSet.Find(entity.Guid);

            if (obj != null)
            {
                obj.Fill(entity);
                await SaveChangesAsync();
                return obj;
            }

            return default;
        }

        public virtual async Task<bool> Delete(Guid guid)
        {
            DbSet<TObject> objectSet = Set<TObject>();
            TObject obj = objectSet.Find(guid);

            if (obj != null)
            {
                objectSet.Remove(obj);
                return await SaveChangesAsync() > 0;
            }

            return default;

        }


        protected virtual async Task<bool> Delete(Expression<Func<TObject, bool>> condition,int taken=int.MaxValue)
        {
            DbSet<TObject> dataSet = Set<TObject>();

            TObject[] removed;

            if (taken > 0 && taken < int.MaxValue)
            {
                removed = await dataSet.Where(condition).Take(taken).ToArrayAsync();
            }
            else
            {
                removed = await dataSet.Where(condition).ToArrayAsync();
            }


            if (removed != null && removed.Length > 0)
            {
                dataSet.RemoveRange(removed);
                return await SaveChangesAsync()>0;
            }

            return false;

        }

        public virtual async Task<IEnumerable<TInterface>> SelectMany(Guid[] guids)
        {
            return await AsQueryable<TObject>().Where(x => guids.Contains(x.Guid)).ToArrayAsync();
        }
    }


    public class DataEntityRepository<TInterface, TEntity> : DataRepository<TInterface, TEntity> where TEntity : DataEntity, TInterface, new() where TInterface : IBussnessEntity
    {
        public DataEntityRepository(IDataRepositoryProvider provider) : base(provider)
        {
        }

        public override IQueryable<TEntity> Where(IQueryable<TEntity> query, IFilter filter)
        {

            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                query = query.Where(x => x.Name.Contains(filter.SearchText) || x.Description.Contains(filter.SearchText));
            }

            return query;
        }
    }
}
