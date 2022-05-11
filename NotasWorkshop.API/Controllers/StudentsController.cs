using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SicopataSchool.Api.Controllers;
using SicopataSchool.Bl.Dtos;
using SicopataSchool.Model.Entities;
using SicopataSchool.Services.Services;

namespace SicopataSchool.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BaseController<Student, StudentDto>
    {
        public StudentsController(IStudentService studentService,
            IValidatorFactory validationFactory,
            IMapper mapper)
            : base(studentService, validationFactory, mapper)
        {

        }

    }
}
