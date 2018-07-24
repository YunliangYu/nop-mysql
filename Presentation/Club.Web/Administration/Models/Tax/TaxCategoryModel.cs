using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Tax;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Tax
{
    [Validator(typeof(TaxCategoryValidator))]
    public partial class TaxCategoryModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Configuration.Tax.Categories.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Tax.Categories.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }
    }
}