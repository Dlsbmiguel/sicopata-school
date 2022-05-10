using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SicopataSchool.Api.Controllers;
using SicopataSchool.Bl.Dtos;
using SicopataSchool.Model.Entities;
using SicopataSchool.Services.Services;

namespace SicopataSchool.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : BaseController<Note, NoteDto>
    {
        public NotesController(INoteService noteService,
            IValidatorFactory validationFactory,
            IMapper mapper) 
            : base(noteService, validationFactory, mapper)
        {
        }
    }
}
