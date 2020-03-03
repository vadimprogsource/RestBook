using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public sealed  class DataAddressMapper : DataObjectMapper<DataAddress>
    {

        protected override string TableName => "addresses";


        public override void Map(EntityTypeBuilder<DataAddress> context)
        {
            base.Map(context);

            context.Property(x => x.LT      ).HasColumnName("last_access_time");
            context.Property(x => x.Region  ).HasColumnName("region").HasMaxLength(100);
            context.Property(x => x.City    ).HasColumnName("city").HasMaxLength(100);
            context.Property(x => x.ZipCode ).HasColumnName("zip").HasMaxLength(20);
            context.Property(x => x.Street  ).HasColumnName("street").HasMaxLength(100);
            context.Property(x => x.House   ).HasColumnName("house").HasMaxLength(10);
            context.Property(x => x.Building).HasColumnName("build").HasMaxLength(10);
            context.Property(x => x.Flat    ).HasColumnName("flat").HasMaxLength(10);
            context.Property(x => x.Floor   ).HasColumnName("floor").HasMaxLength(10);
            context.Property(x => x.HashCode).HasColumnName("hash_code");
        }

        public static DataAddress ADDRESS = new DataAddress { Guid = Guid.NewGuid(), City = "Minsk", Country = "RB", Street = "Timiryazev str.", House = "9", Building = "10" };


        public override void Seed(EntityTypeBuilder<DataAddress> context)
        {
            context.HasData(ADDRESS);
        }
    }
}
