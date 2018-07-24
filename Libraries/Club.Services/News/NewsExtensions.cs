using System;
using System.Collections.Generic;
using System.Linq;
using Club.Core;
using Club.Core.Domain.Customers;
using Club.Services.Directory;
using Club.Services.Localization;
using Club.Services.Shipping.Date;
using Club.Core.Domain.News;

namespace Club.Services.News
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class NewsExtensions
    {

        /// <summary>
        /// Indicates whether a news tag exists
        /// </summary>
        /// <param name="product">news</param>
        /// <param name="productTagId">news tag identifier</param>
        /// <returns>Result</returns>
        public static bool NewsTagExists(this NewsItem newsItem,
            int newsTagId)
        {
            if (newsItem == null)
                throw new ArgumentNullException("newsItem");

            bool result = newsItem.NewsTags.ToList().Find(pt => pt.Id == newsTagId) != null;
            return result;
        }
    }
}
