using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Orders;
using Club.Core.Domain.Catalog;
using Club.Web.Framework;
using Club.Web.Framework.Localization;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Orders
{
    [Validator(typeof(CheckoutAttributeValidator))]
    public partial class CheckoutAttributeModel : BaseSiteEntityModel, ILocalizedModel<CheckoutAttributeLocalizedModel>
    {
        public CheckoutAttributeModel()
        {
            Locales = new List<CheckoutAttributeLocalizedModel>();
            AvailableTaxCategories = new List<SelectListItem>();

            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
        }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.TextPrompt")]
        [AllowHtml]
        public string TextPrompt { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.IsRequired")]
        public bool IsRequired { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.ShippableProductRequired")]
        public bool ShippableProductRequired { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.IsTaxExempt")]
        public bool IsTaxExempt { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.TaxCategory")]
        public int TaxCategoryId { get; set; }
        public IList<SelectListItem> AvailableTaxCategories { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.AttributeControlType")]
        public int AttributeControlTypeId { get; set; }
        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.AttributeControlType")]
        [AllowHtml]
        public string AttributeControlTypeName { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }


        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.MinLength")]
        [UIHint("Int32Nullable")]
        public int? ValidationMinLength { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.MaxLength")]
        [UIHint("Int32Nullable")]
        public int? ValidationMaxLength { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.FileAllowedExtensions")]
        public string ValidationFileAllowedExtensions { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.FileMaximumSize")]
        [UIHint("Int32Nullable")]
        public int? ValidationFileMaximumSize { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.DefaultValue")]
        public string DefaultValue { get; set; }

        public IList<CheckoutAttributeLocalizedModel> Locales { get; set; }

        //condition
        public bool ConditionAllowed { get; set; }
        public ConditionModel ConditionModel { get; set; }

        //store mapping
        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.LimitedToStores")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

    }

    public partial class ConditionModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Condition.EnableCondition")]
        public bool EnableCondition { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Condition.Attributes")]
        public int SelectedAttributeId { get; set; }

        public IList<AttributeConditionModel> ConditionAttributes { get; set; }
    }

    public partial class AttributeConditionModel : BaseSiteEntityModel
    {
        public string Name { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public IList<SelectListItem> Values { get; set; }

        public string SelectedValueId { get; set; }
    }

    public partial class CheckoutAttributeLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Fields.TextPrompt")]
        [AllowHtml]
        public string TextPrompt { get; set; }

    }
}