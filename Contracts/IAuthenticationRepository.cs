using JobHuntApi.DTO.User;
using Microsoft.AspNetCore.Identity;

namespace JobHuntApi.Contracts
{
    public interface IAuthenticationRepository
    {
        Task<IdentityResult> RegisterUserAsync(RegisterUserDto registerUserDto);
        Task<GetUserDto?> ValidateUserAsync(LoginUserDto loginUserDto);
        Task<string> CreateAccessToken();
    }
}