using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using PatientManagement.Domain;
using PatientManagement.Domain.Aggregates;
using PatientManagement.Domain.Aggregates.PatientAggregate;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Domain.Tests
{
    [TestFixture]
    public class AppointmentEntityShould
    {
        [Test]
        public void Create_NewAppointment_VieConstructor()
        {
            int patientId = 1;
            int doctorId = 1;
            string departmentName = "Orthology";
            DateTime dateTime = DateTime.Now ;
            var appointment = new Appointment(patientId, doctorId, departmentName, dateTime);
            Assert.That(appointment, Is.Not.Null);
            Assert.That(appointment, Is.InstanceOf<Appointment>());
            Assert.That(appointment.PatientId, Is.EqualTo(patientId));
            Assert.That(appointment.DoctorId, Is.EqualTo(doctorId));
            Assert.That(appointment.DepartmentName, Is.EqualTo(departmentName));
            Assert.That(appointment.DateOfAppointment, Is.EqualTo(dateTime));
        }

        [Test]
        public void Update_ChangeAppointment_ReturnUpdateNewDate()
        {
            int patientId = 1;
            int doctorId = 1;
            string departmentName = "Orthology";
            DateTime dateTime = new DateTime(2022, 01, 1);
            var appointment = new Appointment(patientId, doctorId, departmentName, dateTime);
            appointment.ChangeAppointment(new DateTime(2022,01,25));
            Assert.That(appointment.DateOfAppointment, Is.EqualTo(new DateTime(2022, 01, 25)));
        }
    }

   
}
