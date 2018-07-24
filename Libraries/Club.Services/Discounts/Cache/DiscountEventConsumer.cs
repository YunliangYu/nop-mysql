using Club.Core.Caching;
using Club.Core.Domain.Catalog;
using Club.Core.Domain.Configuration;
using Club.Core.Domain.Discounts;
using Club.Core.Events;
using Club.Core.Infrastructure;
using Club.Services.Events;

namespace Club.Services.Discounts.Cache
{
    /// <summary>
    /// Cache event consumer (used for caching of discounts)
    /// </summary>
    public partial class DiscountEventConsumer :
        //discounts
        IConsumer<EntityInserted<Discount>>,
        IConsumer<EntityUpdated<Discount>>,
        IConsumer<EntityDeleted<Discount>>,
        //discount requirements
        IConsumer<EntityInserted<DiscountRequirement>>,
        IConsumer<EntityUpdated<DiscountRequirement>>,
        IConsumer<EntityDeleted<DiscountRequirement>>,
        //settings
        IConsumer<EntityUpdated<Setting>>,
        //categories
        IConsumer<EntityInserted<Category>>,
        IConsumer<EntityUpdated<Category>>,
        IConsumer<EntityDeleted<Category>>,
        //manufacturers
        IConsumer<EntityInserted<Manufacturer>>,
        IConsumer<EntityUpdated<Manufacturer>>,
        IConsumer<EntityDeleted<Manufacturer>>
    {
        /// <summary>
        /// Key for discount requirement of a certain discount
        /// </summary>
        /// <remarks>
        /// {0} : discount id
        /// </remarks>
        public const string DISCOUNT_REQUIREMENT_MODEL_KEY = "Club.discounts.requirements-{0}";
        public const string DISCOUNT_REQUIREMENT_PATTERN_KEY = "Club.discounts.requirements";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// {1} : coupon code
        /// {2} : discount name
        /// </remarks>
        public const string DISCOUNT_ALL_KEY = "Club.discounts.all-{0}-{1}-{2}";
        public const string DISCOUNT_ALL_PATTERN_KEY = "Club.discounts.all";

        /// <summary>
        /// Key for category IDs of a discount
        /// </summary>
        /// <remarks>
        /// {0} : discount id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public const string DISCOUNT_CATEGORY_IDS_MODEL_KEY = "Club.discounts.categoryids-{0}-{1}-{2}";
        public const string DISCOUNT_CATEGORY_IDS_PATTERN_KEY = "Club.discounts.categoryids";

        /// <summary>
        /// Key for manufacturer IDs of a discount
        /// </summary>
        /// <remarks>
        /// {0} : discount id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public const string DISCOUNT_MANUFACTURER_IDS_MODEL_KEY = "Club.discounts.manufacturerids-{0}-{1}-{2}";
        public const string DISCOUNT_MANUFACTURER_IDS_PATTERN_KEY = "Club.discounts.manufacturerids";



        private readonly ICacheManager _cacheManager;

        public DiscountEventConsumer()
        {
            //TODO inject static cache manager using constructor
            this._cacheManager = EngineContext.Current.ContainerManager.Resolve<ICacheManager>("club_cache_static");
        }

        //discounts
        public void HandleEvent(EntityInserted<Discount> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_ALL_PATTERN_KEY);
            _cacheManager.RemoveByPattern(DISCOUNT_REQUIREMENT_PATTERN_KEY);
            _cacheManager.RemoveByPattern(DISCOUNT_CATEGORY_IDS_PATTERN_KEY);
            _cacheManager.RemoveByPattern(DISCOUNT_MANUFACTURER_IDS_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<Discount> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_ALL_PATTERN_KEY);
            _cacheManager.RemoveByPattern(DISCOUNT_REQUIREMENT_PATTERN_KEY);
            _cacheManager.RemoveByPattern(DISCOUNT_CATEGORY_IDS_PATTERN_KEY);
            _cacheManager.RemoveByPattern(DISCOUNT_MANUFACTURER_IDS_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<Discount> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_ALL_PATTERN_KEY);
            _cacheManager.RemoveByPattern(DISCOUNT_REQUIREMENT_PATTERN_KEY);
            _cacheManager.RemoveByPattern(DISCOUNT_CATEGORY_IDS_PATTERN_KEY);
            _cacheManager.RemoveByPattern(DISCOUNT_MANUFACTURER_IDS_PATTERN_KEY);
        }

        //discount requirements
        public void HandleEvent(EntityInserted<DiscountRequirement> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_REQUIREMENT_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<DiscountRequirement> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_REQUIREMENT_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<DiscountRequirement> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_REQUIREMENT_PATTERN_KEY);
        }


        //settings
        public void HandleEvent(EntityUpdated<Setting> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_CATEGORY_IDS_PATTERN_KEY);
            _cacheManager.RemoveByPattern(DISCOUNT_MANUFACTURER_IDS_PATTERN_KEY);
        }

        //categories
        public void HandleEvent(EntityInserted<Category> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_CATEGORY_IDS_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<Category> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_CATEGORY_IDS_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<Category> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_CATEGORY_IDS_PATTERN_KEY);
        }


        //manufacturers
        public void HandleEvent(EntityInserted<Manufacturer> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_MANUFACTURER_IDS_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<Manufacturer> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_MANUFACTURER_IDS_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<Manufacturer> eventMessage)
        {
            _cacheManager.RemoveByPattern(DISCOUNT_MANUFACTURER_IDS_PATTERN_KEY);
        }

    }
}
