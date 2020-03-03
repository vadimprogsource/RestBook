using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Entity
{
    public abstract class DataContact : DataEntity, IContactEntity
    {
        public string Cellular { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Skype { get; set; }

        public string Title => Name;

        public override void Fill(IBussnessEntity obj)
        {
            base.Fill(obj);

            IContactEntity c = obj as IContactEntity;

            Cellular = c.Cellular;
            Phone    = c.Phone;
            Email    = c.Email;
            Skype    = c.Skype;
        }
    }
}
