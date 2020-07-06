using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Repositories;
using ElectronicsStore.Domain.Services;
using ElectronicsStore.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Services {
    public class UsersService : IUsersService {

        private readonly IUsersRepository usersRepository;

        public UsersService(IUsersRepository usersRepository) {
            this.usersRepository = usersRepository;
        }

        public async Task<UserStatusResponse> FindUserByUsernameAsync(string username) {
            User user = await usersRepository.FindByUsernameAsync(username);
            if (user == null)
                return new UserStatusResponse("Username Not Found");
            return new UserStatusResponse(user);
        }
    }
}
