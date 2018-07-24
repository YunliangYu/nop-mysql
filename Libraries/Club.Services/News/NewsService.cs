using System;
using System.Collections.Generic;
using System.Linq;
using Club.Core;
using Club.Core.Data;
using Club.Core.Domain.Catalog;
using Club.Core.Domain.News;
using Club.Core.Domain.Stores;
using Club.Services.Events;

namespace Club.Services.News
{
    /// <summary>
    /// News service
    /// </summary>
    public partial class NewsService : INewsService
    {
        #region Fields

        private readonly IRepository<NewsItem> _newsItemRepository;
        private readonly IRepository<NewsComment> _newsCommentRepository;
        private readonly IRepository<NewsPicture> _newsPictureRepository;
        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly CatalogSettings _catalogSettings;
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region Ctor

        public NewsService(IRepository<NewsItem> newsItemRepository, 
            IRepository<NewsComment> newsCommentRepository,
            IRepository<NewsPicture> newsPictureRepository,
            IRepository<StoreMapping> storeMappingRepository,
            CatalogSettings catalogSettings,
            IEventPublisher eventPublisher)
        {
            this._newsItemRepository = newsItemRepository;
            this._newsCommentRepository = newsCommentRepository;
            this._newsPictureRepository = newsPictureRepository;
            this._storeMappingRepository = storeMappingRepository;
            this._catalogSettings = catalogSettings;
            this._eventPublisher = eventPublisher;
        }

        #endregion

        #region Methods

        #region News

        /// <summary>
        /// Deletes a news
        /// </summary>
        /// <param name="newsItem">News item</param>
        public virtual void DeleteNews(NewsItem newsItem)
        {
            if (newsItem == null)
                throw new ArgumentNullException("newsItem");

            _newsItemRepository.Delete(newsItem);
            
            //event notification
            _eventPublisher.EntityDeleted(newsItem);
        }

        /// <summary>
        /// Gets a news
        /// </summary>
        /// <param name="newsId">The news identifier</param>
        /// <returns>News</returns>
        public virtual NewsItem GetNewsById(int newsId)
        {
            if (newsId == 0)
                return null;

            return _newsItemRepository.GetById(newsId);
        }

        /// <summary>
        /// Gets news
        /// </summary>
        /// <param name="newsIds">The news identifiers</param>
        /// <returns>News</returns>
        public virtual IList<NewsItem> GetNewsByIds(int[] newsIds)
        {
            var query = _newsItemRepository.Table;
            return query.Where(p => newsIds.Contains(p.Id)).ToList();
        }

        /// <summary>
        /// Gets all news
        /// </summary>
        /// <param name="languageId">Language identifier; 0 if you want to get all records</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>News items</returns>
        public virtual IPagedList<NewsItem> GetAllNews(int languageId = 0, int storeId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = _newsItemRepository.Table;
            if (languageId > 0)
                query = query.Where(n => languageId == n.LanguageId);
            if (!showHidden)
            {
                var utcNow = DateTime.UtcNow;
                query = query.Where(n => n.Published);
                query = query.Where(n => !n.StartDateUtc.HasValue || n.StartDateUtc <= utcNow);
                query = query.Where(n => !n.EndDateUtc.HasValue || n.EndDateUtc >= utcNow);
            }
            query = query.OrderByDescending(n => n.StartDateUtc ?? n.CreatedOnUtc);

            //Store mapping
            if (storeId > 0 && !_catalogSettings.IgnoreStoreLimitations)
            {
                query = from n in query
                        join sm in _storeMappingRepository.Table
                        on new { c1 = n.Id, c2 = "NewsItem" } equals new { c1 = sm.EntityId, c2 = sm.EntityName } into n_sm
                        from sm in n_sm.DefaultIfEmpty()
                        where !n.LimitedToStores || storeId == sm.StoreId
                        select n;

                //only distinct items (group by ID)
                query = from n in query
                        group n by n.Id
                        into nGroup
                        orderby nGroup.Key
                        select nGroup.FirstOrDefault();
                query = query.OrderByDescending(n => n.StartDateUtc ?? n.CreatedOnUtc);
            }

            var news = new PagedList<NewsItem>(query, pageIndex, pageSize);
            return news;
        }

        /// <summary>
        /// Inserts a news item
        /// </summary>
        /// <param name="news">News item</param>
        public virtual void InsertNews(NewsItem news)
        {
            if (news == null)
                throw new ArgumentNullException("news");

            _newsItemRepository.Insert(news);

            //event notification
            _eventPublisher.EntityInserted(news);
        }

        /// <summary>
        /// Updates the news item
        /// </summary>
        /// <param name="news">News item</param>
        public virtual void UpdateNews(NewsItem news)
        {
            if (news == null)
                throw new ArgumentNullException("news");

            _newsItemRepository.Update(news);
            
            //event notification
            _eventPublisher.EntityUpdated(news);
        }

        #endregion

        #region News comments

        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <param name="customerId">Customer identifier; 0 to load all records</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="newsItemId">News item ID; 0 or null to load all records</param>
        /// <param name="approved">A value indicating whether to content is approved; null to load all records</param> 
        /// <param name="fromUtc">Item creation from; null to load all records</param>
        /// <param name="toUtc">Item creation to; null to load all records</param>
        /// <param name="commentText">Search comment text; null to load all records</param>
        /// <returns>Comments</returns>
        public virtual IList<NewsComment> GetAllComments(int customerId = 0, int storeId = 0, int? newsItemId = null,
            bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null)
        {
            var query = _newsCommentRepository.Table;

            if (approved.HasValue)
                query = query.Where(comment => comment.IsApproved == approved);

            if (newsItemId > 0)
                query = query.Where(comment => comment.NewsItemId == newsItemId);

            if (customerId > 0)
                query = query.Where(comment => comment.CustomerId == customerId);

            if (storeId > 0)
                query = query.Where(comment => comment.StoreId == storeId);

            if (fromUtc.HasValue)
                query = query.Where(comment => fromUtc.Value <= comment.CreatedOnUtc);

            if (toUtc.HasValue)
                query = query.Where(comment => toUtc.Value >= comment.CreatedOnUtc);

            if (!string.IsNullOrEmpty(commentText))
                query = query.Where(c => c.CommentText.Contains(commentText) || c.CommentTitle.Contains(commentText));

            query = query.OrderBy(nc => nc.CreatedOnUtc);

            return query.ToList();
        }

        /// <summary>
        /// Gets a news comment
        /// </summary>
        /// <param name="newsCommentId">News comment identifier</param>
        /// <returns>News comment</returns>
        public virtual NewsComment GetNewsCommentById(int newsCommentId)
        {
            if (newsCommentId == 0)
                return null;

            return _newsCommentRepository.GetById(newsCommentId);
        }

        /// <summary>
        /// Get news comments by identifiers
        /// </summary>
        /// <param name="commentIds">News comment identifiers</param>
        /// <returns>News comments</returns>
        public virtual IList<NewsComment> GetNewsCommentsByIds(int[] commentIds)
        {
            if (commentIds == null || commentIds.Length == 0)
                return new List<NewsComment>();

            var query = from nc in _newsCommentRepository.Table
                        where commentIds.Contains(nc.Id)
                        select nc;
            var comments = query.ToList();
            //sort by passed identifiers
            var sortedComments = new List<NewsComment>();
            foreach (int id in commentIds)
            {
                var comment = comments.Find(x => x.Id == id);
                if (comment != null)
                    sortedComments.Add(comment);
            }
            return sortedComments;
        }

        /// <summary>
        /// Get the count of news comments
        /// </summary>
        /// <param name="newsItem">News item</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="isApproved">A value indicating whether to count only approved or not approved comments; pass null to get number of all comments</param>
        /// <returns>Number of news comments</returns>
        public virtual int GetNewsCommentsCount(NewsItem newsItem, int storeId = 0, bool? isApproved = null)
        {
            var query = _newsCommentRepository.Table.Where(comment => comment.NewsItemId == newsItem.Id);

            if (storeId > 0)
                query = query.Where(comment => comment.StoreId == storeId);

            if (isApproved.HasValue)
                query = query.Where(comment => comment.IsApproved == isApproved.Value);

            return query.Count();
        }

        /// <summary>
        /// Deletes a news comment
        /// </summary>
        /// <param name="newsComment">News comment</param>
        public virtual void DeleteNewsComment(NewsComment newsComment)
        {
            if (newsComment == null)
                throw new ArgumentNullException("newsComment");

            _newsCommentRepository.Delete(newsComment);

            //event notification
            _eventPublisher.EntityDeleted(newsComment);
        }

        /// <summary>
        /// Deletes a news comments
        /// </summary>
        /// <param name="newsComments">News comments</param>
        public virtual void DeleteNewsComments(IList<NewsComment> newsComments)
        {
            if (newsComments == null)
                throw new ArgumentNullException("newsComments");

            foreach (var newsComment in newsComments)
            {
                DeleteNewsComment(newsComment);
            }
        }

        #endregion

        #region News pictures

        /// <summary>
        /// Deletes a news picture
        /// </summary>
        /// <param name="newsPicture">News picture</param>
        public virtual void DeleteNewsPicture(NewsPicture newsPicture)
        {
            if (newsPicture == null)
                throw new ArgumentNullException("newsPicture");

            _newsPictureRepository.Delete(newsPicture);

            //event notification
            _eventPublisher.EntityDeleted(newsPicture);
        }

        /// <summary>
        /// Gets a news pictures by news identifier
        /// </summary>
        /// <param name="newsId">The news identifier</param>
        /// <returns>News pictures</returns>
        public virtual IList<NewsPicture> GetNewsPicturesByNewsId(int newsId)
        {
            var query = from pp in _newsPictureRepository.Table
                        where pp.NewsId == newsId
                        orderby pp.DisplayOrder, pp.Id
                        select pp;
            var newsPictures = query.ToList();
            return newsPictures;
        }

        /// <summary>
        /// Gets a news picture
        /// </summary>
        /// <param name="newsPictureId">News picture identifier</param>
        /// <returns>News picture</returns>
        public virtual NewsPicture GetNewsPictureById(int newsPictureId)
        {
            if (newsPictureId == 0)
                return null;

            return _newsPictureRepository.GetById(newsPictureId);
        }

        /// <summary>
        /// Inserts a news picture
        /// </summary>
        /// <param name="newsPicture">News picture</param>
        public virtual void InsertNewsPicture(NewsPicture newsPicture)
        {
            if (newsPicture == null)
                throw new ArgumentNullException("newsPicture");

            _newsPictureRepository.Insert(newsPicture);

            //event notification
            _eventPublisher.EntityInserted(newsPicture);
        }

        /// <summary>
        /// Updates a news picture
        /// </summary>
        /// <param name="newsPicture">News picture</param>
        public virtual void UpdateNewsPicture(NewsPicture newsPicture)
        {
            if (newsPicture == null)
                throw new ArgumentNullException("newsPicture");

            _newsPictureRepository.Update(newsPicture);

            //event notification
            _eventPublisher.EntityUpdated(newsPicture);
        }

        /// <summary>
        /// Get the IDs of all news images 
        /// </summary>
        /// <param name="newssIds">Newss IDs</param>
        /// <returns>All picture identifiers grouped by news ID</returns>
        public IDictionary<int, int[]> GetNewsImagesIds(int[] newsIds)
        {
            return _newsPictureRepository.Table.Where(p => newsIds.Contains(p.NewsId))
                .GroupBy(p => p.NewsId).ToDictionary(p => p.Key, p => p.Select(p1 => p1.PictureId).ToArray());
        }

        #endregion

        #endregion
    }
}
