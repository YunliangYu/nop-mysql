using System;
using System.Collections.Generic;
using System.Linq;
using Club.Core.Data;
using Club.Core.Domain.News;
using Club.Services.Events;
using Club.Core.Caching;

namespace Club.Services.News
{
    /// <summary>
    /// News Program service
    /// </summary>
    public partial class NewsProgramService : INewsProgramService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// </remarks>
        private const string NEWSPROGRAM_COUNT_KEY = "Club.newsprogram.count-{0}";

        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        private const string NEWSPROGRAM_PATTERN_KEY = "Club.newsprogram.";

        #endregion

        #region Fields

        private readonly IRepository<NewsProgram> _newsProgramRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="newsProgramRepository">News Program repository</param>
        /// <param name="eventPublisher">Event published</param>
        public NewsProgramService(IRepository<NewsProgram> newsProgramRepository,
            ICacheManager cacheManager,
            IEventPublisher eventPublisher)
        {
            this._newsProgramRepository = newsProgramRepository;
            this._cacheManager = cacheManager;
            this._eventPublisher = eventPublisher;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete news program
        /// </summary>
        /// <param name="newsProgram">News Program</param>
        public virtual void DeleteNewsProgram(NewsProgram newsProgram)
        {
            if (newsProgram == null)
                throw new ArgumentNullException("newsProgram");

            _newsProgramRepository.Delete(newsProgram);

            _cacheManager.RemoveByPattern(NEWSPROGRAM_PATTERN_KEY);
            //event notification
            _eventPublisher.EntityDeleted(newsProgram);
        }

        /// <summary>
        /// Gets all news programs
        /// </summary>
        /// <returns>News Programs</returns>
        public virtual IList<NewsProgram> GetAllNewsPrograms()
        {
            var query = from pt in _newsProgramRepository.Table
                        orderby pt.DisplayOrder, pt.Id
                        select pt;

            var templates = query.ToList();
            return templates;
        }

        /// <summary>
        /// Gets a news program
        /// </summary>
        /// <param name="newsProgramId">News Program identifier</param>
        /// <returns>News Program</returns>
        public virtual NewsProgram GetNewsProgramById(int newsProgramId)
        {
            if (newsProgramId == 0)
                return null;

            return _newsProgramRepository.GetById(newsProgramId);
        }

        /// <summary>
        /// Inserts news program
        /// </summary>
        /// <param name="newsProgram">News Program</param>
        public virtual void InsertNewsProgram(NewsProgram newsProgram)
        {
            if (newsProgram == null)
                throw new ArgumentNullException("newsProgram");

            _newsProgramRepository.Insert(newsProgram);
            _cacheManager.RemoveByPattern(NEWSPROGRAM_PATTERN_KEY);
            //event notification
            _eventPublisher.EntityInserted(newsProgram);
        }

        /// <summary>
        /// Updates the news program
        /// </summary>
        /// <param name="newsProgram">News Program</param>
        public virtual void UpdateNewsProgram(NewsProgram newsProgram)
        {
            if (newsProgram == null)
                throw new ArgumentNullException("newsProgram");

            _newsProgramRepository.Update(newsProgram);
            _cacheManager.RemoveByPattern(NEWSPROGRAM_PATTERN_KEY);
            //event notification
            _eventPublisher.EntityUpdated(newsProgram);
        }
        
        #endregion
    }
}
