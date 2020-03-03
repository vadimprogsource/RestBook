using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class OrgModel : EntityModel ,IOrg
    {
        public int Rating { get; set; }

        public AddressModel Address { get; set; }

        public IEnumerable<LocationModel> Locations { get; set; }

        public string Cellular { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Skype { get; set; }


        public string Uri { get; set; }

        public string Description { get; set; }

        IAddress IOrg.Address => Address;

        IEnumerable<ILocation> IOrg.Locations => null;


        string IBussnessEntity.Code => string.Empty;

        public int ReorderLevel { get; set; }

        public string Title => Name;


        public OrgModel()
        {
            
        }

        public OrgModel(IOrg org) : base(org)
        {
            Rating = org.Rating;

            ReorderLevel = org.ReorderLevel; 

            if (org.Address != null)
            {
                Address = new AddressModel(org.Address);
            }

            Cellular = org.Cellular;
            Phone = org.Phone;
            Email = org.Email;
            Skype = org.Skype;

            Description = org.Description;
            Uri = org.Uri;

            if (org.Locations != null && org.Locations.Any())
            {
                Locations = org.Locations.Select(x => new LocationModel(x)).ToList();
            }
        }


    }
}
