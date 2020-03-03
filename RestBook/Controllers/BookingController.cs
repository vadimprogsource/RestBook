using Microsoft.AspNetCore.Mvc;
using RestBook.Api.Service;
using RestBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Controllers
{

    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService m_booking_service;

        public BookingController(IBookingService bookingService)
        {
            m_booking_service = bookingService;
        }

        [HttpGet("reserved/{orgGuid}/{yyyy}/{mm}/{dd}")]
        public  async Task<IActionResult> GetReserved(Guid orgGuid, int yyyy, int mm, int dd)
        {
            try
            {
                return Ok(( await m_booking_service.GetReservedLocationPlaces(orgGuid , new DateTime(yyyy, mm, dd), null)).Select(x=>new LocationPlacesModel(x)).ToArray());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("reserved/{orgGuid}/{yyyy}/{mm}/{dd}/{locationGuid}")]
        public async Task<IActionResult> GetReserved(Guid orgGuid, int yyyy, int mm, int dd, Guid locationGuid)
        {
            try
            {
                return Ok((await m_booking_service.GetReservedLocationPlaces(orgGuid, new DateTime(yyyy, mm, dd), locationGuid)).Select(x => new LocationPlacesModel(x)).ToArray());
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
