using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;
using Club.Web.Validators.Catalog;

namespace Club.Web.Models.Catalog
{
    [Validator(typeof(ProductEmailAFriendValidator))]
    public partial class ProductEmailAFriendModel : BaseSiteModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductSeName { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Products.EmailAFriend.FriendEmail")]
        public string FriendEmail { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Products.EmailAFriend.YourEmailAddress")]
        public string YourEmailAddress { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Products.EmailAFriend.PersonalMessage")]
        public string PersonalMessage { get; set; }

        public bool SuccessfullySent { get; set; }
        public string Result { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}