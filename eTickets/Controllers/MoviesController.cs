using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
       
        private readonly IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var _allMovies = await _service.GetAllAsync(n =>n.Cinema);
            return View(_allMovies);
        }

        public async Task<IActionResult> Details(int id)
        { var movieDetail = await _service.GetMovieByIdAsync(id);
          return View(movieDetail);
        
        }
        //Get Movies
        public async Task<IActionResult> Create()
        {

            var movieDropDownList = await _service.GetNewMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropDownList.Cinemas, "Id", "Name");
            ViewBag.Producers= new SelectList(movieDropDownList.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownList.Actors, "Id", "FullName");
            return View();

        }
    }
}
