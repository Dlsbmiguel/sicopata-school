using AutoMapper;
using SicopataSchool.Bl.Dtos;
using SicopataSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.Bl.Mappings
{
    public class LogInProfile: Profile
    {
        public LogInProfile()
        {
            CreateMap<Student, LogInDto>().ReverseMap();
            //ForMember(dest => dest.EnrollmentCode, opt => opt.MapFrom(src => src.EnrollmentCode));
        }
    }
}
