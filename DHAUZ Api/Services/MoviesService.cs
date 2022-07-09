using DHAUZ_Api.Data;
using DHAUZ_Api.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace DHAUZ_Api.Services
{
    public static class MoviesService
    {
        private static string apiKey = "6cd4f60d";

        public static List<MovieVM> GetAll(MovieDbContext context)
        {
            return context.Movies.ToList();
        }

        public static MovieVM GetById(MovieDbContext context, int id)
        {
            return context.Movies.Where(w => w.Id == id).FirstOrDefault();
        }

        public static MovieVM GetByIdImdb(MovieDbContext context, string id)
        {
            return context.Movies.Where(w => w.IdImdb == id).FirstOrDefault();
        }

        public static string Save(MovieDbContext context, string idImdb)
        {
            var lastMovieAdded = context.Movies.OrderByDescending(o => o.Id).FirstOrDefault();

            int id = 0;
            if (lastMovieAdded != null) id = lastMovieAdded.Id;

            //Buscar filme no omdb
            RestClient client = new RestClient("http://www.omdbapi.com/");
            RestRequest request = new RestRequest("", Method.Get);

            request.AddHeader("Accept", "");
            request.AddParameter("apikey", apiKey);
            request.AddParameter("i", idImdb);

            var response = client.Execute(request);

            MovieOmdb? movie = null;

            if (response.IsSuccessful)
            {
                movie = JsonConvert.DeserializeObject<MovieOmdb>(response.Content);
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }

            MovieVM newMovie = new MovieVM()
            {
                Id = id,
                IdImdb = movie.imdbID,
                Name = movie.Title,
                Description = movie.Plot,
                ReleaseDate = movie.Released,
                Genre = movie.Genre,
                Watched = false,
                UserScore = Convert.ToDouble(movie.imdbRating.Replace(".", ","))
            };

            context.Movies.Add(newMovie);
            context.SaveChanges();

            return "Filme adicionado com sucesso.";
        }

        public static string Update(MovieDbContext context, MovieVM vm)
        {
            var movie = context.Movies.Find(vm.Id);

            if(movie != null)
            {
                if (!string.IsNullOrEmpty(vm.Name)) movie.Name = vm.Name;
                if (!string.IsNullOrEmpty(vm.Description)) movie.Description = vm.Description;
                if (!string.IsNullOrEmpty(vm.ReleaseDate)) movie.ReleaseDate = vm.ReleaseDate;
                if (!string.IsNullOrEmpty(vm.Genre)) movie.Name = vm.Genre;
                if (vm.Watched != null) movie.Watched = vm.Watched;
                if (vm.UserScore != null) movie.UserScore = vm.UserScore;

                context.SaveChanges();
            }

            return "Operação realizada com sucesso.";
        }

        public static string Delete(MovieDbContext context, int id)
        {
            var movie = context.Movies.Find(id);

            if (movie != null)
            {
                context.Movies.Remove(movie);

                context.SaveChanges();
            }

            return "Operação realizada com sucesso.";
        }
    }
}
