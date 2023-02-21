using FilmTavsiye.Core.Dtos;
using FluentValidation;

namespace FilmTavsiye.API.Validations
{
    public class CreateUserNoteValidator : AbstractValidator<CreateUserNoteDto>
    {
        public CreateUserNoteValidator()
        {
            RuleFor(x => x.Score).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Score is required").ExclusiveBetween(1,10).WithMessage("Score must be in the range 1-10");
        }
    }
}
