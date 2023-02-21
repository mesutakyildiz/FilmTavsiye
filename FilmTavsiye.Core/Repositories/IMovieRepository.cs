using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Core.Repositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<List<Movie>> GetMovieUserNote(int movieId);
        Task<List<Movie>> GetMovieListPage(int page ,int pageSize);
    }
}
