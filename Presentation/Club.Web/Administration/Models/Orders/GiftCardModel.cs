using System;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    public partial class GiftCardModel: BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.GiftCards.Fields.GiftCardType")]
        public int GiftCardTypeId { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.OrderId")]
        public int? PurchasedWithOrderId { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.CustomOrderNumber")]
        public string PurchasedWithOrderNumber { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.Amount")]
        public decimal Amount { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.Amount")]
        public string AmountStr { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.RemainingAmount")]
        public string RemainingAmountStr { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.IsGiftCardActivated")]
        public bool IsGiftCardActivated { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.GiftCardCouponCode")]
        [AllowHtml]
        public string GiftCardCouponCode { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.RecipientName")]
        [AllowHtml]
        public string RecipientName { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.RecipientEmail")]
        [AllowHtml]
        public string RecipientEmail { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.SenderName")]
        [AllowHtml]
        public string SenderName { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.SenderEmail")]
        [AllowHtml]
        public string SenderEmail { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.Message")]
        [AllowHtml]
        public string Message { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.IsRecipientNotified")]
        public bool IsRecipientNotified { get; set; }

        [SiteResourceDisplayName("Admin.GiftCards.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        public string PrimaryStoreCurrencyCode { get; set; }

        #region Nested classes

        public partial class GiftCardUsageHistoryModel : BaseSiteEntityModel
        {
            [SiteResourceDisplayName("Admin.GiftCards.History.UsedValue")]
            public string UsedValue { get; set; }
            
            public int OrderId { get; set; }

            [SiteResourceDisplayName("Admin.GiftCards.History.CreatedOn")]
            public DateTime CreatedOn { get; set; }

            [SiteResourceDisplayName("Admin.GiftCards.History.CustomOrderNumber")]
            public string CustomOrderNumber { get; set; }
        }

        #endregion
    }
}