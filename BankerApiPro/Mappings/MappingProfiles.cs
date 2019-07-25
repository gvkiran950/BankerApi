using AutoMapper;
using Banker.Entity;
using Banker.Models;

namespace Banker.Api.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}