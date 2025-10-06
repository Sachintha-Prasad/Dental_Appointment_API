using Dental.Domain.Entities;
using Dental.Domain.Enums;
using Dental.Domain.Exceptions;
using Dental.Domain.ValueObjects;

namespace Dental.Tests.Domain.Entities
{
    [TestClass]
    public class AppointmentTests
    {
        private Guid _patientId = Guid.NewGuid();
        private Guid _dentistId = Guid.NewGuid();
        private Guid _dentalOfficeId = Guid.NewGuid();
        private TimeInterval _timeInterval = new TimeInterval(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

        [TestMethod]
        public void Constructor_ValidAppointment_StatusScheduled_NoExceptionThrown()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);

            Assert.AreEqual(_patientId, appointment.PatientId);
            Assert.AreEqual(_dentistId, appointment.DentisId);
            Assert.AreEqual(_dentalOfficeId, appointment.DentalOfficeId);
            Assert.AreEqual(_timeInterval, appointment.TimeInterval);
            Assert.AreEqual(AppointmentStatus.Scheduled, appointment.Status);
            Assert.AreNotEqual(Guid.Empty, appointment.Id);
        }

        [TestMethod]
        public void Constructor_CancellingAppointment_ChangeStatusToCancelled_NoExceptionThrown()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appointment.Cancel();

            Assert.AreEqual(AppointmentStatus.Cancelled, appointment.Status);
        }

        [TestMethod]
        public void Constructor_CompletingAppointment_ChangeStatusToCompleted_NoExceptionThrown()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appointment.Complete();

            Assert.AreEqual(AppointmentStatus.Completed, appointment.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_StartTimeInThePast_ThrowBusinessRuleException()
        {
            var interval = new TimeInterval(DateTime.UtcNow.AddHours(-1), DateTime.UtcNow);

            new Appointment(_patientId, _dentistId, _dentalOfficeId, interval);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Cancel_CancellingAppointment_ThrowBusinessRuleException()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appointment.Cancel();
            appointment.Cancel();
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Complete_CancellingAppointment_NotScheduledAppointment_ThrowsBusinessRuleException()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appointment.Cancel();
            appointment.Complete();
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Complete_CompletingAppointment_ThrowBusinessRulesException()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appointment.Complete();
            appointment.Complete();
        }
    }
}
