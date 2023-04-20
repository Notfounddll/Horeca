using Horeca.DataBaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Data.Interfaces
{
    public interface IDaStockDataService
    {
        public Task<StockModel> GetStockById(int Id);
        public Task<List<StockModel>> GetAllStocks();
        public Task CreateStockItem(StockModel newStockItem);
        public Task DeleteStockItem(int setActive);
        public Task UpdateStockItem(StockModel updateStockItem);
        public Task UpdateStockAmount(StockModel addedValue);
        public Task UpdateStockNameAndAmount(StockModel updateNameAmount);
    }
}
