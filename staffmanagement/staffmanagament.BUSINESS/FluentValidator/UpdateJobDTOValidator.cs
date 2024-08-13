using FluentValidation;
using staffmanagament.CORE.DTOs;

namespace staffmanagament.BUSINESS.Validations
{
    public class UpdateJobDTOValidator : AbstractValidator<UpdateJobDTO>
    {
        public UpdateJobDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Job Title is required.");
        }
    }
}
