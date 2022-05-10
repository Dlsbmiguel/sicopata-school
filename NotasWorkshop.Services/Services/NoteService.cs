using AutoMapper;
using SicopataSchool.Bl.Dtos;
using SicopataSchool.Model.Contexts.SicopataSchool;
using SicopataSchool.Model.Entities;
using SicopataSchool.Model.UnitOfWorks;
using SicopataSchool.Services.Generic;

namespace SicopataSchool.Services.Services
{
    public interface INoteService : IEntityCRUDService<Note, NoteDto>
    {
        // Agregar mas metodo al servicio
    }

    public class NoteService : EntityCRUDService<Note, NoteDto>, INoteService
    {
        public NoteService(IMapper mapper, IUnitOfWork<ISicopataSchoolDbContext> uow) 
            : base(mapper, uow)
        {
            
        }
    }
}
