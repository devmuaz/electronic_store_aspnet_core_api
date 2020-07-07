using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Repositories;
using ElectronicsStore.Domain.Services;
using ElectronicsStore.Domain.Services.Communication;
using ElectronicsStore.Resources.Requests;
using ElectronicsStore.System;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace ElectronicsStore.Services {
    public class UsersService : IUsersService {

        private readonly IUsersRepository usersRepository;
        private readonly IFileService fileService;
        private IConfiguration config { get; }

        public UsersService(IUsersRepository usersRepository, IFileService fileService, IConfiguration config) {
            this.usersRepository = usersRepository;
            this.fileService = fileService;
            this.config = config;
        }

        public async Task<UserStatusResponse> FindUserByUsernameAsync(string username) {
            User user = await usersRepository.FindByUsernameAsync(username);
            if (user == null)
                return new UserStatusResponse("Username Not Found");
            return new UserStatusResponse(user);
        }

        public async Task<UserStatusResponse> UpdateAsync(UserUpdateRequest request) {
            try {
                User user = await usersRepository.FindByIdAsync(request.UserId);
                if (user == null)
                    return new UserStatusResponse("User Not Found.");

                if (request.AvatarImage != null)
                    user.AvatarImage = await fileService.StoreImage(config.GetSection("UsersImages").Value, request.AvatarImage);

                user.Username = request.Username ?? user.Username;
                user.Fullname = request.Fullname ?? user.Fullname;
                user.Password = request.Password ?? user.Password;
                user.Email = request.Email ?? user.Email;

                User updatedUser = await usersRepository.UpdateAsync(user);
                return new UserStatusResponse(updatedUser);

            } catch (Exception e) {
                return new UserStatusResponse(e.Message);
            }
        }

        public async Task<bool> DeleteAsync(Guid id) {
            User user = await usersRepository.FindByIdAsync(id);
            if (user == null)
                return false;
            return await usersRepository.DeleteAsync(user);
        }
    }
}
