using Club.Core.Caching;
using Club.Core.Domain.Customers;
using Club.Core.Infrastructure;
using Club.Services.Events;

namespace Club.Services.Customers.Cache
{
    /// <summary>
    /// Customer cache event consumer (used for caching of current customer password)
    /// </summary>
    public partial class CustomerCacheEventConsumer : IConsumer<CustomerPasswordChangedEvent>
    {
        #region Constants

        /// <summary>
        /// Key for current customer password lifetime
        /// </summary>
        /// <remarks>
        /// {0} : customer identifier
        /// </remarks>
        public const string CUSTOMER_PASSWORD_LIFETIME = "Club.customers.passwordlifetime-{0}";

        #endregion

        #region Fields

        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        public CustomerCacheEventConsumer()
        {
            //TODO inject static cache manager using constructor
            this._cacheManager = EngineContext.Current.ContainerManager.Resolve<ICacheManager>("club_cache_static");
        }

        #endregion

        #region Methods

        //password changed
        public void HandleEvent(CustomerPasswordChangedEvent eventMessage)
        {
            _cacheManager.Remove(string.Format(CUSTOMER_PASSWORD_LIFETIME, eventMessage.Password.CustomerId));
        }

        #endregion
    }
}
