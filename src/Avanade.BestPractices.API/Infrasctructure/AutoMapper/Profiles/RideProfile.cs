using AutoMapper;
using Avanade.BestPractices.API.Models.Ride;
using Avanade.BestPractices.Domain.Entities;

namespace Avanade.BestPractices.API.Infrasctructure.AutoMapper.Profiles
{
    public class RideProfile : Profile
    {
        public RideProfile()
        {
            CreateMap<Ride, RideModel>();
        }
    }
}
