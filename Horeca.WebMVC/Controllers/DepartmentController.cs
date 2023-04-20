using Horeca.DataBaseLibrary.Data.Interfaces;
using Horeca.DataBaseLibrary.Models.CustomModels;
using Horeca.DataBaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Horeca.WebMVC.Controllers
{
    //[Authorize(Roles = "Level2")]
    public class DepartmentController : Controller
    {
        private readonly IDaDepartmentDataService _daDepartmentData;
        private readonly IDaLocationDataService _daLocationData;
        private readonly IDaProductDataService _daProductData;
        public DepartmentController(IDaDepartmentDataService daDepartmentData, IDaLocationDataService daLocationData, IDaProductDataService daProductData)
        {
            _daDepartmentData = daDepartmentData;
            _daLocationData = daLocationData;
            _daProductData = daProductData;
        }
        public async Task<IActionResult> DisplayLocationForDepartments()
        {

            List<LocationModel> locations = await _daLocationData.GetAllLocations();
            return View(locations);
        }
        public async Task<IActionResult> ViewDepartmentByIdLocation(int id)
        {
            List<LocationToDepartmentModel> departments = await _daLocationData.GetDepartmentByIdLocation(id);
            return View(departments);
        }
        [HttpGet]
        public async Task<IActionResult> CreateDepartment()
        {
            dynamic newModel = new ExpandoObject();
            newModel.Location = await _daLocationData.GetAllLocations();
            newModel.Department = new DepartmentModel();
            return View(newModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentModel newDepartment)
        {
            await _daDepartmentData.CreateDepartment(newDepartment);
            return RedirectToAction("ViewDepartmentByIdLocation", new { id = newDepartment.Id_Location });
        }
        [HttpGet]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            DepartmentModel getDepartment = await _daDepartmentData.GetDepartmentById(id);
            return View(getDepartment);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDepartment(DepartmentModel setInactive)
        {
            await _daDepartmentData.DeleteDepartment(setInactive.Id);
            return RedirectToAction("ViewDepartmentByIdLocation", new { id = setInactive.Id });
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
            await _daProductData.CreateProduct(newProduct);
            return RedirectToAction("CreateProduct");
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
            await _daProductData.CreateProduct(addProduct);
            return RedirectToAction("ViewDepartmentByIdLocation", new { id = addProduct.Id_Department });
        }
    }
}
