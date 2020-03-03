using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public sealed class DataCatalogMapper : DataEntityMapper<DataCatalog>
    {
        public override void Map(EntityTypeBuilder<DataCatalog> context)
        {
            base.Map(context);
        }


        public static DataCatalog  MENU     = new DataCatalog { Guid = Guid.NewGuid(), Name = "MENU"    ,ReorderLevel=1};
        public static DataCatalog  BAR_MENU = new DataCatalog { Guid = Guid.NewGuid(), Name = "BAR MENU",ReorderLevel=2};



        public override void Seed(EntityTypeBuilder<DataCatalog> context)
        {
            context.HasData(MENU, BAR_MENU);
        }
    }
}
