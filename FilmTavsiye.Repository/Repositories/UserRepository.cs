using FilmTavsiye.Core.Models;
using FilmTavsiye.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Repository.Repositories
{
    internal class UserRepository : GenericRepository<UserApp>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
