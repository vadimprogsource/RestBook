using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public sealed class DataSessionMapper : DataObjectMapper<DataUserSession>
    {
   

        public override void Map(EntityTypeBuilder<DataUserSession> context)
        {
            base.Map(context);
            context.Ignore(x => x.ReorderLevel);

            context.Property(x => x.CreatedDateTime).HasColumnName("session_created_dt");
            context.Property(x => x.ExpiredDateTime).HasColumnName("session_expired_dt");
            context.Property(x => x.UserGuid       ).HasColumnName("session_user_guid");
            context.Property(x => x.PinCodeGuid    ).HasColumnName("session_pin_guid");
            context.Property(x => x.PinCodeHash    ).HasColumnName("session_pin_hash").HasMaxLength(32);

            context.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserGuid);

        }
    }
}
