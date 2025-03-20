using Business.Abstracts;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class MovieManager:IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieManager(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAll()
        {
           return _movieRepository.GetAll();
        }

        public Movie? GetById(int id)
        { 
            Movie? movie=_movieRepository.GetById(id);
            if (movie is null)
                throw new BusinessException("Bu id' ye ait bir fiilm bulunamadı.");

            return movie;
        }

        public void Add(Movie movie)
        {
            _movieRepository.Add(movie);
        }

        public Movie? Update(int id, Movie movie)
        {
             return  _movieRepository.Update(id,movie);
        }

        public void Delete(int id)
        {

            Movie? movie=_movieRepository.GetById(id);
            if (movie is null) 
            throw new BusinessException("Bu id'ye ait bir film bulunamadı"); 

            _movieRepository.Delete(id);

        
        }

        public List<Movie> GetByQuery(string? name, string? category)
        {
          return _movieRepository.GetByQuery(name,category);
        }
    }
}
