using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Newsletter
{
    public partial class NewsletterBoxModel : BaseSiteModel
    {
        public string NewsletterEmail { get; set; }
        public bool AllowToUnsubscribe { get; set; }
    }
}