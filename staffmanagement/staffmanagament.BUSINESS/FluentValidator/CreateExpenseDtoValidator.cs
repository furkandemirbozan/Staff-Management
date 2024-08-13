using FluentValidation;
using staffmanagament.CORE.DTOs;

namespace staffmanagament.BUSINESS.Validations
{
    public class CreateExpenseDtoValidator : AbstractValidator<CreateExpenseDto>
    {
        public CreateExpenseDtoValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount should be greater than 0.");
            RuleFor(x => x.ExpenseDate).LessThanOrEqualTo(DateTime.Today).WithMessage("Expense Date cannot be in the future.");
        }
    }
}
