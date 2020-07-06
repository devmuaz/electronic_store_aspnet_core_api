using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Repositories;
using ElectronicsStore.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Services {
    public class TokenService : ITokenService {

        private readonly IUsersRepository usersRepository;

        private readonly byte[] secretKey;
        private readonly int expirationDateInYears;
        private readonly JwtSecurityTokenHandler tokenHandler;

        public TokenService(IConfiguration config, IUsersRepository usersRepository) {

            secretKey = Encoding.ASCII.GetBytes(config.GetSection("JWTConfig").GetSection("SecretKey").Value);
            expirationDateInYears = int.Parse(config.GetSection("JWTConfig").GetSection("ExpirationDateInYears").Value);

            tokenHandler = new JwtSecurityTokenHandler();
            this.usersRepository = usersRepository;
        }

        public string GenerateToken(User user) {

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor() {
                Subject = new ClaimsIdentity(new [] {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddYears(expirationDateInYears),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256
                ),
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public async Task<User> ValidateTokenAsync(string token) {
            token = token.Replace("Bearer ", "");
            JwtSecurityToken securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            Guid uid = Guid.Parse(securityToken.Claims.First(claim => claim.Type == "nameid").Value);
            User user = await usersRepository.FindByIdAsync(uid);
            return user;
        }
    }
}
