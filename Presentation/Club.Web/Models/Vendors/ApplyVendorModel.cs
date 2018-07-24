using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;
using Club.Web.Validators.Vendors;

namespace Club.Web.Models.Vendors
{
    [Validator(typeof(ApplyVendorValidator))]
    public partial class ApplyVendorModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Vendors.ApplyAccount.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Vendors.ApplyAccount.Email")]
        [AllowHtml]
        public string Email { get; set; }

        [SiteResourceDisplayName("Vendors.ApplyAccount.Description")]
        [AllowHtml]
        public string Description { get; set; }
        
        public bool DisplayCaptcha { get; set; }

        public bool DisableFormInput { get; set; }
        public string Result { get; set; }
    }
}