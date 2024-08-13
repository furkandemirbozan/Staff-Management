using FluentValidation;
using staffmanagament.CORE.DTOs;

namespace staffmanagament.BUSINESS.Validations
{
    public class UpdateLeaveStatusDTOValidator : AbstractValidator<UpdateLeaveStatusDTO>
    {
        public UpdateLeaveStatusDTOValidator()
        {
            RuleFor(x => x.RequestStatusId).GreaterThan(0).WithMessage("Request Status Id is required.");
        }
    }
}
