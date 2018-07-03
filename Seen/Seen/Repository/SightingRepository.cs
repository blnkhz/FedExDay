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
            var sightingList = await feedbackContext.Questions.ToListAsync();
            return sightingList;
        }

        public async Task<Question> SelectByIdAsync(long id)
        {
            var questionToFind = await feedbackContext.Questions.FindAsync(id);
            return questionToFind;
        }

        public async Task UpdateAsync(Question question)
        {
            feedbackContext.Questions.Update(question);
            await feedbackContext.SaveChangesAsync();
        }
    }
}
