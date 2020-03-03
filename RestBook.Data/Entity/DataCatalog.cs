using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.Entity
{
    public class DataCatalog : DataEntity, ICatalog
    {
       public IEnumerable<DataGroup>    Groups { get; set; }
    
        IEnumerable<IGroup> ICatalog.Groups => Groups;
    }
}
