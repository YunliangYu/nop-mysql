using System.Collections.Generic;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Common
{
    public partial class CurrencySelectorModel : BaseSiteModel
    {
        public CurrencySelectorModel()
        {
            AvailableCurrencies = new List<CurrencyModel>();
        }

        public IList<CurrencyModel> AvailableCurrencies { get; set; }

        public int CurrentCurrencyId { get; set; }
    }
}