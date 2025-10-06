using Dental.Domain.Entities;
using Dental.Domain.Exceptions;
using Dental.Domain.ValueObjects;

namespace Dental.Tests.Domain.Entities
{
    [TestClass]
    public class DentistTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NameIsNullOrEmpty_ThrowsBusinessRuleException()
        {
            var email = new Email("hello@gmail.com");
            new Dentist(null!, email);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_EmailIsNull_ThrowsBusinessRuleException()
        {
            new Dentist("Dr. Smith", null!);
        }

        [TestMethod]
        public void Consrtuctor_ValidDentist_NoExceptionThrown()
        {
            var email = new Email("hello@gmail.com");
            new Dentist("Dr. Smith", email);
        }
    }
}