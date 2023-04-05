using AutoMapper;
using ToDoApplication.WebAPI.DTO;
using ToDoApplication.WebAPI.Model;

namespace ToDoApplication.WebAPI.MappingProfile
{
    public class ToDoMappingProfile : Profile
    {
        public ToDoMappingProfile()
        {
            CreateMap<ToDoCreateDTO, To_Do_Item>().ReverseMap();
            CreateMap<To_Do_Item, ToDoGetDTO>().ReverseMap();
        }
    }
}
