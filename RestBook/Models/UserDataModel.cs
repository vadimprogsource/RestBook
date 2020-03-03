using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class UserDataModel : IContactData
    {
        public string Title { get; set; }
        public string Cellular { get; set; }
    
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Phone { get; set; }

        public string Skype { get; set; }

        public string Token { get; set; }

        public string LoginName { get; set; }
        public UserDataModel() { }

        public UserDataModel(IContactData data)
        {
            Title = data.Title;
            Cellular = data.Cellular;
            Email = data.Email;
            Skype = data.Skype;
            Phone = data.Phone;
        }
    }
}
