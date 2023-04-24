using Horeca.DataBaseLibrary.Data.Interfaces;
using Horeca.DataBaseLibrary.Models.CustomModels;
using Horeca.DataBaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Horeca.WebMVC.Controllers
{
    //[Authorize(Roles = "Level1")]
    public class LocationController : Controller
    {
        private readonly IDaLocationDataService _daLocationData;
        public LocationController(IDaLocationDataService daLocationData)
        {
            _daLocationData = daLocationData;
        }

        public async Task<IActionResult> DisplayLocations()
        {
            List<LocationModel> locations = await _daLocationData.GetAllLocations();
            return View(locations);
        }
        public async Task<IActionResult> ViewStockByIdLocation(int id)
        {
            List<LocationToStockModel> stocks = await _daLocationData.GetStockByIdLocation(id);
            return View(stocks);
        }

        [HttpGet]
        public async Task<IActionResult> CreateLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(LocationModel newLocation)
        {
            if (ModelState.IsValid)
            {
                await _daLocationData.CreateLocation(newLocation);
                return RedirectToAction("DisplayLocations");
            }
            else
            {
                return View(newLocation);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            LocationModel getLocation = await _daLocationData.GetLocationById(id);
            return View(getLocation);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteLocation(LocationModel setInactive)
        {
            await _daLocationData.DeleteLocation(setInactive.Id);
            return RedirectToAction("DisplayLocations");
        }
        [HttpGet]
        public async Task<IActionResult> EditLocation(int id)
        {
            LocationModel getLocation = await _daLocationData.GetLocationById(id);
            return View(getLocation);
        }
        [HttpPost]
        public async Task<IActionResult> EditLocation(LocationModel editLocation)
        {
            if (ModelState.IsValid)
            {
                await _daLocationData.UpdateLocation(editLocation);
                return RedirectToAction("DisplayLocations");
            }
            else
            {
                return View(editLocation);
            }
        }
    }
}
