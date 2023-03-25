using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        //GET: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieIdAsync(id);
            return View(movieDetail);
        }

        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

		//GET: Movies/Edit/1
		public async Task<IActionResult> Edit(int id)
		{
			var movieDetails = await _service.GetMovieIdAsync(id);
			if (movieDetails == null) return View("NotFound");

			var response = new NewMovieVM()
			{
				Id = movieDetails.Id,
				Name = movieDetails.Name,
				Description = movieDetails.Description,
				Price = movieDetails.Price,
				StartDate = movieDetails.StartDate,
				EndDate = movieDetails.EndDate,
				ImageURL = movieDetails.ImageURL,
				MovieCategory = movieDetails.MovieCategory,
				CinemaId = movieDetails.CinemaId,
				ProducerId = movieDetails.ProducerId,
				ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
			};

			var movieDropdownData = await _service.GetNewMovieDropdownsValues();
			ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
			ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
			ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");

			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, NewMovieVM movie)
		{
			if (id != movie.Id) return View("NotFound");

			if (!ModelState.IsValid)
			{
				var movieDropdownData = await _service.GetNewMovieDropdownsValues();

				ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
				ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
				ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");

				return View(movie);
			}

			await _service.UpdateMovieAsync(movie);
			return RedirectToAction(nameof(Index));
		}
	}
}
