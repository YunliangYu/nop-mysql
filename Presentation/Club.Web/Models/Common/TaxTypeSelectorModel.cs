using Club.Core.Domain.Tax;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Common
{
    public partial class TaxTypeSelectorModel : BaseSiteModel
    {
        public TaxDisplayType CurrentTaxType { get; set; }
    }
}