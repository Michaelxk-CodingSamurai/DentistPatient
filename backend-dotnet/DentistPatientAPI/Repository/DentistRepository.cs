using System.Linq;
using System.Collections.Generic;

using Contracts;
using Entities;
using Entities.Models;
using Entities.ExtendedModels;

namespace Repository
{
    public class DentistRepository : RepositoryBase<Dentist>, IDentistRepository
    {
        public DentistRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Dentist> GetAllDentists()
        {
            return FindAll()
            .OrderBy(d => d.Name);
        }

        public Dentist GetDentistById(int dentistId)
        {
            return FindByCondition(dentist => dentist.Id.Equals(dentistId))
                .DefaultIfEmpty(new Dentist())
                .FirstOrDefault(); 
        }

        public DentistExtended GetDentistWithDetails (int dentistId)
        {
            return new DentistExtended(GetDentistById(dentistId))
            {
                Patients = RepositoryContext.Patients
                    .Where(p => p.DentistId == dentistId),
                Appointments = RepositoryContext.Appointments
                    .Where(a => a.DentistId == dentistId)
            };
        }

    }
}