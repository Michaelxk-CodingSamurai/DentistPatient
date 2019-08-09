using System.Collections.Generic;
using Entities.Models;
using System;

namespace Entities.ExtendedModels
{
    public class DentistExtended  : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }

        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public DentistExtended()
        {
        }

        public DentistExtended (Dentist dentist)
        {
            Id = dentist.Id;
            Name = dentist.Name;
            DateOfBirth = dentist.DateOfBirth;
            Address = dentist.Address;
            Email = dentist.Email;
            Phone = dentist.Phone;
            Specialty = dentist.Specialty;
        }
    }
}