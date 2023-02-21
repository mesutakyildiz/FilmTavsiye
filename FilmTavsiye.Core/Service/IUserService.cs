using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Models;

namespace FilmTavsiye.Core.Services
{
    public interface IUserService : IServiceGeneric<UserApp, UserAppDto>
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<Response<UserAppDto>> GetUserByNameAsync(string userName);


        Task<Response<NoContent>> CreateUserRoles(string userId,string role);
        Task<Response<NoContent>> CreateRoles(string role);

        Task<Response<UserAppDto>> UpdateUserAsync(UpdateUserDto updateUserDto);
        Task<Response<NoContent>> DeleteUserAsync(string userId);
    }
}