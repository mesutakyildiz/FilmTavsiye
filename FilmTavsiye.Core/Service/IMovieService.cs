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
    public interface IMovieService : IServiceGeneric<Movie, MovieDto>
    {
        Task<Response<List<MovieWithUserNoteDto>>> GetMovieUserNote(int movieId);
        Task<Response<List<MovieDto>>> GetMovieListPage(int page, int pageSize);

    }
}
