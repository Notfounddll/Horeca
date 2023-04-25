using Horeca.DataBaseLibrary.Data.Interfaces;
using Horeca.DataBaseLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Horeca.WebMVC.Controllers
{
    //[Authorize(Roles = "Level2")]
    public class RecipeController : Controller
    {
        private readonly IDaRecipeDataService _recipeDataService;
        private readonly IDaProductDataService _productDataService;
        public RecipeController(IDaRecipeDataService recipeDataService, IDaProductDataService productDataService)
        {
            _recipeDataService = recipeDataService;
            _productDataService = productDataService;
        }

        public async Task<IActionResult> ViewAllProducts()
        {
            List<ProductModel> products = await _productDataService.GetAllProducts();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> AddRecipe()
        {
            var model = new RecipeModel(); // create a new instance of RecipeModel
            return View(model); // pass the model to the view
        }
        [HttpPost]
        public async Task<IActionResult> AddRecipe(RecipeModel newRecipe)
        {
            await _recipeDataService.CreateRecipe(newRecipe);
            return View("ViewAllProducts");
        }
    }
}
