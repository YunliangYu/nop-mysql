using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Settings
{
    public partial class VendorSettingsModel : BaseSiteModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }


        [SiteResourceDisplayName("Admin.Configuration.Settings.Vendor.VendorsBlockItemsToDisplay")]
        public int VendorsBlockItemsToDisplay { get; set; }
        public bool VendorsBlockItemsToDisplay_OverrideForStore { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Vendor.ShowVendorOnProductDetailsPage")]
        public bool ShowVendorOnProductDetailsPage { get; set; }
        public bool ShowVendorOnProductDetailsPage_OverrideForStore { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Vendor.AllowCustomersToContactVendors")]
        public bool AllowCustomersToContactVendors { get; set; }
        public bool AllowCustomersToContactVendors_OverrideForStore { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Vendor.AllowCustomersToApplyForVendorAccount")]
        public bool AllowCustomersToApplyForVendorAccount { get; set; }
        public bool AllowCustomersToApplyForVendorAccount_OverrideForStore { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Vendor.AllowSearchByVendor")]
        public bool AllowSearchByVendor { get; set; }
        public bool AllowSearchByVendor_OverrideForStore { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Vendor.AllowVendorsToEditInfo")]
        public bool AllowVendorsToEditInfo { get; set; }
        public bool AllowVendorsToEditInfo_OverrideForStore { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Vendor.NotifyStoreOwnerAboutVendorInformationChange")]
        public bool NotifyStoreOwnerAboutVendorInformationChange { get; set; }
        public bool NotifyStoreOwnerAboutVendorInformationChange_OverrideForStore { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Vendor.MaximumProductNumber")]
        public int MaximumProductNumber { get; set; }
        public bool MaximumProductNumber_OverrideForStore { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Settings.Vendor.AllowVendorsToImportProducts")]
        public bool AllowVendorsToImportProducts { get; set; }
        public bool AllowVendorsToImportProducts_OverrideForStore { get; set; }
    }
}