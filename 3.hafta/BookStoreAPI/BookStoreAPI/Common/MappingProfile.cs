using AutoMapper;
using BookStoreAPI.Applications.BookOperations.Commands.CreateBook;
using BookStoreAPI.Applications.BookOperations.Commands.GetBookDetail;
using BookStoreAPI.Applications.BookOperations.Commands.GetBooks;
using BookStoreAPI.Applications.BookOperations.Commands.UpdateBook;
using static CreateGenreCommand;
using static GetGenreDetailQuery;
using static GetGenresQuery;
using static UpdateGenreCommand;
using static GetAuthorsQuery;
using static GetAuthorDetailQuery;
using static CreateAuthorCommand;
using static UpdateAuthorCommand;

namespace BookStoreAPI.Common
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
			CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
			CreateMap<CreateBookCommand.CreateBookViewModel, Book>();
			CreateMap<UpdateBookViewModel, Book>();
			
			CreateMap<Genre, GenreViewModel>();
			CreateMap<Genre, GenreDetailViewModel>();
			CreateMap<CreateGenreViewModel, Genre>();
			CreateMap<UpdateGenreViewModel, Genre>();
			
			CreateMap<Author, AuthorsViewModel>();
			CreateMap<Author, AuthorDetailViewModel>();
			CreateMap<CreateAuthorViewModel, Author>();
			CreateMap<UpdateAuthorViewModel, Author>();
			
			CreateMap<CreateUserViewModel, User>();
		}
	}
}