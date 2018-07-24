using System.Collections.Generic;
using Club.Core.Domain.Catalog;
using Club.Core.Domain.News;

namespace Club.Services.News
{
    /// <summary>
    /// News tag service interface
    /// </summary>
    public partial interface INewsTagService
    {
        /// <summary>
        /// Delete a news tag
        /// </summary>
        /// <param name="newsTag">News tag</param>
        void DeleteNewsTag(NewsTag newsTag);

        /// <summary>
        /// Gets all news tags
        /// </summary>
        /// <returns>News tags</returns>
        IList<NewsTag> GetAllNewsTags();

        /// <summary>
        /// Gets news tag
        /// </summary>
        /// <param name="newsTagId">News tag identifier</param>
        /// <returns>News tag</returns>
        NewsTag GetNewsTagById(int newsTagId);
        
        /// <summary>
        /// Gets news tag by name
        /// </summary>
        /// <param name="name">News tag name</param>
        /// <returns>News tag</returns>
        NewsTag GetNewsTagByName(string name);

        /// <summary>
        /// Inserts a news tag
        /// </summary>
        /// <param name="newsTag">News tag</param>
        void InsertNewsTag(NewsTag newsTag);

        /// <summary>
        /// Updates the news tag
        /// </summary>
        /// <param name="newsTag">News tag</param>
        void UpdateNewsTag(NewsTag newsTag);

        /// <summary>
        /// Get number of newss
        /// </summary>
        /// <param name="newsTagId">News tag identifier</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Number of newss</returns>
        int GetNewsCount(int newsTagId, int storeId);

        /// <summary>
        /// Update news tags
        /// </summary>
        /// <param name="news">News for update</param>
        /// <param name="newsTags">News tags</param>
        void UpdateNewsTags(NewsItem news, string[] newsTags);
    }
}
