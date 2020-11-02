using AutoMapper;
using MLRSIntroductoryWebApi.DTO;
using MLRSIntroductoryWebApi.Models;

namespace MLRSIntroductoryWebApi.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Birthdate, y => y.MapFrom(z => z.Birthdate))
                .ForMember(x => x.EmailAddress, y => y.MapFrom(z => z.EmailAddress))
                .ForMember(x => x.UserTitleId, y => y.MapFrom(z => z.UserTitleId))
                .ForMember(x => x.UserTypeId, y => y.MapFrom(z => z.UserTypeId))
                .ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<UserDTO, User>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Birthdate, y => y.MapFrom(z => z.Birthdate))
                .ForMember(x => x.EmailAddress, y => y.MapFrom(z => z.EmailAddress))
                .ForMember(x => x.UserTitleId, y => y.MapFrom(z => z.UserTitleId))
                .ForMember(x => x.UserTypeId, y => y.MapFrom(z => z.UserTypeId))
                .ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
