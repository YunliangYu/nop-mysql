using System;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public partial class RecurringPaymentModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.ID")]
        public override int Id { get; set; }

        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.CycleLength")]
        public int CycleLength { get; set; }

        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.CyclePeriod")]
        public int CyclePeriodId { get; set; }

        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.CyclePeriod")]
        public string CyclePeriodStr { get; set; }

        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.TotalCycles")]
        public int TotalCycles { get; set; }

        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.StartDate")]
        public string StartDate { get; set; }

        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.IsActive")]
        public bool IsActive { get; set; }

        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.NextPaymentDate")]
        public string NextPaymentDate { get; set; }

        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.CyclesRemaining")]
        public int CyclesRemaining { get; set; }

        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.InitialOrder")]
        public int InitialOrderId { get; set; }

        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.Customer")]
        public int CustomerId { get; set; }
        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.Customer")]
        public string CustomerEmail { get; set; }

        [SiteResourceDisplayName("Admin.RecurringPayments.Fields.PaymentType")]
        public string PaymentType { get; set; }
        
        public bool CanCancelRecurringPayment { get; set; }

        public bool LastPaymentFailed { get; set; }

        #region Nested classes


        public partial class RecurringPaymentHistoryModel : BaseSiteEntityModel
        {
            public int OrderId { get; set; }

            [SiteResourceDisplayName("Admin.RecurringPayments.History.CustomOrderNumber")]
            public string CustomOrderNumber { get; set; }

            public int RecurringPaymentId { get; set; }

            [SiteResourceDisplayName("Admin.RecurringPayments.History.OrderStatus")]
            public string OrderStatus { get; set; }

            [SiteResourceDisplayName("Admin.RecurringPayments.History.PaymentStatus")]
            public string PaymentStatus { get; set; }

            [SiteResourceDisplayName("Admin.RecurringPayments.History.ShippingStatus")]
            public string ShippingStatus { get; set; }

            [SiteResourceDisplayName("Admin.RecurringPayments.History.CreatedOn")]
            public DateTime CreatedOn { get; set; }
        }

        #endregion
    }
}