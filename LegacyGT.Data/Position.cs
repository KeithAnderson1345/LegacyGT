using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Data
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        public string Positions { get; set; }

        [ForeignKey(nameof(Volunteer))]
        public int VolunteerId { get; set; }
        public virtual Volunteer Volunteer { get; set; }

    }
}
