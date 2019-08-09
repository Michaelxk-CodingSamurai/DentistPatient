using System.Linq;
using System.Collections.Generic;

using Contracts;
using Entities;
using Entities.Models;
using Entities.ExtendedModels;

namespace Repository
{
    public class PatientRepository: RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
            {
            }
        public IEnumerable<Patient> GetAllPatients()
        {
            return FindAll()
                .OrderBy(p => p.Name);
        }

        public Patient GetPatientById(int patientId)
        {
            return FindByCondition(patient => patient.Id.Equals(patientId))
                .FirstOrDefault();
        }

        public PatientExtended GetPatientWithDetails(int patientId)
        {
            return new PatientExtended(GetPatientById(patientId))
            {
                Appointments = RepositoryContext.Appointments
                    .Where(a => a.PatientId == patientId)
            };
        }
    }
}