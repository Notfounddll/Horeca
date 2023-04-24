using Horeca.DataBaseLibrary.Data.Interfaces;
using Horeca.DataBaseLibrary.Models.CustomModels;
using Horeca.DataBaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

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
        public async Task<IActionResult> CreateProduct()
        {
            dynamic newModel = new ExpandoObject();
            newModel.DepartmentWithLocation = await _daDepartmentData.GetAllDepartmentsWithLocation();
            newModel.Product = new ProductModel();
            return View(newModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel newProduct)
        {
            if (ModelState.IsValid)
            {
                await _daProductData.CreateProduct(newProduct);
                return RedirectToAction("CreateProduct");
            }
            else
            {
                return View(newProduct);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateProductFromDepartment(int id)
        {
            dynamic newModel = new ExpandoObject();
            newModel.Department = await _daDepartmentData.GetDepartmentById(id);
            newModel.Product = new ProductModel();
            return View(newModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductFromDepartment(ProductModel addProduct)
        {
            if (ModelState.IsValid)
            {
                await _daProductData.CreateProduct(addProduct);
                return RedirectToAction("ViewDepartmentByIdLocation", "Department", new { id = addProduct.Id_Department });
            }
            else
            {
                return View(addProduct);
            }
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
            await _daProductData.DeleteProduct(setInnactive.Id);
            return RedirectToAction("ViewDepartmentByIdLocation", "Department", new { id = setInnactive.Id_Department });
        }
    }
}
