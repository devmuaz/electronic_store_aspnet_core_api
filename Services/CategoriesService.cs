using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Repositories;
using ElectronicsStore.Domain.Services;
using ElectronicsStore.Domain.Services.Communication;
using ElectronicsStore.Resources.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicsStore.System {
    public class CategoriesService : ICategoriesService {

        private readonly ICategoriesRepository categoryRepository;

        public CategoriesService(ICategoriesRepository categoryRepository) {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(int startIndex, int perPage) {
            return await categoryRepository.GetAllAsync(startIndex, perPage);
        }

        public async Task<Category> FindByIdAsync(Guid id) {
            return await categoryRepository.FindByIdAsync(id);
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
                Category category = await categoryRepository.FindByIdAsync(request.Id);
                if (category == null)
                    return new CategoryStatusResponse("Invalid Category Id.");
                category.CategoryName = request.CategoryName ?? category.CategoryName;
                category.Description = request.Description ?? category.Description;
                category.ModifiedAt = DateTime.UtcNow;
                Category updatedCategory = await categoryRepository.UpdateAsync(category);
                return new CategoryStatusResponse(category);
            } catch (Exception e) {
                return new CategoryStatusResponse(e.Message);
            }
        }

        public async Task<bool> DeleteAsync(Guid id) {
            Category category = await categoryRepository.FindByIdAsync(id);
            if (category == null)
                return false;
            return await categoryRepository.DeleteAsync(category);
        }
    }
}
