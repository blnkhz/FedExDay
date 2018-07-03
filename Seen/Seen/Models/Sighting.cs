using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seen.Models
{
    public class Sighting
    {
        [Required]
        public long Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime Day { get; set; }
        public string SocialHandle { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public string HairStyle { get; set; }
        public bool Glasses { get; set; }
        
    }
}
