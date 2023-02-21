using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Models;
using FilmTavsiye.Core.Services;
using System.Security.Claims;
using FilmTavsiye.Core.UnitOfWork;
using FilmTavsiye.Core.Repositories;
using System.Text.RegularExpressions;
using System.Globalization;

namespace FilmTavsiye.Service.Services
{
    public class UserService : ServiceGeneric<UserApp, UserAppDto>, IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IGenericRepository<UserApp> genericRepository, UserManager<UserApp> userManager, RoleManager<IdentityRole> roleManager, IUserRepository userRepository) : base(unitOfWork, genericRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepository = userRepository;
        }

     
        public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
           
            var checkPhone = _userRepository.Where(x => x.PhoneNumber == createUserDto.PhoneNumber);
            if (checkPhone.Any())
            {
                return Response<UserAppDto>.Fail(new ErrorDto("Phone number is used", true), 400);
            }
            var nName= Regex.Replace(createUserDto.FirstName, @"\s+", "").ToUpper(new CultureInfo("tr-TR", false)).ToLower(new CultureInfo("en-En",true));
            var nSName = Regex.Replace(createUserDto.Surname, @"\s+", "").ToUpper(new CultureInfo("tr-TR", false)).ToLower(new CultureInfo("en-EN", true));
            var rnd = new Random();
            var kod = rnd.Next(1111, 99999).ToString();
            var username = string.Concat(nName,nSName,"@",kod);
            var user = new UserApp { FirstName = createUserDto.FirstName, Surname = createUserDto.Surname, PhoneNumber = createUserDto.PhoneNumber,Email=createUserDto.Email, UserName = username };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<UserAppDto>.Fail(new ErrorDto(errors, true), 400);
            }
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }

        public async Task<Response<NoContent>> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Response<NoContent>.Fail("UserName not found", 404, true);
            }
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<NoContent>.Fail(new ErrorDto(errors, true), 400);
            }
            return Response<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<Response<UserAppDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Response<UserAppDto>.Fail("UserName not found", 404, true);
            }

            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }

        public async Task<Response<UserAppDto>> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByIdAsync(updateUserDto.Id);
            if (user == null)
            {
                return Response<UserAppDto>.Fail("UserName not found", 404, true);
            }
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<UserAppDto>.Fail(new ErrorDto(errors, true), 400);
            }
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }

        public async Task<Response<NoContent>> CreateUserRoles(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Response<NoContent>.Fail("User is not found", 404, true);
            }
            if (!await _roleManager.RoleExistsAsync(role))
            {
                return Response<NoContent>.Fail("Role is not found", 404, true);
            }

            await _userManager.AddToRoleAsync(user, role);

            return Response<NoContent>.Success(StatusCodes.Status201Created);

        }

        public async Task<Response<NoContent>> CreateRoles(string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                return Response<NoContent>.Fail("Role is not found", 404, true);
            }

            await _roleManager.CreateAsync(new() { Name = role });
            return Response<NoContent>.Success(StatusCodes.Status201Created);
        }

    }
}