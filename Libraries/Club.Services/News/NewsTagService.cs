using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Club.Core.Caching;
using Club.Core.Data;
using Club.Core.Domain.Catalog;
using Club.Core.Domain.Common;
using Club.Core.Domain.Stores;
using Club.Data;
using Club.Services.Events;
using Club.Core.Domain.News;

namespace Club.Services.News
{
    /// <summary>
    /// News tag service
    /// </summary>
    public partial class NewsTagService : INewsTagService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// </remarks>
        private const string NEWSTAG_COUNT_KEY = "Club.newstag.count-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        private const string NEWSTAG_PATTERN_KEY = "Club.newstag.";

        #endregion

        #region Fields

        private readonly IRepository<NewsTag> _newsTagRepository;
        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly CommonSettings _commonSettings;
        private readonly CatalogSettings _catalogSettings;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly INewsService _newsService;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="newsTagRepository">News tag repository</param>
        /// <param name="dataProvider">Data provider</param>
        /// <param name="dbContext">Database Context</param>
        /// <param name="commonSettings">Common settings</param>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="eventPublisher">Event published</param>
        /// <param name="storeMappingRepository">Store mapping repository</param>
        /// <param name="catalogSettings">Catalog settings</param>
        /// <param name="newsService">News service</param>
        public NewsTagService(IRepository<NewsTag> newsTagRepository,
            IRepository<StoreMapping> storeMappingRepository,
            IDataProvider dataProvider,
            IDbContext dbContext,
            CommonSettings commonSettings,
            CatalogSettings catalogSettings,
            ICacheManager cacheManager,
            IEventPublisher eventPublisher,
            INewsService newsService)
        {
            this._newsTagRepository = newsTagRepository;
            this._storeMappingRepository = storeMappingRepository;
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._commonSettings = commonSettings;
            this._catalogSettings = catalogSettings;
            this._cacheManager = cacheManager;
            this._eventPublisher = eventPublisher;
            this._newsService = newsService;
        }

        #endregion

        #region Nested classes

        private class NewsTagWithCount
        {
            public int NewsTagId { get; set; }
            public int NewsCount { get; set; }
        }

        #endregion
        
        #region Utilities

        /// <summary>
        /// Get news count for each of existing news tag
        /// </summary>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Dictionary of "news tag ID : news count"</returns>
        private Dictionary<int, int> GetNewsCount(int storeId)
        {
            string key = string.Format(NEWSTAG_COUNT_KEY, storeId);
            return _cacheManager.Get(key, () =>
            {

                if (_commonSettings.UseStoredProceduresIfSupported && _dataProvider.StoredProceduredSupported)
                {
                    //stored procedures are enabled and supported by the database. 
                    //It's much faster than the LINQ implementation below 

                    #region Use stored procedure

                    //prepare parameters
                    var pStoreId = _dataProvider.GetParameter();
                    pStoreId.ParameterName = "StoreId";
                    pStoreId.Value = storeId;
                    pStoreId.DbType = DbType.Int32;


                    //invoke stored procedure
                    var result = _dbContext.SqlQuery<NewsTagWithCount>(
                        "Exec NewsTagCountLoadAll @StoreId",
                        pStoreId);

                    var dictionary = new Dictionary<int, int>();
                    foreach (var item in result)
                        dictionary.Add(item.NewsTagId, item.NewsCount);
                    return dictionary;

                    #endregion
                }
                else
                {
                    //stored procedures aren't supported. Use LINQ
                    #region Search newss
                    var query = _newsTagRepository.Table.Select(pt => new
                    {
                        Id = pt.Id,
                        NewsCount = (storeId == 0 || _catalogSettings.IgnoreStoreLimitations) ?
                            pt.News.Count(p => p.Published)
                            : (from p in pt.News
                               join sm in _storeMappingRepository.Table
                               on new { p1 = p.Id, p2 = "News" } equals new { p1 = sm.EntityId, p2 = sm.EntityName } into p_sm
                               from sm in p_sm.DefaultIfEmpty()
                               where (!p.LimitedToStores || storeId == sm.StoreId) && p.Published
                               select p).Count()
                    });
                    var dictionary = new Dictionary<int, int>();
                    foreach (var item in query)
                        dictionary.Add(item.Id, item.NewsCount);
                    return dictionary;

                    #endregion

                }
            });
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete a news tag
        /// </summary>
        /// <param name="newsTag">News tag</param>
        public virtual void DeleteNewsTag(NewsTag newsTag)
        {
            if (newsTag == null)
                throw new ArgumentNullException("newsTag");

            _newsTagRepository.Delete(newsTag);

            //cache
            _cacheManager.RemoveByPattern(NEWSTAG_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityDeleted(newsTag);
        }

        /// <summary>
        /// Gets all news tags
        /// </summary>
        /// <returns>News tags</returns>
        public virtual IList<NewsTag> GetAllNewsTags()
        {
            var query = _newsTagRepository.Table;
            var newsTags = query.ToList();
            return newsTags;
        }

        /// <summary>
        /// Gets news tag
        /// </summary>
        /// <param name="newsTagId">News tag identifier</param>
        /// <returns>News tag</returns>
        public virtual NewsTag GetNewsTagById(int newsTagId)
        {
            if (newsTagId == 0)
                return null;

            return _newsTagRepository.GetById(newsTagId);
        }

        /// <summary>
        /// Gets news tag by name
        /// </summary>
        /// <param name="name">News tag name</param>
        /// <returns>News tag</returns>
        public virtual NewsTag GetNewsTagByName(string name)
        {
            var query = from pt in _newsTagRepository.Table
                        where pt.Name == name
                        select pt;

            var newsTag = query.FirstOrDefault();
            return newsTag;
        }

        /// <summary>
        /// Inserts a news tag
        /// </summary>
        /// <param name="newsTag">News tag</param>
        public virtual void InsertNewsTag(NewsTag newsTag)
        {
            if (newsTag == null)
                throw new ArgumentNullException("newsTag");

            _newsTagRepository.Insert(newsTag);

            //cache
            _cacheManager.RemoveByPattern(NEWSTAG_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityInserted(newsTag);
        }

        /// <summary>
        /// Updates the news tag
        /// </summary>
        /// <param name="newsTag">News tag</param>
        public virtual void UpdateNewsTag(NewsTag newsTag)
        {
            if (newsTag == null)
                throw new ArgumentNullException("newsTag");

            _newsTagRepository.Update(newsTag);

            //cache
            _cacheManager.RemoveByPattern(NEWSTAG_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityUpdated(newsTag);
        }

        /// <summary>
        /// Get number of newss
        /// </summary>
        /// <param name="newsTagId">News tag identifier</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Number of newss</returns>
        public virtual int GetNewsCount(int newsTagId, int storeId)
        {
            var dictionary = GetNewsCount(storeId);
            if (dictionary.ContainsKey(newsTagId))
                return dictionary[newsTagId];
            
            return 0;
        }

        /// <summary>
        /// Update news tags
        /// </summary>
        /// <param name="news">News for update</param>
        /// <param name="newsTags">News tags</param>
        public virtual void UpdateNewsTags(NewsItem news, string[] newsTags)
        {
            if (news == null)
                throw new ArgumentNullException("news");

            //news tags
            var existingNewsTags = news.NewsTags.ToList();
            var newsTagsToRemove = new List<NewsTag>();
            foreach (var existingNewsTag in existingNewsTags)
            {
                var found = false;
                foreach (var newNewsTag in newsTags)
                {
                    if (existingNewsTag.Name.Equals(newNewsTag, StringComparison.InvariantCultureIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    newsTagsToRemove.Add(existingNewsTag);
                }
            }
            foreach (var newsTag in newsTagsToRemove)
            {
                news.NewsTags.Remove(newsTag);
                _newsService.UpdateNews(news);
            }
            foreach (var newsTagName in newsTags)
            {
                NewsTag newsTag;
                var newsTag2 = GetNewsTagByName(newsTagName);
                if (newsTag2 == null)
                {
                    //add new news tag
                    newsTag = new NewsTag
                    {
                        Name = newsTagName
                    };
                    InsertNewsTag(newsTag);
                }
                else
                {
                    newsTag = newsTag2;
                }
                if (!news.NewsTagExists(newsTag.Id))
                {
                    news.NewsTags.Add(newsTag);
                    _newsService.UpdateNews(news);
                }
            }
        }
        #endregion
    }
}
