using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;
using Club.Web.Validators.Common;

namespace Club.Web.Models.Common
{
    [Validator(typeof(ContactUsValidator))]
    public partial class ContactUsModel : BaseSiteModel
    {
        [AllowHtml]
        [SiteResourceDisplayName("ContactUs.Email")]
        public string Email { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("ContactUs.Subject")]
        public string Subject { get; set; }
        public bool SubjectEnabled { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("ContactUs.Enquiry")]
        public string Enquiry { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("ContactUs.FullName")]
        public string FullName { get; set; }

        public bool SuccessfullySent { get; set; }
        public string Result { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}