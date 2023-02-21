using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Models;
using FilmTavsiye.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Core.Service
{
    public interface IUserNoteService : IServiceGeneric<UserNote, UserNoteDto>
    {
    }
}
