using AcctMan.Application.Dtos;
using AcctMan.Domain.Entities;

namespace AcctMan.Application.Abstract;

    public interface IUserService
    {
    Task<APIResponse<UserDto>> RegisterUSer(CreateUserDto createUser);
    Task<APIResponse<object>> Login(LoginDto loginDto);
    }

