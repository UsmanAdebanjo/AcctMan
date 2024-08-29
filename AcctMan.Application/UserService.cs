using AcctMan.Application.Abstract;
using AcctMan.Application.Dtos;
using AcctMan.Domain.Entities;
using AcctMan.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AcctMan.Application
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public UserService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<APIResponse<object>> Login(LoginDto loginDto)
        {
            var user =  await _userManager.FindByEmailAsync(loginDto.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {

                var userRoles= await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, user.UserName)
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = GetToken(authClaims);
                var tokenObj = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };
                return APIResponse<object>.Response("Login successful", tokenObj, System.Net.HttpStatusCode.OK);

            }

            return APIResponse<object>.Response("Something went wrong", null, System.Net.HttpStatusCode.Unauthorized);
        }


        public async Task<APIResponse<UserDto>> RegisterUSer(CreateUserDto createUser)
        {
            var user = new User
            {
                FirstName = createUser.FirstName,
                LastName = createUser.LastName,
                DateOfBirth=  createUser.DateOfBirth,
                Pin=createUser.Pin,
                Gender=createUser.Gender,
                Email= createUser.Email,
                UserName=  createUser.Email,
                PhoneNumber= createUser.PhoneNumber
                
            };
          var status= await _userManager.CreateAsync(user, createUser.Password);
            if (status.Succeeded)
            {
                //await _userManager.AddToRoleAsync(user, createUser.Role.ToString());

                //Send email for otp

                //automatically activate account pending email for otp will be implemented

                user.EmailConfirmed = true;

                return APIResponse<UserDto>.Response("user created successfully", user.AsUserDto(), System.Net.HttpStatusCode.Created);
                
            }
            else
            {
                return APIResponse<UserDto>.Response("error occured", null, System.Net.HttpStatusCode.InternalServerError);

            }

        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddSeconds(300),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }


    }

}
