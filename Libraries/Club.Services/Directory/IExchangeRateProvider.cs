using System.Collections.Generic;
using Club.Core.Domain.Directory;
using Club.Core.Plugins;

namespace Club.Services.Directory
{
    /// <summary>
    /// Exchange rate provider interface
    /// </summary>
    public partial interface IExchangeRateProvider : IPlugin
    {
        /// <summary>
        /// Gets currency live rates
        /// </summary>
        /// <param name="exchangeRateCurrencyCode">Exchange rate currency code</param>
        /// <returns>Exchange rates</returns>
        IList<ExchangeRate> GetCurrencyLiveRates(string exchangeRateCurrencyCode);
    }
}