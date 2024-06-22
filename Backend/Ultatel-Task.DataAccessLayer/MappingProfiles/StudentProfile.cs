using AutoMapper;
using Ultatel_Task.DataAccessLayer.DTO;
using Ultatel_Task.Models;


namespace Ultatel_Task.DataAccessLayer.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>()
           .ForMember(destination => destination.Student_ID, opt => opt.MapFrom(src => src.Student_ID))
           .ForMember(destination => destination.FirstName, opt => opt.MapFrom(src => src.FirstName))
           .ForMember(destination => destination.LastName, opt => opt.MapFrom(src => src.LastName))
           .ForMember(destination => destination.FullName, opt => opt.MapFrom(src => src.FullName)) 
           .ForMember(destination => destination.Country, opt => opt.MapFrom(src => src.Country))
           .ForMember(destination => destination.Gender, opt => opt.MapFrom(src => src.Gender))
           .ForMember(destination => destination.StudentCreatedBy, opt => opt.MapFrom(src => src.StudentCreatedBy))
           .ForMember(destination => destination.LastAuditedBy, opt => opt.MapFrom(src => src.LastAuditedBy))
           .ForMember(destination => destination.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
           .ForMember(destination => destination.Student_Email, opt => opt.MapFrom(src => src.Student_Email))
           .ReverseMap();
        } 
    }
}
