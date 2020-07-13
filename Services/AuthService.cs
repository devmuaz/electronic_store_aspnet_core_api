using AutoMapper;
using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Repositories;
using ElectronicsStore.Domain.Services;
using ElectronicsStore.Domain.Services.Communication;
using ElectronicsStore.Resources.Requests;
using ElectronicsStore.Resources.Responses;
using ElectronicsStore.System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ElectronicsStore.Services {
    public class AuthService : IAuthService {

        private readonly IUsersRepository authRepository;
        private readonly ITokenService tokenService;
        private readonly IFileService fileService;
        private readonly IMapper mapper;
        private IConfiguration config { get; }

        public AuthService(IUsersRepository authRepository, ITokenService tokenService, IFileService fileService, IMapper mapper, IConfiguration config) {
            this.authRepository = authRepository;
            this.tokenService = tokenService;
            this.fileService = fileService;
            this.mapper = mapper;
            this.config = config;
        }

        public async Task<AuthStatusResponse> SignInAsync(User user) {
            User userExists = await authRepository.GetUserAsync(user);
            if (userExists == null)
                return new AuthStatusResponse {
                    Status = false, Message = "Unauthorized.", Token = null, User = null
                };
            string token = tokenService.GenerateToken(userExists);
            UserResponse userResponse = mapper.Map<User, UserResponse>(userExists);
            return new AuthStatusResponse {
                Status = true, Message = "Successful signing in.", Token = token, User = userResponse
            };
        }

        public async Task<AuthStatusResponse> SignUpAsync(UserSignUpRequest request, User user) {
            User userExists = await authRepository.GetUserAsync(user);
            if (userExists != null)
                return new AuthStatusResponse {
                    Status = false, Message = "Unauthorized.", Token = null, User = null
                };
            user.AvatarImage = await fileService.StoreImage(config.GetSection("UsersImages").Value, request.AvatarImage);
            User newAddedUser = await authRepository.AddAsync(user);
            if (newAddedUser == null)
                return new AuthStatusResponse {
                    Status = false, Message = "Signing up failed.", Token = null, User = null
                };
            string token = tokenService.GenerateToken(user);
            UserResponse userResponse = mapper.Map<User, UserResponse>(newAddedUser);
            return new AuthStatusResponse {
                Status = true, Message = "Successful signing up", Token = token, User = userResponse
            };
        }
    }
}
