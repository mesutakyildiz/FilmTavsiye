using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Models;
using FilmTavsiye.Core.Services;
using FilmTavsiye.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FilmTavsiye.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserNoteController : CustomBaseController
    {
        private readonly IServiceGeneric<UserNote,UserNoteDto > _userNoteService;
        private readonly IUserService _userService;

        public UserNoteController(IServiceGeneric<UserNote, UserNoteDto> userNoteService, IUserService userService)
        {
            _userNoteService = userNoteService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return ActionResultInstance(await _userNoteService.GetAllAsync());
        }
        //[Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Save(CreateUserNoteDto userNoteDto)
        {
            var user = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);
            var userNote= new UserNoteDto { MovieId= userNoteDto.MovieId ,Note=userNoteDto.Note,Score=userNoteDto.Score,UserId=user.Data.Id};
            return ActionResultInstance(await _userNoteService.AddAsync(userNote));
        }
        //[Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UserNoteDto userNoteDto)
        {
            return ActionResultInstance(await _userNoteService.Update(userNoteDto, userNoteDto.Id));
        }
        //[Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return ActionResultInstance(await _userNoteService.Remove(id));
        }
    }
}
