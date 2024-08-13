using FluentValidation;
using staffmanagament.CORE.DTOs;

namespace staffmanagament.BUSINESS.Validations
{
    public class CalendarEventDtoValidator : AbstractValidator<CalendarEventDto>
    {
        public CalendarEventDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(x => x.Start).LessThanOrEqualTo(x => x.End).WithMessage("Start date must be before End date.");
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required.");
        }
    }
}
