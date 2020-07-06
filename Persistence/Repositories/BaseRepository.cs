using ElectronicsStore.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Persistence.Repositories {
    public abstract class BaseRepository {

        protected readonly AppDbContext context;

        public BaseRepository(AppDbContext context) {
            this.context = context;
        }
    }
}
