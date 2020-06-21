using AutoMapper;
using Drafter.Model;
using Drafter.Model.Resources;

namespace Drafter
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Mapping
            CreateMap<User, UserResource>();
            CreateMap<CreateUserResource, User>();
            CreateMap<UpdateUserResource, User>();
            CreateMap<AuthenticationResource, User>();

            // Team Mapping
            CreateMap<Team, TeamResource>();
            CreateMap<CreateTeamResource, Team>();
            CreateMap<UpdateTeamResource, Team>();
        }
    }
}