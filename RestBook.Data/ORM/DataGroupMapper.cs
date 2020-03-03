using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public sealed class DataGroupMapper : DataEntityMapper<DataGroup>
    {
        public override void Map(EntityTypeBuilder<DataGroup> context)
        {
            base.Map(context);
            context.Property(x => x.CatalogGuid).HasColumnName("cat_guid");

            context.HasOne(x => x.Catalog).WithMany(x=>x.Groups).HasForeignKey(x => x.CatalogGuid);
        
        }




        public static DataGroup SALADS       = new DataGroup { Guid = Guid.NewGuid(), Name = "SALADS", Code = "01", CatalogGuid = DataCatalogMapper.MENU.Guid  ,ReorderLevel=1 };
        public static DataGroup COLD_SNACKS = new DataGroup  { Guid = Guid.NewGuid(), Name = "COLD SNACKS", Code = "02", CatalogGuid = DataCatalogMapper.MENU.Guid, ReorderLevel = 2 };
        public static DataGroup HOT_APPETIZERS = new DataGroup { Guid = Guid.NewGuid(), Name = "HOT APPETIZERS", Code = "03", CatalogGuid = DataCatalogMapper.MENU.Guid, ReorderLevel = 3 };
        public static DataGroup BURGERS = new DataGroup { Guid = Guid.NewGuid(), Name = "BURGERS", Code = "04", CatalogGuid = DataCatalogMapper.MENU.Guid, ReorderLevel = 4 };
        public static DataGroup SOUPS = new DataGroup { Guid = Guid.NewGuid(), Name = "SOUPS", Code = "05", CatalogGuid = DataCatalogMapper.MENU.Guid, ReorderLevel = 5 };
        public static DataGroup POULTRY_DISHES = new DataGroup { Guid = Guid.NewGuid(), Name = "POULTRY DISHES", Code = "06", CatalogGuid = DataCatalogMapper.MENU.Guid, ReorderLevel = 6 };
        public static DataGroup GOURMET_DISHES = new DataGroup { Guid = Guid.NewGuid(), Name = "GOURMET DISHES", Code = "07", CatalogGuid = DataCatalogMapper.MENU.Guid, ReorderLevel = 7};
        public static DataGroup PASTA_RAVIOLI_RISOTTO = new DataGroup { Guid = Guid.NewGuid(), Name = "PASTA, RAVIOLI & RISOTTO", Code = "08", CatalogGuid = DataCatalogMapper.MENU.Guid, ReorderLevel = 8 };
        public static DataGroup SETS = new DataGroup { Guid = Guid.NewGuid(), Name = "SETS", Code = "09", CatalogGuid = DataCatalogMapper.MENU.Guid , ReorderLevel = 9 };
        public static DataGroup DESSERT = new DataGroup { Guid = Guid.NewGuid(), Name = "DESSERT", Code = "10", CatalogGuid = DataCatalogMapper.MENU.Guid, ReorderLevel = 10 };
        public static DataGroup BEEF_DISHES = new DataGroup { Guid = Guid.NewGuid(), Name = "BEEF DISHES", Code = "11", CatalogGuid = DataCatalogMapper.MENU.Guid , ReorderLevel = 11 };
        public static DataGroup FISH_AND_SEAFOOD_DISHES = new DataGroup { Guid = Guid.NewGuid(), Name = "FISH AND SEAFOOD DISHES", Code = "12", CatalogGuid = DataCatalogMapper.MENU.Guid, ReorderLevel = 12 };
        public static DataGroup PORK_DISHES = new DataGroup { Guid = Guid.NewGuid(), Name = "PORK DISHES", Code = "13", CatalogGuid = DataCatalogMapper.MENU.Guid , ReorderLevel = 13 };



        public override void Seed(EntityTypeBuilder<DataGroup> context)
        {
            context.HasData(SALADS, COLD_SNACKS, HOT_APPETIZERS, BURGERS, SOUPS, POULTRY_DISHES, GOURMET_DISHES, PASTA_RAVIOLI_RISOTTO, SETS, DESSERT, BEEF_DISHES, FISH_AND_SEAFOOD_DISHES, PORK_DISHES ); 
        }
    }
}
