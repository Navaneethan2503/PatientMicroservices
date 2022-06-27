using PatientManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientManagement.Domain.Aggregates.PatientAggregate
{
    public class Appointment : EntityBase,IAggregateRoot
    {
        public virtual int PatientId { get; private set; }
        public virtual int DoctorId { get; private set; }
        public virtual string DepartmentName { get; private set; }
        public virtual DateTime DateOfAppointment { get; set; }

        public Appointment(int patientId, int doctorId, string departmentName, DateTime dateOfAppointment)
        {
            this.PatientId = patientId;
            this.DoctorId = doctorId;
            this.DepartmentName = departmentName;
            this.DateOfAppointment = dateOfAppointment;
        }

        protected Appointment() { }

        public void ChangeAppointment(DateTime dateTime)
        {
            if (this.DateOfAppointment == dateTime)
                return;
            this.DateOfAppointment = dateTime;
        }

    }
}
