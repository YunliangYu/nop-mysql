using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Common
{
    public partial class SystemWarningModel : BaseSiteModel
    {
        public SystemWarningLevel Level { get; set; }

        public string Text { get; set; }
    }

    public enum SystemWarningLevel
    {
        Pass,
        Warning,
        Fail
    }
}