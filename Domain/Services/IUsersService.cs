using ElectronicsStore.Domain.Services.Communication;
using ElectronicsStore.Resources.Requests;
using System;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Services {
    public interface IUsersService {

        public Task<UserStatusResponse> FindUserByUsernameAsync(string username);

        public Task<UserStatusResponse> UpdateAsync(UserUpdateRequest request);

        public Task<bool> DeleteAsync(Guid id);
    }
}
