using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TaskManager.Common.DTO;
using TaskManager.Models;

namespace TaskManager
{
    public class PresentationAutoMapperConfig : IPresentationAutoMapperConfig
    {
        readonly private IMapper mapper;
        public PresentationAutoMapperConfig()
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
        public IEnumerable<Task> DtoListToTask(IEnumerable<TaskDto> task)
        {
            return mapper.Map<IEnumerable<Task>>(task);
        }
        public Task TaskDtoToTask(TaskDto taskDto)
        {
            return mapper.Map<Task>(taskDto);
        }
    }
}
