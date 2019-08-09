using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class AppointmentRepository: RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
            {
            }
    }
}