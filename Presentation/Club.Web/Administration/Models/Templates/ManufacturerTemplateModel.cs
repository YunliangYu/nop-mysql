using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Templates;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Templates
{
    [Validator(typeof(ManufacturerTemplateValidator))]
    public partial class ManufacturerTemplateModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.System.Templates.Manufacturer.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.System.Templates.Manufacturer.ViewPath")]
        [AllowHtml]
        public string ViewPath { get; set; }

        [SiteResourceDisplayName("Admin.System.Templates.Manufacturer.DisplayOrder")]
        public int DisplayOrder { get; set; }
    }
}