using System;
using System.Collections.Generic;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;
using Club.Web.Models.Common;

namespace Club.Web.Models.Order
{
    public partial class CustomerRewardPointsModel : BaseSiteModel
    {
        public CustomerRewardPointsModel()
        {
            RewardPoints = new List<RewardPointsHistoryModel>();
        }

        public IList<RewardPointsHistoryModel> RewardPoints { get; set; }
        public PagerModel PagerModel { get; set; }
        public int RewardPointsBalance { get; set; }
        public string RewardPointsAmount { get; set; }
        public int MinimumRewardPointsBalance { get; set; }
        public string MinimumRewardPointsAmount { get; set; }

        #region Nested classes

        public partial class RewardPointsHistoryModel : BaseSiteEntityModel
        {
            [SiteResourceDisplayName("RewardPoints.Fields.Points")]
            public int Points { get; set; }

            [SiteResourceDisplayName("RewardPoints.Fields.PointsBalance")]
            public string PointsBalance { get; set; }

            [SiteResourceDisplayName("RewardPoints.Fields.Message")]
            public string Message { get; set; }

            [SiteResourceDisplayName("RewardPoints.Fields.Date")]
            public DateTime CreatedOn { get; set; }
        }

        #endregion
    }
}