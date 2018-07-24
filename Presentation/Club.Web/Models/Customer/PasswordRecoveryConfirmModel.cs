using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;
using Club.Web.Validators.Customer;

namespace Club.Web.Models.Customer
{
    [Validator(typeof(PasswordRecoveryConfirmValidator))]
    public partial class PasswordRecoveryConfirmModel : BaseSiteModel
    {
        [AllowHtml]
        [DataType(DataType.Password)]
        [NoTrim]
        [SiteResourceDisplayName("Account.PasswordRecovery.NewPassword")]
        public string NewPassword { get; set; }

        [AllowHtml]
        [NoTrim]
        [DataType(DataType.Password)]
        [SiteResourceDisplayName("Account.PasswordRecovery.ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }

        public bool DisablePasswordChanging { get; set; }
        public string Result { get; set; }
    }
}