using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Repositories;
using ElectronicsStore.Domain.Services;
using ElectronicsStore.Domain.Services.Communication;
using ElectronicsStore.Resources.Requests;
using ElectronicsStore.System;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Resources.Responses {
    public class ProductsService : IProductsService {

        private readonly IProductsRepository productsRepository;
        private readonly ICategoriesRepository categoryRepository;
        private readonly IFileService fileService;
        private IConfiguration config { get; }

        public ProductsService(IProductsRepository productsRepository, ICategoriesRepository categoryRepository, IFileService fileService, IConfiguration config) {
            this.productsRepository = productsRepository;
            this.categoryRepository = categoryRepository;
            this.fileService = fileService;
            this.config = config;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() {
            return await productsRepository.GetAllAsync();
        }

        public async Task<Product> FindByIdAsync(Guid id) {
            return await productsRepository.FindAsync(id);
        }

        public async Task<ProductStatusResponse> SaveAsync(ProductSaveRequest request, Product product) {
            try {
                if ((await categoryRepository.FindByIdAsync(request.CategoryId)) == null)
                    return new ProductStatusResponse("Invald Category Id.");

                for (int i = 0; i < request.Images.Count; i++)
                    product.Images.Add(new ImagePath {
                        Filename = await fileService.StoreImage(config.GetSection("ProductsImages").Value, request.Images[i])
                    });

                Product newAddedProduct = await productsRepository.AddAsync(product);

                return new ProductStatusResponse(newAddedProduct);
            } catch (Exception e) {
                return new ProductStatusResponse(e.Message);
            }
        }

        public async Task<ProductStatusResponse> UpdateAsync(ProductUpdateRequest request) {
            try {
                Product product = await productsRepository.FindAsync(request.ProductId);
                if (product == null)
                    return new ProductStatusResponse("Invalid Product Id.");
                product.ProductName = request.ProductName ?? product.ProductName;
                product.Description = request.Description ?? product.Description;
                product.Price = product.Price;
                product.Quantity = product.Quantity;
                product.CategoryId = product.CategoryId;
                product.ModifiedAt = DateTime.UtcNow;

                Product updatedProduct = await productsRepository.UpdateAsync(product);

                return new ProductStatusResponse(updatedProduct);
            } catch (Exception e) {
                return new ProductStatusResponse(e.Message);
            }
        }

        public async Task<bool> DeleteAsync(Guid id) {
            Product product = await productsRepository.FindAsync(id);
            if (product == null)
                return false;
            return await productsRepository.DeleteAsync(product);
        }
    }
}
