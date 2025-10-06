using FluentValidation.Results;

namespace Dental.Application.Exceptions
{
    public class CustomValidationExcepton : Exception
    {
        public List<string> ValidationErrors { get; set; } = [];

        public CustomValidationExcepton(ValidationResult validationResult)
        {
            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }

    }
}
