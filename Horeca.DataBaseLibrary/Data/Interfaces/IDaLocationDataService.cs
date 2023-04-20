using Horeca.DataBaseLibrary.Models;
using Horeca.DataBaseLibrary.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Data.Interfaces
{
    public interface IDaLocationDataService
    {
        public Task<LocationModel> GetLocationById(int Id);
        public Task<List<LocationModel>> GetAllLocations();
        public Task CreateLocation(LocationModel newLocation);
        public Task DeleteLocation(int setActive);
        public Task UpdateLocation(LocationModel updateLocation);
        public Task<List<LocationToStockModel>> GetStockByIdLocation(int Id);
        public Task<List<LocationToDepartmentModel>> GetDepartmentByIdLocation(int Id);
    }
}
