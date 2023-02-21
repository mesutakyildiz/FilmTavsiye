using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Core.Models
{
    public class Movie : BaseEntity
    {
        public int ApiId { get; set; }  
        public bool? Adult { get; set; }
        public string? MediaTypes { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public decimal Popularity { get; set; }
        public string? PosterPath { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Title { get; set; }
        public bool? Video { get; set; }
        public decimal? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public ICollection<UserNote> UserNotes { get; set; }

    }
}
