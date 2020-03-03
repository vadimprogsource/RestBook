using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Entity
{
    public abstract class DataObject : IEntity
    {
        public Guid Guid { get; set; }

        public int ReorderLevel { get; set; }

        public abstract void Fill(IEntity entity);
    }
}
