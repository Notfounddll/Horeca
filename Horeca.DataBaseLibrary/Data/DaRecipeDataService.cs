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
    public class DaRecipeDataService : IDaRecipeDataService
    {
        private readonly ISqlDataAcces _dataAccess;
        public DaRecipeDataService(ISqlDataAcces dataAccess)
        {
            _dataAccess = dataAccess;
        }

        
        public async Task CreateRecipe(RecipeModel newRecipe)
        {
            string sql = $"insert into [HorecaApp].[dbo].[Recipe] " +
            $"(Id_Product, Id_Stock, Amount, Active) " +
            $"values ('{newRecipe.Id_Product}','{newRecipe.Id_Stock}','{newRecipe.Amount}','1');";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

        
        public async Task DeleteRecipe(int setActive)
        {
            string sql = $"update [HorecaApp].[dbo].[Recipe] set " +
            $"[HorecaApp].[dbo].[Recipe].[Active] = '0' " +
            $"where [HorecaApp].[dbo].[Recipe].[Id_Product] = '{setActive}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

        
        public async Task UpdateRecipe(RecipeModel updateRecipe)
        {
            string sql = $"update [HorecaApp].[dbo].[Recipe] set " +
            $"[HorecaApp].[dbo].[Recipe].[Id_Stock] = '{updateRecipe.Id_Stock}', " +
            $"[HorecaApp].[dbo].[Recipe].[Amount] = '{updateRecipe.Amount}' " +
            $"where [HorecaApp].[dbo].[Recipe].[Id_Product] = '{updateRecipe.Id_Product}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }
    }
}
