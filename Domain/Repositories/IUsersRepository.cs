using ElectronicsStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Repositories {
    public interface IUsersRepository {

        public Task<User> GetUserAsync(User user);

        public Task<User> AddAsync(User user);

        public Task<User> FindByIdAsync(Guid id);

        public Task<User> FindByUsernameAsync(string username);
    }
}
