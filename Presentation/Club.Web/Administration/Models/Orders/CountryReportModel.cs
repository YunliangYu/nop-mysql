using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public partial class CountryReportModel : BaseSiteModel
    {
        public CountryReportModel()
        {
            AvailableOrderStatuses = new List<SelectListItem>();
            AvailablePaymentStatuses = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.SalesReport.Country.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [SiteResourceDisplayName("Admin.SalesReport.Country.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }


        [SiteResourceDisplayName("Admin.SalesReport.Country.OrderStatus")]
        public int OrderStatusId { get; set; }
        [SiteResourceDisplayName("Admin.SalesReport.Country.PaymentStatus")]
        public int PaymentStatusId { get; set; }

        public IList<SelectListItem> AvailableOrderStatuses { get; set; }
        public IList<SelectListItem> AvailablePaymentStatuses { get; set; }
    }
}