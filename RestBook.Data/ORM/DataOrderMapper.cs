using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public sealed class DataOrderMapper : DataEntityMapper<DataOrder>
    {
        public override void Map(EntityTypeBuilder<DataOrder> context)
        {
            base.Map(context);

            context.Property(x => x.OrderNumber ).HasColumnName("order_number").HasMaxLength(30);
            context.Property(x => x.OrderedAt   ).HasColumnName("order_date"  );
            context.Property(x => x.Discount    ).HasColumnName("order_discount");

            context.Property(x => x.SubTotal    ).HasColumnName("order_sub_total");
            context.Property(x => x.TotalTax    ).HasColumnName("order_total_tax");
            context.Property(x => x.TotalDue    ).HasColumnName("order_total_due");
            context.Property(x => x.OrgGuid     ).HasColumnName("order_org_guid");

            context.Property(x => x.CustomerGuid).HasColumnName("order_customer_guid");
            context.Property(x => x.AddressGuid ).HasColumnName("order_address_guid");


            context.HasOne(x => x.Org).WithMany().HasForeignKey(x => x.OrgGuid);

            context.HasOne(x => x.Customer       ).WithMany().HasForeignKey(x => x.CustomerGuid   );
            context.HasOne(x => x.DeliveryAddress).WithMany().HasForeignKey(x => x.AddressGuid);

        }
    }
}
