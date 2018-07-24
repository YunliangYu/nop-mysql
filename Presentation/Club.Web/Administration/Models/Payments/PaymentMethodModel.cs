using System.Web.Mvc;
using System.Web.Routing;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Payments
{
    public partial class PaymentMethodModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.FriendlyName")]
        [AllowHtml]
        public string FriendlyName { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SystemName")]
        [AllowHtml]
        public string SystemName { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.IsActive")]
        public bool IsActive { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.Logo")]
        public string LogoUrl { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SupportCapture")]
        public bool SupportCapture { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SupportPartiallyRefund")]
        public bool SupportPartiallyRefund { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SupportRefund")]
        public bool SupportRefund { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SupportVoid")]
        public bool SupportVoid { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.RecurringPaymentType")]
        public string RecurringPaymentType { get; set; }
        



        public string ConfigurationActionName { get; set; }
        public string ConfigurationControllerName { get; set; }
        public RouteValueDictionary ConfigurationRouteValues { get; set; }
    }
}