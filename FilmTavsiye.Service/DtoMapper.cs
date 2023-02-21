using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Models;

namespace FilmTavsiye.Service
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<UserApp, UserAppDto>().ReverseMap();
            CreateMap<UserNote, UserNoteDto>().ReverseMap();
            CreateMap<Movie, MovieWithUserNoteDto>().ReverseMap().ForMember(x => x.UserNotes, y => y.MapFrom(y => y.UserNotes.Select(z => z.MovieId))); 
        }
    }
}