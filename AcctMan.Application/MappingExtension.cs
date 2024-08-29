using AcctMan.Application.Dtos;
using AcctMan.Domain.Entities;

namespace AcctMan.Application
{
    public static class MappingExtension
    {
        public static UserDto AsUserDto(this User user)
        {
            return new UserDto();
        }
    }
}