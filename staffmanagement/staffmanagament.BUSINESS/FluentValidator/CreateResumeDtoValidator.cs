using FluentValidation;
using staffmanagament.CORE.DTOs;

namespace staffmanagament.BUSINESS.Validations
{
    public class CreateResumeDtoValidator : AbstractValidator<CreateResumeDto>
    {
        public CreateResumeDtoValidator()
        {
            RuleFor(x => x.Path).NotEmpty().WithMessage("Path is required.");
            RuleFor(x => x.CompanyId).GreaterThan(0).When(x => x.CompanyId.HasValue).WithMessage("Company Id should be greater than 0.");
        }
    }
}
