using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnicornRanch.Models
{
    // Basic model to represent a unicorn's possible location at any given time
    // Multiple Unicorns may be at the same location
    public class UnicornLocationModel
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Current Location")]
        public string LocationName { get; set; }

    }
}
