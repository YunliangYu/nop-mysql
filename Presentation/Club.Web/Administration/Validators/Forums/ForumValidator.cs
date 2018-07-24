using FluentValidation;
using Club.Admin.Models.Forums;
using Club.Core.Domain.Forums;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Forums
{
    public partial class ForumValidator : BaseSiteValidator<ForumModel>
    {
        public ForumValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.Forum.Fields.Name.Required"));
            RuleFor(x => x.ForumGroupId).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.Forum.Fields.ForumGroupId.Required"));

            SetDatabaseValidationRules<Forum>(dbContext);
        }
    }
}