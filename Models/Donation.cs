using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
        public class Donation
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Donor Name")]
            public string DonorName { get; set; }

            [Required]
            [Display(Name = "Donation Type")]
            public string DonationType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
            public int Quantity { get; set; }

            [Required]
            [Display(Name = "Date Donated")]
            [DataType(DataType.Date)]
            public DateTime DateDonated { get; set; }

            [Required]
            public string Status { get; set; } // Pending, Approved, Rejected
        }
    }


