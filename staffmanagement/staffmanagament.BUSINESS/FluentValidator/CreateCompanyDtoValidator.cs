using FluentValidation;
using staffmanagament.CORE.DTOs;

namespace staffmanagament.BUSINESS.Validations
{
    public class CreateCompanyDtoValidator : AbstractValidator<CreateCompanyDto>
    {
        public CreateCompanyDtoValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company Name is required.");
            RuleFor(x => x.CompanyEmail).EmailAddress().WithMessage("Valid email is required.");
            RuleFor(x => x.CompanyPhoneNumber).NotEmpty().WithMessage("Company Phone Number is required.");
            RuleFor(x => x.createAddressDto).SetValidator(new CreateAddressDtoValidator());
        }
    }
}
