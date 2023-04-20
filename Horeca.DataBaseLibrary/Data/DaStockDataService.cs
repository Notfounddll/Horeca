using Horeca.DataBaseLibrary.DataAcces;
using Horeca.DataBaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Data
{
    public class DaStockDataService
    {
        private readonly ISqlDataAcces _dataAccess;
        public DaStockDataService(ISqlDataAcces dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        public async Task<StockModel> GetStockById(int Id)
        {
            string sql = $"select * from [HorecaApp].[dbo].[Stock] " +
            $"where [HorecaApp].[dbo].[Stock].[Id] = '{Id}' ;";
            return await _dataAccess.LoadDataSingle<StockModel, dynamic>(sql, new { }, "Default");
        }

        
        public async Task<List<StockModel>> GetAllStocks()
        {
            string sql = $"select * from [HorecaApp].[dbo].[Stock] " +
            $"where [HorecaApp].[dbo].[Stock].[Active] = 1 " +
            $"order by [HorecaApp].[dbo].[Stock].[Name] asc;";
            return await _dataAccess.LoadData<StockModel, dynamic>(sql, new { }, "Default");
        }

        
        public async Task CreateStockItem(StockModel newStockItem)
        {
            string sql = $"insert into [HorecaApp].[dbo].[Stock] " +
            $"(Id_Location, Name, Amount, Active) " +
            $"values ('{newStockItem.Id_Location}','{newStockItem.Name}','{newStockItem.Amount}','1');";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

        
        public async Task DeleteStockItem(int setActive)
        {
            string sql = $"update [HorecaApp].[dbo].[Stock] set " +
            $"[HorecaApp].[dbo].[Stock].[Active] = '0' " +
            $"where [HorecaApp].[dbo].[Stock].[Id] = '{setActive}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

        
        public async Task UpdateStockItem(StockModel updateStockItem)
        {
            string sql = $"update [HorecaApp].[dbo].[Stock] set " +
            $"[HorecaApp].[dbo].[Stock].[Id_Location] = '{updateStockItem.Id_Location}', [HorecaApp].[dbo].[Stock].[Name] = '{updateStockItem.Name}', [HorecaApp].[dbo].[Stock].[Amount] = '{updateStockItem.Amount}'" +
            $"where [HorecaApp].[dbo].[Stock].[Id] = '{updateStockItem.Id}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

        public async Task UpdateStockAmount(StockModel addedValue)
        {
            string sql = $"update [HorecaApp].[dbo].[Stock] set " +
            $"[HorecaApp].[dbo].[Stock].[Amount] = '{addedValue.Amount}'" +
            $"where [HorecaApp].[dbo].[Stock].[Id] = '{addedValue.Id}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

        public async Task UpdateStockNameAndAmount(StockModel updateNameAmount)
        {
            string sql = $"update [HorecaApp].[dbo].[Stock] set " +
            $"[HorecaApp].[dbo].[Stock].[Amount] = '{updateNameAmount.Amount}', [HorecaApp].[dbo].[Stock].[Name] = '{updateNameAmount.Name}'" +
            $"where [HorecaApp].[dbo].[Stock].[Id] = '{updateNameAmount.Id}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }
    }
}
