using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public override async Task<StudentDto> GetById(int id)
        {
            if (_repository is null) return new StudentDto();
            var student = await _repository.GetAll().Include(x => x.Notes).Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<StudentDto>(student);
        }
    }
}
