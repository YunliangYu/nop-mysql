using System;
using System.Web.Mvc;
using Club.Admin.Models.Common;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Affiliates
{
    public partial class AffiliateModel : BaseSiteEntityModel
    {
        public AffiliateModel()
        {
            Address = new AddressModel();
        }

        [SiteResourceDisplayName("Admin.Affiliates.Fields.URL")]
        public string Url { get; set; }
        
        [SiteResourceDisplayName("Admin.Affiliates.Fields.AdminComment")]
        [AllowHtml]
        public string AdminComment { get; set; }

        [SiteResourceDisplayName("Admin.Affiliates.Fields.FriendlyUrlName")]
        [AllowHtml]
        public string FriendlyUrlName { get; set; }
        
        [SiteResourceDisplayName("Admin.Affiliates.Fields.Active")]
        public bool Active { get; set; }

        public AddressModel Address { get; set; }

        #region Nested classes
        
        public partial class AffiliatedOrderModel : BaseSiteEntityModel
        {
            public override int Id { get; set; }
            [SiteResourceDisplayName("Admin.Affiliates.Orders.CustomOrderNumber")]
            public string CustomOrderNumber { get; set; }

            [SiteResourceDisplayName("Admin.Affiliates.Orders.OrderStatus")]
            public string OrderStatus { get; set; }
            [SiteResourceDisplayName("Admin.Affiliates.Orders.OrderStatus")]
            public int OrderStatusId { get; set; }

            [SiteResourceDisplayName("Admin.Affiliates.Orders.PaymentStatus")]
            public string PaymentStatus { get; set; }

            [SiteResourceDisplayName("Admin.Affiliates.Orders.ShippingStatus")]
            public string ShippingStatus { get; set; }

            [SiteResourceDisplayName("Admin.Affiliates.Orders.OrderTotal")]
            public string OrderTotal { get; set; }

            [SiteResourceDisplayName("Admin.Affiliates.Orders.CreatedOn")]
            public DateTime CreatedOn { get; set; }
        }

        public partial class AffiliatedCustomerModel : BaseSiteEntityModel
        {
            [SiteResourceDisplayName("Admin.Affiliates.Customers.Name")]
            public string Name { get; set; }
        }

        #endregion
    }
}