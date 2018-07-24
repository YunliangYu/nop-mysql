using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;
using Club.Web.Validators.Customer;

namespace Club.Web.Models.Customer
{
    [Validator(typeof(PasswordRecoveryValidator))]
    public partial class PasswordRecoveryModel : BaseSiteModel
    {
        [AllowHtml]
        [SiteResourceDisplayName("Account.PasswordRecovery.Email")]
        public string Email { get; set; }

        public string Result { get; set; }
    }
}