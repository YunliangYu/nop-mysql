using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;
using Club.Web.Validators.Vendors;

namespace Club.Web.Models.Vendors
{
    [Validator(typeof(VendorInfoValidator))]
    public class VendorInfoModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Account.VendorInfo.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Account.VendorInfo.Email")]
        [AllowHtml]
        public string Email { get; set; }

        [SiteResourceDisplayName("Account.VendorInfo.Description")]
        [AllowHtml]
        public string Description { get; set; }

        [SiteResourceDisplayName("Account.VendorInfo.Picture")]
        public string PictureUrl { get; set; }
    }
}