using Entities.Models;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IDentistRepository Dentist { get; }
        IPatientRepository Patient { get; }
        IAppointmentRepository Appointment { get; }
    }
}