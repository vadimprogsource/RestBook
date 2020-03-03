using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.EF
{
    public abstract class DataModelMapper<TEntity> : IDataModel, IDataModel<TEntity> where TEntity : class
    {

        protected virtual string TableName => $"{GetType().Name.Replace("Mapper", string.Empty).Replace("Data", string.Empty).ToLowerInvariant()}s";

        public virtual void Map(ModelBuilder context)
        {
            EntityTypeBuilder<TEntity> typeBuilder = context.Entity<TEntity>();
            typeBuilder.ToTable(TableName);
            Map(typeBuilder);
            Seed(typeBuilder);
        }



        public virtual void Seed(EntityTypeBuilder<TEntity> context){}
        public abstract void Map(EntityTypeBuilder<TEntity> context);

    }
}
