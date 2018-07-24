using FluentValidation;
using Club.Admin.Models.Tasks;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Tasks
{
    public partial class ScheduleTaskValidator : BaseSiteValidator<ScheduleTaskModel>
    {
        public ScheduleTaskValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.ScheduleTasks.Name.Required"));
            RuleFor(x => x.Seconds).GreaterThan(0).WithMessage(localizationService.GetResource("Admin.System.ScheduleTasks.Seconds.Positive"));
        }
    }
}