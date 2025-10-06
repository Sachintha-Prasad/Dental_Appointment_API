using Dental.Domain.Exceptions;
using Dental.Domain.ValueObjects;

namespace Dental.Tests.Domain.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Construtor_NullEmail_ThrowsBusinessRuleException()
        {
            new Email(null!);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_InvalidEmail_ThrowsBusinessRuleException()
        {
            new Email("invalidemail.com");
        }

        [TestMethod]
        public void Constructor_ValidEmail_NoExceptionThrown()
        {
            var email = new Email("valid@gmail.com");
        }
    }
}
