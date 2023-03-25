﻿using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services
{
	public interface IMoviesService: IEntityBaseRepository<Movie>
	{
		Task<Movie> GetMovieIdAsync(int id);
		Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
		Task AddNewMovieAsync(NewMovieVM data);

		Task UpdateMovieAsync(NewMovieVM data);
	}
}
