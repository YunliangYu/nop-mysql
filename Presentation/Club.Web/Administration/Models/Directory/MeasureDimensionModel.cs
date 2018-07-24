using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Directory;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Directory
{
    [Validator(typeof(MeasureDimensionValidator))]
    public partial class MeasureDimensionModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.SystemKeyword")]
        [AllowHtml]
        public string SystemKeyword { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.Ratio")]
        public decimal Ratio { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.IsPrimaryDimension")]
        public bool IsPrimaryDimension { get; set; }
    }
}