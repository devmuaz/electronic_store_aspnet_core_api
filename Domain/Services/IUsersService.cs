using ElectronicsStore.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Services {
    public interface IUsersService {

        public Task<UserStatusResponse> FindUserByUsernameAsync(string username);
    }
}
