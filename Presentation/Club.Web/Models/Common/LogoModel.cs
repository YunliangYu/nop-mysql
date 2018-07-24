using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Common
{
    public partial class LogoModel : BaseSiteModel
    {
        public string StoreName { get; set; }

        public string LogoPath { get; set; }
    }
}