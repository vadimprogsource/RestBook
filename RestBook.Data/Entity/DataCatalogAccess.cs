using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Entity
{
    public class DataCatalogAccess : ICatalogAccess
    {
        public int Index { get; set; }
        public bool IsWeekend { get; set; }
        public bool IsWorkDay { get; set; }
        public bool IsHoliday { get; set; }
        public long FromTime { get; set; }
        public long ToTime { get; set; }
        
        
        public DataLocation Location { get; set; }
        public Guid LocationGuid { get; set; }
        public Guid CatalogGuid  { get; set; }

        public DataCatalog Catalog { get; set; }

        ICatalog ICatalogAccess.Catalog => Catalog;

        TimeSpan ICatalogAccess.FromTime => TimeSpan.FromTicks(FromTime);
        TimeSpan ICatalogAccess.ToTime => TimeSpan.FromTicks(ToTime);
    }
}
