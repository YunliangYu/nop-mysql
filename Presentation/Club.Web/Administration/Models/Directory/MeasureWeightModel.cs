using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Directory;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Directory
{
    [Validator(typeof(MeasureWeightValidator))]
    public partial class MeasureWeightModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.SystemKeyword")]
        [AllowHtml]
        public string SystemKeyword { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.Ratio")]
        public decimal Ratio { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.IsPrimaryWeight")]
        public bool IsPrimaryWeight { get; set; }
    }
}