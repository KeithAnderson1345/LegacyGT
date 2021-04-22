using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Data
{
    public class Dinner
    {
        [Key]
        public int DinnerId { get; set; }

        [Required]
        public bool DinnerChoosen { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        [ForeignKey(nameof(Volunteer))]
        public int VolunteerId { get; set; }
        public virtual Volunteer Volunteer { get; set; }

    }
}
