using Horeca.DataBaseLibrary.Data.Interfaces;
using Horeca.DataBaseLibrary.DataAcces;
using Horeca.DataBaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Data
{
    public class DaHistoryDataService : IDaHistoryDataService
    {
        private readonly ISqlDataAcces _dataAccess;
        
        public DaHistoryDataService(ISqlDataAcces dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task InsertSell(HistoryModel newHis)
        {
            string sql = $"insert into [HorecaApp].[dbo].[History] " +
            $"(Id_Product, Product, Price) " +
            $"select [HorecaApp].[dbo].[Product].[Id], " +
            $"[HorecaApp].[dbo].[Product].[Product], " +
            $"[HorecaApp].[dbo].[Product].[Price] " +
            $"from [HorecaApp].[dbo].[Product] " +
            $"where [HorecaApp].[dbo].[Product].[Id] = '{newHis.Id_Product}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }
    }
}
