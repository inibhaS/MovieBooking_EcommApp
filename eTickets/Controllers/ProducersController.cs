using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

using eTickets.Models;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    { //inject appdbcontext
        private readonly IProducersService _service; 
        public ProducersController(IProducersService  service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var _allProducers = await _service.GetAllAsync();
            return View(_allProducers);
        }


        //Get : producers/details/1

        public async Task<IActionResult> Details(int id)
        {
            var _producerDetails = await _service.GetByIdAsync(id);
            if (_producerDetails == null) return View("NotFound");
            return View(_producerDetails);
        
        
        }

        public IActionResult Create()
        {
            return View();
        }

        //Get: Producers/Create/Postmethod
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);

            return RedirectToAction(nameof(Index));
        }

      
        //Get: Producers/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
      



        //Get: Producers/EDit/Postmethod
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureUrl,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            if (id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);

                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        //Delete  

        //get:Actors/Delete/1 --
        //1) for showing detail 2) for editing 
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);



            return RedirectToAction(nameof(Index));
        }
    }
}
 