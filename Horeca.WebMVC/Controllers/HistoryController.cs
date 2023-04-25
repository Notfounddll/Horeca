using Horeca.DataBaseLibrary.Data.Interfaces;
using Horeca.DataBaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Horeca.WebMVC.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IDaHistoryDataService _daHistoryData;
        private readonly IDaProductDataService _daProductData;
        public HistoryController(IDaHistoryDataService daHistoryData, IDaProductDataService daProductData)
        {
            _daHistoryData = daHistoryData;
            _daProductData = daProductData;
        }
        [HttpGet]
        public async Task <IActionResult> InsertSell (int id)
        {
            dynamic newModel = new ExpandoObject();
            newModel.getProduct = await _daProductData.GetProductById(id);
            return View(newModel);
        }
        [HttpPost]
        public async Task<IActionResult> InsertSell(HistoryModel instertHistory)
        {
            await _daHistoryData.InsertSell(instertHistory);
            return RedirectToAction("SelectProductToSell", "Product", new {id = instertHistory.Id_Product});
        }

    }
}
