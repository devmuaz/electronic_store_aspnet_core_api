using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Repositories;
using ElectronicsStore.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Persistence.Repositories {
    public class CategoriesRepository : BaseRepository, ICategoriesRepository {

        public CategoriesRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetAllAsync(int startIndex, int perPage) {
            return await context.categories.Skip(startIndex).Take(perPage).ToListAsync();
        }

        public async Task<Category> FindByIdAsync(Guid id) {
            return await context.categories.FindAsync(id);
        }

        public async Task<Category> AddAsync(Category category) {
            var result = await context.categories.AddAsync(category);
            return (await context.SaveChangesAsync() > 0) ? result.Entity : null;
        }

        public async Task<Category> UpdateAsync(Category category) {
            var result = context.categories.Update(category);
            return (await context.SaveChangesAsync() > 0) ? result.Entity : null;
        }

        public async Task<bool> DeleteAsync(Category category) {
            context.categories.Remove(category);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
