using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Services.Communication;
using ElectronicsStore.Resources.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Services {
    public interface IProductsService {

        public Task<IEnumerable<Product>> GetAllAsync(int startIndex, int perPage);

        public Task<Product> FindByIdAsync(Guid id);

        public Task<ProductStatusResponse> SaveAsync(ProductSaveRequest request, Product product);

        public Task<ProductStatusResponse> UpdateAsync(ProductUpdateRequest request);

        public Task<bool> DeleteAsync(Guid id);
    }
}
