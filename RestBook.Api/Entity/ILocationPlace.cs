using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{
    public interface ILocationPlace
    {
        ILocation Location { get; }
        string PlaceCode { get; } 
    }

    public interface ILocationPlaces
    {
        ILocation Location { get; }
        string[] PlaceCodes { get; }

    }
}
