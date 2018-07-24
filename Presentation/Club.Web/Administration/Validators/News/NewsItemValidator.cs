using FluentValidation;
using Club.Admin.Models.News;
using Club.Core.Domain.News;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.News
{
    public partial class NewsItemValidator : BaseSiteValidator<NewsItemModel>
    {
        public NewsItemValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Fields.Title.Required"));

            RuleFor(x => x.Short).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Fields.Short.Required"));

            RuleFor(x => x.Full).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.News.NewsItems.Fields.Full.Required"));

            SetDatabaseValidationRules<NewsItem>(dbContext);
        }
    }
}