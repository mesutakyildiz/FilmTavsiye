using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmTavsiye.Core.Dtos;

namespace FilmTavsiye.API.Validations
{
    public class MailDtoValidator : AbstractValidator<MailDto>
    {
  
        public MailDtoValidator()
        {
 
            RuleForEach(x => x.EmailAdress).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is wrong");
    
        }

    
    }
}