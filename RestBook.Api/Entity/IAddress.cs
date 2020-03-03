using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{
    public interface IAddress
    {
        string Country { get; }
        string ZipCode { get; }
        string Region { get; }
        string City { get; }
        string Street { get; }
        string House { get; }
        string Building { get; }
        string Floor { get; }
        string Flat { get; }

    }
}
