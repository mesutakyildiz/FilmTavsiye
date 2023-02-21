using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmTavsiye.Core.Dtos;

namespace FilmTavsiye.API.Validations
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
  
        public CreateUserDtoValidator()
        {
            

            
            RuleFor(x => x.FirstName).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Name is required").Must(IsValidName).WithMessage("{PropertyName} is must be char.");
            RuleFor(x => x.Surname).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("SurName is required").Must(IsValidName).WithMessage("{PropertyName} is must be char.");
            RuleFor(x => x.Email).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is wrong");
            RuleFor(x => x.PhoneNumber).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("PhoneNumber is required").Length(10,10).WithMessage("PhoneNumber is must 10 digit.").Must(IsValidNumber).WithMessage("PhoneNumber is wrong");
            RuleFor(x => x.Password).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Password is required");


        }
        private bool IsValidNumber(string name)
        {
            return name.All(Char.IsNumber);
        }
        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}