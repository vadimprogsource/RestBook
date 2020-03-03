using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class LocationPlacesModel
    {
        public Guid Guid   { get; set; }
        public string Name { get; set; }

        public string[] PlaceCodes { get; set; }

        public LocationPlacesModel(ILocationPlaces locationPlaces)
        {

            Guid = locationPlaces.Location.Guid;
            Name = locationPlaces.Location.Name;

            PlaceCodes = locationPlaces.PlaceCodes;
        }
    }
}
