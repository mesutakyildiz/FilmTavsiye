using FilmTavsiye.Core.Dtos;
using FilmTavsiye.Core.Models;
using FilmTavsiye.Core.Services;
using Newtonsoft.Json;

namespace FilmTavsiye.Service.Extensions
{
    public class Job
    {

        private const string theMovieDbApiKey = "f7292ef50cebaa3134b6628fc1f781f2";
        private const int movieId = 28;
        private readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://api.themoviedb.org//3//")
        };

        private readonly IServiceGeneric<Movie, MovieDto> _movieService;

        public Job(IServiceGeneric<Movie, MovieDto> movieService)
        {
            _movieService = movieService;
        }

        public async Task Jobs()  
        {
            var request = httpClient.GetAsync($"genre//movie//list?api_key={theMovieDbApiKey}").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<MovieList>(response);
            foreach (var item in value.genres )
            {
                var request1 = httpClient.GetAsync($"list//{item.id}?api_key={theMovieDbApiKey}").Result;
                var response1 = request1.Content.ReadAsStringAsync().Result;
                var value1 = JsonConvert.DeserializeObject<Root>(response1);

                if (value1.items!=null)
                {
                    foreach (var x in value1.items)
                    {
                        var any = await _movieService.Where(z => z.ApiId == x.id);
                        if (any.Data.Any())
                        {
                            var data = any.Data.FirstOrDefault();
                            await _movieService.Update(new MovieDto { Id = data.Id, ApiId = x.id, Adult = x.adult, MediaTypes = x.media_type, OriginalLanguage = x.original_language, OriginalTitle = x.original_title, Overview = x.overview, Popularity = x.popularity, PosterPath = x.poster_path, ReleaseDate = DateTime.Parse(x.release_date), Title = x.title, Video = x.video, VoteAverage = x.vote_average, VoteCount = x.vote_count }, data.Id);
                        }
                        else
                        {
                            await _movieService.AddAsync(new MovieDto { Adult = x.adult, MediaTypes = x.media_type, OriginalLanguage = x.original_language, OriginalTitle = x.original_title, Overview = x.overview, Popularity = x.popularity, PosterPath = x.poster_path, ReleaseDate = DateTime.Parse(x.release_date), Title = x.title, Video = x.video, VoteAverage = x.vote_average, VoteCount = x.vote_count, ApiId = x.id });
                        }

                    }
                }
             
            }

            
        }
        public class Item
        {
            public bool adult { get; set; }
            public string backdrop_path { get; set; }
            public List<int> genre_ids { get; set; }
            public int id { get; set; }
            public string media_type { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public string overview { get; set; }
            public decimal popularity { get; set; }
            public string poster_path { get; set; }
            public string release_date { get; set; }
            public string title { get; set; }
            public bool video { get; set; }
            public decimal vote_average { get; set; }
            public int vote_count { get; set; }
        }

        public class Root
        {
            public string created_by { get; set; }
            public string description { get; set; }
            public int favorite_count { get; set; }
            public int id { get; set; }
            public List<Item> items { get; set; }
            public int item_count { get; set; }
            public string iso_639_1 { get; set; }
            public string name { get; set; }
            public string poster_path { get; set; }
        }
        public class Genre
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public class MovieList
        {
            public List<Genre> genres { get; set; }
        }
    }
}
