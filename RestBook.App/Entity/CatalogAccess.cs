using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.App.Entity
{
    public class CatalogAccess : ICatalogAccess
    {
        public bool IsHoliday { get; set; }
        public bool IsWeekend { get; set; }

        public bool IsWorkDay { get; set; }

        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }

        public Catalog Catalog { get; set; }

        ICatalog ICatalogAccess.Catalog => Catalog;


        public CatalogAccess(ICatalogAccess catalogAccess)
        {
            IsHoliday = catalogAccess.IsHoliday;
            IsWeekend = catalogAccess.IsWeekend;
            IsWorkDay = catalogAccess.IsWorkDay;
            FromTime  = catalogAccess.FromTime;
            ToTime   = catalogAccess.ToTime;

            if (catalogAccess.Catalog!=null)
            {
                Catalog = new Catalog(catalogAccess.Catalog);
            }

        }


        public bool IsFilter(DateTime now)
        {
            bool flag = false;

            if (IsWeekend)
            {
                flag |= now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday;
            }


            if (IsWorkDay)
            {
                flag |= now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday;
            }

            flag &= now.TimeOfDay >= FromTime && now.TimeOfDay <= ToTime;
            return flag;
        }
    }
}
