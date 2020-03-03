using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.Data.EF;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public sealed class DataCatalogAccessMapper : DataModelMapper<DataCatalogAccess>
    {
        protected override string TableName => "catalogs_access";

        public override void Map(EntityTypeBuilder<DataCatalogAccess> context)
        {
            context.Property(x => x.Index).HasColumnName("access_index");
            context.Property(x => x.IsHoliday).HasColumnName("access_holiday_flag");
            context.Property(x => x.IsWeekend).HasColumnName("access_weekend_flag");
            context.Property(x => x.IsWorkDay).HasColumnName("access_workday_flag");
            context.Property(x => x.FromTime ).HasColumnName("access_start_time");
            context.Property(x => x.ToTime   ).HasColumnName("access_to_time");
            context.Property(x => x.LocationGuid).HasColumnName("access_location_guid");
            context.Property(x => x.CatalogGuid).HasColumnName("access_catalog_guid");

            context.HasKey(x => new { x.LocationGuid , x.CatalogGuid,x.Index });

            context.HasOne(x => x.Location).WithMany(x=>x.Catalogs).HasForeignKey(x => x.LocationGuid);
            context.HasOne(x => x.Catalog).WithMany().HasForeignKey(x => x.CatalogGuid);


        }



        public override void Seed(EntityTypeBuilder<DataCatalogAccess> context)
        {
            
            context.HasData
            (
                new DataCatalogAccess { CatalogGuid = DataCatalogMapper.MENU.Guid    , FromTime = TimeSpan.FromHours(0).Ticks , ToTime = TimeSpan.FromHours(23).Ticks , IsHoliday = true, IsWeekend = true , IsWorkDay = true, LocationGuid = DataLocationMapper.RESTAURANT_HALL.Guid,Index=1} ,
                new DataCatalogAccess { CatalogGuid = DataCatalogMapper.BAR_MENU.Guid, FromTime = TimeSpan.FromHours(0).Ticks , ToTime = TimeSpan.FromHours(23).Ticks , IsHoliday = true, IsWeekend = true , IsWorkDay = true, LocationGuid = DataLocationMapper.RESTAURANT_BAR.Guid, Index = 2 }
            );
            
        }
    }
}
