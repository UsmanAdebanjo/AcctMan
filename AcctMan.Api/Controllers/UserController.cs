
using AcctMan.Application.Abstract;
using AcctMan.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AcctMan.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService; 
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var result = await _userService.RegisterUSer(createUserDto);
            return result.StatusCode == HttpStatusCode.Created ? Created("", result.Data) : BadRequest();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginUser)
        {
            var result= await _userService.Login(loginUser);
            return result.StatusCode==HttpStatusCode.OK? Ok(result.Data) : Unauthorized();
        }
    }
}
