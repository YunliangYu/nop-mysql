using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;
using Club.Web.Validators.ShoppingCart;

namespace Club.Web.Models.ShoppingCart
{
    [Validator(typeof(WishlistEmailAFriendValidator))]
    public partial class WishlistEmailAFriendModel : BaseSiteModel
    {
        [AllowHtml]
        [SiteResourceDisplayName("Wishlist.EmailAFriend.FriendEmail")]
        public string FriendEmail { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Wishlist.EmailAFriend.YourEmailAddress")]
        public string YourEmailAddress { get; set; }

        [AllowHtml]
        [SiteResourceDisplayName("Wishlist.EmailAFriend.PersonalMessage")]
        public string PersonalMessage { get; set; }

        public bool SuccessfullySent { get; set; }
        public string Result { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}