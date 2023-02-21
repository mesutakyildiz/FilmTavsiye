using FilmTavsiye.Core.Models;
using FilmTavsiye.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Repository.Repositories
{
    public class UserNoteRepository : GenericRepository<UserNote>, IUserNoteRepository
    {
        public UserNoteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
