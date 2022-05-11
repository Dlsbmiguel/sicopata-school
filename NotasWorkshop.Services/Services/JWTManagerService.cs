using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SicopataSchool.Bl.Dtos;
using SicopataSchool.Model.Contexts.SicopataSchool;
using SicopataSchool.Model.Entities;
using SicopataSchool.Model.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.Services.Services
{
    public interface IJWTManagerService
    {
        JWTToken GetToken(LogInDto student);
    }
    public class JWTManagerService: IJWTManagerService
    {
        private readonly IConfiguration _iconfiguration;
        private readonly IUnitOfWork<ISicopataSchoolDbContext> _uow;
        public JWTManagerService(IMapper mapper, IUnitOfWork<ISicopataSchoolDbContext> uow, IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
            _uow = uow;

        }
        
        public JWTToken GetToken(LogInDto student)
        {
            var verifyStudent =  _uow.context.GetDbSet<Student>().Where(x => x.EnrollmentCode == student.EnrollmentCode).SingleOrDefaultAsync();
            if (verifyStudent == null) { return null; }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, student.EnrollmentCode)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                //RefreshToken = new ClaimsIdentity(new Claim[]
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new JWTToken { Token = tokenHandler.WriteToken(token) };

        }
    }
}

