using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestBook.App.Entity
{
    public class Location : BussinessEntity, ILocation
    {
        public Location() { }
        public Location(ILocation loc) : base(loc) 
        {
            if (loc.Catalogs != null && loc.Catalogs.Any())
            {
                Catalogs = loc.Catalogs.Select(x => new CatalogAccess(x)).ToArray();
            }

            ImageInfo = loc.ImageInfo;
            WorkTimeFrom = loc.WorkTimeFrom;
            WorkTimeTo = loc.WorkTimeTo;
            CookDescription = loc.CookDescription;
            InterierInfo = loc.InterierInfo;
            PlacesInfo = loc.PlacesInfo;
            ActionDescription = loc.ActionDescription;
            EventDescription = loc.EventDescription;
        }

       public IEnumerable<CatalogAccess> Catalogs { get; set; }

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
