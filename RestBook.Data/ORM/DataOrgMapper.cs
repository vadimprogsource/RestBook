using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public sealed class DataOrgMapper : DataContactMapper<DataOrg>
    {
        public override void Map(EntityTypeBuilder<DataOrg> context)
        {
            base.Map(context);
            context.Property(x => x.AddressGuid).HasColumnName("org_address_guid");
            context.Property(x => x.Rating).HasColumnName("org_rating");
            context.HasOne(x => x.Address).WithMany().HasForeignKey(x => x.AddressGuid);
        }

        public static DataOrg ORG = new DataOrg { Guid = Guid.NewGuid(), AddressGuid = DataAddressMapper.ADDRESS.Guid, Name = "Brooklyn", Cellular = "+375 (29) 577 33 77" ,Rating =1 , ReorderLevel =1 };



        public override void Seed(EntityTypeBuilder<DataOrg> context)
        {
            context.HasData(ORG);
        }


    }
}
