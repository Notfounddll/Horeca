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
    public class DaProductDataService : IDaProductDataService
    {
        private readonly ISqlDataAcces _dataAccess;
        public DaProductDataService(ISqlDataAcces dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        public async Task<ProductModel> GetProductById(int Id)
        {
            string sql = $"select * from [HorecaApp].[dbo].[Product] " +
            $"where [HorecaApp].[dbo].[Product].[Id] = '{Id}' ;";
            return await _dataAccess.LoadDataSingle<ProductModel, dynamic>(sql, new { }, "Default");
        }

        
        public async Task<List<ProductModel>> GetAllProducts()
        {
            string sql = $"select * from [HorecaApp].[dbo].[Product] " +
            $"where [HorecaApp].[dbo].[Product].[Active] = 1 " +
            $"order by [HorecaApp].[dbo].[Product].[Product] asc;";
            return await _dataAccess.LoadData<ProductModel, dynamic>(sql, new { }, "Default");
        }

        
        public async Task CreateProduct(ProductModel newProduct)
        {
            string sql = $"insert into [HorecaApp].[dbo].[Product] " +
            $"(Id_Department, Product, Price, Active) " +
            $"values ('{newProduct.Id_Department}','{newProduct.Product}','{newProduct.Price}','1');";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

        
        public async Task DeleteProduct(int setActive)
        {
            string sql = $"update [HorecaApp].[dbo].[Product] set " +
            $"[HorecaApp].[dbo].[Product].[Active] = '0' " +
            $"where [HorecaApp].[dbo].[Product].[Id] = '{setActive}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

        
        public async Task UpdateProduct(ProductModel updateProduct)
        {
            string sql = $"update [HorecaApp].[dbo].[Product] set " +
            $"[HorecaApp].[dbo].[Product].[Id_Department] = '{updateProduct.Id_Department}', [HorecaApp].[dbo].[Product].[Product] = '{updateProduct.Product}', [HorecaApp].[dbo].[Product].[Price] = '{updateProduct.Price}' " +
            $"where [HorecaApp].[dbo].[Product].[Id] = '{updateProduct.Id}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }
    }
}
