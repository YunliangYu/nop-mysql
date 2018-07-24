using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Settings
{
    public partial class ProductEditorSettingsModel : BaseSiteModel
    {
        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Id")]
        public bool Id { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ProductType")]
        public bool ProductType { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.VisibleIndividually")]
        public bool VisibleIndividually { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ProductTemplate")]
        public bool ProductTemplate { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AdminComment")]
        public bool AdminComment { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Vendor")]
        public bool Vendor { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Stores")]
        public bool Stores { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ACL")]
        public bool ACL { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ShowOnHomePage")]
        public bool ShowOnHomePage { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DisplayOrder")]
        public bool DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AllowCustomerReviews")]
        public bool AllowCustomerReviews { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ProductTags")]
        public bool ProductTags { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ManufacturerPartNumber")]
        public bool ManufacturerPartNumber { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.GTIN")]
        public bool GTIN { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ProductCost")]
        public bool ProductCost { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.TierPrices")]
        public bool TierPrices { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Discounts")]
        public bool Discounts { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DisableBuyButton")]
        public bool DisableBuyButton { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DisableWishlistButton")]
        public bool DisableWishlistButton { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AvailableForPreOrder")]
        public bool AvailableForPreOrder { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.CallForPrice")]
        public bool CallForPrice { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.OldPrice")]
        public bool OldPrice { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.CustomerEntersPrice")]
        public bool CustomerEntersPrice { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.PAngV")]
        public bool PAngV { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.RequireOtherProductsAddedToTheCart")]
        public bool RequireOtherProductsAddedToTheCart { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.IsGiftCard")]
        public bool IsGiftCard { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DownloadableProduct")]
        public bool DownloadableProduct { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.RecurringProduct")]
        public bool RecurringProduct { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.IsRental")]
        public bool IsRental { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.FreeShipping")]
        public bool FreeShipping { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ShipSeparately")]
        public bool ShipSeparately { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AdditionalShippingCharge")]
        public bool AdditionalShippingCharge { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DeliveryDate")]
        public bool DeliveryDate { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.TelecommunicationsBroadcastingElectronicServices")]
        public bool TelecommunicationsBroadcastingElectronicServices { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ProductAvailabilityRange")]
        public bool ProductAvailabilityRange { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.UseMultipleWarehouses")]
        public bool UseMultipleWarehouses { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Warehouse")]
        public bool Warehouse { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DisplayStockAvailability")]
        public bool DisplayStockAvailability { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DisplayStockQuantity")]
        public bool DisplayStockQuantity { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.MinimumStockQuantity")]
        public bool MinimumStockQuantity { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.LowStockActivity")]
        public bool LowStockActivity { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.NotifyAdminForQuantityBelow")]
        public bool NotifyAdminForQuantityBelow { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Backorders")]
        public bool Backorders { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AllowBackInStockSubscriptions")]
        public bool AllowBackInStockSubscriptions { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.MinimumCartQuantity")]
        public bool MinimumCartQuantity { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.MaximumCartQuantity")]
        public bool MaximumCartQuantity { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AllowedQuantities")]
        public bool AllowedQuantities { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AllowAddingOnlyExistingAttributeCombinations")]
        public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.NotReturnable")]
        public bool NotReturnable { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Weight")]
        public bool Weight { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Dimensions")]
        public bool Dimensions { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AvailableStartDate")]
        public bool AvailableStartDate { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AvailableEndDate")]
        public bool AvailableEndDate { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.MarkAsNew")]
        public bool MarkAsNew { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.MarkAsNewStartDate")]
        public bool MarkAsNewStartDate { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.MarkAsNewEndDate")]
        public bool MarkAsNewEndDate { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Published")]
        public bool Published { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.CreatedOn")]
        public bool CreatedOn { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.UpdatedOn")]
        public bool UpdatedOn { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.RelatedProducts")]
        public bool RelatedProducts { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.CrossSellsProducts")]
        public bool CrossSellsProducts { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Seo")]
        public bool Seo { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.PurchasedWithOrders")]
        public bool PurchasedWithOrders { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.OneColumnProductPage")]
        public bool OneColumnProductPage { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ProductAttributes")]
        public bool ProductAttributes { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.SpecificationAttributes")]
        public bool SpecificationAttributes { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Manufacturers")]
        public bool Manufacturers { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.ProductEditor.StockQuantityHistory")]
        public bool StockQuantityHistory { get; set; }
    }
}