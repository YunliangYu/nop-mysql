using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Common
{
    public partial class AdminHeaderLinksModel : BaseSiteModel
    {
        public string ImpersonatedCustomerName { get; set; }
        public bool IsCustomerImpersonated { get; set; }
        public bool DisplayAdminLink { get; set; }
        public string EditPageUrl { get; set; }
    }
}