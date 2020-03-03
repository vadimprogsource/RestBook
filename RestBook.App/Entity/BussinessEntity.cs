using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.App.Entity
{
    public abstract class BussinessEntity : BaseEntity ,  IBussnessEntity
    {
    
        public string Name { get; set; }

        public string Code { get; set; }

        public string Uri { get; set; }

        public string Description { get; set; }

        public BussinessEntity() { }
        public BussinessEntity(IBussnessEntity obj) 
        {
            Guid = obj.Guid;
            Name = obj.Name;
            Code = obj.Code;
            Uri  = obj.Uri;

            Description = obj.Description;
        }

    }
}
