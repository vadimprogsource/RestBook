using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.App.Entity
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Guid { get; set; }
        public int  ReorderLevel { get; set; }

        public BaseEntity() { }
        public BaseEntity(IEntity obj) 
        {
            Guid         = obj.Guid;
            ReorderLevel = obj.ReorderLevel;
        }

    }
}
