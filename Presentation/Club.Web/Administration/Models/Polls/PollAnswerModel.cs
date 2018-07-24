using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Polls;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Polls
{
    [Validator(typeof(PollAnswerValidator))]
    public partial class PollAnswerModel : BaseSiteEntityModel
    {
        public int PollId { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Answers.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Answers.Fields.NumberOfVotes")]
        public int NumberOfVotes { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Answers.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

    }
}