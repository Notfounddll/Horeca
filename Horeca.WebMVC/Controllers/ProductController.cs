using Horeca.DataBaseLibrary.Data.Interfaces;
using Horeca.DataBaseLibrary.Models.CustomModels;
using Horeca.DataBaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Horeca.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDaProductDataService _daProductData;
        private readonly IDaDepartmentDataService _daDepartmentData;
        public ProductController(IDaProductDataService daProductData, IDaDepartmentDataService daDepartmentData)
        {
            _daProductData = daProductData;
            _daDepartmentData = daDepartmentData;
        }

        public async Task<IActionResult> ViewProductByIdDepartment(int id)
        {
            List<DepartmentToProductModel> products = await _daDepartmentData.GetProductByIdDepartment(id);
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            ProductModel getProduct = await _daProductData.GetProductById(id);
            return View(getProduct);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ProductModel setInnactive)
        {
            await _daProductData.DeleteProduct(setInnactive.Active);
            return RedirectToAction("ViewDepartmentByIdLocation", "Department", new { id = setInnactive.Id_Department });
        }
    }
}
