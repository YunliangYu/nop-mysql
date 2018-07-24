using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Models.Common;
using Club.Admin.Validators.Vendors;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Vendors
{
    [Validator(typeof(VendorValidator))]
    public partial class VendorModel : BaseSiteEntityModel, ILocalizedModel<VendorLocalizedModel>
    {
        public VendorModel()
        {
            if (PageSize < 1)
            {
                PageSize = 5;
            }
            Address = new AddressModel();

            Locales = new List<VendorLocalizedModel>();
            AssociatedCustomers = new List<AssociatedCustomerInfo>();
        }

        [SiteResourceDisplayName("Admin.Vendors.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.Description")]
        [AllowHtml]
        public string Description { get; set; }

        [UIHint("Picture")]
        [SiteResourceDisplayName("Admin.Vendors.Fields.Picture")]
        public int PictureId { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.AdminComment")]
        [AllowHtml]
        public string AdminComment { get; set; }

        public AddressModel Address { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.Active")]
        public bool Active { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }
        

        [SiteResourceDisplayName("Admin.Vendors.Fields.MetaKeywords")]
        [AllowHtml]
        public string MetaKeywords { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.MetaDescription")]
        [AllowHtml]
        public string MetaDescription { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.MetaTitle")]
        [AllowHtml]
        public string MetaTitle { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.SeName")]
        [AllowHtml]
        public string SeName { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.PageSize")]
        public int PageSize { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.AllowCustomersToSelectPageSize")]
        public bool AllowCustomersToSelectPageSize { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.PageSizeOptions")]
        public string PageSizeOptions { get; set; }

        public IList<VendorLocalizedModel> Locales { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.AssociatedCustomerEmails")]
        public IList<AssociatedCustomerInfo> AssociatedCustomers { get; set; }



        //vendor notes
        [SiteResourceDisplayName("Admin.Vendors.VendorNotes.Fields.Note")]
        [AllowHtml]
        public string AddVendorNoteMessage { get; set; }




        #region Nested classes

        public class AssociatedCustomerInfo : BaseSiteEntityModel
        {
            public string Email { get; set; }
        }


        public partial class VendorNote : BaseSiteEntityModel
        {
            public int VendorId { get; set; }
            [SiteResourceDisplayName("Admin.Vendors.VendorNotes.Fields.Note")]
            public string Note { get; set; }
            [SiteResourceDisplayName("Admin.Vendors.VendorNotes.Fields.CreatedOn")]
            public DateTime CreatedOn { get; set; }
        }
        #endregion

    }

    public partial class VendorLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.Description")]
        [AllowHtml]
        public string Description { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.MetaKeywords")]
        [AllowHtml]
        public string MetaKeywords { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.MetaDescription")]
        [AllowHtml]
        public string MetaDescription { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.MetaTitle")]
        [AllowHtml]
        public string MetaTitle { get; set; }

        [SiteResourceDisplayName("Admin.Vendors.Fields.SeName")]
        [AllowHtml]
        public string SeName { get; set; }
    }
}