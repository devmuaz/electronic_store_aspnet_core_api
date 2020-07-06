using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Repositories;
using ElectronicsStore.Domain.Services;
using ElectronicsStore.Domain.Services.Communication;
using ElectronicsStore.Resources.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.System {
    public class CategoriesService : ICategoriesService {

        private readonly ICategoriesRepository categoryRepository;

        public CategoriesService(ICategoriesRepository categoryRepository) {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() {
            return await categoryRepository.GetAllAsync();
        }

        public async Task<Category> FindByIdAsync(Guid id) {
            return await categoryRepository.FindAsync(id);
        }

        public async Task<CategoryStatusResponse> SaveCategoryAsync(Category category) {
            try {
                Category newAddedCategory = await categoryRepository.AddAsync(category);
                return new CategoryStatusResponse(newAddedCategory);
            } catch (Exception ex) {
                return new CategoryStatusResponse(ex.Message);
            }
        }

        public async Task<CategoryStatusResponse> UpdateAsync(CategoryUpdateRequest request) {
            try {
                Category category = await categoryRepository.FindAsync(request.Id);
                if (category == null)
                    return new CategoryStatusResponse("Invalid Category Id.");
                category.CategoryName = request.CategoryName ?? category.CategoryName;
                category.Description = request.Description ?? category.Description;
                category.ModifiedAt = DateTime.UtcNow;
                Category updatedCategory = await categoryRepository.Update(category);
                return new CategoryStatusResponse(category);
            } catch (Exception e) {
                return new CategoryStatusResponse(e.Message);
            }
        }

        public async Task<bool> DeleteAsync(Guid id) {
            Category category = await categoryRepository.FindAsync(id);
            return await categoryRepository.Delete(category);
        }
    }
}
