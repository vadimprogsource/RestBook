using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.App.Entity
{
    public class UserSession : BaseEntity, IAccessToken
    {

        public readonly static UserSession Empty = new UserSession();

        public DateTime CreatedDateTime { get; set; }

        public DateTime ExpiredDateTime { get; set; }

        public bool HasExpired => ExpiredDateTime <=DateTime.Now;

        public UserAccount User { get; set; }

        IUserAccount IAccessToken.User => User;

        public UserSession() { }
        public UserSession(IAccessToken accessToken) : base(accessToken) 
        {
            CreatedDateTime = accessToken.CreatedDateTime;
            ExpiredDateTime = accessToken.ExpiredDateTime;

            User = new UserAccount(accessToken.User);
        }

        public override string ToString() => Guid.ToString("N");
    }
}
