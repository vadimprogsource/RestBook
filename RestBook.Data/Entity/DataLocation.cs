using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestBook.Data.Entity
{
    public class DataLocation :DataEntity ,  ILocation
    {
        public IEnumerable<DataCatalogAccess> Catalogs { get; set; }
        public Guid OrgGuid { get; set; }
        public DataOrg Org  { get; set; }

        public string ImageInfo { get; set; }

        public TimeSpan WorkTimeFrom { get; set; }

        public TimeSpan WorkTimeTo { get; set; }

        public string CookDescription { get; set; }

        public string InterierInfo { get; set; }

        public string PlacesInfo { get; set; }

        public string ActionDescription { get; set; }

        public string EventDescription { get; set; }

        IEnumerable<ICatalogAccess> ILocation.Catalogs => Catalogs;
    }
}
