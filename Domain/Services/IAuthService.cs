using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Services.Communication;
using ElectronicsStore.Resources.Requests;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Services {
    public interface IAuthService {

        public Task<AuthStatusResponse> SignInAsync(User user);

        public Task<AuthStatusResponse> SignUpAsync(UserSignUpRequest request, User user);
    }
}
