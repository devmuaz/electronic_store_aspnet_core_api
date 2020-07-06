using ElectronicsStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Services {
    public interface ITokenService {

        public string GenerateToken(User user);

        public Task<User> ValidateTokenAsync(string token);
    }
}
