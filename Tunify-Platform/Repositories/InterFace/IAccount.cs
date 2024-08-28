using System.Security.Claims;
using Tunify_Platform.Models.DTO;

namespace Tunify_Platform.Repositories.InterFace
{
    public interface IAccount
    {
        public Task<UserDto> Register(RegisterDto registerDto);

        public Task<UserDto> Login(LoginDto loginDto);
        Task LogoutAsync();
        public Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal);

    }
}
