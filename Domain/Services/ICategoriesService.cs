using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Services.Communication;
using ElectronicsStore.Resources.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Services {
    public interface ICategoriesService {

        public Task<IEnumerable<Category>> GetAllAsync();

        public Task<Category> FindByIdAsync(Guid id);

        public Task<CategoryStatusResponse> SaveCategoryAsync(Category category);

        public Task<CategoryStatusResponse> UpdateAsync(CategoryUpdateRequest request);

        public Task<bool> DeleteAsync(Guid id);
    }
}
