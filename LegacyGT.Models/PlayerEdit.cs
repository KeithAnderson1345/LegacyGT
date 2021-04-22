using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Models
{
    public class PlayerEdit
    {
        public int PlayerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Handicap { get; set; }

        public string ShirtSize { get; set; }

        public bool Dinner { get; set; }

        public bool Raffle { get; set; }

        public bool Mulligans { get; set; }
    }
}
