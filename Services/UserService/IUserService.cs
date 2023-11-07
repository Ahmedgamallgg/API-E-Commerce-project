using Services.UserService.Dto;

namespace Services.UserService
{
    public interface IUserService
    {

        public Task<UserDto> Register(RegisterDto registerDto);
        public Task<UserDto> Login(LoginDto loginDto);

       

    }
}
