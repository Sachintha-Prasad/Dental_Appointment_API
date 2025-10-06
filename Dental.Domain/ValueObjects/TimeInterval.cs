using Dental.Domain.Exceptions;

namespace Dental.Domain.ValueObjects
{
    public class TimeInterval
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public TimeInterval(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new BusinessRuleException("Start time must be before end time.");
            }

            Start = start;
            End = end;
        }
    }
}
