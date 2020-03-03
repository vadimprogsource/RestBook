using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Entity
{
    public class DataUserSession : DataObject, IAccessToken
    {
        public DateTime CreatedDateTime { get; set; }

        public DateTime ExpiredDateTime { get; set; }

        public bool HasExpired => false;

        public Guid PinCodeGuid { get; set; }
        public byte[] PinCodeHash { get; set; }

        public Guid UserGuid { get; set; }
        public DataUserAccount User { get; set; }

        IUserAccount IAccessToken.User => User;

        public override void Fill(IEntity entity)
        {
            IAccessToken at = entity as IAccessToken;

            Guid = entity.Guid;
            CreatedDateTime = at.CreatedDateTime;
            ExpiredDateTime = at.ExpiredDateTime;
            UserGuid = at.User.Guid;

        }
    }
}
