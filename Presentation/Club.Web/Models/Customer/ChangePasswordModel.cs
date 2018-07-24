using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;
using Club.Web.Validators.Customer;

namespace Club.Web.Models.Customer
{
    [Validator(typeof(ChangePasswordValidator))]
    public partial class ChangePasswordModel : BaseSiteModel
    {
        [AllowHtml]
        [NoTrim]
        [DataType(DataType.Password)]
        [SiteResourceDisplayName("Account.ChangePassword.Fields.OldPassword")]
        public string OldPassword { get; set; }

        [AllowHtml]
        [NoTrim]
        [DataType(DataType.Password)]
        [SiteResourceDisplayName("Account.ChangePassword.Fields.NewPassword")]
        public string NewPassword { get; set; }

        [AllowHtml]
        [NoTrim]
        [DataType(DataType.Password)]
        [SiteResourceDisplayName("Account.ChangePassword.Fields.ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }

        public string Result { get; set; }

    }
}