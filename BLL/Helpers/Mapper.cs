using AutoMapper;
using BLL.Dtos;
using DAL.Entities;
namespace BLL.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ToDoItemDto, ToDoItem>().ReverseMap();
        }
    }
}
