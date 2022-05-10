using AutoMapper;
using SicopataSchool.Bl.Dtos;
using SicopataSchool.Bl.Extensions;
using SicopataSchool.Model.Entities;

namespace SicopataSchool.Bl.Mappings
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            this._CreateMap_WithConventions_FromAssemblies<Note, NoteDto>();

            /// CreateMap<Note, NoteDto>().ReverseMap();
            /// CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
