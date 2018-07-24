using System.Collections.Generic;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Web.Models.Catalog
{
    public partial class SearchModel : BaseSiteModel
    {
        public SearchModel()
        {
            this.PagingFilteringContext = new CatalogPagingFilteringModel();
            this.Products = new List<ProductOverviewModel>();

            this.AvailableCategories = new List<SelectListItem>();
            this.AvailableManufacturers = new List<SelectListItem>();
            this.AvailableVendors = new List<SelectListItem>();
        }

        public string Warning { get; set; }

        public bool NoResults { get; set; }

        /// <summary>
        /// Query string
        /// </summary>
        [SiteResourceDisplayName("Search.SearchTerm")]
        [AllowHtml]
        public string q { get; set; }
        /// <summary>
        /// Category ID
        /// </summary>
        [SiteResourceDisplayName("Search.Category")]
        public int cid { get; set; }
        [SiteResourceDisplayName("Search.IncludeSubCategories")]
        public bool isc { get; set; }
        /// <summary>
        /// Manufacturer ID
        /// </summary>
        [SiteResourceDisplayName("Search.Manufacturer")]
        public int mid { get; set; }
        /// <summary>
        /// Vendor ID
        /// </summary>
        [SiteResourceDisplayName("Search.Vendor")]
        public int vid { get; set; }
        /// <summary>
        /// Price - From 
        /// </summary>
        [AllowHtml]
        public string pf { get; set; }
        /// <summary>
        /// Price - To
        /// </summary>
        [AllowHtml]
        public string pt { get; set; }
        /// <summary>
        /// A value indicating whether to search in descriptions
        /// </summary>
        [SiteResourceDisplayName("Search.SearchInDescriptions")]
        public bool sid { get; set; }
        /// <summary>
        /// A value indicating whether "advanced search" is enabled
        /// </summary>
        [SiteResourceDisplayName("Search.AdvancedSearch")]
        public bool adv { get; set; }
        /// <summary>
        /// A value indicating whether "allow search by vendor" is enabled
        /// </summary>
        public bool asv { get; set; }
        public IList<SelectListItem> AvailableCategories { get; set; }
        public IList<SelectListItem> AvailableManufacturers { get; set; }
        public IList<SelectListItem> AvailableVendors { get; set; }


        public CatalogPagingFilteringModel PagingFilteringContext { get; set; }
        public IList<ProductOverviewModel> Products { get; set; }

        #region Nested classes

        public class CategoryModel : BaseSiteEntityModel
        {
            public string Breadcrumb { get; set; }
        }

        #endregion
    }
}