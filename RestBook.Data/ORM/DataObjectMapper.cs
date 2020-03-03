using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.Data.EF;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public abstract class DataObjectMapper<TDataEntity> : DataModelMapper<TDataEntity> where TDataEntity : DataObject
    {
        public override void Map(EntityTypeBuilder<TDataEntity> context)
        {
            context.Property(x => x.Guid).HasColumnName("obj_guid");
            context.Property(x => x.ReorderLevel).HasColumnName("obj_reord_lev");
            context.HasKey  (x => x.Guid);
        }
    }


    public abstract class DataEntityMapper<TDataEntity> : DataObjectMapper<TDataEntity> where TDataEntity : DataEntity
    {
        public override void Map(EntityTypeBuilder<TDataEntity> context)
        {
            base.Map(context);

            context.Property(x => x.Code).HasColumnName("entity_code").HasMaxLength(50);
            context.Property(x => x.Name).HasColumnName("entity_name").HasMaxLength(500);
            context.Property(x => x.Uri ).HasColumnName("entity_uri").HasMaxLength(250);

            context.Property(x => x.Description).HasColumnName("entity_descr").HasMaxLength(2000);
        }
    }


}
