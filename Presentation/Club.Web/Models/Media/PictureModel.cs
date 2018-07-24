using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Media
{
    public partial class PictureModel : BaseSiteModel
    {
        public string ImageUrl { get; set; }

        public string ThumbImageUrl { get; set; }

        public string FullSizeImageUrl { get; set; }

        public string Title { get; set; }

        public string AlternateText { get; set; }
    }
}