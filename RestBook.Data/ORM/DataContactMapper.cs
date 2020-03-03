using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public abstract class DataContactMapper<TContactEntity> : DataEntityMapper<TContactEntity> where TContactEntity : DataContact
    {
        public override void Map(EntityTypeBuilder<TContactEntity> context)
        {
            base.Map(context);
            context.Property(x => x.Cellular).HasColumnName("contact_cellular").HasMaxLength(100);
            context.Property(x => x.Phone   ).HasColumnName("contact_phone").HasMaxLength(100);
            context.Property(x => x.Skype   ).HasColumnName("contact_skype").HasMaxLength(100);
            context.Property(x => x.Email   ).HasColumnName("contact_email").HasMaxLength(100);

            context.Ignore(x => x.Title);

        }
    }
}
