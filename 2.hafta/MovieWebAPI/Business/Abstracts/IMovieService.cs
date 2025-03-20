using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        Movie? GetById(int id);
        void Add(Movie movie);
        Movie? Update(int id, Movie movie);
        void Delete(int id);
        List<Movie> GetByQuery(string? name, string? category);
    }
}
