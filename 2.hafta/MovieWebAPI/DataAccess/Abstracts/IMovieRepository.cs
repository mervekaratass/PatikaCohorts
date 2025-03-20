using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IMovieRepository
    {
        Movie? GetById(int id);
        List<Movie> GetAll();
        void Add(Movie movie);
        Movie? Update(int id, Movie movie);
        List<Movie> GetByQuery(string? name, string? category);
        void Delete(int id);
       
    }
}
