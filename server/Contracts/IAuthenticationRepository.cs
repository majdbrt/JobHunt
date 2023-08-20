using JobHuntApi.DTO.User;
using JobHuntApi.Models;
using Microsoft.AspNetCore.Identity;

namespace JobHuntApi.Contracts
{
    public interface IAuthenticationRepository
    {
        Task<IdentityResult> RegisterUserAsync(RegisterUserDto registerUserDto);
        Task<(GetUserDto,string)?> ValidateUserAsync(LoginUserDto loginUserDto);

        Task<string?> RefreshAccessToken(string refreshToken);

    }
}