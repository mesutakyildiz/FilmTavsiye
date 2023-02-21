using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Models;
using FilmTavsiye.Core.Repositories;
using FilmTavsiye.Core.Service;
using FilmTavsiye.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Service.Services
{
    public class UserNoteService : ServiceGeneric<UserNote, UserNoteDto>, IUserNoteService
    {
        public UserNoteService(IUnitOfWork unitOfWork, IGenericRepository<UserNote> genericRepository) : base(unitOfWork, genericRepository)
        {
        }
    }
}
