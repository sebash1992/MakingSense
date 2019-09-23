using application.API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.API.Dto
{
    public class PostDto
    {
        public string Id {get; set;}
        public string  Title { get; set; }
        public string  Body { get; set; }
        public string  State { get; set; }
        public DateTime  CreationDate { get; set; }
        public string ClientId {get; set;}
        public string Owner  { get; set; }
    }
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>()
            .ForMember(dest => dest.Owner, opt =>
            {
                opt.MapFrom(src => src.Client.FirstName + " " + src.Client.LastName);
            });

            CreateMap<PostDto, Post>()

                .ForMember(x => x.ClientId, opt => opt.AllowNull())

                .ForMember(x => x.Id, opt => opt.AllowNull())

                .ForMember(x => x.CreationDate, opt => opt.AllowNull())
                .ForMember(x => x.Client, opt => opt.Ignore());

        }
    }
}
