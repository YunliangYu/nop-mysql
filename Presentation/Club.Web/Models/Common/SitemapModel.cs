﻿using System.Collections.Generic;
using Club.Web.Framework.Mvc;
using Club.Web.Models.Catalog;
using Club.Web.Models.Topics;

namespace Club.Web.Models.Common
{
    public partial class SitemapModel : BaseSiteModel
    {
        public SitemapModel()
        {
            Products = new List<ProductOverviewModel>();
            Categories = new List<CategorySimpleModel>();
            Manufacturers = new List<ManufacturerBriefInfoModel>();
            Topics = new List<TopicModel>();
        }
        public IList<ProductOverviewModel> Products { get; set; }
        public IList<CategorySimpleModel> Categories { get; set; }
        public IList<ManufacturerBriefInfoModel> Manufacturers { get; set; }
        public IList<TopicModel> Topics { get; set; }

        public bool NewsEnabled { get; set; }
        public bool BlogEnabled { get; set; }
        public bool ForumEnabled { get; set; }
    }
}