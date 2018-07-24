using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;
using Club.Web.Validators.Common;

namespace Club.Web.Models.Common
{
    [Validator(typeof(ContactVendorValidator))]
    public partial class ContactVendorModel : BaseSiteModel
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("ContactVendor.Email")]
        public string Email { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("ContactVendor.Subject")]
        public string Subject { get; set; }
        public bool SubjectEnabled { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("ContactVendor.Enquiry")]
        public string Enquiry { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("ContactVendor.FullName")]
        public string FullName { get; set; }

        public bool SuccessfullySent { get; set; }
        public string Result { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}