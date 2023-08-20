using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobHuntApi.Contracts;
using JobHuntApi.DTO.User;
using JobHuntApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc;

namespace JobHuntApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            this._authenticationRepository = authenticationRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            var result = await _authenticationRepository.RegisterUserAsync(registerUserDto);

            if(!result.Succeeded){
                foreach(var error in result.Errors){
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }// if

            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<GetUserDto>> Login([FromBody] LoginUserDto loginUserDto){
            var result = await _authenticationRepository.ValidateUserAsync(loginUserDto);
            GetUserDto? getUserDto = result?.Item1;
            string? refreshToken = result?.Item2;
            if (getUserDto == null)
                return Unauthorized();

            if (refreshToken == null)
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            
            CookieOptions cookieOptions = new CookieOptions{
                HttpOnly = true
            };
            HttpContext.Response.Cookies.Append("Refresh_Token", refreshToken, cookieOptions);
            
            return Ok(getUserDto);
        }

        [HttpPost]
        [Route("logout")]
        public ActionResult Logout(){
            
            HttpContext.Response.Cookies.Delete("Refresh_Token");
            return Ok();
        }
    
        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult<string>> RefreshAccessToken(){
            var refreshToken = HttpContext.Request.Cookies["Refresh_Token"];
            if (refreshToken == null)
                return Unauthorized("here");

            var accessToken = await _authenticationRepository.RefreshAccessToken(refreshToken);
            if(accessToken == null){
                HttpContext.Response.Cookies.Delete("Refresh_Token");
                return Unauthorized();
            }
                
            //HttpContext.Response.Cookies.Delete("Refresh_Token");
            return Ok(accessToken);
        }
        
    }
}