using FluentValidation;
using SicopataSchool.Bl.Dtos;
using SicopataSchool.Bl.Validators.Generic;

namespace SicopataSchool.Bl.Validators
{
    public class NoteValidator : BaseValidator<NoteDto>
    {
        public NoteValidator()
        {
            RuleFor(x => x.Title)
                .Length(11)
                .WithMessage("El campo titulo debe contener 11 dígitos");
        }
    }
}
