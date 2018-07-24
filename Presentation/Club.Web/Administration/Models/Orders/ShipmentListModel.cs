using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public partial class ShipmentListModel : BaseSiteModel
    {
        public ShipmentListModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
            AvailableWarehouses = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Orders.Shipments.List.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [SiteResourceDisplayName("Admin.Orders.Shipments.List.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }

        [SiteResourceDisplayName("Admin.Orders.Shipments.List.TrackingNumber")]
        [AllowHtml]
        public string TrackingNumber { get; set; }
        
        public IList<SelectListItem> AvailableCountries { get; set; }
        [SiteResourceDisplayName("Admin.Orders.Shipments.List.Country")]
        public int CountryId { get; set; }

        public IList<SelectListItem> AvailableStates { get; set; }
        [SiteResourceDisplayName("Admin.Orders.Shipments.List.StateProvince")]
        public int StateProvinceId { get; set; }

        [SiteResourceDisplayName("Admin.Orders.Shipments.List.City")]
        [AllowHtml]
        public string City { get; set; }

        [SiteResourceDisplayName("Admin.Orders.Shipments.List.LoadNotShipped")]
        public bool LoadNotShipped { get; set; }


        [SiteResourceDisplayName("Admin.Orders.Shipments.List.Warehouse")]
        public int WarehouseId { get; set; }
        public IList<SelectListItem> AvailableWarehouses { get; set; }
    }
}