using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Forums;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Forums
{
    [Validator(typeof(ForumValidator))]
    public partial class ForumModel : BaseSiteEntityModel
    {
        public ForumModel()
        {
            ForumGroups = new List<ForumGroupModel>();
        }

        [SiteResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.ForumGroupId")]
        public int ForumGroupId { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.Description")]
        [AllowHtml]
        public string Description { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Forums.Forum.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        public List<ForumGroupModel> ForumGroups { get; set; }
    }
}