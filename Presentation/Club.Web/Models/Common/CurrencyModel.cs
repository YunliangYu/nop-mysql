using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Common
{
    public partial class CurrencyModel : BaseSiteEntityModel
    {
        public string Name { get; set; }

        public string CurrencySymbol { get; set; }
    }
}