using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{

    public interface ILocation : IBussnessEntity
    {

        string ImageInfo { get; }
        TimeSpan WorkTimeFrom { get; }
        TimeSpan WorkTimeTo   { get; }
        string CookDescription { get;}
        string InterierInfo { get; }
        string PlacesInfo  { get; }
        string ActionDescription { get; }
        string EventDescription { get; }
        IEnumerable<ICatalogAccess> Catalogs { get; }
    }

    public interface IOrg : IContactEntity
    {
        int Rating { get; }
        IAddress Address                 { get; }
        IEnumerable<ILocation> Locations { get; }
    }
}
