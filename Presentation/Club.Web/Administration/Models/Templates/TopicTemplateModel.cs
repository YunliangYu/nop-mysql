using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Templates;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Templates
{
    [Validator(typeof(TopicTemplateValidator))]
    public partial class TopicTemplateModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.System.Templates.Topic.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.System.Templates.Topic.ViewPath")]
        [AllowHtml]
        public string ViewPath { get; set; }

        [SiteResourceDisplayName("Admin.System.Templates.Topic.DisplayOrder")]
        public int DisplayOrder { get; set; }
    }
}