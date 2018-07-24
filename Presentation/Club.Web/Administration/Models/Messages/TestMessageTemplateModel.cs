using System.Collections.Generic;
using FluentValidation.Attributes;
using Club.Admin.Validators.Messages;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Messages
{
    [Validator(typeof(TestMessageTemplateValidator))]
    public partial class TestMessageTemplateModel : BaseSiteEntityModel
    {
        public TestMessageTemplateModel()
        {
            Tokens = new List<string>();
        }

        public int LanguageId { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.MessageTemplates.Test.Tokens")]
        public List<string> Tokens { get; set; }

        [SiteResourceDisplayName("Admin.ContentManagement.MessageTemplates.Test.SendTo")]
        public string SendTo { get; set; }
    }
}