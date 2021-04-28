using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Models
{
    public class VolunteerCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least one character.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least one character.")]
        public string LastName { get; set; }

        [Required]
        [MinLength(7, ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter a size from the following: S / M / L / XL / XXL / XXXL")]
        public string ShirtSize { get; set; }

        [Required]
        public bool Dinner { get; set; }
    }
}
