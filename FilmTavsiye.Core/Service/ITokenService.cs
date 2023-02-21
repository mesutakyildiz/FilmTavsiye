using System;
using System.Collections.Generic;
using System.Text;

using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Models;

namespace FilmTavsiye.Core.Services
{
    public interface ITokenService
    {
        Task<TokenDto> CreateToken(UserApp userApp);
    }
}