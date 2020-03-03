using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestBook.App.Entity
{
    public class Org : ContactEntity, IOrg
    {
        public int Rating { get; set; }



        public Address Address { get; set; }

        public Location[] Locations { get; set; }

        public Org() { }

        public Org(IOrg org) : base(org) 
        {
            Rating = org.Rating;


            if (org.Address!=null)
            {
                Address = new Address(org.Address); 
            }

            if (org.Locations != null && org.Locations.Any())
            {
                Locations = org.Locations.Select(x => new Location(x)).OrderBy(x=>x.ReorderLevel).ToArray();
            }
        }

  
        IEnumerable<ILocation> IOrg.Locations => Locations;

        IAddress IOrg.Address => Address;
    }
}
