using Microsoft.EntityFrameworkCore;
using Seen.Entities;
using Seen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seen.Repository
{
    public class SightingRepository
    {
        private SeenContext seenContext;

        public SightingRepository(SeenContext seenContext)
        {
            this.seenContext = seenContext;
        }

        public async Task CreateAsync(Sighting sighting)
        {
            await seenContext.Sightings.AddAsync(sighting);
            await seenContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var sightingToDelete = await SelectByIdAsync(id);
            seenContext.Remove(sightingToDelete);
            await seenContext.SaveChangesAsync();
        }

        public async Task<List<Sighting>> SelectAllAsync()
        {
            var sightingList = await seenContext.Sightings.ToListAsync();
            return sightingList;
        }

        public async Task<Sighting> SelectByIdAsync(long id)
        {
            var questionToFind = await seenContext.Sightings.FindAsync(id);
            return questionToFind;
        }

        public async Task UpdateAsync(Sighting sighting)
        {
            seenContext.Sightings.Update(sighting);
            await seenContext.SaveChangesAsync();
        }
    }
}
