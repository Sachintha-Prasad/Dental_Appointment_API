using Dental.Domain.Enums;
using Dental.Domain.Exceptions;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DentisId { get; private set; }
        public Guid DentalOfficeId { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public TimeInterval TimeInterval { get; set; }
        public Patient Patient { get; private set; } = null!;
        public Dentist Dentist { get; private set; } = null!;
        public DentalOffice DentalOffice { get; private set; } = null!;

        public Appointment(Guid patientId, Guid dentistId, Guid dentalOfficeId, TimeInterval timeInterval)
        {
            if (timeInterval.Start < DateTime.UtcNow)
            {
                throw new BusinessRuleException("Start time must be in the future.");
            }

            PatientId = patientId;
            DentisId = dentistId;
            DentalOfficeId = dentalOfficeId;
            TimeInterval = timeInterval;
            Status = AppointmentStatus.Scheduled;
            Id = Guid.CreateVersion7();
        }

        public void Cancel()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled appointments can be cancelled.");
            }

            Status = AppointmentStatus.Cancelled;
        }

        public void Complete()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled appointments can be completed.");
            }
            Status = AppointmentStatus.Completed;
        }
    }
}
