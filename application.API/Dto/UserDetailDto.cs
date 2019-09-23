using application.API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.API.Dto
{
    public class UserDetailDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class UserDetailProfile : Profile
    {
        public UserDetailProfile()
        {
            CreateMap<AppUser, UserDetailDto>()
                .ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<UserDetailDto, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));

        }
    }
}
