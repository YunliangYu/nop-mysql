using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Models.Settings;
using Club.Admin.Validators.Catalog;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    [Validator(typeof(ProductValidator))]
    public partial class ProductModel : BaseSiteEntityModel, ILocalizedModel<ProductLocalizedModel>
    {
        public ProductModel()
        {
            Locales = new List<ProductLocalizedModel>();
            ProductPictureModels = new List<ProductPictureModel>();
            CopyProductModel = new CopyProductModel();
            AddPictureModel = new ProductPictureModel();
            AddSpecificationAttributeModel = new AddProductSpecificationAttributeModel();
            ProductWarehouseInventoryModels = new List<ProductWarehouseInventoryModel>();
            ProductEditorSettingsModel = new ProductEditorSettingsModel();
            StockQuantityHistory = new StockQuantityHistoryModel();

            AvailableBasepriceUnits = new List<SelectListItem>();
            AvailableBasepriceBaseUnits = new List<SelectListItem>();
            AvailableProductTemplates = new List<SelectListItem>();
            AvailableTaxCategories = new List<SelectListItem>();
            AvailableDeliveryDates = new List<SelectListItem>();
            AvailableProductAvailabilityRanges = new List<SelectListItem>();
            AvailableWarehouses = new List<SelectListItem>();
            AvailableProductAttributes = new List<SelectListItem>();
            ProductsTypesSupportedByProductTemplates = new Dictionary<int, IList<SelectListItem>>();

            AvailableVendors = new List<SelectListItem>();

            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();

            SelectedManufacturerIds = new List<int>();
            AvailableManufacturers = new List<SelectListItem>();

            SelectedCategoryIds = new List<int>();
            AvailableCategories = new List<SelectListItem>();

            SelectedCustomerRoleIds = new List<int>();
            AvailableCustomerRoles = new List<SelectListItem>();

            SelectedDiscountIds = new List<int>();
            AvailableDiscounts = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ID")]
        public override int Id { get; set; }

        //picture thumbnail
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.PictureThumbnailUrl")]
        public string PictureThumbnailUrl { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ProductType")]
        public int ProductTypeId { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ProductType")]
        public string ProductTypeName { get; set; }


        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AssociatedToProductName")]
        public int AssociatedToProductId { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AssociatedToProductName")]
        public string AssociatedToProductName { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.VisibleIndividually")]
        public bool VisibleIndividually { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ProductTemplate")]
        public int ProductTemplateId { get; set; }
        public IList<SelectListItem> AvailableProductTemplates { get; set; }
        //<product type ID, list of supported product template IDs>
        public Dictionary<int, IList<SelectListItem>> ProductsTypesSupportedByProductTemplates { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ShortDescription")]
        [AllowHtml]
        public string ShortDescription { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.FullDescription")]
        [AllowHtml]
        public string FullDescription { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AdminComment")]
        [AllowHtml]
        public string AdminComment { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ShowOnHomePage")]
        public bool ShowOnHomePage { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MetaKeywords")]
        [AllowHtml]
        public string MetaKeywords { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MetaDescription")]
        [AllowHtml]
        public string MetaDescription { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MetaTitle")]
        [AllowHtml]
        public string MetaTitle { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.SeName")]
        [AllowHtml]
        public string SeName { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AllowCustomerReviews")]
        public bool AllowCustomerReviews { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ProductTags")]
        public string ProductTags { get; set; }




        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Sku")]
        [AllowHtml]
        public string Sku { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ManufacturerPartNumber")]
        [AllowHtml]
        public string ManufacturerPartNumber { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.GTIN")]
        [AllowHtml]
        public virtual string Gtin { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.IsGiftCard")]
        public bool IsGiftCard { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.GiftCardType")]
        public int GiftCardTypeId { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.OverriddenGiftCardAmount")]
        [UIHint("DecimalNullable")]
        public decimal? OverriddenGiftCardAmount { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.RequireOtherProducts")]
        public bool RequireOtherProducts { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.RequiredProductIds")]
        public string RequiredProductIds { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AutomaticallyAddRequiredProducts")]
        public bool AutomaticallyAddRequiredProducts { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.IsDownload")]
        public bool IsDownload { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Download")]
        [UIHint("Download")]
        public int DownloadId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.UnlimitedDownloads")]
        public bool UnlimitedDownloads { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MaxNumberOfDownloads")]
        public int MaxNumberOfDownloads { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.DownloadExpirationDays")]
        [UIHint("Int32Nullable")]
        public int? DownloadExpirationDays { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.DownloadActivationType")]
        public int DownloadActivationTypeId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.HasSampleDownload")]
        public bool HasSampleDownload { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.SampleDownload")]
        [UIHint("Download")]
        public int SampleDownloadId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.HasUserAgreement")]
        public bool HasUserAgreement { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.UserAgreementText")]
        [AllowHtml]
        public string UserAgreementText { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.IsRecurring")]
        public bool IsRecurring { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.RecurringCycleLength")]
        public int RecurringCycleLength { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.RecurringCyclePeriod")]
        public int RecurringCyclePeriodId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.RecurringTotalCycles")]
        public int RecurringTotalCycles { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.IsRental")]
        public bool IsRental { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.RentalPriceLength")]
        public int RentalPriceLength { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.RentalPricePeriod")]
        public int RentalPricePeriodId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.IsShipEnabled")]
        public bool IsShipEnabled { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.IsFreeShipping")]
        public bool IsFreeShipping { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ShipSeparately")]
        public bool ShipSeparately { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AdditionalShippingCharge")]
        public decimal AdditionalShippingCharge { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.DeliveryDate")]
        public int DeliveryDateId { get; set; }
        public IList<SelectListItem> AvailableDeliveryDates { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.IsTaxExempt")]
        public bool IsTaxExempt { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.TaxCategory")]
        public int TaxCategoryId { get; set; }
        public IList<SelectListItem> AvailableTaxCategories { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.IsTelecommunicationsOrBroadcastingOrElectronicServices")]
        public bool IsTelecommunicationsOrBroadcastingOrElectronicServices { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ManageInventoryMethod")]
        public int ManageInventoryMethodId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ProductAvailabilityRange")]
        public int ProductAvailabilityRangeId { get; set; }
        public IList<SelectListItem> AvailableProductAvailabilityRanges { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.UseMultipleWarehouses")]
        public bool UseMultipleWarehouses { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Warehouse")]
        public int WarehouseId { get; set; }
        public IList<SelectListItem> AvailableWarehouses { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.StockQuantity")]
        public int StockQuantity { get; set; }
        public int LastStockQuantity { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.StockQuantity")]
        public string StockQuantityStr { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.DisplayStockAvailability")]
        public bool DisplayStockAvailability { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.DisplayStockQuantity")]
        public bool DisplayStockQuantity { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MinStockQuantity")]
        public int MinStockQuantity { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.LowStockActivity")]
        public int LowStockActivityId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.NotifyAdminForQuantityBelow")]
        public int NotifyAdminForQuantityBelow { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.BackorderMode")]
        public int BackorderModeId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AllowBackInStockSubscriptions")]
        public bool AllowBackInStockSubscriptions { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.OrderMinimumQuantity")]
        public int OrderMinimumQuantity { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.OrderMaximumQuantity")]
        public int OrderMaximumQuantity { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AllowedQuantities")]
        public string AllowedQuantities { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AllowAddingOnlyExistingAttributeCombinations")]
        public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.NotReturnable")]
        public bool NotReturnable { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.DisableBuyButton")]
        public bool DisableBuyButton { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.DisableWishlistButton")]
        public bool DisableWishlistButton { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AvailableForPreOrder")]
        public bool AvailableForPreOrder { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.PreOrderAvailabilityStartDateTimeUtc")]
        [UIHint("DateTimeNullable")]
        public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.CallForPrice")]
        public bool CallForPrice { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Price")]
        public decimal Price { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.OldPrice")]
        public decimal OldPrice { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ProductCost")]
        public decimal ProductCost { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.CustomerEntersPrice")]
        public bool CustomerEntersPrice { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MinimumCustomerEnteredPrice")]
        public decimal MinimumCustomerEnteredPrice { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MaximumCustomerEnteredPrice")]
        public decimal MaximumCustomerEnteredPrice { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.BasepriceEnabled")]
        public bool BasepriceEnabled { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.BasepriceAmount")]
        public decimal BasepriceAmount { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.BasepriceUnit")]
        public int BasepriceUnitId { get; set; }
        public IList<SelectListItem> AvailableBasepriceUnits { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.BasepriceBaseAmount")]
        public decimal BasepriceBaseAmount { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.BasepriceBaseUnit")]
        public int BasepriceBaseUnitId { get; set; }
        public IList<SelectListItem> AvailableBasepriceBaseUnits { get; set; }


        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MarkAsNew")]
        public bool MarkAsNew { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MarkAsNewStartDateTimeUtc")]
        [UIHint("DateTimeNullable")]
        public DateTime? MarkAsNewStartDateTimeUtc { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MarkAsNewEndDateTimeUtc")]
        [UIHint("DateTimeNullable")]
        public DateTime? MarkAsNewEndDateTimeUtc { get; set; }


        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Weight")]
        public decimal Weight { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Length")]
        public decimal Length { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Width")]
        public decimal Width { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Height")]
        public decimal Height { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AvailableStartDateTime")]
        [UIHint("DateTimeNullable")]
        public DateTime? AvailableStartDateTimeUtc { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AvailableEndDateTime")]
        [UIHint("DateTimeNullable")]
        public DateTime? AvailableEndDateTimeUtc { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Published")]
        public bool Published { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.CreatedOn")]
        public DateTime? CreatedOn { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.UpdatedOn")]
        public DateTime? UpdatedOn { get; set; }


        public string PrimaryStoreCurrencyCode { get; set; }
        public string BaseDimensionIn { get; set; }
        public string BaseWeightIn { get; set; }

        public IList<ProductLocalizedModel> Locales { get; set; }



        //ACL (customer roles)
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.AclCustomerRoles")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedCustomerRoleIds { get; set; }
        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

        //store mapping
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.LimitedToStores")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        //categories
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Categories")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedCategoryIds { get; set; }
        public IList<SelectListItem> AvailableCategories { get; set; }

        //manufacturers
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Manufacturers")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedManufacturerIds { get; set; }
        public IList<SelectListItem> AvailableManufacturers { get; set; }

        //vendors
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Vendor")]
        public int VendorId { get; set; }
        public IList<SelectListItem> AvailableVendors { get; set; }

        //discounts
        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Discounts")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedDiscountIds { get; set; }
        public IList<SelectListItem> AvailableDiscounts { get; set; }

        //vendor
        public bool IsLoggedInAsVendor { get; set; }

        //product attributes
        public IList<SelectListItem> AvailableProductAttributes { get; set; }
        
        //pictures
        public ProductPictureModel AddPictureModel { get; set; }
        public IList<ProductPictureModel> ProductPictureModels { get; set; }

        //add specification attribute model
        public AddProductSpecificationAttributeModel AddSpecificationAttributeModel { get; set; }

        //multiple warehouses
        [SiteResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory")]
        public IList<ProductWarehouseInventoryModel> ProductWarehouseInventoryModels { get; set; }

        //copy product
        public CopyProductModel CopyProductModel { get; set; }

        //editor settings
        public ProductEditorSettingsModel ProductEditorSettingsModel { get; set; }

        //stock quantity history
        public StockQuantityHistoryModel StockQuantityHistory { get; set; }

        #region Nested classes

        public partial class AddRequiredProductModel : BaseSiteModel
        {
            public AddRequiredProductModel()
            {
                AvailableCategories = new List<SelectListItem>();
                AvailableManufacturers = new List<SelectListItem>();
                AvailableStores = new List<SelectListItem>();
                AvailableVendors = new List<SelectListItem>();
                AvailableProductTypes = new List<SelectListItem>();
            }

            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchProductName")]
            [AllowHtml]
            public string SearchProductName { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchCategory")]
            public int SearchCategoryId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchManufacturer")]
            public int SearchManufacturerId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchStore")]
            public int SearchStoreId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchVendor")]
            public int SearchVendorId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchProductType")]
            public int SearchProductTypeId { get; set; }

            public IList<SelectListItem> AvailableCategories { get; set; }
            public IList<SelectListItem> AvailableManufacturers { get; set; }
            public IList<SelectListItem> AvailableStores { get; set; }
            public IList<SelectListItem> AvailableVendors { get; set; }
            public IList<SelectListItem> AvailableProductTypes { get; set; }

            //vendor
            public bool IsLoggedInAsVendor { get; set; }
        }

        public partial class AddProductSpecificationAttributeModel : BaseSiteModel
        {
            public AddProductSpecificationAttributeModel()
            {
                AvailableAttributes = new List<SelectListItem>();
                AvailableOptions = new List<SelectListItem>();
            }
            
            [SiteResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.SpecificationAttribute")]
            public int SpecificationAttributeId { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.AttributeType")]
            public int AttributeTypeId { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.SpecificationAttributeOption")]
            public int SpecificationAttributeOptionId { get; set; }

            [AllowHtml]
            [SiteResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.CustomValue")]
            public string CustomValue { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.AllowFiltering")]
            public bool AllowFiltering { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.ShowOnProductPage")]
            public bool ShowOnProductPage { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.DisplayOrder")]
            public int DisplayOrder { get; set; }

            public IList<SelectListItem> AvailableAttributes { get; set; }
            public IList<SelectListItem> AvailableOptions { get; set; }
        }
        
        public partial class ProductPictureModel : BaseSiteEntityModel
        {
            public int ProductId { get; set; }

            [UIHint("Picture")]
            [SiteResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.Picture")]
            public int PictureId { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.Picture")]
            public string PictureUrl { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.DisplayOrder")]
            public int DisplayOrder { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.OverrideAltAttribute")]
            [AllowHtml]
            public string OverrideAltAttribute { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.OverrideTitleAttribute")]
            [AllowHtml]
            public string OverrideTitleAttribute { get; set; }
        }

        public partial class RelatedProductModel : BaseSiteEntityModel
        {
            public int ProductId2 { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.RelatedProducts.Fields.Product")]
            public string Product2Name { get; set; }
            
            [SiteResourceDisplayName("Admin.Catalog.Products.RelatedProducts.Fields.DisplayOrder")]
            public int DisplayOrder { get; set; }
        }
        public partial class AddRelatedProductModel : BaseSiteModel
        {
            public AddRelatedProductModel()
            {
                AvailableCategories = new List<SelectListItem>();
                AvailableManufacturers = new List<SelectListItem>();
                AvailableStores = new List<SelectListItem>();
                AvailableVendors = new List<SelectListItem>();
                AvailableProductTypes = new List<SelectListItem>();
            }

            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchProductName")]
            [AllowHtml]
            public string SearchProductName { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchCategory")]
            public int SearchCategoryId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchManufacturer")]
            public int SearchManufacturerId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchStore")]
            public int SearchStoreId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchVendor")]
            public int SearchVendorId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchProductType")]
            public int SearchProductTypeId { get; set; }

            public IList<SelectListItem> AvailableCategories { get; set; }
            public IList<SelectListItem> AvailableManufacturers { get; set; }
            public IList<SelectListItem> AvailableStores { get; set; }
            public IList<SelectListItem> AvailableVendors { get; set; }
            public IList<SelectListItem> AvailableProductTypes { get; set; }

            public int ProductId { get; set; }

            public int[] SelectedProductIds { get; set; }

            //vendor
            public bool IsLoggedInAsVendor { get; set; }
        }

        public partial class AssociatedProductModel : BaseSiteEntityModel
        {
            [SiteResourceDisplayName("Admin.Catalog.Products.AssociatedProducts.Fields.Product")]
            public string ProductName { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.AssociatedProducts.Fields.DisplayOrder")]
            public int DisplayOrder { get; set; }
        }
        public partial class AddAssociatedProductModel : BaseSiteModel
        {
            public AddAssociatedProductModel()
            {
                AvailableCategories = new List<SelectListItem>();
                AvailableManufacturers = new List<SelectListItem>();
                AvailableStores = new List<SelectListItem>();
                AvailableVendors = new List<SelectListItem>();
                AvailableProductTypes = new List<SelectListItem>();
            }

            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchProductName")]
            [AllowHtml]
            public string SearchProductName { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchCategory")]
            public int SearchCategoryId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchManufacturer")]
            public int SearchManufacturerId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchStore")]
            public int SearchStoreId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchVendor")]
            public int SearchVendorId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchProductType")]
            public int SearchProductTypeId { get; set; }

            public IList<SelectListItem> AvailableCategories { get; set; }
            public IList<SelectListItem> AvailableManufacturers { get; set; }
            public IList<SelectListItem> AvailableStores { get; set; }
            public IList<SelectListItem> AvailableVendors { get; set; }
            public IList<SelectListItem> AvailableProductTypes { get; set; }

            public int ProductId { get; set; }

            public int[] SelectedProductIds { get; set; }

            //vendor
            public bool IsLoggedInAsVendor { get; set; }
        }

        public partial class CrossSellProductModel : BaseSiteEntityModel
        {
            public int ProductId2 { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.CrossSells.Fields.Product")]
            public string Product2Name { get; set; }
        }
        public partial class AddCrossSellProductModel : BaseSiteModel
        {
            public AddCrossSellProductModel()
            {
                AvailableCategories = new List<SelectListItem>();
                AvailableManufacturers = new List<SelectListItem>();
                AvailableStores = new List<SelectListItem>();
                AvailableVendors = new List<SelectListItem>();
                AvailableProductTypes = new List<SelectListItem>();
            }

            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchProductName")]
            [AllowHtml]
            public string SearchProductName { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchCategory")]
            public int SearchCategoryId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchManufacturer")]
            public int SearchManufacturerId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchStore")]
            public int SearchStoreId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchVendor")]
            public int SearchVendorId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchProductType")]
            public int SearchProductTypeId { get; set; }

            public IList<SelectListItem> AvailableCategories { get; set; }
            public IList<SelectListItem> AvailableManufacturers { get; set; }
            public IList<SelectListItem> AvailableStores { get; set; }
            public IList<SelectListItem> AvailableVendors { get; set; }
            public IList<SelectListItem> AvailableProductTypes { get; set; }

            public int ProductId { get; set; }

            public int[] SelectedProductIds { get; set; }

            //vendor
            public bool IsLoggedInAsVendor { get; set; }
        }

        public partial class TierPriceModel : BaseSiteEntityModel
        {
            public TierPriceModel()
            {
                AvailableStores = new List<SelectListItem>();
                AvailableCustomerRoles = new List<SelectListItem>();
            }

            public int ProductId { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.TierPrices.Fields.CustomerRole")]
            public int CustomerRoleId { get; set; }
            public IList<SelectListItem> AvailableCustomerRoles { get; set; }
            public string CustomerRole { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.TierPrices.Fields.Store")]
            public int StoreId { get; set; }
            public IList<SelectListItem> AvailableStores { get; set; }
            public string Store { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.TierPrices.Fields.Quantity")]
            public int Quantity { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.TierPrices.Fields.Price")]
            public decimal Price { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.TierPrices.Fields.StartDateTimeUtc")]
            [UIHint("DateTimeNullable")]
            public DateTime? StartDateTimeUtc { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.TierPrices.Fields.EndDateTimeUtc")]
            [UIHint("DateTimeNullable")]
            public DateTime? EndDateTimeUtc { get; set; }
        }

        public partial class ProductWarehouseInventoryModel : BaseSiteModel
        {
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory.Fields.Warehouse")]
            public int WarehouseId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory.Fields.Warehouse")]
            public string WarehouseName { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory.Fields.WarehouseUsed")]
            public bool WarehouseUsed { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory.Fields.StockQuantity")]
            public int StockQuantity { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory.Fields.ReservedQuantity")]
            public int ReservedQuantity { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory.Fields.PlannedQuantity")]
            public int PlannedQuantity { get; set; }
        }


        public partial class ProductAttributeMappingModel : BaseSiteEntityModel
        {
            public int ProductId { get; set; }

            public int ProductAttributeId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Fields.Attribute")]
            public string ProductAttribute { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Fields.TextPrompt")]
            [AllowHtml]
            public string TextPrompt { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Fields.IsRequired")]
            public bool IsRequired { get; set; }

            public int AttributeControlTypeId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Fields.AttributeControlType")]
            public string AttributeControlType { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Fields.DisplayOrder")]
            public int DisplayOrder { get; set; }

            public bool ShouldHaveValues { get; set; }
            public int TotalValues { get; set; }

            //validation fields
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.ValidationRules")]
            public bool ValidationRulesAllowed { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.ValidationRules.MinLength")]
            [UIHint("Int32Nullable")]
            public int? ValidationMinLength { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.ValidationRules.MaxLength")]
            [UIHint("Int32Nullable")]
            public int? ValidationMaxLength { get; set; }
            [AllowHtml]
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.ValidationRules.FileAllowedExtensions")]
            public string ValidationFileAllowedExtensions { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.ValidationRules.FileMaximumSize")]
            [UIHint("Int32Nullable")]
            public int? ValidationFileMaximumSize { get; set; }
            [AllowHtml]
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.ValidationRules.DefaultValue")]
            public string DefaultValue { get; set; }
            public string ValidationRulesString { get; set; }
            
            //condition
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Condition")]
            public bool ConditionAllowed { get; set; }
            public string ConditionString { get; set; }
        }
        public partial class ProductAttributeValueListModel : BaseSiteModel
        {
            public int ProductId { get; set; }

            public string ProductName { get; set; }

            public int ProductAttributeMappingId { get; set; }

            public string ProductAttributeName { get; set; }
        }
        [Validator(typeof(ProductAttributeValueModelValidator))]
        public partial class ProductAttributeValueModel : BaseSiteEntityModel, ILocalizedModel<ProductAttributeValueLocalizedModel>
        {
            public ProductAttributeValueModel()
            {
                ProductPictureModels = new List<ProductPictureModel>();
                Locales = new List<ProductAttributeValueLocalizedModel>();
            }

            public int ProductAttributeMappingId { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.AttributeValueType")]
            public int AttributeValueTypeId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.AttributeValueType")]
            public string AttributeValueTypeName { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.AssociatedProduct")]
            public int AssociatedProductId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.AssociatedProduct")]
            public string AssociatedProductName { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.Name")]
            [AllowHtml]
            public string Name { get; set; }
            
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.ColorSquaresRgb")]
            [AllowHtml]
            public string ColorSquaresRgb { get; set; }
            public bool DisplayColorSquaresRgb { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.ImageSquaresPicture")]
            [UIHint("Picture")]
            public int ImageSquaresPictureId { get; set; }
            public bool DisplayImageSquaresPicture { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.PriceAdjustment")]
            public decimal PriceAdjustment { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.PriceAdjustment")]
            //used only on the values list page
            public string PriceAdjustmentStr { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.WeightAdjustment")]
            public decimal WeightAdjustment { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.WeightAdjustment")]
            //used only on the values list page
            public string WeightAdjustmentStr { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.Cost")]
            public decimal Cost { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.CustomerEntersQty")]
            public bool CustomerEntersQty { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.Quantity")]
            public int Quantity { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.IsPreSelected")]
            public bool IsPreSelected { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.DisplayOrder")]
            public int DisplayOrder { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.Picture")]
            public int PictureId { get; set; }
            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.Picture")]
            public string PictureThumbnailUrl { get; set; }

            public IList<ProductPictureModel> ProductPictureModels { get; set; }
            public IList<ProductAttributeValueLocalizedModel> Locales { get; set; }

            #region Nested classes

            public partial class AssociateProductToAttributeValueModel : BaseSiteModel
            {
                public AssociateProductToAttributeValueModel()
                {
                    AvailableCategories = new List<SelectListItem>();
                    AvailableManufacturers = new List<SelectListItem>();
                    AvailableStores = new List<SelectListItem>();
                    AvailableVendors = new List<SelectListItem>();
                    AvailableProductTypes = new List<SelectListItem>();
                }

                [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchProductName")]
                [AllowHtml]
                public string SearchProductName { get; set; }
                [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchCategory")]
                public int SearchCategoryId { get; set; }
                [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchManufacturer")]
                public int SearchManufacturerId { get; set; }
                [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchStore")]
                public int SearchStoreId { get; set; }
                [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchVendor")]
                public int SearchVendorId { get; set; }
                [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchProductType")]
                public int SearchProductTypeId { get; set; }

                public IList<SelectListItem> AvailableCategories { get; set; }
                public IList<SelectListItem> AvailableManufacturers { get; set; }
                public IList<SelectListItem> AvailableStores { get; set; }
                public IList<SelectListItem> AvailableVendors { get; set; }
                public IList<SelectListItem> AvailableProductTypes { get; set; }
                
                //vendor
                public bool IsLoggedInAsVendor { get; set; }


                public int AssociatedToProductId { get; set; }
            }
            #endregion
        }
        public partial class ProductAttributeValueLocalizedModel : ILocalizedModelLocal
        {
            public int LanguageId { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Values.Fields.Name")]
            [AllowHtml]
            public string Name { get; set; }
        }
        public partial class ProductAttributeCombinationModel : BaseSiteEntityModel
        {
            public int ProductId { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.Attributes")]
            [AllowHtml]
            public string AttributesXml { get; set; }

            [AllowHtml]
            public string Warnings { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.StockQuantity")]
            public int StockQuantity { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.AllowOutOfStockOrders")]
            public bool AllowOutOfStockOrders { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.Sku")]
            public string Sku { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.ManufacturerPartNumber")]
            public string ManufacturerPartNumber { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.Gtin")]
            public string Gtin { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.OverriddenPrice")]
            [UIHint("DecimalNullable")]
            public decimal? OverriddenPrice { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.ProductAttributes.AttributeCombinations.Fields.NotifyAdminForQuantityBelow")]
            public int NotifyAdminForQuantityBelow { get; set; }

        }

        #region Stock quantity history

        public partial class StockQuantityHistoryModel : BaseSiteEntityModel
        {
            [SiteResourceDisplayName("Admin.Catalog.Products.List.SearchWarehouse")]
            public int SearchWarehouseId { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.Warehouse")]
            [AllowHtml]
            public string WarehouseName { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.Combination")]
            [AllowHtml]
            public string AttributeCombination { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.QuantityAdjustment")]
            public int QuantityAdjustment { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.StockQuantity")]
            public int StockQuantity { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.Message")]
            [AllowHtml]
            public string Message { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.CreatedOn")]
            [UIHint("DecimalNullable")]
            public DateTime CreatedOn { get; set; }
        }

        #endregion

        #endregion
    }

    public partial class ProductLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.ShortDescription")]
        [AllowHtml]
        public string ShortDescription { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.FullDescription")]
        [AllowHtml]
        public string FullDescription { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MetaKeywords")]
        [AllowHtml]
        public string MetaKeywords { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MetaDescription")]
        [AllowHtml]
        public string MetaDescription { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.MetaTitle")]
        [AllowHtml]
        public string MetaTitle { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Products.Fields.SeName")]
        [AllowHtml]
        public string SeName { get; set; }
    }
}