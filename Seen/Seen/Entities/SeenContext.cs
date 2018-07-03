using Microsoft.EntityFrameworkCore;
using Seen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seen.Entities
{
    public class SeenContext : DbContext
    {
        public DbSet<Sighting> Sightings{ get; set; }

        public SeenContext(DbContextOptions<SeenContext> options) : base(options) { }
    }
}
