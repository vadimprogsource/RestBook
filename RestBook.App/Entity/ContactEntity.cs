using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.App.Entity
{
   public class ContactEntity : BussinessEntity , IContactEntity
    {
        public string Cellular { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Skype { get; set; }

        public string Title => Name;


        public IContactData Data 
        { 
            get =>this;
            set
            {
                Name = value.Title;
                Cellular = value.Cellular;
                Phone = value.Phone;
                Email = value.Email;
                Skype = value.Skype;
            }
        }

        public ContactEntity() { }


        
        public ContactEntity(IContactEntity contact) : base(contact) 
        {
            Data = contact;
        }

    }
}
