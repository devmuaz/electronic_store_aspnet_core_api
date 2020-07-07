using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Repositories;
using ElectronicsStore.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Persistence.Repositories {
    public class UsersRepository : BaseRepository, IUsersRepository {

        public UsersRepository(AppDbContext context) : base(context) { }


        public async Task<User> GetUserAsync(User user) {
            return await context.users.FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);
        }

        public async Task<User> AddAsync(User user) {
            var result = await context.users.AddAsync(user);
            return (await context.SaveChangesAsync() > 0) ? result.Entity : null;
        }

        public async Task<User> FindByIdAsync(Guid id) {
            return await context.users.FindAsync(id);
        }

        public async Task<User> FindByUsernameAsync(string username) {
            return await context.users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> UpdateAsync(User user) {
            var result = context.users.Update(user);
            return (await context.SaveChangesAsync() > 0) ? result.Entity : null;
        }

        public async Task<bool> DeleteAsync(User user) {
            context.users.Remove(user);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
