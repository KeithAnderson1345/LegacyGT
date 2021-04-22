using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Data
{
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }

        [Required]
        public string Donations { get; set; }

        [ForeignKey(nameof(Sponsor))]
        public int SponsorId { get; set; }
        public virtual Sponsor Sponsor { get; set; }

    }
}
