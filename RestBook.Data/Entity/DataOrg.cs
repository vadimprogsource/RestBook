using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Entity
{
    public class DataOrg : DataContact, IOrg
    {
        public IEnumerable<DataLocation> Locations { get; set; }
        public Guid AddressGuid { get; set; }
        public DataAddress Address { get; set; }
        public int Rating{ get;set; }
        IEnumerable<ILocation> IOrg.Locations => Locations;
        IAddress IOrg.Address => Address;


   
    }
}
