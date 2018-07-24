using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Settings
{
    public partial class ModeModel : BaseSiteModel
    {
        public string ModeName { get; set; }
        public bool Enabled { get; set; }
    }
}