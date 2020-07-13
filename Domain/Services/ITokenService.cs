using ElectronicsStore.Domain.Models;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Services {
    public interface ITokenService {

        public string GenerateToken(User user);

        public Task<User> ValidateTokenAsync(string token);
    }
}
