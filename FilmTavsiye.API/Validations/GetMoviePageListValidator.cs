using FilmTavsiye.Core.Dtos;
using FluentValidation;

namespace FilmTavsiye.API.Validations
{
    public class GetMoviePageListValidator : AbstractValidator<GetMoviePageListDto>
    {
        public GetMoviePageListValidator()
        {
            RuleFor(x => x.page).Cascade(CascadeMode.StopOnFirstFailure).GreaterThanOrEqualTo(1).WithMessage("Page must be greater 0");
            RuleFor(x => x.pageSize).Cascade(CascadeMode.StopOnFirstFailure).GreaterThanOrEqualTo(1).WithMessage("PageSize must be greater 0");
        }
    }
}
