using System.Collections.Generic;
using Entities.Models;
using Entities.ExtendedModels;


namespace Contracts
{
public interface IPatientRepository : IRepositoryBase<Patient>
    {
        IEnumerable<Patient> PatientsByDentist(int dentistId); 
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int patientId); 
        PatientExtended GetPatientWithDetails(int patientId); 
        void CreatePatient (Patient patient); 
        void UpdatePatient(Patient dbatient, Patient patient); 
        void DeletePatient(Patient patient); 

    }
}