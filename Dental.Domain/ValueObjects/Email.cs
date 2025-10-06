using Dental.Domain.Exceptions;

namespace Dental.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; } = null!;

        public Email(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new BusinessRuleException($"The {nameof(email)} is required");
            }

            if (!email.Contains("@"))
            {
                throw new BusinessRuleException($"The {nameof(email)} is invalid");
            }

            Value = email;
        }
    }
}
