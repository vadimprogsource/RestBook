using RestBook.Api.Entity;
using RestBook.Api.Provider;
using RestBook.Api.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.App.Service
{
    public class BookingService : IBookingService
    {
        private IOrderProvider m_order_provider;

        public BookingService(IOrderProvider orderProvider)
        {
            m_order_provider = orderProvider;
        }


        private class LocationPlaces : ILocationPlaces
        {
            public ILocation Location { get; }

            public string[] PlaceCodes { get; }

            public LocationPlaces(ILocation location ,   IEnumerable<string> placeCodes)
            {
                Location = location;
                PlaceCodes = placeCodes.ToArray();
            }
        }

        
        public async Task<IEnumerable<ILocationPlaces>> GetReservedLocationPlaces(Guid orgGuid, DateTime today, Guid? locationGuid)
        {
            return (await m_order_provider.GetOrders(orgGuid, today, locationGuid))
                   .SelectMany(x => x.Details)
                   .GroupBy(x => x.Location.Guid)
                   .Select(x => new LocationPlaces(x.First().Location, x.Select(y => y.PlaceCode)))
                   .OrderBy(x=>x.Location.ReorderLevel)
                   .ToArray();
        }
    }
}
