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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<AppointmentDTO>))]
        public IActionResult GetAppointment()
        {
            var appointments = appointmentRepository.Get();
            var dtos = from appointment in appointments
                       select new AppointmentDTO { 
                           Id = appointment.Id,
                           PatientId = appointment.PatientId,
                           DoctorId = appointment.DoctorId,
                           DepartmentName = appointment.DepartmentName,
                           DateOfAppointment = appointment.DateOfAppointment
                       };
            return Ok(dtos);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateAppointmentDate(int Id, [FromBody] DateTime dateTime)
        {
            var appointment = appointmentRepository.GetById(Id);
            if (appointment == null)
                return NotFound();
            appointment.ChangeAppointment(dateTime);
            appointmentRepository.Update(appointment);
            await appointmentRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteAppointment(int Id)
        {
            var appointment = appointmentRepository.GetById(Id);
            if (appointment == null)
                return NotFound();
            appointmentRepository.Remove(appointment);
            await appointmentRepository.SaveAsync();
            return Ok();
        }
    }
}
