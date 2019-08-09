using Entities.Models; 

namespace Entities.Extensions
{
    public static class PatientExtensions
    {
        public static void Map(this Patient dbPatient, Patient patient)
        {
            dbPatient.Name = patient.Name;
            dbPatient.DateOfBirth = patient.DateOfBirth;
            dbPatient.Address = patient.Address;
            dbPatient.Email = patient.Email;
            dbPatient.Phone = patient.Phone;
            dbPatient.Priority = patient.Priority;
            dbPatient.Notes = patient.Notes;
        }
    }
}