using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.App.Entity
{
    public class Address  :IAddress
    {
        public Address() { }
        public Address(IAddress address)  
        {
            Country = address.Country;
            ZipCode = address.ZipCode;
            Region = address.Region;
            City = address.City;
            Street = address.Street;
            House = address.House;
            Building = address.Building;
            Floor = address.Floor;
            Flat = address.Flat;
        }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Building { get; set; }

        public string Floor { get; set; }

        public string Flat { get; set; }
    }
}
