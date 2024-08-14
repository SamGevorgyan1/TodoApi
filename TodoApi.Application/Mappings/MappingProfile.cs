using AutoMapper;
using TodoApi.Application.Command;
using TodoApi.Application.DTO;
using TodoApi.Domain.Entity;

namespace TodoApi.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Todo, TodoDto>();
        CreateMap<CreateTodo, Todo>();
        CreateMap<UpdateTodo, Todo>();
    }
}