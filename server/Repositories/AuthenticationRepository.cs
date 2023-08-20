using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobHuntApi.Contracts;
using JobHuntApi.DTO.User;
using JobHuntApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace JobHuntApi.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private User? _user;
        private static readonly string? issuer = Environment.GetEnvironmentVariable("JWT_VALID_ISSUER");
        private static readonly string? audience = Environment.GetEnvironmentVariable("JWT_VALID_AUDIENCE");
        private static readonly string? accessTokenExpiration = Environment.GetEnvironmentVariable("JWT_ACCESSTOKEN_EXPIRATION_HOURS");
        private static readonly string? refreshTokenExpiration = Environment.GetEnvironmentVariable("JWT_REFRESHTOKEN_EXPIRATION_HOURS");
        private static readonly string? secret = System.Environment.GetEnvironmentVariable("JWT_SECRET");

        public AuthenticationRepository(IMapper mapper, UserManager<User> userManager)
        {
            this._userManager = userManager;
            this._mapper = mapper;
        }

        public async Task<string> CreateAccessToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(accessTokenExpiration)),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private async Task<List<Claim>> GetClaims()
        {
            if (_user?.Email == null)
            {
                throw new NullReferenceException(_user?.Email);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, _user.Id),
                new Claim(ClaimTypes.Email, _user.Email),
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private static SigningCredentials GetSigningCredentials()
        {
            if (secret == null)
            {
                throw new NullReferenceException(secret);
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            var user = _mapper.Map<User>(registerUserDto);
            user.UserName = user.Email;

            var result = await _userManager.CreateAsync(user, registerUserDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result;
        }

        public async Task<(GetUserDto, string)?> ValidateUserAsync(LoginUserDto loginUserDto)
        {
            _user = await _userManager.FindByEmailAsync(loginUserDto.Email);

            if (_user == null || !await _userManager.CheckPasswordAsync(_user, loginUserDto.Password))
            {
                return null;
            }

            _user.RefreshToken = await CreateRefreshToken();

            GetUserDto getUserDto = _mapper.Map<GetUserDto>(_user);

            getUserDto.AccessToken = await CreateAccessToken();
            return (getUserDto, _user.RefreshToken);
        }

        private async Task<string> CreateRefreshToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(refreshTokenExpiration)),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private ClaimsPrincipal GetClaimsPrincipal(string token)
        {

            if (secret == null)
            {
                throw new NullReferenceException(secret);
            }

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
            };

            var claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out SecurityToken securityToken);

            var jwtSecurityToken = (JwtSecurityToken)securityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid Token");
            }

            return claimsPrincipal;
        }

        public async Task<string?> RefreshAccessToken(string refreshToken)
        {
            try
            {
                ClaimsPrincipal claimsPrincipal = GetClaimsPrincipal(refreshToken);
                string? id = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (id == null)
                    return null;
                _user = await _userManager.FindByIdAsync(id);
                return await CreateAccessToken();

            }
            catch
            {
                return null;
            }
        }
    }
}