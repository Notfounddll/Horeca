using Horeca.DataBaseLibrary.Data.Interfaces;
using Horeca.DataBaseLibrary.DataAcces;
using Horeca.DataBaseLibrary.Models;
using Horeca.DataBaseLibrary.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Data
{
    public class DaDepartmentDataService : IDaDepartmentDataService
    {
        private readonly ISqlDataAcces _dataAccess;
        public DaDepartmentDataService(ISqlDataAcces dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        public async Task<DepartmentModel> GetDepartmentById(int Id)
        {
            string sql = $"select * from [HorecaApp].[dbo].[Department] " +
            $"where [HorecaApp].[dbo].[Department].[Id] = '{Id}' ;";
            return await _dataAccess.LoadDataSingle<DepartmentModel, dynamic>(sql, new { }, "Default");
        }

        
        public async Task<List<DepartmentModel>> GetAllDepartments()
        {
            string sql = $"select * from [HorecaApp].[dbo].[Department] " +
            $"where [HorecaApp].[dbo].[Department].[Active] = 1 " +
            $"order by [HorecaApp].[dbo].[Department].[Department] asc;";
            return await _dataAccess.LoadData<DepartmentModel, dynamic>(sql, new { }, "Default");
        }

        
        public async Task CreateDepartment(DepartmentModel newDepartment)
        {
            string sql = $"insert into [HorecaApp].[dbo].[Department] " +
            $"(Id_Location, Department, Active) " +
            $"values ('{newDepartment.Id_Location}','{newDepartment.Department}','1');";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

        
        public async Task DeleteDepartment(int setActive)
        {
            string sql = $"update [HorecaApp].[dbo].[Department] set " +
            $"[HorecaApp].[dbo].[Department].[Active] = '0' " +
            $"where [HorecaApp].[dbo].[Department].[Id] = '{setActive}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

        
        public async Task UpdateDepartment(DepartmentModel updateDepartment)
        {
            string sql = $"update [HorecaApp].[dbo].[Department] set " +
            $"[HorecaApp].[dbo].[Department].[Id_Location] = '{updateDepartment.Id_Location}', [HorecaApp].[dbo].[Department].[Department] = '{updateDepartment.Department}' " +
            $"where [HorecaApp].[dbo].[Department].[Id] = '{updateDepartment.Id}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }
        public async Task<List<DepartmentToLocationModel>> GetAllDepartmentsWithLocation()
        {
            string sql = $"SELECT [HorecaApp].[dbo].[Department].[Id] AS [Id_Department], " +
                         $"[HorecaApp].[dbo].[Location].[Id] AS [Id_Location], " +
                         $"[HorecaApp].[dbo].[Department].[Department], " +
                         $"[HorecaApp].[dbo].[Location].[Location] " +
                         $"FROM [HorecaApp].[dbo].[Department] " +
                         $"JOIN [HorecaApp].[dbo].[Location] " +
                         $"ON [HorecaApp].[dbo].[Department].[Id_Location] = [HorecaApp].[dbo].[Location].[Id] " +
                         $"WHERE [HorecaApp].[dbo].[Department].[Active] = 1 AND [HorecaApp].[dbo].[Location].[Active] = 1;";
            return await _dataAccess.LoadData<DepartmentToLocationModel, dynamic>(sql, new { }, "Default");
        }
        public async Task<List<DepartmentToProductModel>> GetProductByIdDepartment(int Id)
        {
            string sql = $"SELECT [HorecaApp].[dbo].[Product].[Id], [HorecaApp].[dbo].[Product].[Product], [HorecaApp].[dbo].[Product].[Price] " +
                         $"FROM[HorecaApp].[dbo].[Department] " +
                         $"JOIN[HorecaApp].[dbo].[Product] " +
                         $"ON[HorecaApp].[dbo].[Department].[Id] = [HorecaApp].[dbo].[Product].[Id_Department]" +
                         $"WHERE[HorecaApp].[dbo].[Product].[Active] = 1 AND [HorecaApp].[dbo].[Product].[Id_Department] = {Id};";
            return await _dataAccess.LoadData<DepartmentToProductModel, dynamic>(sql, new { }, "Default");
        }
    }
}
