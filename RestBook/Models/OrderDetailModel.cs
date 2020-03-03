using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class OrderDetailModel : EntityModel, IOrderDetail ,ILocation
    {
      
        public string PlaceCode { get; set; }

        public OrderItemModel[]  Items { get; set; }

        public decimal TotalPrice { get; set; }

        IEnumerable<ICatalogAccess> ILocation.Catalogs => null;


        string IBussnessEntity.Code => string.Empty;

       string IBussnessEntity.Uri => string.Empty ;

        string IBussnessEntity.Description => string.Empty;


        int IEntity.ReorderLevel => 0;

        IEnumerable<IOrderItem> IOrderDetail.Items => Items;

        public ILocation Location => this;

        string ILocation.ImageInfo => string.Empty;

        TimeSpan ILocation.WorkTimeFrom => TimeSpan.Zero;

        TimeSpan ILocation.WorkTimeTo => TimeSpan.Zero;

        string ILocation.CookDescription => string.Empty;

        string ILocation.InterierInfo => string.Empty;

        string ILocation.PlacesInfo => string.Empty;

        string ILocation.ActionDescription => string.Empty;

        string ILocation.EventDescription => string.Empty;



        public OrderDetailModel() { }
        public OrderDetailModel(IOrderDetail orderDetail) 
        {
            PlaceCode  = orderDetail.PlaceCode;
            Name       = orderDetail.Location.Name;
            Guid       = orderDetail.Location.Guid;
            TotalPrice = orderDetail.TotalPrice;

            if (orderDetail.Items != null )
            {
                Items = orderDetail.Items.Select(x => new OrderItemModel(x)).ToArray();
            }

        }

    }
}
