using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seen.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string SocialHandle { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public string HairStyle { get; set; }
        public bool Glasses { get; set; }
    }
}
