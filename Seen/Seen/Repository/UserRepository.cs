using Microsoft.EntityFrameworkCore;
using Seen.Entities;
using Seen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seen.Repository
{
    public class UserRepository
    {
        private SeenContext seenContext;

        public UserRepository(SeenContext seenContext)
        {
            this.seenContext = seenContext;
        }


        public async Task CreateAsync(User user)
        {
            await seenContext.Users.AddAsync(user);
            await seenContext.SaveChangesAsync();
        }

        public async Task<User> SelectByIdAsync(long id)
        {
            var userToFind = await seenContext.Users.FindAsync(id);
            return userToFind;
        }

        public async Task<List<User>> SelectAllAsync()
        {
            var userList = await seenContext.Users.ToListAsync();
            return userList;
        }
    }
}
