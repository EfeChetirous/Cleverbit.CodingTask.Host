using Cleverbit.CodingTask.Host.Models;
using Cleverbit.CodingTask.Utilities.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.ApiControllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private IUserService _userService;
        private IMatchService _matchService;

        public PingController(IUserService userService, IMatchService matchService)
        {
            _userService = userService;
            _matchService = matchService;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromForm] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet("GetUserMatches")]
        public async Task<IActionResult> GetUserMatches()
        {
            var users = await _matchService.GetUserMatchAsync();
            return Ok(users);
        }
        
        [HttpGet("GetRandomNumber")]
        public async Task<IActionResult> GetRandomNumber()
        {
            var randomNumber = await _matchService.GetRandomNumberAsync();
            return Ok(randomNumber);
        }        
    }
}
