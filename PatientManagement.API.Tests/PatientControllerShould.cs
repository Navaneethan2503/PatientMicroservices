using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using PatientManagement.API.Controllers;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Aggregates;
using PatientManagement.Domain.Interfaces;
using Moq;
using PatientManagement.API.DTOs;
using PatientManagement.Domain.Aggregates.PatientAggregate;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace PatientManagement.API.Tests
{
    [TestFixture]
    public class PatientControllerShould
    {
        [Test]
        public async Task AddAppointment_ReturnStatusCreated201()
        {
            var appointment = new AppointmentDTO()
            {
                PatientId = 1,
                DoctorId = 2,
                DepartmentName = "Orthology",
                DateOfAppointment = DateTime.Now
            };

            var rep = new Mock<IRepository<Appointment>>();
            rep.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var reObj = rep.Object;

            var controller = new PatientController(reObj);

            var result = (IStatusCodeActionResult)await controller.AddAppointment(appointment).ConfigureAwait(false);
            Assert.That(result.StatusCode,Is.EqualTo(201));
            Assert.IsNotNull(result);
           
        }

        [Test]
        public void GetAppointment_Return200StatusCode()
        {
            int patientId = 1;
            int doctorId = 1;
            string DepartName = "Orthology";
            DateTime dateTime = DateTime.Now;             
            var repo = new Mock<IRepository<Appointment>>();
            repo.Setup(m => m.Get()).Returns(() =>
            {
                Appointment appointment = new Appointment(patientId, doctorId, DepartName, dateTime);
                return new List<Appointment>() { appointment };
            });
            var repoObj = repo.Object;
            var controller = new PatientController(repoObj);
            OkObjectResult result = (OkObjectResult)controller.GetAppointment();            
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(result);
        }

        [Test]
       
        public async Task UpdateAppointment_Return200StatusCode()
        {
            var appointment = new AppointmentDTO()
            {
                Id= 1,
                PatientId = 1,
                DoctorId = 2,
                DepartmentName = "Orthology",
                DateOfAppointment = DateTime.Now
            };
            var rep = new Mock<IRepository<Appointment>>();
            rep.Setup(m => m.SaveAsync()).ReturnsAsync(1);           
            var reObj = rep.Object;
            var controller = new PatientController(reObj);
            var result = (IStatusCodeActionResult)await controller.UpdateAppointmentDate(1, new DateTime(2022 - 06 - 25)).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(result);

        }

        [Test]
        [TestCase(2)]
        public async Task UpdateAppointment_Return404StatusCode(int Id)
        {
            var appointment = new AppointmentDTO()
            {
                PatientId = 1,
                DoctorId = 2,
                DepartmentName = "Orthology",
                DateOfAppointment = DateTime.Now
            };
            var rep = new Mock<IRepository<Appointment>>();
            rep.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var reObj = rep.Object;
            var controller = new PatientController(reObj);
            var result = (IStatusCodeActionResult)await controller.UpdateAppointmentDate(Id, new DateTime(2022 - 06 - 25)).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(404));
            Assert.IsNotNull(result);

        }

        [Test]
        [TestCase(1)]
        public async Task DeleteAppointment_Return200StatusCode()
        {
            var appointment = new AppointmentDTO()
            {
                Id = 1,
                PatientId = 1,
                DoctorId = 2,
                DepartmentName = "Orthology",
                DateOfAppointment = DateTime.Now
            };
            var rep = new Mock<IRepository<Appointment>>();
            rep.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var reObj = rep.Object;
            var controller = new PatientController(reObj);
            var result = (IStatusCodeActionResult)await controller.DeleteAppointment(1).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(result);

        }

        [Test]
        [TestCase(2)]
        public async Task DeleteAppointment_Return404StatusCode(int Id)
        {
            var appointment = new AppointmentDTO()
            {
                Id = 1,
                PatientId = 1,
                DoctorId = 2,
                DepartmentName = "Orthology",
                DateOfAppointment = DateTime.Now
            };
            var rep = new Mock<IRepository<Appointment>>();
            rep.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var reObj = rep.Object;
            var controller = new PatientController(reObj);
            var result = (IStatusCodeActionResult)await controller.DeleteAppointment(Id).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(404));
            Assert.IsNotNull(result);

        }


    }
        
}
