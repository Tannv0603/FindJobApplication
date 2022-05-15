using AutoMapper;
using DAL.Entities;
using WebApp.Models.RequestModel;

namespace WebApp.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, EmployeeRegisterRequest>().ReverseMap();   
            CreateMap<Job,JobCreateRequest>().ReverseMap();   
        }
    }
}
