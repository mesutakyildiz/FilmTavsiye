using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Services;

namespace FilmTavsiye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;
  
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

 
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            return ActionResultInstance(await _userService.UpdateUserAsync(updateUserDto));
        }

        [Authorize]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            return ActionResultInstance(await _userService.DeleteUserAsync(userId));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return ActionResultInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }


        //[Authorize(Roles ="admin")]
        //[HttpPost("[action]/{userId}/{role}")]
        //public async Task<IActionResult> CreateUserRoles(string userId,string role)
        //{
        //    return ActionResultInstance(await _userService.CreateUserRoles(userId,role));
        //}

        //[Authorize(Roles = "admin")]
        //[HttpPost("[action]/{role}")]
        //public async Task<IActionResult> CreateRoles(string role)
        //{
        //    return ActionResultInstance(await _userService.CreateRoles(role));
        //}
       
    }
}