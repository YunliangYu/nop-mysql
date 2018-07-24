﻿using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Plugins
{
    public partial class OfficialFeedListModel : BaseSiteModel
    {
        public OfficialFeedListModel()
        {
            AvailableVersions = new List<SelectListItem>();
            AvailableCategories = new List<SelectListItem>();
            AvailablePrices = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Configuration.Plugins.OfficialFeed.Name")]
        [AllowHtml]
        public string SearchName { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.Plugins.OfficialFeed.Version")]
        public int SearchVersionId { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.Plugins.OfficialFeed.Category")]
        public int SearchCategoryId { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.Plugins.OfficialFeed.Price")]
        public int SearchPriceId { get; set; }


        [SiteResourceDisplayName("Admin.Configuration.Plugins.OfficialFeed.Version")]
        public IList<SelectListItem> AvailableVersions { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.Plugins.OfficialFeed.Category")]
        public IList<SelectListItem> AvailableCategories { get; set; }
        [SiteResourceDisplayName("Admin.Configuration.Plugins.OfficialFeed.Price")]
        public IList<SelectListItem> AvailablePrices { get; set; }

        #region Nested classes

        public partial class ItemOverview
        {
            public string Url { get; set; }
            public string Name { get; set; }
            public string CategoryName { get; set; }
            public string SupportedVersions { get; set; }
            public string PictureUrl { get; set; }
            public string Price { get; set; }
        }

        #endregion
    }
}