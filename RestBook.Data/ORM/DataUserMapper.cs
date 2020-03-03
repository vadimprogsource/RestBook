using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.App.Builder;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public sealed class DataUserMapper : DataContactMapper<DataUserAccount>
    {


        public override void Map(EntityTypeBuilder<DataUserAccount> context)
        {
            base.Map(context);

            context.Property(x => x.CreatedDateTime).HasColumnName("user_created_dt");
            context.Property(x => x.Role           ).HasColumnName("user_access_role");
            context.Property(x => x.LoginName      ).HasColumnName("user_login_name").HasMaxLength(50);

            context.Property(x => x.AddressGuid    ).HasColumnName("user_address_guid");
            context.Property(x => x.PasswordGuid   ).HasColumnName("user_password_guid");
            context.Property(x => x.PasswordHash   ).HasColumnName("user_password_hash").HasMaxLength(32);

            context.HasOne(x => x.Address).WithMany().HasForeignKey(x => x.AddressGuid);

            context.Ignore(x => x.IsAdmin);
            context.Ignore(x => x.IsStaff);
            context.Ignore(x => x.IsCustomer);


        }

        public override void Seed(EntityTypeBuilder<DataUserAccount> context)
        {
            PasswordBuilder pb = new PasswordBuilder();
            context.HasData(new DataUserAccount { IsAdmin = true, Name = "Admin", LoginName = "admin", Guid = Guid.NewGuid(), CreatedDateTime = DateTime.Now, PasswordGuid = pb.MakeGuid("admin", "1"), PasswordHash = pb.MakePasswordHash("admin", "1") });
        }
    }
}
