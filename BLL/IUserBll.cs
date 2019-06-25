using System.Collections.Generic;
using TaskManager.Common.DTO;


namespace BLL
{
    public interface IUserBll
    {
        UserDto RegisterUser(UserDto userDto);

        UserDto GetUserByEmail(string email, string password);

        UserDto GetUser(string email);

        string CreateHash(string value, string salt);

        string CreateSalt();

    }
}