using Horeca.DataBaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Data.Interfaces
{
    public interface IDaDepartmentDataService
    {
        public Task<DepartmentModel> GetDepartmentById(int Id);
        public Task<List<DepartmentModel>> GetAllDepartments();
        public Task CreateDepartment(DepartmentModel newDepartment);
        public Task DeleteDepartment(int setActive);
        public Task UpdateDepartment(DepartmentModel updateDepartment);
        public Task<List<DepartmentToLocationModel>> GetAllDepartmentsWithLocation();
        public Task<List<DepartmentToProductModel>> GetProductByIdDepartment(int Id);
    }
}
