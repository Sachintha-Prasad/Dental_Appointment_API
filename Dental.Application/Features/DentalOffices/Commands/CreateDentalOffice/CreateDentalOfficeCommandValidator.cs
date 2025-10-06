using Dental.Application.Features.DentalOffices.Commands.CreateDentalOffices;
using FluentValidation;

namespace Dental.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommandValidator : AbstractValidator<CreateDentalOfficeCommand>
    {
        public CreateDentalOfficeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The field {PropertyName} is required");
        }
    }
}
