using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Models;
using FilmTavsiye.Core.Repositories;
using FilmTavsiye.Core.Service;
using FilmTavsiye.Core.Services;
using FilmTavsiye.Core.UnitOfWork;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
namespace FilmTavsiye.Service.Services
{

    public class MovieService : ServiceGeneric<Movie, MovieDto>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        
        public MovieService(IUnitOfWork unitOfWork, IGenericRepository<Movie> genericRepository, IMovieRepository movieRepository) : base(unitOfWork, genericRepository)
        {
            _movieRepository = movieRepository;
           
        }

        public async Task<Response<List<MovieDto>>> GetMovieListPage(int page, int pageSize)
        {
            var movie = await _movieRepository.GetMovieListPage(page,pageSize);
            return Response<List<MovieDto>>.Success(ObjectMapper.Mapper.Map<List<MovieDto>>(movie), 200);
        }

        public async Task<Response<List<MovieWithUserNoteDto>>> GetMovieUserNote(int movieId)
        {
            var movie = await _movieRepository.GetMovieUserNote(movieId);

            return Response<List<MovieWithUserNoteDto>>.Success(ObjectMapper.Mapper.Map<List<MovieWithUserNoteDto>>(movie), 200);
        }

      
    }
}
