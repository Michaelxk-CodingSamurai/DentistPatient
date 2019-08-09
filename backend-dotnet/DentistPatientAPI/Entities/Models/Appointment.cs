using System; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("appointment")]

    public class Appointment
    {
        [Column("AppointmentId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Time is required")]
        public TimeSpan Time { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100, ErrorMessage = "Location cannot be longer then 100 characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Reason is required")]
        [StringLength(300, ErrorMessage = "Reason cannot be longer then 100 characters")]
        public string Reason { get; set; }
        public int DentistId { get; set; }
        public int PatientId { get; set; }
    }
}