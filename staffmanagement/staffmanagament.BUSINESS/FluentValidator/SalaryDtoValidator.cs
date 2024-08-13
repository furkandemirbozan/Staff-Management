using FluentValidation;
using staffmanagament.CORE.DTOs;

namespace staffmanagament.BUSINESS.Validations
{
    public class SalaryDtoValidator : AbstractValidator<SalaryDto>
    {
        public SalaryDtoValidator()
        {
            RuleFor(x => x.EmployeeId).GreaterThan(0).WithMessage("Employee Id is required.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount should be greater than 0.");
        }
    }
}
