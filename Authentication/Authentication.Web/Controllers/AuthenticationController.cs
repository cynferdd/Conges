using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Domain.PrimaryPorts;
using Authentication.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Exceptions;

namespace Authentication.Web.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationUseCase _authenticationUseCase;
        public AuthenticationController(IAuthenticationUseCase authenticationUseCase)
        {
            _authenticationUseCase = authenticationUseCase;
        }

        [HttpGet("/{token}")]
        public Task<IActionResult> GetAsync([FromQuery] string token) => 
            GetAsync(token, DateTime.Now);


        public async Task<IActionResult> GetAsync(string token, DateTime now)
        {
            var authenticationToken = new AuthenticationToken(new Guid(token));
            var isValid = await _authenticationUseCase.IsValidAsync(authenticationToken, now);
            if (isValid)
            {
                return Ok();
            }
            return Unauthorized();
        }

        [HttpPost()]
        public async Task<IActionResult> ConnectAsync([FromBody] AuthenticationDto authenticationDto)
        {
            try
            {
                return Ok(await _authenticationUseCase.ConnectAsync(authenticationDto.Login, authenticationDto.Password));
            }
            catch (NotFoundException<string>)
            {

                return NotFound();
            }
            
        }
    }

    
}
