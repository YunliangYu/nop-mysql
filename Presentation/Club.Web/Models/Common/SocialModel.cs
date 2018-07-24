using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Common
{
    public partial class SocialModel : BaseSiteModel
    {
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string YoutubeLink { get; set; }
        public string GooglePlusLink { get; set; }
        public int WorkingLanguageId { get; set; }
        public bool NewsEnabled { get; set; }
    }
}