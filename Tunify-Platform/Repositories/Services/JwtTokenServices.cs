using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Services
{
    public class JwtTokenServices
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;

        public JwtTokenServices(IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public static TokenValidationParameters ValidateToken(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        }
        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var SecretKey = configuration["JWT:SecretKey"];
            if (SecretKey == null)
            {
                throw new InvalidOperationException();
            }
            var SecretBytes = Encoding.UTF8.GetBytes(SecretKey);

            return new SymmetricSecurityKey(SecretBytes);
        }

        public async Task<string> GenerateToken(IdentityUser user)
        {
           var userPrinciple = await _signInManager.CreateUserPrincipalAsync(user);
            if (userPrinciple == null)
            {
               return null;
            }

            var signInKey = GetSecurityKey(_configuration);

            var token = new JwtSecurityToken(
                    expires: DateTime.UtcNow.AddMinutes(5),
                    signingCredentials : new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256),
                    claims: userPrinciple.Claims
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
    
}
