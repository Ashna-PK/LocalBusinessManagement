using AutoMapper;
using Booking.Models;

namespace Booking.Services
{
    public class MappingProfile :Profile
    {
        public MappingProfile() { 
        CreateMap<Bookin,BookinDto>().ReverseMap();
        }
    }
}
