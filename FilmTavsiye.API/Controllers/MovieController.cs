using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Models;
using FilmTavsiye.Core.Service;
using FilmTavsiye.Core.Services;
using FilmTavsiye.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;

namespace FilmTavsiye.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : CustomBaseController
    {
        private readonly IServiceGeneric<Movie, MovieDto> _movieService ;
        private readonly IMovieService _defaulMovieService;
        private readonly IMailService _mail;
        private readonly IUserService _userService;


        public MovieController(IServiceGeneric<Movie, MovieDto> movieService, IMovieService defaulMovieService, IMailService mail, IUserService userService)
        {
            _movieService = movieService;
            _defaulMovieService = defaulMovieService;
            _mail = mail;
            _userService = userService;
        }
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{

        //    return ActionResultInstance(await _movieService.GetAllAsync());
        //}

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetMovieWithUserNot(int id)

        {
            var movie = await _defaulMovieService.GetMovieUserNote(id);
            return ActionResultInstance(movie);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetMovieListPage(GetMoviePageListDto pageListDto)

        {
            var movie = await _defaulMovieService.GetMovieListPage(pageListDto.page, pageListDto.pageSize);
            return ActionResultInstance(movie);
        }

        ////[Authorize(Roles = "admin")]
        //[HttpPost]
        //public async Task<IActionResult> Save(MovieDto movieDto)
        //{
            
        //    return ActionResultInstance(await _movieService.AddAsync(movieDto));
        //}
        ////[Authorize(Roles = "admin")]
        //[HttpPut]
        //public async Task<IActionResult> Update(MovieDto movieDto)
        //{
        //    return ActionResultInstance(await _movieService.Update(movieDto, movieDto.Id));
        //}
        ////[Authorize(Roles = "admin")]
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return ActionResultInstance(await _movieService.Remove(id));
        //}
        [HttpPost("[action]")]
        public async Task<IActionResult> SendMailAsync(MailDto mailDto)
        {
            var user = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);
            var movie = await _movieService.GetByIdAsync(mailDto.MovieId);
            if (movie.Data != null)
            {
                var mailData = new MailData(mailDto.EmailAdress, "Filmtavsiye.io'dan mesaj var", $"{string.Concat(user.Data.FirstName, ' ', user.Data.Surname)} sana {DateOnly.FromDateTime(movie.Data.ReleaseDate)} tarihinde çıkan {movie.Data.Title} adlı filmi öneriyor.");
                bool result = await _mail.SendAsync(mailData, new CancellationToken());

                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, "Mail has successfully been sent.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. The Mail could not be sent.");
                }
            }
            return StatusCode(StatusCodes.Status404NotFound, "MovieId is not found.");
        }
            
    }
}
