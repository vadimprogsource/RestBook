using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Entity
{
    public class DataAddress : DataObject, IAddress
    {
        public DateTime LT { get; set; }
        public string Country { get; set; }

        public string ZipCode { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Building { get; set; }

        public string Floor { get; set; }

        public string Flat { get; set; }

        public Guid HashCode { get; set; }

        public override void Fill(IEntity entity)
        {
            
        }
    }
}
