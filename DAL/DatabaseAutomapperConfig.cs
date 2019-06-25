using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TaskManager.Common.DTO;
using DAL.Models;
namespace DAL
{
    public class DatabaseAutomapperConfig : IDatabaseAutomapperConfig
    {
        readonly private IMapper mapper;
        public DatabaseAutomapperConfig()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<Task, TaskDto>().ReverseMap();
                
            });
            mapper = config.CreateMapper();
        }

        public UserDto UserToDto(User user)
        {
            return mapper.Map<UserDto>(user);
        }

        public User UserDtoToUser(UserDto userDto)
        {
            return mapper.Map<User>(userDto);
        }

        public TaskDto TaskToTaskDto(Task task)
        {
            return mapper.Map<TaskDto>(task);
        }

        public IEnumerable<TaskDto> TaskListToDto(IEnumerable<Task> task)
        {
            return mapper.Map<IEnumerable<TaskDto>>(task);
        }

        public Task TaskDtoToTask(TaskDto taskDto)
        {
            return mapper.Map<Task>(taskDto);
        }
    }
}
