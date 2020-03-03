using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class GroupModel : EntityModel 
    {

        public ProductModel[] Products { get; set; }

        public GroupModel(IGroup group) : base(group)
        {
            if (group.Products != null && group.Products.Any())
            {
                Products = group.Products
                                .Select(x => new ProductModel(x))
                                .ToArray();
            }
        }
    }
}
