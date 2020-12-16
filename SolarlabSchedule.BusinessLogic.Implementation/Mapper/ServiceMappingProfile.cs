using AutoMapper;
using SolarlabSchedule.BusinessLogic.Contract.Models;
using SolarSchedule.AccessLayer.Entities;

namespace SolarlabSchedule.BusinessLogic.Implementation.Mapper
{
    /// <summary>
    /// AutoMapper 
    /// entity => DTO
    /// DTO => Entity
    /// </summary>
    public class ServiceMappingProfile:Profile
    {
        
        public ServiceMappingProfile()
        {
            // из таск в таскДТО
            CreateMap<Task, TaskDto>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Description, x => x.MapFrom(y => y.Description))
                .ForMember(x => x.DeadLine, x => x.MapFrom(y => y.DeadLine));

            // из таскДТО в таск
            CreateMap<TaskDto, Task>()
                .ForMember(x => x.User, x => x.Ignore());

            // из юзера в юзердто
            CreateMap<User, UserDto>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name));

            // а теперь наоборот
            CreateMap<UserDto, User>()
                .ForMember(x => x.Task, x => x.Ignore());
        }
    }
}