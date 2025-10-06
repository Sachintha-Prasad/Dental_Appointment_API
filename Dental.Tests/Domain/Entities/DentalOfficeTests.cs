using Dental.Domain.Entities;
using Dental.Domain.Exceptions;

namespace Dental.Tests.Domain.Entities
{
    [TestClass]
    public class DentalOfficeTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_DentalOfficeNameIsNullOrEmpty_ThrowsBusinessRuleException()
        {
            new DentalOffice(null!);
        }

        [TestMethod]
        public void Constructor_ValidName_NoExceptionThrown()
        {
            new DentalOffice("Happy Smiles");
        }
    }
}
