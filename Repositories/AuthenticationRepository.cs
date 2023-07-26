using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobHuntApi.Contracts;
using JobHuntApi.DTO.User;
using JobHuntApi.Models;
using Microsoft.AspNetCore.Identity;

namespace JobHuntApi.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public AuthenticationRepository(IMapper mapper, UserManager<User> userManager)
        {
            this._userManager = userManager;
            this._mapper = mapper;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            var user = _mapper.Map<User>(registerUserDto);
            user.UserName = user.Email;

            var result = await _userManager.CreateAsync(user, registerUserDto.Password);

            if(result.Succeeded){
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result;
        }
    }
}