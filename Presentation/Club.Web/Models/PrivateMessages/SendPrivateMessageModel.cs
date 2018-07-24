using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Web.Framework.Mvc;
using Club.Web.Validators.PrivateMessages;

namespace Club.Web.Models.PrivateMessages
{
    [Validator(typeof(SendPrivateMessageValidator))]
    public partial class SendPrivateMessageModel : BaseSiteEntityModel
    {
        public int ToCustomerId { get; set; }
        public string CustomerToName { get; set; }
        public bool AllowViewingToProfile { get; set; }

        public int ReplyToMessageId { get; set; }

        [AllowHtml]
        public string Subject { get; set; }

        [AllowHtml]
        public string Message { get; set; }
    }
}