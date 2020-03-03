using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Service
{
    public interface IBookingService
    {

        Task<IEnumerable<ILocationPlaces>> GetReservedLocationPlaces(Guid orgGuid, DateTime today , Guid? locationGuid);
    }
}
