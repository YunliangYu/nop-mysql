using FluentValidation;
using Club.Admin.Models.Orders;
using Club.Services.Localization;
using Club.Web.Framework.Validators;

namespace Club.Admin.Validators.Orders
{
    public partial class ReturnRequestValidator : BaseSiteValidator<ReturnRequestModel>
    {
        public ReturnRequestValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.ReasonForReturn).NotEmpty().WithMessage(localizationService.GetResource("Admin.ReturnRequests.Fields.ReasonForReturn.Required"));
            RuleFor(x => x.RequestedAction).NotEmpty().WithMessage(localizationService.GetResource("Admin.ReturnRequests.Fields.RequestedAction.Required"));
        }
    }
}