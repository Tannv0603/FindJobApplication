using AutoMapper;
using DAL.Entities;
using WebApp.Models.RequestModel;

namespace WebApp.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserRegisterRequest>().ReverseMap();   
            CreateMap<Job,JobRequest>().ReverseMap();   
        }
    }
}
