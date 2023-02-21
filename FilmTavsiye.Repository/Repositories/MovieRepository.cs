using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Models;
using FilmTavsiye.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Repository.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Movie>> GetMovieListPage(int page, int pageSize)
        {
            var result = await _appDbContext.Movies.OrderBy(x => x.Id).Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
            return result;
        }

        public async Task<List<Movie>> GetMovieUserNote(int movieId)
        {
            var result = await _appDbContext.Movies.Include(x => x.UserNotes).Where(x => x.Id == movieId).ToListAsync();

            return result;
        }
    }
}
