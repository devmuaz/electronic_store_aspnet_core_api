using ElectronicsStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Repositories {
    public interface ICategoriesRepository {

        public Task<IEnumerable<Category>> GetAllAsync(int startIndex, int perPage);

        public Task<Category> FindByIdAsync(Guid id);

        public Task<Category> AddAsync(Category category);

        public Task<Category> UpdateAsync(Category category);

        public Task<bool> DeleteAsync(Category category);
    }
}
