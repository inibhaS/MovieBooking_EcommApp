using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using eTickets.Data.Services;
using System.Threading.Tasks;
using eTickets.Models;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        
        //service Dependency injection  in constructor 
        //by creating Actorservice class & interface IActorService
        //then registering the services in Configure Service of Startup class & the lifetile is scoped .

        private readonly IActorService _service;
        public ActorsController(IActorService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var _data = await _service.GetAllAsync();

            return View(_data);
        }

        //get:Actors/Create 
        public IActionResult Create()
        {
            return View();
        }
        //Get:Actors/Create Post method
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
          await  _service.AddAsync(actor);

            return RedirectToAction(nameof(Index));
        }



        //get:Actors/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var actrDetails =  await _service.GetByIdAsync(id);
            if (actrDetails == null) return View("Empty");

            return View(actrDetails);
        }

        //edit section

        //get:Actors/Edit -- 1) for showing detail 2) for editing 
        public async Task <IActionResult> Edit(int id)
        {
            var actrDetails = await _service.GetByIdAsync(id);
            if (actrDetails == null) return View("NotFound");

            return View(actrDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id , Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id,actor);

            return RedirectToAction(nameof(Index));
        }

        //get:Actors/Delete/1 --
        //1) for showing detail 2) for editing 
        public async Task<IActionResult> Delete(int id)
        {
            var actrDetails = await _service.GetByIdAsync(id);
            if (actrDetails == null) return View("NotFound");

            return View(actrDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var actrDetails = await _service.GetByIdAsync(id);
            if (actrDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
           
    

            return RedirectToAction(nameof(Index));
        }



    }
}
