using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnicornRanch.Models
{
    // Basic model to represent a unicorn
    public class UnicornModel
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Unicorn Name")]
        public string UnicornName { get; set; }
        [DisplayName("Color")] 
        public string Color { get; set; }
        [DisplayName("Favorite Snack")] 
        public string FavoriteSnack { get; set; }
        public UnicornLocationModel CurrentLocation { get; set; }

    }
}
