using FluentValidation;
using Club.Admin.Models.News;
using Club.Core.Domain.News;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.News
{
    public partial class NewsProgramValidator : BaseSiteValidator<NewsProgramModel>
    {
        public NewsProgramValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.NewsProgram.Fields.Name.Required"));

            SetDatabaseValidationRules<NewsTag>(dbContext);
        }
    }
}