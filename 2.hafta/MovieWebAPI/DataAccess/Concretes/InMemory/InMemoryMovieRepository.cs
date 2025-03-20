using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.InMemory
{
    public class InMemoryMovieRepository : IMovieRepository
    {
       
        private readonly List<Movie> _movies  = new()
             {
            new Movie { MovieId = 1, MovieName = "Inception", Duration = 148, Category = "Science Fiction", Director = "Christopher Nolan" },
            new Movie { MovieId = 2, MovieName = "Interstellar", Duration = 169, Category = "Science Fiction", Director = "Christopher Nolan" },
            new Movie {MovieId=3,   MovieName="Upgrade",    Duration=100,   Category="Science Fiction", Director="Leigh Whannell" },
            new Movie { MovieId=4, MovieName="A Beautiful Mind",   Duration=135,      Category="Drama",     Director="Ron Howard" }

             };

      

        public void Add(Movie movie)
        {
            if (_movies.Count > 0)
                movie.MovieId = _movies.Max(m => m.MovieId) + 1; // En büyük ID'yi bulup +1 ekliyoruz
            else
                movie.MovieId = 1; // Eğer liste boşsa, ilk film 1 ID ile başlasın

            _movies.Add(movie);
        }

        public void Delete(int id)
        {
            Movie? movie =_movies.FirstOrDefault(m => m.MovieId == id);
            _movies.Remove(movie);
        }

        public List<Movie> GetAll()
        {
            return _movies;
        }

        public Movie? GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.MovieId == id);           
        }

        public List<Movie> GetByQuery(string? name, string? category)
        {
            return _movies.Where(m =>
               (string.IsNullOrEmpty(name) || m.MovieName.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
               (string.IsNullOrEmpty(category) || m.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
           ).ToList();
        }

        public Movie? Update(int id, Movie movie)
        {
            var existing = _movies.FirstOrDefault(m => m.MovieId == id);
           
            existing.MovieName = movie.MovieName;
            existing.Duration = movie.Duration;
            existing.Category = movie.Category;
            existing.Director = movie.Director;
          
            return existing;
        }
    }
}
