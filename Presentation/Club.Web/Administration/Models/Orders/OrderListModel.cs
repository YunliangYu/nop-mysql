using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public partial class OrderListModel : BaseSiteModel
    {
        public OrderListModel()
        {
            OrderStatusIds = new List<int>();
            PaymentStatusIds = new List<int>();
            ShippingStatusIds = new List<int>();
            AvailableOrderStatuses = new List<SelectListItem>();
            AvailablePaymentStatuses = new List<SelectListItem>();
            AvailableShippingStatuses = new List<SelectListItem>();
            AvailableStores = new List<SelectListItem>();
            AvailableVendors = new List<SelectListItem>();
            AvailableWarehouses = new List<SelectListItem>();
            AvailablePaymentMethods = new List<SelectListItem>();
            AvailableCountries = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Orders.List.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.OrderStatus")]
        [UIHint("MultiSelect")]
        public List<int> OrderStatusIds { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.PaymentStatus")]
        [UIHint("MultiSelect")]
        public List<int> PaymentStatusIds { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.ShippingStatus")]
        [UIHint("MultiSelect")]
        public List<int> ShippingStatusIds { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.PaymentMethod")]
        public string PaymentMethodSystemName { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.Store")]
        public int StoreId { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.Vendor")]
        public int VendorId { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.Warehouse")]
        public int WarehouseId { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.Product")]
        public int ProductId { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.BillingEmail")]
        [AllowHtml]
        public string BillingEmail { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.BillingLastName")]
        [AllowHtml]
        public string BillingLastName { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.BillingCountry")]
        public int BillingCountryId { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.OrderNotes")]
        [AllowHtml]
        public string OrderNotes { get; set; }

        [SiteResourceDisplayName("Admin.Orders.List.GoDirectlyToNumber")]
        public string GoDirectlyToCustomOrderNumber { get; set; }

        public bool IsLoggedInAsVendor { get; set; }


        public IList<SelectListItem> AvailableOrderStatuses { get; set; }
        public IList<SelectListItem> AvailablePaymentStatuses { get; set; }
        public IList<SelectListItem> AvailableShippingStatuses { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }
        public IList<SelectListItem> AvailableVendors { get; set; }
        public IList<SelectListItem> AvailableWarehouses { get; set; }
        public IList<SelectListItem> AvailablePaymentMethods { get; set; }
        public IList<SelectListItem> AvailableCountries { get; set; }
    }
}