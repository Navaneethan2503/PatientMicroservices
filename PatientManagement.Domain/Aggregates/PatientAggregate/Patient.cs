using PatientManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatientManagement.Domain.Aggregates.PatientAggregate
{
    public class Patient : EntityBase, IAggregateRoot
    {
        public virtual string FirstName { get; private set; }
        public virtual string LastName { get; private set; }
        public virtual string Occupation { get; private set; }
        public virtual string Gender { get; private set; }
        public virtual int Age { get; private set; }
        public virtual int PhoneNumber { get; private set; }
        public virtual string Address { get; private set; }
        public virtual DateTime DateOfBirth { get; private set; }
        public virtual string EmailId { get; private set; }
        public virtual string UserName { get; private set; }
        public virtual List<Appointment> appointments { get; set; } = new List<Appointment>();

        public Patient(string firstName, string lastName , string  occupation , string gender , int age , int phoneNumber , string address , DateTime dateOfBirth , string email , string UserName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Occupation = occupation;
            this.Gender = gender;
            this.Age = age;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
            this.EmailId = email;
            this.UserName = UserName;
        }

        private Patient() { }
       
        public void AddAppointment(Appointment appointment)
        {
            this.appointments.Add(appointment);
        }

        public void RemoveAppointment(int appointmentId)
        {
            var appointment = appointments.First(m => m.Id == appointmentId);
            this.appointments.Remove(appointment);
        }
    }
}
