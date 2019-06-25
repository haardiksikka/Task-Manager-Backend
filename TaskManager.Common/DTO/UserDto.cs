using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Common.DTO
{
   public class UserDto
    {
        public int UserId { get; set; }
        
        public string FirstName { get; set; }

        public string Lastname { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string Salt { get; set; }
    }
}
