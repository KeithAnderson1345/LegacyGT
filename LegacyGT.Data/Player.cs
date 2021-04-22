using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Data
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Handicap { get; set; }

        [Required]
        public string ShirtSize { get; set; }

        [Required]
        public bool Dinner { get; set; }

        [Required]
        public bool Raffle { get; set; }

        [Required]
        public bool Mulligans { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }

        public DateTimeOffset? Modified { get; set; }
    }
}
