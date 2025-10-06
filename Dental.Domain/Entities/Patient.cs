using Dental.Domain.Exceptions;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;

        public Patient(string name, Email email)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new BusinessRuleException($"The {nameof(name)} is required");
            }

            if (email is null)
            {
                throw new BusinessRuleException($"The {nameof(email)} is required");
            }

            Name = name;
            Email = email;
            Id = Guid.CreateVersion7();
        }
    }
}
