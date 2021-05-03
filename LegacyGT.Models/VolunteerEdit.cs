using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Models
{
    public class VolunteerEdit
    {
        public int VolunteerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Positions { get; set; }

        public string ShirtSize { get; set; }

        public bool Dinner { get; set; }
    }
}
