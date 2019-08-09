using System.Collections.Generic;
using Entities.Models;
using Entities.ExtendedModels;


namespace Contracts
{
public interface IPatientRepository : IRepositoryBase<Patient>
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int patientId); 
        PatientExtended GetPatientWithDetails(int patientId); 

    }
}