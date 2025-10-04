using System;
using System.ComponentModel.DataAnnotations;

    namespace WebApplication8.Models
    {
        public class Incident
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [Required]
            [Display(Name = "Description")]
            public string Description { get; set; }

            [Required]
            [Display(Name = "Date Reported")]
            [DataType(DataType.Date)]
            public DateTime DateReported { get; set; }

            [Display(Name = "Volunteer Involved")]
            public int? VolunteerId { get; set; } // optional link to volunteer

            public Volunteer Volunteer { get; set; } // navigation property

            [Required]
            public string Status { get; set; } // Pending, Resolved, Investigating
        }
    }


