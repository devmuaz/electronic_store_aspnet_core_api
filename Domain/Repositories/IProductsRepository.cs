using ElectronicsStore.Domain.Models;using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Repositories {
    public interface IProductsRepository {

        public Task<IEnumerable<Product>> GetAllAsync();

        public Task<Product> FindAsync(Guid id);

        public Task<Product> AddAsync(Product product);

        public Task<Product> UpdateAsync(Product product);

        public Task<bool> DeleteAsync(Product product);
    }
}
