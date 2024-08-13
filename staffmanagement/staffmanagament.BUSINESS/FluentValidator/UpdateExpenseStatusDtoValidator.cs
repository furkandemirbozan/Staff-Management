using FluentValidation;
using staffmanagament.CORE.DTOs;

namespace staffmanagament.BUSINESS.Validations
{
    public class UpdateExpenseStatusDtoValidator : AbstractValidator<UpdateExpenseStatusDto>
    {
        public UpdateExpenseStatusDtoValidator()
        {
            RuleFor(x => x.RequestStatusId).GreaterThan(0).WithMessage("Request Status Id is required.");
        }
    }
}
