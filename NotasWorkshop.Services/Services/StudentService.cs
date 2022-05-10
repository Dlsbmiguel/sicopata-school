using AutoMapper;
using SicopataSchool.Bl.Dtos;
using SicopataSchool.Model.Contexts.SicopataSchool;
using SicopataSchool.Model.Entities;
using SicopataSchool.Model.UnitOfWorks;
using SicopataSchool.Services.Generic;


namespace SicopataSchool.Services.Services
{
    public interface IStudentService : IEntityCRUDService<Student, StudentDto>
    {
        // Agregar mas metodo al servicio
    }
    public class StudentService : EntityCRUDService<Student, StudentDto>, IStudentService
    {
        public StudentService(IMapper mapper, IUnitOfWork<ISicopataSchoolDbContext> uow)
            : base(mapper, uow)
        {
        }
    }
}
