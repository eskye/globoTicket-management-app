using AutoMapper;
using GloboTicket.ManagementApp.Application.Features.Events;
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
        }
        
        
    }
}