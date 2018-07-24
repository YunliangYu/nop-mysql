using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Messages
{
    public partial class NewsLetterSubscriptionListModel : BaseSiteModel
    {
        public NewsLetterSubscriptionListModel()
        {
            AvailableStores = new List<SelectListItem>();
            ActiveList = new List<SelectListItem>();
            AvailableCustomerRoles = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.List.SearchEmail")]
        public string SearchEmail { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.List.SearchStore")]
        public int StoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.List.SearchActive")]
        public int ActiveId { get; set; }
        [SiteResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.List.SearchActive")]
        public IList<SelectListItem> ActiveList { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.List.CustomerRoles")]
        public int CustomerRoleId { get; set; }
        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.List.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.NewsLetterSubscriptions.List.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }

    }
}