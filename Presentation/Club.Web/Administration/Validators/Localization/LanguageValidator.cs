using System.Globalization;
using FluentValidation;
using Club.Admin.Models.Localization;
using Club.Core.Domain.Localization;
using Club.Data;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Localization
{
    public partial class LanguageValidator : BaseSiteValidator<LanguageModel>
    {
        public LanguageValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Fields.Name.Required"));
            RuleFor(x => x.LanguageCulture)
                .Must(x =>
                          {
                              try
                              {
                                  //let's try to create a CultureInfo object
                                  //if "DisplayLocale" is wrong, then exception will be thrown
                                  var culture = new CultureInfo(x);
                                  return true;
                              }
                              catch
                              {
                                  return false;
                              }
                          })
                .WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Fields.LanguageCulture.Validation"));

            RuleFor(x => x.UniqueSeoCode).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Fields.UniqueSeoCode.Required"));
            RuleFor(x => x.UniqueSeoCode).Length(2).WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Fields.UniqueSeoCode.Length"));

            SetDatabaseValidationRules<Language>(dbContext, "UniqueSeoCode");

        }
    }
}