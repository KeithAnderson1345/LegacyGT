using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Models
{
    public class PlayerListItem
    {
        public int PlayerId { get; set; }

        public string FirstName { get; set; }
       
        public string LastName { get; set; }   
      
        [Display(Name ="Registration Date")]
        public DateTimeOffset Created { get; set; }       
    }
}
