using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;
using Club.Web.Validators.Customer;

namespace Club.Web.Models.Customer
{
    [Validator(typeof(LoginValidator))]
    public partial class LoginModel : BaseSiteModel
    {
        public bool CheckoutAsGuest { get; set; }

        [SiteResourceDisplayName("Account.Login.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }

        public bool UsernamesEnabled { get; set; }
        [SiteResourceDisplayName("Account.Login.Fields.UserName")]
        [AllowHtml]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [NoTrim]
        [SiteResourceDisplayName("Account.Login.Fields.Password")]
        [AllowHtml]
        public string Password { get; set; }

        [SiteResourceDisplayName("Account.Login.Fields.RememberMe")]
        public bool RememberMe { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}