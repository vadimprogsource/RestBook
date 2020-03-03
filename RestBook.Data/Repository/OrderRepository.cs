using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : DataEntityRepository<IRetailOrder, DataOrder> , IOrderRepository
    {
        public OrderRepository(IDataRepositoryProvider  provider) : base(provider)
        {
        }

        public async Task<int> GetMaxReorderLevel(Guid orgGuid, int year)
        {
            try
            {
                DateTime start = new DateTime(year, 1, 1), end = start.AddYears(1);
                return await AsQueryable<DataOrder>().Where(x =>x.OrgGuid == orgGuid &&  x.OrderedAt >= start && x.OrderedAt < end).MaxAsync(x => x.ReorderLevel);
            }
            catch 
            {
                return default;
            }
       }


        public async override Task<IRetailOrder> Insert(IRetailOrder order)
        {

            DataOrder dataOrder = new DataOrder(order);
            Set<DataOrder>().Add(dataOrder);

            DbSet<DataOrderItem> itemSet = Set<DataOrderItem>();

            foreach (IOrderDetail detail in order.Details)
            {
                foreach (IOrderItem item in detail.Items)
                {
                    itemSet.Add(new DataOrderItem(order, detail, item));
                }
            }

            await SaveChangesAsync();
            return order;
        }


        public async override Task<bool> Delete(Guid guid)
        {
            DbSet<DataOrder> orderSet = Set<DataOrder>();
            DataOrder order = await orderSet.FindAsync(guid);

            if (order != null)
            {
                DbSet<DataOrderItem> itemSet = Set<DataOrderItem>();

                DataOrderItem[] items = await itemSet.Where(x => x.OrderGuid == guid).ToArrayAsync();

                if (items != null || items.Any())
                {
                    itemSet.RemoveRange(items);
                }

                orderSet.Remove(order);
                return await SaveChangesAsync() > 0;
            }

            return false;
        }


        private IQueryable<DataOrder> SelectDataOrder()=>  Set<DataOrder>()
                                                          .Include(x => x.Org)
                                                          .Include(x => x.Rows)
                                                          .ThenInclude(x => x.Product)
                                                          .Include(x => x.Rows)
                                                          .ThenInclude(x => x.Location)
                                                          .AsNoTracking();
        

        private IQueryable<DataOrder> SelectDataOrderRange(Guid orgGuid , DateTime start, DateTime end) => SelectDataOrder().Where(x => x.OrgGuid == orgGuid && x.OrderedAt >= start && x.OrderedAt <= end);
        

        public async Task<IEnumerable<IRetailOrder>> GetActiveOrders(IUserAccount userAccount)=> await SelectDataOrder()
                       .OrderByDescending(x => x.OrderedAt)
                       .ThenByDescending(x => x.ReorderLevel)
                       .Where(x=>x.CustomerGuid==userAccount.Guid)
                       .ToArrayAsync();
        

        public async override Task<IRetailOrder> Select(Guid guid)=> await SelectDataOrder().FirstOrDefaultAsync(x => x.Guid==guid);
        


        public async Task<IEnumerable<IRetailOrder>> GetOrders(Guid orgGuid, Guid? locationGuid, DateTime startDate, DateTime endDate)
        {
            IQueryable<DataOrder> query = SelectDataOrderRange(orgGuid , startDate, endDate);


            if (locationGuid.HasValue)
            {
                query = query.Where(x => x.Rows.Any(x => x.LocationGuid == locationGuid));
            }

            return await query.OrderByDescending(x => x.OrderedAt).ThenByDescending(x => x.ReorderLevel).ToArrayAsync();
        }
    }
}
