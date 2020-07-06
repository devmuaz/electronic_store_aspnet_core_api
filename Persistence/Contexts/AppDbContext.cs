﻿using ElectronicsStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Persistence.Contexts {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<ImagePath> images { get; set; }

        public DbSet<User> users { get; set; }
    }
}
