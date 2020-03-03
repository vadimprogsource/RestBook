using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class AddressModel : IAddress
    {
        public AddressModel() { }
        public AddressModel(IAddress address)
        {
            City = address.City;
            Street = address.Street;
            House = address.House;
            Building = address.Building;
            Floor = address.Floor;
            Flat = address.Flat;
        }

        public string City { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Building { get; set; }

        public string Floor { get; set; }

        public string Flat { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public string Region { get; set; }
    }
}
