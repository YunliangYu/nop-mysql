using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public class ReturnRequestListModel: BaseSiteModel
    {
        public ReturnRequestListModel()
        {
            ReturnRequestStatusList = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.ReturnRequests.SearchStartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [SiteResourceDisplayName("Admin.ReturnRequests.SearchEndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }

        [SiteResourceDisplayName("Admin.ReturnRequests.SearchCustomNumber")]
        public string CustomNumber { get; set; }

        [SiteResourceDisplayName("Admin.ReturnRequests.SearchReturnRequestStatus")]
        public int ReturnRequestStatusId { get; set; }
        public IList<SelectListItem> ReturnRequestStatusList { get; set; }
    }
}