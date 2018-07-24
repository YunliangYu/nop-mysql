using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Discounts;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Discounts
{
    [Validator(typeof(DiscountValidator))]
    public partial class DiscountModel : BaseSiteEntityModel
    {
        public DiscountModel()
        {
            AvailableDiscountRequirementRules = new List<SelectListItem>();
            AvailableRequirementGroups = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.DiscountType")]
        public int DiscountTypeId { get; set; }
        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.DiscountType")]
        public string DiscountTypeName { get; set; }

        //used for the list page
        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.TimesUsed")]
        public int TimesUsed { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.UsePercentage")]
        public bool UsePercentage { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.DiscountPercentage")]
        public decimal DiscountPercentage { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.DiscountAmount")]
        public decimal DiscountAmount { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.MaximumDiscountAmount")]
        [UIHint("DecimalNullable")]
        public decimal? MaximumDiscountAmount { get; set; }

        public string PrimaryStoreCurrencyCode { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.StartDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? StartDateUtc { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.EndDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? EndDateUtc { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.RequiresCouponCode")]
        public bool RequiresCouponCode { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.CouponCode")]
        [AllowHtml]
        public string CouponCode { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.IsCumulative")]
        public bool IsCumulative { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.DiscountLimitation")]
        public int DiscountLimitationId { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.LimitationTimes")]
        public int LimitationTimes { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.MaximumDiscountedQuantity")]
        [UIHint("Int32Nullable")]
        public int? MaximumDiscountedQuantity { get; set; }
        
        [SiteResourceDisplayName("Admin.Promotions.Discounts.Fields.AppliedToSubCategories")]
        public bool AppliedToSubCategories { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Requirements.DiscountRequirementType")]
        public string AddDiscountRequirement { get; set; }

        public IList<SelectListItem> AvailableDiscountRequirementRules { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Requirements.GroupName")]
        public string GroupName { get; set; }

        [SiteResourceDisplayName("Admin.Promotions.Discounts.Requirements.RequirementGroup")]
        public int RequirementGroupId { get; set; }

        public IList<SelectListItem> AvailableRequirementGroups { get; set; }

        #region Nested classes

        public partial class DiscountRequirementMetaInfo : BaseSiteModel
        {
            public DiscountRequirementMetaInfo()
            {
                ChildRequirements = new List<DiscountRequirementMetaInfo>();
            }

            public int DiscountRequirementId { get; set; }
            public string RuleName { get; set; }
            public string ConfigurationUrl { get; set; }
            public int InteractionTypeId { get; set; }
            public int? ParentId { get; set; }
            public SelectList AvailableInteractionTypes { get; set; }
            public bool IsGroup { get; set; }
            public bool IsLastInGroup { get; set; }
            public IList<DiscountRequirementMetaInfo> ChildRequirements { get; set; }
        }

        public partial class DiscountUsageHistoryModel : BaseSiteEntityModel
        {
            public int DiscountId { get; set; }
            
            public int OrderId { get; set; }

            [SiteResourceDisplayName("Admin.Promotions.Discounts.History.CustomOrderNumber")]
            public string CustomOrderNumber { get; set; }

            [SiteResourceDisplayName("Admin.Promotions.Discounts.History.OrderTotal")]
            public string OrderTotal { get; set; }

            [SiteResourceDisplayName("Admin.Promotions.Discounts.History.CreatedOn")]
            public DateTime CreatedOn { get; set; }
        }

        public partial class AppliedToCategoryModel : BaseSiteModel
        {
            public int CategoryId { get; set; }

            public string CategoryName { get; set; }
        }
        public partial class AddCategoryToDiscountModel : BaseSiteModel
        {
            [SiteResourceDisplayName("Admin.Catalog.Categories.List.SearchCategoryName")]
            [AllowHtml]
            public string SearchCategoryName { get; set; }

            public int DiscountId { get; set; }

            public int[] SelectedCategoryIds { get; set; }
        }


        public partial class AppliedToManufacturerModel : BaseSiteModel
        {
            public int ManufacturerId { get; set; }

            public string ManufacturerName { get; set; }
        }
        public partial class AddManufacturerToDiscountModel : BaseSiteModel
        {
            [SiteResourceDisplayName("Admin.Catalog.Manufacturers.List.SearchManufacturerName")]
            [AllowHtml]
            public string SearchManufacturerName { get; set; }

            public int DiscountId { get; set; }

            public int[] SelectedManufacturerIds { get; set; }
        }


        public partial class AppliedToProductModel : BaseSiteModel
        {
            public int ProductId { get; set; }

            public string ProductName { get; set; }
        }
        public partial class AddProductToDiscountModel : BaseSiteModel
        {
            public AddProductToDiscountModel()
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

            public int DiscountId { get; set; }

            public int[] SelectedProductIds { get; set; }
        }

        #endregion
    }
}