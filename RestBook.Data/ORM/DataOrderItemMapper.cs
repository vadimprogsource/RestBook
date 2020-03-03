using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public sealed class DataOrderItemMapper : DataObjectMapper<DataOrderItem>
    {
        public override void Map(EntityTypeBuilder<DataOrderItem> context)
        {
            base.Map(context);

            context.Property(x => x.Quantity).HasColumnName("order_item_qty");
            context.Property(x => x.Discount).HasColumnName("order_item_discount");

            context.Property(x => x.TaxValue).HasColumnName("order_item_tax");
            context.Property(x => x.TotalPrice).HasColumnName("order_item_total");
            context.Property(x => x.UnitPrice).HasColumnName("order_item_price");
            context.Property(x => x.ProductGuid).HasColumnName("product_guid");
            context.Property(x => x.LocationGuid).HasColumnName("location_guid");
            context.Property(x => x.OrderGuid).HasColumnName("order_guid");
            context.Property(x => x.PlaceCode).HasColumnName("order_item_place").HasMaxLength(20);

            context.HasOne(x => x.Location).WithMany().HasForeignKey(x => x.LocationGuid);
            context.HasOne(x => x.Product ).WithMany().HasForeignKey(x => x.ProductGuid );
            context.HasOne(x => x.Order   ).WithMany(x=>x.Rows).HasForeignKey(x => x.OrderGuid);

        }
    }
}
