using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Data.ViewModel;
using eTickets.Models;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
       
        private readonly IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        //Home: //Index
        public async Task<IActionResult> Index()
        {
            var _allMovies = await _service.GetAllAsync(n =>n.Cinema);
            return View(_allMovies);
        }
        //for searching of movie 
        public async Task<IActionResult> Filter(string searchString)
        {
            var _allMovies = await _service.GetAllAsync(n => n.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = _allMovies.Where(n => n.Name.Contains(searchString) || 
                                    n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            
            }
            return View("Index",_allMovies);
        }


        //Details
        public async Task<IActionResult> Details(int id)
        { var movieDetail = await _service.GetMovieByIdAsync(id);
          return View(movieDetail);
        
        }
        //Get Movies:Edit
        public async Task<IActionResult> Create()
        {

            var movieDropDownList = await _service.GetNewMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropDownList.Cinemas, "Id", "Name");
            ViewBag.Producers= new SelectList(movieDropDownList.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownList.Actors, "Id", "FullName");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM newMovieVM)
        {    if (!ModelState.IsValid)
                {
                return View(newMovieVM);
                }
            await _service.AddNewMovieAsync(newMovieVM);
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null)
                return View("NotFound");
            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                ProducerId = movieDetails.ProducerId,
                CinemaId = movieDetails.CinemaId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),

            };


            var movieDropDownList = await _service.GetNewMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropDownList.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownList.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownList.Actors, "Id", "FullName");
            return View(response);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id ,NewMovieVM newMovieVM)
        {
            if (id != newMovieVM.Id) return View("Notfound");

            
            
           if (!ModelState.IsValid)
            {
                return View(newMovieVM);
            }
            await _service.UpdateMovieAsync(newMovieVM);
            return RedirectToAction(nameof(Index));

        }


    }
}
