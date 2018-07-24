using System;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Forums;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Forums
{
    [Validator(typeof(ForumGroupValidator))]
    public partial class ForumGroupModel : BaseSiteEntityModel
    {
        [SiteResourceDisplayName("Admin.ContentManagement.Forums.ForumGroup.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Forums.ForumGroup.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Forums.ForumGroup.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }
    }
}