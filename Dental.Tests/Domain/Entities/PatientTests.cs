using Dental.Domain.Entities;
using Dental.Domain.Exceptions;
using Dental.Domain.ValueObjects;

namespace Dental.Tests.Domain.Entities
{
    [TestClass]
    public class PatientTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_PatientNameIsNullOrEmpty_ThrowsBusinessRuleException()
        {
            var email = new Email("patient@gmail.com");
            new Patient(null!, email);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_EmailIsNullOrEmpty_ThrowsBusinessRuleException()
        {
            new Patient("Prasad", null!);
        }

        [TestMethod]
        public void Constructor_ValidPatient_NoExceptionThrown()
        {
            var email = new Email("patient@gmail.com");
            new Patient("Prasad", email);
        }
    }
}
