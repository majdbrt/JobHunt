using System.Net.Mime;
using AutoMapper;
using JobHuntApi.DTO.Application;
using JobHuntApi.DTO.Interview;
using JobHuntApi.DTO.User;
using JobHuntApi.Models;

namespace JobHuntApi.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Application, GetApplicationDto>().ReverseMap();
            CreateMap<Application, UpdateApplicationDto>().ReverseMap();
            CreateMap<Application, CreateApplicationDto>().ReverseMap();

            CreateMap<Interview, GetInterviewDto>().ReverseMap();
            CreateMap<Interview, UpdateInterviewDto>().ReverseMap();
            CreateMap<Interview, CreateInterviewDto>().ReverseMap();

            CreateMap<User, RegisterUserDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();
        }
    }
}