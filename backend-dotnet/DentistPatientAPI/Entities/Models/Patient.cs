using System; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
 [Table("patient")]
    public class Patient : IEntity
    {
        [Key]
        [Column("PatientId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be longer then 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(45, ErrorMessage = "Email cannot be longer then 45 characters")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Phone is required")]
        [StringLength(25, ErrorMessage = "Phone cannot be longer then 225 characters")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        [StringLength(45, ErrorMessage = "Priority cannot be longer then 45 characters")]
        public string Priority { get; set; }

        [StringLength(45, ErrorMessage = "Notes cannot be longer then 45 characters")]
        public string Notes { get; set; }
        public int DentistId { get; set; }
    }
}