using FluentValidation;
using Club.Admin.Models.Forums;
using Club.Core.Domain.Forums;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Forums
{
    public partial class ForumGroupValidator : BaseSiteValidator<ForumGroupModel>
    {
        public ForumGroupValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.ForumGroup.Fields.Name.Required"));

            SetDatabaseValidationRules<ForumGroup>(dbContext);
        }
    }
}