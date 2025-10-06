using Dental.Domain.Exceptions;
using Dental.Domain.ValueObjects;

namespace Dental.Tests.Domain.ValueObjects
{
    [TestClass]
    public class TimeIntervalTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_EndTimeBeforeStartTime_ThrowsBusinessRuleException()
        {
            new TimeInterval(DateTime.UtcNow, DateTime.UtcNow.AddDays(-1));
        }

        [TestMethod]
        public void Constructor_ValidTimeInterval_NoExceptionThrown()
        {
            new TimeInterval(DateTime.UtcNow, DateTime.UtcNow.AddHours(1));
        }
    }
}
