using TaskManager.Common.DTO;
using DAL.Models;
using System.Linq;

namespace DAL.Repository
{
    public class UserDal : IUserDal
    {
        public TaskManagerContext _context;
        public IDatabaseAutomapperConfig _mapper;
        public UserDal( TaskManagerContext context, IDatabaseAutomapperConfig mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UserDto RegisterUser(UserDto userDto)
        {
            var user = _mapper.UserDtoToUser(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();

            return userDto;
        }

        public UserDto GetUserByEmail(string Email)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email.Equals(Email));
            if(user == null)
            {
                return null;
            }
            else
            {
                return _mapper.UserToDto(user);
            }
        }
    }
}
