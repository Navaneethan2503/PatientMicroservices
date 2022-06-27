using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.DTOs
{
    public class AppointmentDTO
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        [Required, StringLength(30)]
        public string DepartmentName { get; set; }
        public DateTime DateOfAppointment { get; set; }
    }
}
