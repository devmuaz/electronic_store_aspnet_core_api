﻿using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Repositories;
using ElectronicsStore.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Persistence.Repositories {
    public class ProductsRepository : BaseRepository, IProductsRepository {

        public ProductsRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetAllAsync(int startIndex, int perPage) {
            return await context.products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Skip(startIndex)
                .Take(perPage).ToListAsync();
        }

        public async Task<Product> FindAsync(Guid id) {
            return await context.products.Include(p => p.Category)
                .Include(p => p.Images).FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<Product> AddAsync(Product product) {
            var result = await context.products.AddAsync(product);
            return (await context.SaveChangesAsync() > 0) ? result.Entity : null;
        }

        public async Task<Product> UpdateAsync(Product product) {
            var result = context.products.Update(product);
            return (await context.SaveChangesAsync() > 0) ? result.Entity : null;
        }

        public async Task<bool> DeleteAsync(Product product) {
            context.products.Remove(product);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
