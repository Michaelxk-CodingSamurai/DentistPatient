using Entities.Models; 



namespace Entities.Extensions
{
    public static class DentistExtensions
    {
        public static void Map(this Dentist dbDentist, Dentist dentist)
        {
            dbDentist.Name = dentist.Name;
            dbDentist.DateOfBirth = dentist.DateOfBirth;
            dbDentist.Address = dentist.Address;
            dbDentist.Email = dentist.Email;
            dbDentist.Phone = dentist.Phone;
            dbDentist.Specialty = dentist.Specialty;
        }
    }
}