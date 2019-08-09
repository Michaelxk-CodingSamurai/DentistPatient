using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("dentist")]
    public class Dentist : IEntity
    {
        [Key]
        [Column("DentistId")]
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

        
        [Required(ErrorMessage = "Specialty is required")]
        [StringLength(45, ErrorMessage = "Specialty cannot be longer then 45 characters")]
        public string Specialty { get; set; }
    }

}