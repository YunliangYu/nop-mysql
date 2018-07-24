using System.Collections.Generic;
using Club.Core.Domain.Directory;
using Club.Core.Plugins;
using Club.Services.Directory;

namespace Club.Services.Tests.Directory
{
    public class TestExchangeRateProvider : BasePlugin, IExchangeRateProvider
    {
        /// <summary>
        /// Gets currency live rates
        /// </summary>
        /// <param name="exchangeRateCurrencyCode">Exchange rate currency code</param>
        /// <returns>Exchange rates</returns>
        public IList<ExchangeRate> GetCurrencyLiveRates(string exchangeRateCurrencyCode)
        {
            return new List<ExchangeRate>();
        }
    }
}
