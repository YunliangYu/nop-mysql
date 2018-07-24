using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Polls;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Polls
{
    [Validator(typeof(PollValidator))]
    public partial class PollModel : BaseSiteEntityModel
    {
        public PollModel()
        {
            this.AvailableLanguages = new List<SelectListItem>();
        }
        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Fields.Language")]
        public int LanguageId { get; set; }
        public IList<SelectListItem> AvailableLanguages { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Fields.Language")]
        [AllowHtml]
        public string LanguageName { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Fields.SystemKeyword")]
        [AllowHtml]
        public string SystemKeyword { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Fields.Published")]
        public bool Published { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Fields.ShowOnHomePage")]
        public bool ShowOnHomePage { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Fields.AllowGuestsToVote")]
        public bool AllowGuestsToVote { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Fields.StartDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? StartDate { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.Polls.Fields.EndDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? EndDate { get; set; }

    }
}