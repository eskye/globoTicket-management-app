using AutoMapper;
using GloboTicket.ManagementApp.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.ManagementApp.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.ManagementApp.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.ManagementApp.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.ManagementApp.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.ManagementApp.Application.Features.Events.Queries.GetEventList;
using GloboTicket.ManagementApp.Domain.Entities;

namespace GloboTicket.ManagementApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListDto>().ReverseMap();
            CreateMap<Event, EventDetailDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListDto>();
            CreateMap<Category, CategoryEventListDto>();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
        }
        
        
    }
}