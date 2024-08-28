using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.InterFace;

namespace Tunify_Platform.Repositories.Services
{
    public class IdentityAccountServices : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private JwtTokenServices JwtTokenServices;
        public IdentityAccountServices(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, JwtTokenServices jwtTokenServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            JwtTokenServices = jwtTokenServices;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginDto.UserName);
                return new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await JwtTokenServices.GenerateToken(user)
                };
            }
            return null;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();

        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            var user = new IdentityUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                var role = await _userManager.AddToRolesAsync(user, registerDto.Roles);
                return new UserDto { 
                Id = user.Id,
                UserName = user.UserName,
                Token = await JwtTokenServices.GenerateToken(user),
                Roles = await _userManager.GetRolesAsync(user)

                };

            }
            return null;
        }
        public async Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);

            return new UserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = await JwtTokenServices.GenerateToken(user) 
            };
        }
        
     }
}
