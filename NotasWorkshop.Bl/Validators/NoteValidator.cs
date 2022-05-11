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
                .NotEmpty().NotNull()
                .MaximumLength(15)
                .WithMessage("El campo titulo debe contener 15 caracteres");
            RuleFor(x => x.Content)
                .NotNull()
                .NotEmpty()
                .MaximumLength(80)
                .WithMessage("El contenido debe tener 80 caracteres");
            RuleFor(x => x.IsPrivate).
                NotNull()
                .WithMessage("Debe indicar si la nota es privada o no");
            RuleFor(x => x.StudentId).NotNull()
                .WithMessage("Debe indicar el ID del estudiante");
        }
    }
}
