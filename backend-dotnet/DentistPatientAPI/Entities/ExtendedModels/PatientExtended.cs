using System.Collections.Generic;
using Entities.Models;
using System;

namespace Entities.ExtendedModels
{
    public class PatientExtended
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Priority { get; set; }
        public string Notes { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public PatientExtended ()
        {
        }

        public PatientExtended (Patient patient)
        {
            Id = patient.Id; 
            Name = patient.Name;
            DateOfBirth = patient.DateOfBirth;
            Address = patient.Address;
            Email = patient.Email;
            Phone = patient.Phone;
            Priority = patient.Priority;
            Notes = patient.Notes;

        }
    }
}