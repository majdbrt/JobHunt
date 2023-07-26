using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobHuntApi.Contracts;
using JobHuntApi.DTO.User;
using JobHuntApi.Repositories;
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
    }
}