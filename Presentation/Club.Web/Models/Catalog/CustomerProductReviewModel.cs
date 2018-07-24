using System.Collections.Generic;
using Club.Web.Framework.Mvc;
using Club.Web.Models.Common;

namespace Club.Web.Models.Catalog
{
    public class CustomerProductReviewModel : BaseSiteModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSeName { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public string ReplyText { get; set; }
        public int Rating { get; set; }
        public string WrittenOnStr { get; set; }
        public string ApprovalStatus { get; set; }
    }

    public class CustomerProductReviewsModel : BaseSiteModel
    {
        public CustomerProductReviewsModel()
        {
            ProductReviews = new List<CustomerProductReviewModel>();
        }

        public IList<CustomerProductReviewModel> ProductReviews { get; set; }
        public PagerModel PagerModel { get; set; }

        #region Nested class

        /// <summary>
        /// Class that has only page for route value. Used for (My Account) My Product Reviews pagination
        /// </summary>
        public partial class CustomerProductReviewsRouteValues : IRouteValues
        {
            public int page { get; set; }
        }

        #endregion
    }
}