using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class EntityModel
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        

        public EntityModel() { }
        public EntityModel(IBussnessEntity obj ) 
        {
            Guid = obj.Guid;
            Name = obj.Name;
        }


    }
}
