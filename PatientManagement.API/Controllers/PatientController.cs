using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.API.DTOs;
using PatientManagement.Domain.Aggregates.PatientAggregate;
using PatientManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IRepository<Appointment> appointmentRepository;
        public PatientController(IRepository<Appointment> appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddAppointment(AppointmentDTO appointmentDTO)
        {
            var appointment = new Appointment(appointmentDTO.PatientId, appointmentDTO.DoctorId,appointmentDTO.DepartmentName,appointmentDTO.DateOfAppointment);
            appointmentRepository.Add(appointment);
            await appointmentRepository.SaveAsync();
            return StatusCode(201, appointment);
        }

    }
}
