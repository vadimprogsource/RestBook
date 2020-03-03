using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.EF
{
    public interface IDataModel
    {
        void Map(ModelBuilder context);
    }

    public interface IDataModel<TEntity> where TEntity : class
    {
        void Map(EntityTypeBuilder<TEntity> context);
    }
}
