using TaskManager.Common.DTO;
using DAL.Models;
namespace DAL.Repository
{
    public interface IUserDal
    {
        UserDto RegisterUser(UserDto userDto);
        UserDto GetUserByEmail(string Email);
    }
}