using System;
using System.ComponentModel.DataAnnotations;


namespace WebApplication8.Models
{
    public class Volunteer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Date Joined")]
        [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; }

        [Required]
        public string Status { get; set; } // Active, Inactive, Suspended
    }
}
