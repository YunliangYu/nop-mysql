using FluentValidation;
using Club.Admin.Models.News;
using Club.Core.Domain.News;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.News
{
    public partial class NewsTagValidator : BaseSiteValidator<NewsTagModel>
    {
        public NewsTagValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.NewsTags.Fields.Name.Required"));

            SetDatabaseValidationRules<NewsTag>(dbContext);
        }
    }
}