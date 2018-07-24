using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Catalog;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Catalog
{
    [Validator(typeof(ManufacturerValidator))]
    public partial class ManufacturerModel : BaseSiteEntityModel, ILocalizedModel<ManufacturerLocalizedModel>
    {
        public ManufacturerModel()
        {
            if (PageSize < 1)
            {
                PageSize = 5;
            }
            Locales = new List<ManufacturerLocalizedModel>();
            AvailableManufacturerTemplates = new List<SelectListItem>();

            AvailableDiscounts = new List<SelectListItem>();
            SelectedDiscountIds = new List<int>();

            SelectedCustomerRoleIds = new List<int>();
            AvailableCustomerRoles = new List<SelectListItem>();

            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Description")]
        [AllowHtml]
        public string Description { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.ManufacturerTemplate")]
        public int ManufacturerTemplateId { get; set; }
        public IList<SelectListItem> AvailableManufacturerTemplates { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.MetaKeywords")]
        [AllowHtml]
        public string MetaKeywords { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.MetaDescription")]
        [AllowHtml]
        public string MetaDescription { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.MetaTitle")]
        [AllowHtml]
        public string MetaTitle { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.SeName")]
        [AllowHtml]
        public string SeName { get; set; }

        [UIHint("Picture")]
        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Picture")]
        public int PictureId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.PageSize")]
        public int PageSize { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.AllowCustomersToSelectPageSize")]
        public bool AllowCustomersToSelectPageSize { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.PageSizeOptions")]
        public string PageSizeOptions { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.PriceRanges")]
        [AllowHtml]
        public string PriceRanges { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Published")]
        public bool Published { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Deleted")]
        public bool Deleted { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }
        
        public IList<ManufacturerLocalizedModel> Locales { get; set; }


        //ACL (customer roles)
        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.AclCustomerRoles")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedCustomerRoleIds { get; set; }
        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

        
        //store mapping
        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.LimitedToStores")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }


        //discounts
        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Discounts")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedDiscountIds { get; set; }
        public IList<SelectListItem> AvailableDiscounts { get; set; }


        #region Nested classes

        public partial class ManufacturerProductModel : BaseSiteEntityModel
        {
            public int ManufacturerId { get; set; }

            public int ProductId { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Products.Fields.Product")]
            public string ProductName { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Products.Fields.IsFeaturedProduct")]
            public bool IsFeaturedProduct { get; set; }

            [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Products.Fields.DisplayOrder")]
            public int DisplayOrder { get; set; }
        }

        public partial class AddManufacturerProductModel : BaseSiteModel
        {
            public AddManufacturerProductModel()
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

            public int ManufacturerId { get; set; }

            public int[] SelectedProductIds { get; set; }
        }

        #endregion
    }

    public partial class ManufacturerLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.Description")]
        [AllowHtml]
        public string Description {get;set;}

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.MetaKeywords")]
        [AllowHtml]
        public string MetaKeywords { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.MetaDescription")]
        [AllowHtml]
        public string MetaDescription { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.MetaTitle")]
        [AllowHtml]
        public string MetaTitle { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Manufacturers.Fields.SeName")]
        [AllowHtml]
        public string SeName { get; set; }
    }
}