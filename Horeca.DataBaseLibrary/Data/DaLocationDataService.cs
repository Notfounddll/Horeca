using Horeca.DataBaseLibrary.DataAcces;
using Horeca.DataBaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Data
{
    public class DaLocationDataService
    {
        private readonly ISqlDataAcces _dataAccess;
        public DaLocationDataService(ISqlDataAcces dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        public async Task<LocationModel> GetLocationById(int Id)
        {
            string sql = $"select * from [HorecaApp].[dbo].[Location] " +
            $"where [HorecaApp].[dbo].[Location].[Id] = '{Id}' ;";
            return await _dataAccess.LoadDataSingle<LocationModel, dynamic>(sql, new { }, "Default");
        }

        
        public async Task<List<LocationModel>> GetAllLocations()
        {
            string sql = $"select * from [HorecaApp].[dbo].[Location] " +
            $"where [HorecaApp].[dbo].[Location].[Active] = 1 " +
            $"order by [HorecaApp].[dbo].[Location].[Location] asc;";
            return await _dataAccess.LoadData<LocationModel, dynamic>(sql, new { }, "Default");
        }

       
        public async Task CreateLocation(LocationModel newLocation)
        {
            string sql = $"insert into [HorecaApp].[dbo].[Location] " +
            $"(Location, Active) " +
            $"values ('{newLocation.Location}','1');";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

        
        public async Task DeleteLocation(int setActive)
        {
            string sql = $"update [HorecaApp].[dbo].[Location] set " +
            $"[HorecaApp].[dbo].[Location].[Active] = '0' " +
            $"where [HorecaApp].[dbo].[Location].[Id] = '{setActive}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

       
        public async Task UpdateLocation(LocationModel updateLocation)
        {
            string sql = $"update [HorecaApp].[dbo].[Location] set " +
            $"[HorecaApp].[dbo].[Location].[Location] = '{updateLocation.Location}' " +
            $"where [HorecaApp].[dbo].[Location].[Id] = '{updateLocation.Id}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }
        public async Task<List<LocationToStockModel>> GetStockByIdLocation(int Id)
        {
            string sql = $"SELECT [HorecaApp].[dbo].[Stock].[Id], [HorecaApp].[dbo].[Stock].[Name], [HorecaApp].[dbo].[Stock].[Amount]" +
                         $"FROM[HorecaApp].[dbo].[Location]" +
                         $"JOIN[HorecaApp].[dbo].[Stock]" +
                         $"ON[HorecaApp].[dbo].[Location].[Id] = [HorecaApp].[dbo].[Stock].[Id_Location]" +
                         $"WHERE[HorecaApp].[dbo].[Stock].[Active] = 1 AND [HorecaApp].[dbo].[Location].[Id] = {Id};";
            return await _dataAccess.LoadData<LocationToStockModel, dynamic>(sql, new { }, "Default");
        }
        public async Task<List<LocationToDepartmentModel>> GetDepartmentByIdLocation(int Id)
        {
            string sql = $"SELECT [HorecaApp].[dbo].[Department].[Id], [HorecaApp].[dbo].[Department].[Department]" +
                         $"FROM[HorecaApp].[dbo].[Location]" +
                         $"JOIN[HorecaApp].[dbo].[Department]" +
                         $"ON[HorecaApp].[dbo].[Location].[Id] = [HorecaApp].[dbo].[Department].[Id_Location]" +
                         $"WHERE[HorecaApp].[dbo].[Department].[Active] = 1 AND [HorecaApp].[dbo].[Location].[Id] = {Id};";
            return await _dataAccess.LoadData<LocationToDepartmentModel, dynamic>(sql, new { }, "Default");
        }
    }
}
