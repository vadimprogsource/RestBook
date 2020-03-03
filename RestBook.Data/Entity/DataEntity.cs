using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Entity
{
    public class DataEntity : DataObject, IBussnessEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Uri { get; set; }

        public string Description { get; set; }


        public virtual void Fill(IBussnessEntity obj)
        {
            Guid = obj.Guid;
            Name = obj.Name;
            Code = obj.Code;
            Uri  = obj.Uri;
            Description = obj.Description;
        }

        public override void Fill(IEntity entity)
        {
            Fill(entity as IBussnessEntity);
        }
    }
}
