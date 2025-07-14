using AutoMapper;
using TicketSupport.Application.DTOs.Auth;
using TicketSupport.Application.DTOs.User;
using TicketSupport.Domain.Entities;

namespace TicketSupport.Application.Common.Mappings
{
  public class UserMappingProfile : Profile
  {
    public UserMappingProfile()
    {
      // User → AuthResponseDto
      CreateMap<User, AuthResponseDto>()
          .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Uuid))
          .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
          .ForMember(dest => dest.Token, opt => opt.Ignore());

      // RegisterDto → User
      CreateMap<RegisterDto, User>()
          .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
          .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());

      // User → UserDto
      CreateMap<User, UserDto>()
        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Uuid));
    }
  }
}
