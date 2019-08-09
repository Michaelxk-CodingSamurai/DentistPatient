using System.Collections.Generic;
using Entities.Models;
using Entities.ExtendedModels;


namespace Contracts
{
public interface IDentistRepository 
    {
        IEnumerable<Dentist> GetAllDentists();
        Dentist GetDentistById(int dentistId);
        DentistExtended GetDentistWithDetails(int dentistId); 
    }
}