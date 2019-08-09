using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IDentistRepository _dentist;
        private IPatientRepository _patient;
        private IAppointmentRepository _appointment;

        public IDentistRepository Dentist
        {
            get
            {
                if (_dentist == null)
                {
                    _dentist = new DentistRepository(_repoContext);
                }
                return _dentist;
            }
        }

        public IPatientRepository Patient
        {
            get
            {
                if (_patient == null)
                {
                    _patient = new PatientRepository(_repoContext);
                }
                return _patient;
            }
        }

        public IAppointmentRepository Appointment
        {
            get
            {
                if (_appointment == null)
                {
                    _appointment = new AppointmentRepository(_repoContext);
                }
                return _appointment;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}