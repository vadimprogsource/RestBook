using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class AccessTokenModel
    {
        public string Title { get; set; }
        public bool Ok { get; set; }
        public string Token { get; set; }


        public AccessTokenModel()
        {
            
        }

        public AccessTokenModel(IAccessToken accessToken)
        {

            if (accessToken == null)
            {
                Title = string.Empty;
                Ok = false;
                Token = string.Empty;
            }
            else
            {
                Ok = true;
                Title = accessToken.User.Name;
                Token = accessToken.ToString();
            }
        }
    }
}
