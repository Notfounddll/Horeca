using Horeca.DataBaseLibrary.Data.Interfaces;
using Horeca.DataBaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Horeca.WebMVC.Controllers
{
    public class StockController : Controller
    {
        private readonly IDaStockDataService _daStockData;
        private readonly IDaLocationDataService _daLocationData;
        public StockController(IDaStockDataService daStockData, IDaLocationDataService locationData)
        {
            _daStockData = daStockData;
            _daLocationData = locationData;
        }

        [HttpGet]
        public async Task<IActionResult> AddStockAmount(int id)
        {
            StockModel stock = await _daStockData.GetStockById(id);
            return View(stock);
        }
        [HttpPost]
        public async Task<IActionResult> AddStockAmount(StockModel newValue)
        {
            if (ModelState.IsValid)
            {
                newValue.Amount = newValue.Amount + newValue.UpdateValue;
                await _daStockData.UpdateStockAmount(newValue);
                return RedirectToAction("ViewStockByIdLocation", "Location", new { id = newValue.Id_Location });
            }
            else
            {
                return View(newValue);
            }

        }
        [HttpGet]
        public async Task<IActionResult> WithdrawStockAmount(int id)
        {
            StockModel stock = await _daStockData.GetStockById(id);
            return View(stock);

        }
        [HttpPost]
        public async Task<IActionResult> WithdrawStockAmount(StockModel lessValue)
        {
            if (!ModelState.IsValid)
            {
                lessValue.Amount = lessValue.Amount - lessValue.UpdateValue;
                await _daStockData.UpdateStockAmount(lessValue);
                return RedirectToAction("ViewStockByIdLocation", "Location", new { id = lessValue.Id_Location });
            }
            else
            {
                return View(lessValue);
            }

        }
        [HttpGet]
        public async Task<IActionResult> EditStock(int id)
        {
            StockModel stock = await _daStockData.GetStockById(id);
            return View(stock);
        }
        [HttpPost]
        public async Task<IActionResult> EditStock(StockModel changeStock)
        {
            if (ModelState.IsValid)
            {
                await _daStockData.UpdateStockNameAndAmount(changeStock);
                return RedirectToAction("ViewStockByIdLocation", "Location", new { id = changeStock.Id_Location });
            }
            else
            {
                return View(changeStock);
            }
        }
        [HttpGet]
        public async Task<IActionResult> CreateStock()
        {
            dynamic newModel = new ExpandoObject();
            newModel.Location = await _daLocationData.GetAllLocations();
            newModel.Stock = new StockModel();
            return View(newModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStock(StockModel addNewStock)
        {
            await _daStockData.CreateStockItem(addNewStock);
            return RedirectToAction("ViewStockByIdLocation", "Location", new { id = addNewStock.Id_Location });
        }
    }
}
