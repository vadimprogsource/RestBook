using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public sealed class DataLocationMapper : DataEntityMapper<DataLocation>
    {
        public override void Map(EntityTypeBuilder<DataLocation> context)
        {
            base.Map(context);
            context.Property(x => x.OrgGuid).HasColumnName("location_org_guid");
            context.Property(x => x.ImageInfo).HasColumnName("location_img_info").HasMaxLength(255);
            context.Property(x => x.InterierInfo).HasColumnName("location_interier_info").HasMaxLength(255);
            context.Property(x => x.PlacesInfo).HasColumnName("location_palces_info").HasMaxLength(255);
            context.Property(x => x.CookDescription).HasColumnName("location_cook_descr");
            context.Property(x => x.EventDescription).HasColumnName("location_ev_descr");
            context.Property(x => x.ActionDescription).HasColumnName("location_act_descr");
            context.Property(x => x.WorkTimeFrom).HasColumnName("location_work_from");
            context.Property(x => x.WorkTimeTo).HasColumnName("location_work_to");


            context.HasOne(x => x.Org).WithMany(x=>x.Locations).HasForeignKey(x => x.OrgGuid);
        }


        public static DataLocation RESTAURANT_HALL = new DataLocation 
        {
              Guid = Guid.NewGuid(), 
              Name = "HALL", 
              OrgGuid = DataOrgMapper.ORG.Guid,
              ReorderLevel=1 , 
              WorkTimeFrom  = TimeSpan.Parse("07:00") , 
              WorkTimeTo = TimeSpan.Parse("02:00"), 
              ImageInfo = "hall-1.jpg",
              CookDescription = "Italian, Spanish, American", 
              InterierInfo= "interier_1.txt",
              PlacesInfo = "table_hall_1.txt",
              EventDescription="Live music every night",
              ActionDescription= "20% discount on the main menu from 12:00 to 16:00"
        };
        public static DataLocation RESTAURANT_BAR  = new DataLocation 
        { 
            Guid = Guid.NewGuid(), 
            Name = "BAR", 
            WorkTimeFrom = TimeSpan.Parse("00:00"), 
            WorkTimeTo = TimeSpan.Parse("08:00"),
            ImageInfo = "bar-1.jpg",
            CookDescription = "American",
            InterierInfo = "interier_2.txt",
            PlacesInfo = "table_bar_2.txt",
            EventDescription = "Caraoke every night",
            ActionDescription = "20 % discount on ALCOHOL",

            OrgGuid = DataOrgMapper.ORG.Guid,ReorderLevel=2 
        };



        public override void Seed(EntityTypeBuilder<DataLocation> context)
        {
            context.HasData(RESTAURANT_HALL, RESTAURANT_BAR);
        }
    }
}
