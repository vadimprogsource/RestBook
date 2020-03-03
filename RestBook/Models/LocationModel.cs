using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class LocationModel : EntityModel , ILocation
    {

        private TimeSpan m_work_from;
        private TimeSpan m_work_to;


        public IEnumerable<CatalogModel> Catalogs { get; set; }
        public string Uri { get; set; }

        public string ImageInfo { get; set; }

        public string WorkTimeFrom { get => m_work_from.ToString(); set => m_work_from = TimeSpan.Parse(value); }

        public string WorkTimeTo { get => m_work_to.ToString(); set => m_work_to = TimeSpan.Parse(value); }

        public string CookDescription { get; set; }

        public string InterierInfo { get; set; }

        public string PlacesInfo { get; set; }

        public string ActionDescription { get; set; }

        public string EventDescription { get; set; }

        IEnumerable<ICatalogAccess> ILocation.Catalogs => throw new NotImplementedException();

        string   IBussnessEntity.Code => string.Empty;

        public string Description { get; set; }

        int IEntity.ReorderLevel => 0;

        TimeSpan ILocation.WorkTimeFrom => m_work_from;

        TimeSpan ILocation.WorkTimeTo => m_work_to;

        public LocationModel(ILocation location) : base(location)
        {
            Uri = location.Uri;
            if (location.Catalogs != null && location.Catalogs.Any())
            {
                Catalogs = location.Catalogs.Where(x=>x.Catalog!=null).Select(x => new CatalogModel(x.Catalog)).ToArray();
            }

            Uri = location.Uri;
            ImageInfo = location.ImageInfo;
            m_work_from = location.WorkTimeFrom;
            m_work_to   = location.WorkTimeTo;

            InterierInfo = location.InterierInfo;
            PlacesInfo = location.PlacesInfo;

            CookDescription = location.CookDescription;
            ActionDescription = location.ActionDescription;
            EventDescription = location.EventDescription;
        }
    }
}
