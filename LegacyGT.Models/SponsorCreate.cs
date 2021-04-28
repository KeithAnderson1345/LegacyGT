using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Models
{
    public class SponsorCreate
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

    }
}
