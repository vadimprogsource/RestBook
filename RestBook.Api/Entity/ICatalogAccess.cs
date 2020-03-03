using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{
    public interface ICatalogAccess
    {
        bool IsHoliday { get; }
        bool IsWeekend { get; }
        bool IsWorkDay { get; }

        TimeSpan FromTime { get; }
        TimeSpan ToTime { get; }

        public ICatalog Catalog { get; }
    }
}
